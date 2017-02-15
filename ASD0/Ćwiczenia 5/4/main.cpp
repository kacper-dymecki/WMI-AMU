#include <iostream>

using namespace std;

void wyszukiwanie_binarne(int *A, int n, int x)
{
	int i = 0;
	while(i < n)
	{
		if(A[(i + n) / 2] < x)
		{
			i = ((i + n) / 2) + 1;
		}
		else
		{
			n = (i + n) / 2;
		}
	}
	if(A[i] == x)
	{
		cout << x << " znajduje sie na pozycji : " << i;
	}
	else
	{
		cout << x << " nie wystepuje w tej tablicy";
	}
}

int main()
{
	
}