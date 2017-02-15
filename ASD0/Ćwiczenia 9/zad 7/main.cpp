#include <iostream>
#include <string>
#include <stdbool.h>

using namespace std;

int Qhead = 0;
int Qtail = 0;

int QUEUE_EMPTY(int *Q)
{
	if (Qhead == Qtail)
	{
		return true;
	}
	return false;
}

void ENQUEUE(int *Q, int x)
{
	Q[Qtail] = x;
	if (Qtail == 10)
	{
		Qtail = 1;
	}
	else
	{
		Qtail++;
	}
}

int DEQUEUE(int *Q)
{
	int x = Q[Qhead];
	if (Qhead == 10)
	{
		Qhead = 1;
	}
	else
	{
		Qhead++;
	}
	return x;
}

int Stop = 0;

bool STACK_EMPTY(int *S)
{
	if(Stop <= 0)
	{
		return true;		
	}
	return false;
}

int PUSH(int *S, int x, int *Q)
{
	Stop++;
	S[Stop] = x;
	ENQUEUE(Q, x);
}

int POP(int *S)
{
	Stop--;
	return S[Stop + 1];
}

int TOP(int *S)
{
	return S[Stop];
}

int SIZE(int *S)
{
	return Stop;
}

int CLEAR(int *S)
{
	Stop = 0;
}

int MULTIPOP(int *S, int k)
{
	if (Stop < k)
	{
		Stop = 0;
	}
	else
	{
		Stop = Stop - k;
	}
}


int main()
{
	int Stos[10];
	int Queue[10];
	
	int i = 0;
	for(i = 1; i <= 5; i++)
	{
		PUSH(Stos, i, Queue);
	}
/*	for(i = 1; i <= 10; i++)
	{
		cout << Stos[i] << "<- Stos[i] dla " << i << " Queue[i] -> " << Queue[i] << "\n";
	}*/
	for(i = 1; i <= 4; i++)
	{
		cout << Stos[DEQUEUE(Queue)] << "\n";
	}
	for(i = 6; i <= 10; i++)
	{
		PUSH(Stos, i, Queue);
	}	
	for(i = Stop; i > 0; i--)
	{
		cout << Stos[DEQUEUE(Queue)] << "\n";
	}
}
