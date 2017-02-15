#include <iostream>

using namespace std;

void sortowanie_wstawianie(int n, int *A)
{
	int i,j;
	for(i = 2; i < n; i++)
	{
		j = i;
		while((A[j] > A[j - 1]) && (j > 1))
		{
			int tymczasowaZmienna = A[j];
			A[j] = A[j - 1];
			A[j - 1] = tymczasowaZmienna;
			j--;
		}
	}
}

int main()
{
	
}
