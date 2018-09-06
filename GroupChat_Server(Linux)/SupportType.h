#ifndef __SupportType_h__
#define __SupportType_h__

#include <string>

using namespace std;

enum Type { cmd, message };

struct Packet {
    Type type;
    char message[1024];
};

#endif