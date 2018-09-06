#include "server.h"

Server::Server(uint16_t port){
	
	TCP_Set(port);
}

Server::~Server(){

	close(serverSocket);
}

int32_t Server::TCP_Set(uint16_t port){ //設定TCP連線

	serverSocket = socket(AF_INET, SOCK_STREAM, 0); //建立Socket
	if(serverSocket == -1){
		perror("socket failed");
		exit(EXIT_FAILURE);
	}
	
	memset(&serverInfo, 0, sizeof(serverInfo));
	
	serverInfo.sin_family = PF_INET;	//設定Socket
	serverInfo.sin_addr.s_addr = INADDR_ANY;
	serverInfo.sin_port = htons(port);
	
	int32_t reuseAddress = 1;
	if(setsockopt(serverSocket, SOL_SOCKET, SO_REUSEADDR, (void *) &reuseAddress, sizeof(reuseAddress)) == -1){ //位址重複使用
		perror("reuse address failed");
		exit(EXIT_FAILURE);
	}
	
	if(bind(serverSocket, (struct sockaddr *) &serverInfo, sizeof(serverInfo)) == -1){
		perror("bind failed");
		exit(EXIT_FAILURE);
	}


	//TCP Keep Alive
/*	int32_t keepalive = 1;
	int32_t keepidle = 5;
	int32_t keepint32_terval = 1;
	int32_t keepcount = 3;

	setsockopt(serverSocket, SOL_SOCKET, SO_KEEPALIVE, (void *) &keepalive, sizeof(keepalive));
	setsockopt(serverSocket, SOL_TCP, TCP_KEEPIDLE, (void *) &keepidle, sizeof(keepidle));

	setsockopt(serverSocket, SOL_TCP, TCP_KEEPINTVL, (void *) &keepint32_terval, sizeof(keepint32_terval));
	setsockopt(serverSocket, SOL_TCP, TCP_KEEPCNT, (void *) &keepcount, sizeof(keepcount));
*/	
	return 0;
}

int32_t Server::TCP_Run(){ //啟動Server
	
	int32_t state;
	
	uint32_t addrlen;

	if(listen(serverSocket, SOMAXCONN) != 0){ //建立listener
		perror("listen failed!");
		exit(EXIT_FAILURE);	
	}
	
	future<void> agent = exitTrigger.get_future(); //建立關閉執行緒外部觸發
	packetHandle = thread( [this](future<void> &&trigger)  //啟動Server處理執行緒
			 { Server_Handle(move(trigger)); }, move(agent));	
	
	return 0;
}

int32_t Server::TCP_File_Send(int32_t fd, FILE *fp) {
	static uint8_t data[BUF_LEN];
	uint32_t readNum = 0, sendNum = 0, partNum, intervalNum;
	int32_t retryNum;
	
	if(fp != NULL) {
		
		do {
			readNum = fread(data, 1, BUF_LEN, fp);
			intervalNum = readNum;
			sendNum += readNum;

			retryNum = 3;
			while(intervalNum > 0 && retryNum >= 0 ) {
				partNum = send(fd, data, sendNum, 0);	//注意單次傳送上限(此處不會超過)
				intervalNum -= (partNum != -1) ? partNum : 0;
				retryNum--;
			}
			
			if(retryNum == -1) {
				fclose(fp);
				return -1;
			}				

		} while(readNum > 0);
		
		fclose(fp);

		return sendNum;
	}
}

int32_t Server::TCP_File_Recv(int32_t fd, FILE *fp) {
	static uint8_t data[BUF_LEN];
	uint32_t readNum = 0, sendNum, partNum;
	int32_t retryNum;
	//static FILE *fp = tmpfile();

	if(fp != NULL) {
		
		do {			
			
			retryNum = 3;
			partNum = -1;	//進入條件(無數量意義)
			while(partNum == -1 && retryNum >= 0 ) {
				partNum = recv(fd, data, BUF_LEN, 0);
				retryNum--;
			}
						
			if(retryNum == -1) {
				fclose(fp);
				return -1;
			}
			readNum += partNum;
			fwrite(data, 1, partNum, fp);					

		} while(partNum == 0);
		
		fclose(fp);

		return readNum;
	}
}

void Server::setSockNonBlock(int32_t socket){ //設定Socket(Non Block，非堵塞)

	int32_t flag;

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

int32_t Server::updateMaxfd(fd_set fd, int32_t maxfd){ //更新最大字符號碼

	int32_t new_maxfd = 0;
	for(int32_t i = 0; i <= maxfd; i++){
		if(FD_ISSET(i, &fd) && i > new_maxfd){
			new_maxfd = i;
		}
	}
	return new_maxfd;
}
