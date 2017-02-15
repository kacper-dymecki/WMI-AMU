#include <stdio.h>

int main()
{
	int tablica[100];
	int iloscTestow;
	scanf("%d",&iloscTestow);
	int i;
	for(i = 0; i < 100; i++)
	{
		if(i == 0)
		{
			tablica[i] = 4;
		}
		if(i == 1)
		{
			tablica[i] = 7;
		}
		if(i > 1)
		{
			tablica[i] = ((2 * tablica[i - 1]) % 2011 + (5 * tablica[i - 2]) % 2011) % 2011;
		}
	}
	for(i = 0; i < 101; i++)
	{
		printf("%d = %d\n", i, tablica[i]);
	}
	for(i = 0; i < iloscTestow; i++)
	{
		int temp;
		scanf("%d",&temp);
		printf("%d\n",tablica[temp]);
	}
}
