#include <iostream>
#include <string>

using namespace std;

class Engineer;

class Building {

public:
        friend class Engineer;
		string getEngineer() { return engineerName;}
		int getHeight() { return height;}
private:
        string engineerName;
        int height;     
};



class Engineer {

public:
        void registerInBuilding(Building & b) 
		{
                b.engineerName = this->name;            
        }
		string getName() { return name;}
		void setName(string Name) { name = Name;}
		int getAge() { return age;}
		void setAge(int Age) { age = Age;}

private:
        string name;
        int age;        
};

int main()
{
	Building budynek;
	Engineer inz;
	inz.setName("tak");
	inz.setAge(666);
	inz.registerInBuilding(budynek);
	cout << inz.getName() << " / " << inz.getAge();
	cout << budynek.getEngineer();
	
}