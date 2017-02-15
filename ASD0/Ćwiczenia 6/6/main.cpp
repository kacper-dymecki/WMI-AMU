#include <iostream>
#include <stdlib.h>

using namespace std;


void scal(int *A, int p, int q, int r)
{
	int n = q - p + 1;
	int m = r - q;
	int i,j;
	int B[100],C[100];
	for(i = 1; i < n; i++)
	{
		B[i] = A[p + i - 1];
	}
	for(j = 1; j < m; j++)
	{
		C[j] = A[q + j];
	}
	i = 1;
	j = 1;
	for (int k = p; k < r; k++)
	{
		if(B[i] <= C[j])
		{
			A[k] = B[i];
			i++;
		}
		else
		{
			A[k] = C[j];
			j++;
		}
	}
}

void sort_scal(int *A, int p, int r)
{
	if (p < r)
	{
		div_t rslt = div((p + r), 2);
		int q = rslt.quot;
		sort_scal(A, p, q);
		sort_scal(A, q + 1, r);
		scal(A, p, q, r);
	}
}

int main()
{
	
}
