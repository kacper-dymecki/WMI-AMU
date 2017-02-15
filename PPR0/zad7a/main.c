#include <stdio.h>

int main()
{
	int n;
	scanf("%d", &n);
	int tablica[n], i;
	for(i = 1; i <= n; i++)
	{
		scanf("%d",&tablica[i]);	
	}
	for(i = n; i > 0; i--)
	{
		if(i % 3 == 0)
		{
			printf("%d ",tablica[i]);
		}
	}
}
