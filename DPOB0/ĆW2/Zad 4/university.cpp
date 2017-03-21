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

    int getExpense();

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
	int getExpense()
	{
		return scholarship;
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
		return (salary * 0.2);
	}
	int getExpense()
	{
		return getSalary() + getBonus();
	}
};

int main() {

    Student student[10];
	Employee employee[10];
	int ilosc_osob,suma;
	cin >> ilosc_osob;
	for(int i = 0; i < ilosc_osob; i++)
	{
		string imie, nazwisko;
		int rokurodzenia, expense;
		cout << "Podaj imie: ";
		cin >> imie;
		cout << "Podaj nazwisko: ";
		cin >> nazwisko;
		cout << "Rok urodzenia : ";
		cin >> rokurodzenia;
		cout << "Podaj expense : ";
		cin >> expense;
		char se;
		cin >> se;
		if(se == 'e' || se == 'e')
		{
			student[i].setName(imie);
			student[i].setSurname(nazwisko);
			student[i].setBirthYear(rokurodzenia);
			student[i].setScholarship(expense);
			suma += student[i].getExpense();
		}
		else if(se == 's' || se == 's')
		{
			employee[i].setName(imie);
			employee[i].setSurname(nazwisko);
			employee[i].setBirthYear(rokurodzenia);
			employee[i].setSalary(expense);
			suma += employee[i].getExpense();
		}
	}
	cout << "Miesieczne wydatki : " << suma;
    return 0;
}
