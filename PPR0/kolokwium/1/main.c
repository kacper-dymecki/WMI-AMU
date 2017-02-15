#include <stdio.h>

int main()
{
	int ilosc,i;
	float length = 0;
	scanf("%d", &ilosc);
	char stringArray[101][21];
	for(i = 0; i <= ilosc; i++)
	{
		gets(stringArray[i]);
	}
	for(i = ilosc; i >= 0; i--)
	{
		printf("%s\n", stringArray[i]);
		length += strlen(stringArray[i]);
	}
	printf("%.1f", length / ilosc);
}
