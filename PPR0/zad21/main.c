#include <stdio.h>

int main()
{
	int max,i;
	scanf("%d", &max);
	for(i = 0; i < max; i++)
	{
		int a,b;
		char znak;
		scanf("%d %c %d", &a, &znak, &b);
		if(znak == '+') printf("%d\n",a + b);
		if(znak == '-') printf("%d\n",a - b);
		if(znak == '*') printf("%d\n",a * b);
		if(znak == '/') printf("%d\n",a / b);
	}
}
