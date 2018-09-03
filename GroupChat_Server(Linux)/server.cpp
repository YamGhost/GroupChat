#include "server.h"

Server::Server(unsigned short port){
	
	TCP_Set(port);
}

Server::~Server(){

	close(serverSocket);
}

int Server::TCP_Set(unsigned short port){ //設定TCP連線

	serverSocket = socket(AF_INET, SOCK_STREAM, 0); //建立Socket
	if(serverSocket == -1){
		perror("socket failed");
		exit(EXIT_FAILURE);
	}
	
	memset(&serverInfo, 0, sizeof(serverInfo));
	
	serverInfo.sin_family = PF_INET;	//設定Socket
	serverInfo.sin_addr.s_addr = INADDR_ANY;
	serverInfo.sin_port = htons(port);
	
	int reuseAddress = 1;
	if(setsockopt(serverSocket, SOL_SOCKET, SO_REUSEADDR, (void *) &reuseAddress, sizeof(reuseAddress)) == -1){ //位址重複使用
		perror("reuse address failed");
		exit(EXIT_FAILURE);
	}
	
	if(bind(serverSocket, (struct sockaddr *) &serverInfo, sizeof(serverInfo)) == -1){
		perror("bind failed");
		exit(EXIT_FAILURE);
	}


	//TCP Keep Alive
/*	int keepalive = 1;
	int keepidle = 5;
	int keepinterval = 1;
	int keepcount = 3;

	setsockopt(serverSocket, SOL_SOCKET, SO_KEEPALIVE, (void *) &keepalive, sizeof(keepalive));
	setsockopt(serverSocket, SOL_TCP, TCP_KEEPIDLE, (void *) &keepidle, sizeof(keepidle));

	setsockopt(serverSocket, SOL_TCP, TCP_KEEPINTVL, (void *) &keepinterval, sizeof(keepinterval));
	setsockopt(serverSocket, SOL_TCP, TCP_KEEPCNT, (void *) &keepcount, sizeof(keepcount));
*/	
	return 0;
}

int Server::TCP_Run(){ //啟動Server
	
	int state;
	
	unsigned int addrlen;

	if(listen(serverSocket, SOMAXCONN) != 0){ //建立listener
		perror("listen failed!");
		exit(EXIT_FAILURE);	
	}
	
	future<void> agent = exitTrigger.get_future(); //建立關閉執行緒外部觸發
	packetHandle = thread( [this](future<void> &&trigger)  //啟動Server處理執行緒
			 { Server_Handle(move(trigger)); }, move(agent));	
	
	return 0;
}

void Server::setSockNonBlock(int socket){ //設定Socket(Non Block，非堵塞)

	int flag;

	flag = fcntl(socket, F_GETFL, 0); //取得Socket檔案字符
	if(flag < 0){
		perror("fcntl(F_GETFL) failed");
		exit(EXIT_FAILURE);
	}

	if(fcntl(socket, F_SETFL, flag | O_NONBLOCK) < 0){ //設定Socket(Non Block)
		perror("fcntl(F_GETFL) failed");
		exit(EXIT_FAILURE);
	}
}

int Server::updateMaxfd(fd_set fd, int maxfd){ //更新最大字符號碼

	int new_maxfd = 0;
	for(int i = 0; i <= maxfd; i++){
		if(FD_ISSET(i, &fd) && i > new_maxfd){
			new_maxfd = i;
		}
	}
	return new_maxfd;
}
