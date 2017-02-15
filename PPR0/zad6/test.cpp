#include <iostream>

using namespace std;

int main()
{
	
	int powt;
	cin >> powt;
	int wyn[powt + 1];
	bool eql[powt + 1];
	
	for (int i = 1; i <= powt; i++)
	{
		int a,b;
		char znak;
		cin >> a >> b >> znak;
		if (a == b)
		{
			eql[i] = true;	
			continue;
		}
		else if (a > b)
		{
			int swap;
			swap = a;
			a = b;
			b = swap;
		}
		eql[i] = false;
		if(znak == '*')
		{
			wyn[i] = 1;
		}
		else
		{
			wyn[i] = 0;
		}
		for (int k = a; k <= b; k++)
		{
			if (znak == '+')
			{
				wyn[i] = wyn[i] + k;
			}
			else if (znak == '-')
			{
				wyn[i] = wyn[i] - k;
			}
			else if (znak=='*')
			{
			//	cout << "\nwyn[" << i << "]" << " : " << wyn[i] << " k: " << k;
				wyn[i] = wyn[i] * k;	
			}
		}
		
				
	}
	for (int z=1; z <= powt; z++)
	{
		if(eql[z] != true)
		{
			cout << wyn[z] << "\n";
		}
	}
}
