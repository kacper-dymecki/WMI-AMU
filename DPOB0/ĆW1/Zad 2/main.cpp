#include <iostream>
#include <ctime>

using namespace std;

class Data
{
	private :

		int day, month, year;
	
	public  :

		void set(int d, int m, int r)
		{
			year = r;
			month = m;
			day = d;	
		}

		void set()
		{
			time_t t = time(0);
			struct tm * now = localtime(&t);
			year = now -> tm_year + 1900;
			month = now -> tm_mon + 1;
			day = now -> tm_mday;	
		}

		void print()
		{
			cout << "YYYY/MM/DD : " << year << "/" << month << "/" << day << "\n";
		}

		
};

int main()
{
	Data data;
	data.set();
	data.print();
	data.set(15,10,2015);
	data.print();
	return 0;
}
