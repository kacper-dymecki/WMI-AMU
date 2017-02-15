#include <stdio.h>

int main()
{
	int a,b,c, ppc;
	
	scanf("%d%d%d", &a, &b, &c);
	ppc = 2 * (a * b) + 2 * (a * c) + 2 * (b * c);
	printf("%d", ppc);	
}
