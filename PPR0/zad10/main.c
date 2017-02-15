#include <stdio.h>

int main()
{
	int input = 0, daneLength = 0, sredniaLength = 0, i, j;
	int dane[1010];
	float srednia = 0;
	while(input != -1)
	{
		scanf("%d ", &input);
		dane[daneLength] = input;
		daneLength++;	
		if(input == -1)
		{
			break;
		}
	}
	for(i = 0; i < daneLength; i++)
	{
		if(dane[i] > 1 && dane[i] < 6)
		{
			srednia += dane[i];
			sredniaLength++;
		}
		if(dane[i] == 1)
		{
			printf("%.2f\n",(srednia / sredniaLength));
		}
		if(dane[i] == 0)
		{
			for(j = 0; j < i; j++)
			{
				if(dane[j] > 1 && dane[j] < 6)
				{
					printf("%d ", dane[j]);
				}	
			}
			printf("\n");
		}	
	}
}
