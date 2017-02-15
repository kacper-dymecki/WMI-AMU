#include <stdio.h>

int main()
{
//	char wyniki[10][70];
	int n,i = 0;
	scanf("%d\n",&n);
	for(i = 0; i < n; i++)
	{
		char string[30], temp[30];
		int equal = 1;
		scanf("%s", &string);
		int stringLength = 0, j, k = 0,l = 0;
		while(string[stringLength] != '\0')
		{
			stringLength++;
		}
		for(j = (stringLength - 1); j >= 0; j--)
		{
			temp[k] = string[j];
			k++; 
		}
		for(l = 0; l < stringLength; l++)
		{
			if(string[l] != temp[l])
			{
				printf("%s!=%s\n",string,temp);
		//		wyniki[i] = string + "!=" + temp;
				equal = 0;
				break;
			}
		}
		if(equal != 0)
		{
			printf("%s==%s\n",string,temp);
		//	wyniki[i] = string + "==" + temp;
		}
		for(j = 0;j < 30; j++)
		{
			string[j] = '\0';
			temp[j] = '\0';
		}
	}
/*	for(i = 0; i < 10; i++)
	{
		printf("%s\n",wyniki[i]);
	}*/
}
