#ifndef __GroupChat_Server_h__
#define __GroupChat_Server_h__
#include "server.h"
#include <map>
#include <list>
#include <string>
#include "SupportType.h"
#include <codecvt>
#define SELECT_TIMEOUT 1

class GroupChat_Server : public Server {

	public:
		GroupChat_Server(uint16_t port);
		~GroupChat_Server();

		void Server_Handle(future<void> exitSignal) override;
		
		void ReadSocket(future<void> exitSignal);
		int32_t Broadcast(fd_set &fd, int32_t maxfd , int32_t &sourceSocket, list<FILE *> &packet, map<int32_t, string> &ipSocketPair);

};

#endif
