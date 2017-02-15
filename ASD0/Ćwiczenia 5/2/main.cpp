#include <iostream>

using namespace std;

int main()
{
	int a[100];
	int najwieksza,i;
	for(i = 0; i < 100; i++)
	{
		if(a[i] > najwieksza)
		{
			najwieksza = a[i];
		}
	}
	cout << "Najwieksza wartosc : " << najwieksza << " na pozycjach:";
	for(i = 0; i < 100; i++)
	{
		if(a[i] == najwieksza)
		{
			cout << i << " ";
		}
	}
}
