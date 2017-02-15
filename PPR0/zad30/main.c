#include <stdio.h>
#include <string.h>

int main()
{
	float liczba;
	int iteracje, i;
	scanf("%f %d", &liczba, &iteracje);
	for(i = 0; i < iteracje; i++)
	{
		char typ[10];
		scanf("%s", typ);
		if(strcmp(typ, "int") == 1)
		{
			int temp = liczba;
			printf("%d\n", temp);
		}
		if(strcmp(typ, "long") == 1)
		{
			long long int temp = liczba;
			printf("%lld\n", temp); 
		}
		if(strcmp(typ, "float") == 1)
		{
			printf("%f\n", liczba);
		}
		if(strcmp(typ, "double") == 1)
		{
			double temp = liczba;
			printf("%f\n", temp);
		}
	}
}
