#ifndef __server_h__
#define __server_h__
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netinet/tcp.h>
#include <memory.h>
#include <unistd.h>
#include <stdlib.h>
#include <iostream>
#include <thread>
#include <future>
#include <chrono>
#include <fcntl.h>
#include <errno.h>
#include <cstdio>
#define BUF_LEN 1024

using namespace std;

class Server{

	public:
		Server(uint16_t port);
		~Server();

		int32_t TCP_Set(uint16_t port);
		int32_t TCP_Run();

		int32_t TCP_File_Send(int32_t fd, FILE *fp);
		int32_t TCP_File_Recv(int32_t fd, FILE *fp);
		
		void setSockNonBlock(int32_t socket);
		int32_t updateMaxfd(fd_set fd, int32_t maxfd);
		virtual void Server_Handle(future<void> exitSignal) = 0;

		promise<void> exitTrigger;
		thread packetHandle;
	protected:
		int32_t serverSocket;
		struct sockaddr_in serverInfo;
		
};


#endif

