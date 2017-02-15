#include <stdio.h>

int main()
{
	int z,n,k,r,i;
	scanf("%d", &z);
	while(z > 0)
	{
		scanf("%d %d", &n, &k);
		r = 1;
		for(i = n; i >= k; i -= k)
		{
			r *= i;
		}
		printf("%d\n", r);
		z--;
	}
}
