#ifndef SERVER_H
#define SERVER_H

#include "library.h"  

namespace compLibs {
namespace Servers {


class Server : public Computer {
private:
    string _ipAddress;
    string _type;
    static int _counter;

public:
    // Constructor
    Server(string name, string biosName, string ipAddress, string type)
        : Computer(name, biosName, ipAddress), _type(type) {
        _counter++;
    }

    // Default Constructor for the server 

    Server() {
        _counter++;
    }

    // Getters y Setters

    string getIPAddress() const { return _ipAddress; }
    void setIPAddress(const string &value) { _ipAddress = value; }

    string getType() const { return _type; }
    void setType(const string &value) { _type = value; }

    // Static method to get the number of servers created

    static int GetServerComputerNum() {
        return _counter;
    }

    // Static method to create a random number

    static string GetRandomNum() {
        srand(time(0)); // Inicializa la semilla para la generación de números aleatorios
        int num = rand() % (255 - 2 + 1) + 2;
        return to_string(num);
    }

    // Method "StartServer"

    void StartServerComputer(string addr1, string addr2) {
        _ipAddress = addr1 + addr2;
    }

    // Show server info

    virtual void ShowInfo() {
        Computer::ShowInfo();
        cout << "Server of type " << _type << " started with IP: " << _ipAddress << endl;
    }
};

// Inicializice counter

int Server::_counter = 0;

// Clase WebServer derived from Server
class WebServer : public Server {
public:
    WebServer(string name, string biosName, string ipAddress, string type)
        : Server(name, biosName, ipAddress, type) {}
};

}
}

#endif
