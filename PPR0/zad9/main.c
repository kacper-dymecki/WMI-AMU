#include <stdio.h>

int main()
{
	int n,m;
	scanf("%d%d",&n,&m);
	int i,j,tablica[100][100];
	for(i = 0; i < n; i++)
	{
		for(j = 0; j < m; j++)
		{
			scanf("%d",&tablica[i][j]);
		}
	}
	for(i = 0; i < m; i++)
	{
		for(j = n - 1; j >= 0; j--)
		{
			printf("%d ",tablica[j][i]);
		}
		printf("\n");
	}
}
