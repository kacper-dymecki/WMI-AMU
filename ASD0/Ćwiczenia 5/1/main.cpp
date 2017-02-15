#include <iostream>

using namespace std;
string czyDoskonala(int n)
{
	int iloczyn = 0;
	for(int i = 1; i < n; i++)
	{
		if(n % i == 0)
		{
			iloczyn += i;
		}
	}
	if(n == iloczyn)
	{
		return "Liczba " << n << " jest liczba doskonala";
	}
	return "Liczba " << n << " nie jest doskonala";
}

int main()
{
}
