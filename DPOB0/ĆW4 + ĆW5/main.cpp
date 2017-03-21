#include <iostream>

using namespace std;

class Osoba
{
	private:
		int id;
		string imie;
		string nazwisko;
		int nr_albumu;
		int expense;
	public:
		Osoba()
		{
			id = 0;
			imie = "";
			nazwisko = "";
			nr_albumu = 0;
			expense = 0;
		}
		Osoba(int Id, string Imie, string Nazwisko, int Nr_albumu, int Expense)
		{
			id = Id;
			imie = Imie;
			nazwisko = Nazwisko;
			nr_albumu = Nr_albumu;
			expense = Expense; 
		}
		Osoba(Osoba &osoba)
		{
			id = osoba.id + 1;
			imie = osoba.imie;
			nazwisko = osoba.nazwisko;
			nr_albumu = osoba.nr_albumu;
			expense = osoba.expense;
		}
		string getImie()
		{
			return imie;
		}
		string getNazwisko()
		{
			return nazwisko;
		}
		int getId()
		{
			return id;
		}
		int getNrAlbumu()
		{
			return nr_albumu;
		}
		int getExpense()
		{
			return expense;
		}
};

void addStudent(Osoba * studentList, int * count)
{
	string imie,nazwisko;
	cout << "\nPodaj imie i nazwisko studenta\n";
	cin >> imie >> nazwisko;
	Osoba osoba((*count)++, imie, nazwisko, (*count), 0);
	studentList[(*count)] = osoba;
}

void findStudent(Osoba * studentList, int * studentCount)
{
	int menu;
	cout << "\nSzukaj po :\n1. Id\n2. Numerze albumu\n3. Wszyscy studenci\nInna liczba = powrot do glownego menu\n";
	cin >> menu;
	switch(menu)
	{
		case 1:
			int studentId;
			cout << "\nPodaj id studenta :\n";
			cin >> studentId;
			if(studentId < (*studentCount))
			{
				cout << "\nNie ma studenta o takim id\n";
			}
			else
			{
				cout << studentList[studentId].getImie() << "," << studentList[studentId].getNazwisko() << "," << studentList[studentId].getNrAlbumu() << "\n";
			}
			break;
		case 2:
			int studentNrAlbumu;
			cout << "\nPodaj nr albumu studenta :\n";
			cin >> studentNrAlbumu;
			for(int i = 1; i <= (*studentCount); i++)
			{
				if(studentList[i].getNrAlbumu() == studentNrAlbumu)
				{
					cout << "Imie: " << studentList[i].getImie() << "\nNazwisko: " << studentList[i].getNazwisko() << "\nNr albumu: " << studentList[i].getNrAlbumu() << "\nStypendium: " << studentList[i].getExpense() << "\n";
				}
				else if(studentList[i].getNrAlbumu() != studentNrAlbumu && i == (*studentCount))
				{
					cout << "\nNie znaleziono studenta o takim nr albumu";
				}
			}
			break;
		case 3:
			cout << "\n";
			for(int i = 1; i <= (*studentCount); i++)
			{
				cout << "Imie: " << studentList[i].getImie() << "\nNaziwsko: " << studentList[i].getNazwisko() << "\nNr albumu: " << studentList[i].getNrAlbumu() << "\nStypendium: " << studentList[i].getExpense() << "\n";
			}
			break;
		default:
			break;
	}
}

void addPracownik(Osoba * pracownicyList, int * count)
{
	string imie,nazwisko;
	int zarobki;
	cout << "\nPodaj imie, nazwisko i zarobki pracownika\n";
	cin >> imie >> nazwisko >> zarobki;
	Osoba osoba((*count)++, imie, nazwisko, (*count), zarobki);
	pracownicyList[(*count)] = osoba;
}

void findPracownik(Osoba * pracownicyList, int * pracownicyCount)
{
	int menu;
	cout << "\nSzukaj po :\n1. Id\n2. Wszyscy studenci\nInna liczba = powrot do glownego menu\n";
	cin >> menu;
	switch(menu)
	{
		case 1:
			int pracownikId;
			cout << "\nPodaj id pracownika :\n";
			cin >> pracownikId;
			if(pracownikId < (*pracownicyCount))
			{
				cout << "\nNie ma pracownika o takim id\n";
			}
			else
			{
				cout << "\nImie: " <<pracownicyList[pracownikId].getImie() << "\nNazwisko: " << pracownicyList[pracownikId].getNazwisko() << "\nZarobki: " << pracownicyList[pracownikId].getExpense() << "\n";
			}
			break;
		case 2:
			cout << "\n";
			for(int i = 1; i <= (*pracownicyCount); i++)
			{
				cout << "Id: " << i << "\n" << "Imie: " << pracownicyList[i].getImie() << "\nNaziwsko: " << pracownicyList[i].getNazwisko() << "\nZarobki: " << pracownicyList[i].getExpense() << "\n";
			}
			break;
		default:
			break;
	}
}

int main()
{
	bool brk = true;
	int studenciCount = 0;
	int pracownicyCount = 0;
	Osoba student[100];
	Osoba pracownik[100];
	while(true == brk)
	{
		int menu;
		cout << "\n1. Dodaj studenta\n2. Znajdz studenta\n3. Dodaj pracownika\n4. Szukaj pracownika\n5. Wylacz program\n";
		cin >> menu;
		switch(menu)
		{
			case 1:
				addStudent(student, &studenciCount);
				break;
			case 2:
				findStudent(student, &studenciCount);
				break;
			case 3:
				addPracownik(pracownik, &pracownicyCount);
				break;
			case 4:
				findPracownik(pracownik, &pracownicyCount);
				break;
			case 5:
				brk = false;
				break;
			default:
				break;
		}
	}
}
