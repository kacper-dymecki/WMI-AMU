#include <stdio.h>

int main()
{
	int liczbaTestow;
	scanf("%d", &liczbaTestow);
	fflush(stdin);
	int i;
	for (i = 0; i < liczbaTestow; i++)
	{
		char string[102];
		gets(string);
		int tempDane[2] = { 0 , 0};
		int j;
		for(j = 0; j <= strlen(string); j ++)
		{
			if((string[j] > 64 && string[j] < 91) || (string[j] > 96 && string[j] < 123))
			{
				tempDane[0]++;
			}	
			if((string[j] >= 48 && string[j] <= 57))
			{
				tempDane[1]++;
			}
		}
		printf("%d %d %d\n", strlen(string), tempDane[0], tempDane[1]);
	}
}
