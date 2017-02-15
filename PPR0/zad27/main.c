#include <stdio.h>

int nwd(int a, int b)
{
	while(b != 0)
	{
		int temp = a % b;
		a = b;
		b = temp;
	}
	return a;
}

int nww(int a, int b)
{
	return a / nwd(a,b) * b;
}

int main()
{
	int i, iteracje;
	scanf("%d", &iteracje);
	for(i = 0; i < iteracje; i++)
	{
		int a,b,c,d;
		scanf("%d %d %d %d", &a,&b,&c,&d);
		a = nww(a,b);
		a = nww(a,c);
		a = nww(a,d);
		printf("%d\n", a);
	}
}
