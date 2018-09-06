#include "GroupChat_Server.h"

GroupChat_Server::GroupChat_Server(uint16_t port) : Server(port){

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
	int32_t new_socket;
	struct timeval timeout;
	struct sockaddr_in client_addr;
	socklen_t client_addr_len;
	fd_set readfd;
	fd_set readfd_bak;
	
	//Socket檔案字符設定
	int32_t maxfd = serverSocket;
	FD_ZERO(&readfd);
	FD_ZERO(&readfd_bak);
	FD_SET(serverSocket, &readfd_bak);
	
	//Socket資源
	int32_t res, i;
	int32_t new_clientsocket;
	int32_t recv_len;
//	char output[BUF_LEN];
	//struct Packet output;
	string output;
	wchar_t str[BUF_LEN];
	//FILE *fp = tmpfile();
	FILE *fp = fopen("aa.txt", "wr");
	char fbuf[BUF_LEN];
	bool flag = false;

	list<FILE *> groupPacket; //訊息容器
	map<int32_t, string> clientMap; //Socket和IP對應

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
					clientMap.insert(pair<int32_t, string>(new_socket, inet_ntoa(client_addr.sin_addr)));
					cout << "ipv4 = " << inet_ntoa(client_addr.sin_addr) << endl;
					//cout << "ipport" << ntohs(client_addr.sin_port) << endl;
					setSockNonBlock(new_socket); //設定Socket(Non Block)
				
					//更新Socket檔案字符上限
					if(new_socket > maxfd){
						maxfd = new_socket;
					}
					FD_SET(new_socket, &readfd_bak); //添加新檔案字符(Client)

				} else { //Socket為Client
				
					//cout << "RECV HANDL" << endl;
					recv_len = TCP_File_Recv(i, fp);

					
					
					//recv_len = recv(i, (void *)fbuf, sizeof(fbuf), 0); //接收封包
					//fread(fbuf, sizeof(), recv_len, fp);

					//fclose(fp);
					//bool f =  TCP_File_Send(i, fp);
					cout << "recv clienti(" << recv_len << ") : " << "" << endl;
					
					// FILE *fp = fopen("test.txt", "r");
					// if(flag != true){
						
					// 	if(fp == NULL)
					// 		printf("file no exist\n");
					// 	else
					// 		TCP_File_Send(i, fp);
					// }	
					// printf("file out send\n");
					
					if(recv_len < 0 && errno != EINTR){ //移除斷線Client
						shutdown(i, SHUT_RDWR);	
						close(i);
						FD_CLR(i, &readfd_bak);
					
						map<int32_t, string>::iterator key = clientMap.find(i); //移除Socket、IP對應
						if(key != clientMap.end())
							clientMap.erase(key);		
					}
				
					//封包接收成功	
					if(recv_len > 0){
			
						groupPacket.push_back(fp); //紀錄Message
						Broadcast(readfd_bak, maxfd, i, groupPacket, clientMap); //廣播Message到聊天室(已連線IP)
						groupPacket.clear(); //刪除Message紀錄
					}		
				}
			}		
		
		}catch(exception &ex){
			cout << "except : "<< ex.what() << endl;
		}
	}
}

int32_t GroupChat_Server::Broadcast(fd_set &fd, int32_t maxfd, int32_t &sourceSocket, list<FILE *> &packet, map<int32_t, string> &ipSocketPair){ //廣播封包到聊天室

	int32_t count = 0; //廣播數量
	string ip = ipSocketPair[sourceSocket];
	string mix; 
	for(int32_t i = 0; i <= maxfd; i++){ //搜尋Client Socket
	
		if(i != serverSocket && FD_ISSET(i, &fd)){ //Client Socket(其一)
			for(list<FILE *>::iterator iter = packet.begin(); iter != packet.end(); iter++){
		
				//int32_t len = 
				//mix.type = (*iter).type;
				//mix = ("@" + ip + "@\n" + (*iter)); //組合IP和訊息
				//memcpy(mix.message, (*iter).message, 10);
				//if(mix.message.length() > 0) //傳送訊息
				//printf("*********%s***********\n",(*iter).message);
					//send(i, (void *)(*iter), sizeof(packet), 0);
				TCP_File_Send(i, (*iter));

				fclose((*iter));
			}
			count++;
		}
	}	
	return count;
}
