#CC = arm-linux-gnueabihf-g++

CC = g++
CFLAGS_LINK = -std=c++11 -pthread -o
CFLAGS_COMP = -g -std=c++11 -c
SERVER_NAME = server 
SERVER_OBJ =  server_main.o server.o GroupChat_Server.o


.PHONY: clean obj_clean

all: ${SERVER_NAME}  
	@make obj_clean

${SERVER_NAME}: ${SERVER_OBJ}
	${CC} $^ ${CFLAGS_LINK} $@

%.o: %.cpp
	${CC} ${CFLAGS_COMP} $<

obj_clean:
	@rm -f *.o

clean:
	@rm -f *.o ${SERVER_NAME} 
