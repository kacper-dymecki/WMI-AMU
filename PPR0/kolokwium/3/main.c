#include <stdio.h>


int silnia(int a)
{
	if(a == 1)
	{
		return 1;
	}
	if(a > 1)
	{
		return silnia(a - 1) * a;
	}
}

int npok(int a, int b)
{
	return silnia(a) / ( silnia(b) * silnia(a - b));
}


int main()
{
	int n,k;
	scanf("%d %d", &n, &k);
        printf("%d", npok(n,k));	
}
