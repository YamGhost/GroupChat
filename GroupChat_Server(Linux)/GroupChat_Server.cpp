#include "GroupChat_Server.h"

GroupChat_Server::GroupChat_Server(unsigned short port) : Server(port){


}

GroupChat_Server::~GroupChat_Server(){

}

void GroupChat_Server::Server_Handle(future<void> exitSignal){ //Server處理程序
	
	cout << "TCP Server Start!" << endl;
		
	thread recv([this](future<void> &&trigger) { ReadSocket(move(trigger)); }, move(exitSignal)); //封包接收處理

	recv.join();
}

void GroupChat_Server::ReadSocket(future<void> exitSignal){

	//Socket檔案字符
	int new_socket;
	struct timeval timeout;
	struct sockaddr_in client_addr;
	socklen_t client_addr_len;
	fd_set readfd;
	fd_set readfd_bak;
	
	//Socket檔案字符設定
	int maxfd = serverSocket;
	FD_ZERO(&readfd);
	FD_ZERO(&readfd_bak);
	FD_SET(serverSocket, &readfd_bak);
	
	//Socket資源
	int res, i;
	int new_clientsocket;
	int recv_len;
	char output[BUF_LEN];

	
	list<string> groupmessage_tmp; //訊息容器
	map<int, string> clientMap; //Socket和IP對應

	while(exitSignal.wait_for(chrono::seconds(0)) == future_status::timeout){ //外部中止執行緒


		try{	
			//Socke讀取檔案字符
			readfd = readfd_bak;
			maxfd = updateMaxfd(readfd, maxfd);
		
			//Socket檔案字符延時設定
			timeout.tv_sec = SELECT_TIMEOUT;
			timeout.tv_usec = 0;

			cout << "select max fd = " << maxfd << endl;
			
			//選取Socket檔案讀取字符(設定延時)
			res = select(maxfd + 1, &readfd, NULL, NULL, &timeout);
			if(res == -1){
				perror("select failed");
				exit(EXIT_FAILURE);
			} else if(res == 0) { //未找到任何Socket(持續搜尋)
				cout << "select timeout " << SELECT_TIMEOUT << "sec" << endl;
				continue;
			}

			//所有檔案字符中找出Socket讀取字符(Client)
			for(i = 0; i <= maxfd; i++){
				if(!FD_ISSET(i, &readfd)){ //未找到持續向下找,找到執行後續處理
					continue;
				}		

		
				if(i == serverSocket){ //Socket為Server Socket	
			
					client_addr_len = sizeof(client_addr);
					new_socket = accept(serverSocket, (struct sockaddr *) &client_addr, &client_addr_len); //獲取Client Socket
			
					if(new_socket == -1){
						perror("accept failed");
						exit(EXIT_FAILURE);
					}
				
					//插入Socket、IP對應
					clientMap.insert(pair<int, string>(new_socket, inet_ntoa(client_addr.sin_addr)));
					cout << "ipv4 = " << inet_ntoa(client_addr.sin_addr) << endl;
					//cout << "ipport" << ntohs(client_addr.sin_port) << endl;
					setSockNonBlock(new_socket); //設定Socket(Non Block)
				
					//更新Socket檔案字符上限
					if(new_socket > maxfd){
						maxfd = new_socket;
					}
					FD_SET(new_socket, &readfd_bak); //添加新檔案字符(Client)

				} else { //Socket為Client
				
					recv_len = recv(i, output, BUF_LEN, 0); //接收封包
					cout << "recv clienti(" << recv_len << ") : " << output << endl;

			
					if(recv_len < 0 && errno != EINTR){ //移除斷線Client
						shutdown(i, SHUT_RDWR);	
						close(i);
						FD_CLR(i, &readfd_bak);
					
						map<int, string>::iterator key = clientMap.find(i); //移除Socket、IP對應
						if(key != clientMap.end())
							clientMap.erase(key);		
					}
				
					//封包接收成功	
					if(recv_len > 0){
			
						groupmessage_tmp.push_back(output); //紀錄Message
						Broadcast(readfd_bak, maxfd, i, groupmessage_tmp, clientMap); //廣播Message到聊天室(已連線IP)
						groupmessage_tmp.clear(); //刪除Message紀錄
					}		
				}
			}		
		
		}catch(exception &ex){
			cout << "except : "<< ex.what() << endl;
		}
	}
}

int GroupChat_Server::Broadcast(fd_set &fd, int maxfd, int &sourceSocket, list<string> &message, map<int, string> &ipSocketPair){ //廣播封包到聊天室

	int count = 0; //廣播數量
	string mix, ip = ipSocketPair[sourceSocket];
	for(int i = 0; i <= maxfd; i++){ //搜尋Client Socket
	
		if(i != serverSocket && FD_ISSET(i, &fd)){ //Client Socket(其一)
			for(list<string>::iterator iter = message.begin(); iter != message.end(); iter++){
		
				mix = "@" + ip + "@\n" + (*iter); //組合IP和訊息
				if(mix.length() > 0) //傳送訊息
					send(i, mix.c_str(), mix.length() + 1, 0);
			}
			count++;
		}
	}	
	return count;
}
