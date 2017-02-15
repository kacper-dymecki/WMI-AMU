#include <iostream>

using namespace std;

int rekurencja(int n, int k)
{
	if(n == 1) 
	{
		return 2 * k;
	}
	if((k == 1) && (n > 1))
	{
		return n;
	}
    if((n > 1) && (k > 1))
	{
		return rekurencja(n - 1, k) - (2 * rekurencja(n, k - 1));
	}	
}

int dynamiczne(int n, int k, int A[20][20])
{
	int i = 1, j = 1;
	for(i; i <= k; i++)
	{
		A[1][i] = 2 * i;
	}
	for(i; i <= n; i++)
	{
		A[i][1] = i;
	}
	for(i = 2; i < n; i++)
	{
		for(j = 2; j < k; j++)
		{
			A[i][j] = 2 * A[i - 1][j] + (A[i][j - 1] / 2);
		}
	}
	return A[n][k];
}

int main()
{
}
