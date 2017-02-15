#include <stdio.h>

int main()
{
	int m, n;
	scanf("%d%d", &m, &n);
	int wyniki[(m + 1)], i, j;
	for(i = 1; i <= m; i++)
	{
		wyniki[i] = 0;
	}
	for(i = 1; i <= n; i++)
	{
		int temp;
		scanf("%d",&temp);
		for(j = 1; j <= m; j++)
		{
			if(temp == j)
			{
				wyniki[j] += 1;
				break;
			}
		}

	}
	int wygrany = 1;
	for(i = 1; i <= m; i++)
	{
		printf("%d: %d\n", i, wyniki[i]);
	}
	for(i = 1; i <= m; i++)
	{
		if(wyniki[i] > wyniki[wygrany])
		{
			wygrany = i;
		}
	}
	printf("%d", wygrany);
}
