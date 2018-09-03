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
#define BUF_LEN 256

using namespace std;

class Server{

	public:
		Server(unsigned short port);
		~Server();

		int TCP_Set(unsigned short port);
		int TCP_Run();
		
		void setSockNonBlock(int socket);
		int updateMaxfd(fd_set fd, int maxfd);
		virtual void Server_Handle(future<void> exitSignal) = 0;

		promise<void> exitTrigger;
		thread packetHandle;
	protected:
		int serverSocket;
		struct sockaddr_in serverInfo;
		
};


#endif

