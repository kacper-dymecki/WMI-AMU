#include <stdio.h>

int main()
{
	int n, m;
	scanf("%d %d", &n, &m);
	int i;
	for(i = 0; i < n; i++)
	{
		char string[100];
		scanf("%s", &string);
		if(strlen(string) > m)
		{
			int j = 0;
			while((j + m) <= strlen(string))
			{
				int temp = 0;
				for(temp = j; temp < (j + m); temp++)
				{
					printf("%c",string[temp]);
				}
				j++;
				printf("\n");
			}
		}
	}
}
