#include <stdio.h>

int main()
{
	int liczbaPudelek = 0, liczbaPrzedzialow = 0, i, poczPrzedzialu, koniecPrzedzialu;
	int pudelka[1000],przedzialy[1000];
	scanf("%d ",&liczbaPudelek);
	for(i = 0; i < liczbaPudelek; i++)
	{
		scanf("%d ",&pudelka[i]);
	}
	scanf("%d",&liczbaPrzedzialow);
	for(i = 0; i < liczbaPrzedzialow; i++)
	{
		przedzialy[i] = 0;
		scanf("%d %d", &poczPrzedzialu, &koniecPrzedzialu);
		for(poczPrzedzialu; poczPrzedzialu <= koniecPrzedzialu; poczPrzedzialu++)
		{
			przedzialy[i] += pudelka[poczPrzedzialu - 1];
		}
	}
	for(i = 0; i < liczbaPrzedzialow; i++)
	{
		printf("%d\n",przedzialy[i]);
	}	
}
