#include <stdio.h>

int main()
{
	int a,b,c;
	scanf("%d%d %d", &a, &b, &c);
	//scanf(" %d", &c);
	if((c >= a) && (c <= b))
	{
		printf("BINGO");
	}
	else
	{
		if(c < a)
		{
			printf("%d", a - c);
		}
		if(c > b)
		{
			printf("%d", c - b);
		}
	}
	
}
