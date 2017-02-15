#include <stdio.h>

int main()
{
	int a,b;
	char chr;
	scanf("%d%d", &a,&b);
	scanf("\n%c", &chr);
	for(int i = a; i <= b; i++)
	{
		if((chr == 'p') && (i % 2 == 0))
		{
			printf("%d ", i);
		}
		else if((chr =='n') && (i % 2 == 1))
		{
			printf("%d ", i);
		}
	}
}

