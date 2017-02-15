#include <stdio.h>

int main()
{
	char imie[256];
	scanf("%s", imie);
	int i = 0;
	while(imie[i] != '\0')
	{
		i++;
	}
	int j;
	for(j = (i - 1); j >= 0;j--)
	{
		printf("%c",imie[j]);
	}
}
