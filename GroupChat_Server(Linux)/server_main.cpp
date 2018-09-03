#include <iostream>
#include "GroupChat_Server.h"
#include <iostream>

using namespace std;

int  main(int argc, char *argv[]){

	
	int doublecheck = 0;
	char ch;
	GroupChat_Server server(8700); //設定Server

	server.TCP_Run(); //啟動Server
	cout << "TCP Server關閉輸入Q!" << endl;
	while(true){

		ch = cin.get();
		if(ch == 'q' || ch == 'Q'){
			cout << "TCP Server 即將關閉!" << endl;
			server.exitTrigger.set_value();
			break;
		} 	
	}
	
	if(server.packetHandle.joinable())
		server.packetHandle.join();

	cout << "end thread" << endl;
}


