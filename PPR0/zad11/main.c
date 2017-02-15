#include <stdio.h>

int nwd(int a, int b)
{
	while(a != b)
	{
		if(a > b)
		{
			a -= b;
		}
		else
		{
			b -= a;
		}
	}
	return a;
}

int main()
{
	int input = 1;
	int ostatnieNWD[2];
	int sumaNWD = 0;
	int i = 0;
	while(input != 0)
	{
		scanf("%d",&input);
		if(input > 1)
		{
			ostatnieNWD[i % 2] = input;
			i++;	
		}
		if(input == 1)
		{
			sumaNWD = sumaNWD + nwd(ostatnieNWD[0],ostatnieNWD[1]);
		}
		if(input == 0)
		{
			break;
		}
	}
	printf("%d",sumaNWD);
}

