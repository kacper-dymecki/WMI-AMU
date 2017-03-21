#include <string>
#include <iostream>

using namespace std;

class Person
{

private:
    string name;
    string surname;
    int birthYear;

public:

    void setName(string name) {
            this->name = name;
    }
    void setSurname(string surname) {
            this->surname = surname;
    }
    void setBirthYear(int birthYear) {
            this->birthYear = birthYear;
    }

    const string getName() {
            return name;
    }
    const string getSurname() {
            return surname;
    }
    const int getBirthYear() {
            return birthYear;
    }

    void setData(string name, string surname, int birthYear);

    Person() {
    }

    Person(string name, string surname, int birthYear);


};

void Person::setData(string name, string surname, int birthYear) {
    setName(name);
    setSurname(surname);
    setBirthYear(birthYear);
}


Person::Person(string name, string surname, int birthYear) {
    setData(name, surname, birthYear);
}

class Student : public Person 
{
private:
	int scholarship;
public:
	int getScholarship()
	{
		return scholarship;
	}
	void setScholarship(int a)
	{
		scholarship = a;
	}
};

class Employee : public Person
{
private:
	int salary;

public:
	int getSalary()
	{
		return salary;
	}
	void setSalary(int a)
	{
		salary = a;
	}

	float getBonus()
	{
		return (salary * 1.2);
	}
};

int main() {

        Person p1;
        Person p2("Jan", "Kowalski", 1990);
        cout << p2.getSurname() << endl;

        Student s;


        return 0;
}
