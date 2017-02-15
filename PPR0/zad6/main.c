#include <stdio.h>

int main()
{
	int liczbagier;
	scanf("%d",&liczbagier);
	int i,a,b;
	int wyniki[(liczbagier + 1)];
	char znak;
	
	for(i = 1; i <= liczbagier; i++)
	{
		scanf("%d%d %c",&a, &b, &znak);	
		if(a != b)
		{
			if(a > b)
			{
				int temp = a;
				a = b;
				b = temp;
			}
			int j;
			wyniki[i] = 0;
			if(znak == '*')
			{
				wyniki[i] = 1;
			}
			for(j = a; j <= b; j++)
			{
				if(znak == '+')
				{
				//	printf("wyniki[i] : %d, j : %d\n", wyniki[i], j);
					wyniki[i] = wyniki[i] + j;
				}
				if(znak == '-')
				{
				//	printf("wyniki[i] : %d, j : %d\n", wyniki[i], j);
					wyniki[i] = wyniki[i] - j;
				}
				if(znak == '*')
				{
					wyniki[i] = wyniki[i] * j;
				}
			}
	/*		if(wyniki[i] < 0)
			{
				wyniki[i] = wyniki[i] * (-1);
			}*/
		}
		else
		{
			wyniki[i] = -333333;
		}
	}
	for(i = 1; i <= liczbagier; i++) 
	{
		if(wyniki[i] != -333333)
		{
			printf("%d\n",wyniki[i]);
		}
	}
}
