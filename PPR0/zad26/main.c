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

int main()
{
	int i,iteracje;
	scanf("%d",&iteracje);
	for(i = 0; i < iteracje; i++)
	{
		int a,b,c,d;
		scanf("%d %d %d %d", &a, &b, &c, &d);
		a = nwd(a,b);
		a = nwd(a,c);
		printf("%d\n",nwd(a,d));
	}
}
