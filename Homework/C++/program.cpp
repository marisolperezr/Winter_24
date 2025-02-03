#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <cstdlib>
#include <ctime>
#include "server.h" 
#include <algorithm>

using namespace std;
using namespace compLibs;
using namespace compLibs::Servers;

class Program {
private:
    static vector<int> UsedNumbers;
    static ofstream log;
    static vector<Computer*> network;

    static string getNum() {
        if (UsedNumbers.empty()) {
            for (int i = 1; i <= 254; i++) {
                UsedNumbers.push_back(i);
            }
        }

        int index = rand() % UsedNumbers.size();
        int num = UsedNumbers[index];
        UsedNumbers.erase(UsedNumbers.begin() + index);

        return to_string(num);
    }

    static void StartServer() {
        cout << "Enter the server name: ";
        string serverName;
        getline(cin, serverName);
    
        cout << "Enter the BIOS name: ";
        string biosName;
        getline(cin, biosName);
    
        cout << "Enter the server type: ";
        string serverType;
        getline(cin, serverType);

        string ipAddress = "10.0.192." + getNum(); // Generate unique IP

        WebServer* newServer = new WebServer(serverName, biosName, ipAddress, serverType);
        network.push_back(newServer);

        log << "[Server Started]: Name: " << serverName << ", BIOS: " << biosName << ", IP: " << ipAddress << ", Type: " << serverType << ", Time: " << time(0) << endl;

        cout << "Server '" << serverName << "' started with IP " << ipAddress << "." << endl;
    }

    static void StartComputers(int count) {
        for (int i = 0; i < count; i++) {
            string biosName = "comp" + to_string(i);
            string ipAddress = "10.0.192." + getNum();
            network.push_back(new Computer("Default", biosName, ipAddress));
            log << "[Computer Started]: BiosName: " << biosName << ", IpAddress: " << ipAddress << ", Time: " << time(0) << endl;
        }
        cout << count << " Computers added." << endl;
    }

    static void DisplayComputers() {
        for (auto& computer : network) {                            //auto& is to avoid unnecessary copies by referencing each element directly
            if (Server* server = dynamic_cast<Server*>(computer)) { //dynamic_cast to check if a computer is a Server
                server->ShowInfo();                                 //If the cast succeeds it calls ShowInfo() on the Server and prints its type
                cout << "\tType: " << server->getType() << endl;
            } else {
                computer->ShowInfo();
            }
        }
    }

    static void ShutDownComputer(const string& ipAddress) {
        bool found = false;
        for (auto& computer : network) {                           //auto& is to avoid unnecessary copies by referencing each element directly
            if (computer->getIpAddress() == ipAddress) {
                computer->ShutDown();
                log << "[Computer Shut Down]: IpAddress: " << ipAddress << ", Time: " << time(0) << endl;
                cout << "Computer " << ipAddress << " shut down." << endl;
                found = true;
                break;
            }
        }
        if (!found) {
            cout << "Could not find the computer." << endl;
        }
    }

    static void ShutDownAllComputers() {
        for (auto& computer : network) {                            //auto& is to avoid unnecessary copies by referencing each element directly
            computer->ShutDown();
            log << "[All Computers Shut Down]: Time: " << time(0) << endl;
        }
        cout << "All computers have been shut down." << endl;
    }

    static void SeeLog() {
        log.flush();
        cout << "Log saved to 'log.txt'." << endl;
    }

    static void ShutDownServer() {
        cout << "*******!********" << endl;
        cout << "Do you want to shut down the server? (YES/n) ";
        string confirm;
        getline(cin, confirm);

        if (confirm == "YES") {
            Server* serverToShutDown = nullptr;                          //it is like null, and it inicialized a pointer servershutdown of type server* to null 
            for (auto& device : network) {                               //auto& is to avoid unnecessary copies by referencing each element directly
                if (Server* server = dynamic_cast<Server*>(device)) {    //dynamic_cast try to see if a device can cast to server*
                    serverToShutDown = server;                          // if device is a server it points to that object and shuts it down
                    break;
                }
            }

            if (serverToShutDown) {
                log << "[Server Shut Down ]: " << time(0) << endl;
                network.erase(
                    std::remove_if(network.begin(),network.end(),
                    [serverToShutDown](Computer* c){
                        return c == serverToShutDown;
                    }),
                 network.end());
                cout << "Server " << serverToShutDown->getBiosName() << " has been shut down." << endl;
            } else {
                cout << "Server shutdown canceled" << endl;
            }
        }
    }

public:
    static void Main() {
        log.open("log.txt", ios::app);      //iosapp is for the file in append mode. meaning new data will be added to the end of the file without overwriting existing content

        bool on = true;
        while (on) {
            cout << "Program Menu:" << endl;
            cout << "1. Start Server" << endl;
            cout << "2. Start Computers" << endl;
            cout << "3. Display Computers" << endl;
            cout << "4. Shut down computer" << endl;
            cout << "5. Shut down all computers" << endl;
            cout << "6. See the log" << endl;
            cout << "7. Shut down server" << endl;
            cout << "8. Quit" << endl;
            cout << "Select an option: ";

            string options;
            getline(cin, options);

            if (options == "1") {
                StartServer();
            } else if (options == "2") {
                cout << "How many computers do you want to start? ";
                int count;
                if (cin >> count) {
                    cin.ignore();  // Clean up the buffer
                    StartComputers(count);
                }
            } else if (options == "3") {
                DisplayComputers();
            } else if (options == "4") {
                cout << "Which computer do you want to shut down? ";
                string ipAddress;
                getline(cin, ipAddress);
                ShutDownComputer(ipAddress);
            } else if (options == "5") {
                ShutDownAllComputers();
            } else if (options == "6") {
                SeeLog();
            } else if (options == "7") {
                ShutDownServer();
            } else if (options == "8") {
                on = false;
                log << "[Program Terminated]: " << time(0) << endl;
                cout << "Bye!" << endl;
            } else {
                cout << "Invalid option. Try again." << endl;
            }
        }
        log.close();
    }
};

// Inicialize static variables

vector<int> Program::UsedNumbers;
ofstream Program::log;
vector<Computer*> Program::network;

int main() {
    Program::Main();
    return 0;
}
