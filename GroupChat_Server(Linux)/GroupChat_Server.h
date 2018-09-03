#ifndef __GroupChat_Server_h__
#define __GroupChat_Server_h__
#include "server.h"
#include <map>
#include <list>
#include <string>
#define SELECT_TIMEOUT 1

class GroupChat_Server : public Server {

	public:
		GroupChat_Server(unsigned short port);
		~GroupChat_Server();

		void Server_Handle(future<void> exitSignal) override;
		
		void ReadSocket(future<void> exitSignal);
		int Broadcast(fd_set &fd, int maxfd , int &sourceSocket, list<string> &message, map<int, string> &ipSocketPair);

};

#endif
