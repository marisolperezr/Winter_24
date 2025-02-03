#ifndef LIBRARY_H
#define LIBRARY_H

#include <string>
#include <iostream>

using namespace std;

namespace compLibs {

// Abstract class Device

class Device {
protected:
    string _name;

public:
    // Constructor for inizialitice the name of the device 

    Device(string name) : _name(name) {}

    // Abstract methods to be implemented in clases derivadas
    virtual void StartDevice() = 0;
    virtual void ShutDown() = 0;

    // Getter para _name
    string getName() const { return _name; }
};

// Class Computer derived from Device
class Computer : public Device {
private:
    string biosName;
    string ipAddress;
    static int counter;

public:
    // Constructor
    Computer(string name, string biosname, string ipAddress)
        : Device(name), biosName(biosname), ipAddress(ipAddress) {
        counter++;
    }

    // Default constructor

    Computer() : Device("Unknown") {
        counter++;
    }

    // Getters and Setters

    string getBiosName() const { return biosName; }
    void setBiosName(const string &value) { biosName = value; }

    string getIpAddress() const { return ipAddress; }
    void setIpAddress(const string &value) { ipAddress = value; }

    // Static method to get the number of computers created

    static int GetCompNum() {
        return counter;
    }

    // Method "StartDevice"

    void StartDevice() override {
        cout << "Device started." << endl;
    }

    // Method "ShutDown"

    void ShutDown() override {
        cout << "Shutting down device: " << _name << endl;
        ipAddress.clear();
    }

    // Show computer info

    void ShowInfo() const {
        cout << "Name: " << _name << ", BiosName: " << biosName << ", IpAddress: " << ipAddress << endl;
    }
};

// Inicialize counter

int Computer::counter = 0;

}

#endif
