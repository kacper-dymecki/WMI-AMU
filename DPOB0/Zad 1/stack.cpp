#include <iostream>

class Stack 
{
	private:
		int data[100];
		int n;

	public:
		void init() 
		{
			n = 0;
			std::cout << "Pojawiam sie!\n";
		}
		
		void push(int e) 
		{
			data[n++] = e;
		}
		
		int pop() 
		{
			return data[--n];
		}
		
		int empty() 
		{
			return n == 0;
		}

		~Stack()
		{
			std::cout << "Znikam!";	
		}
};

main()
{
	Stack stack;
	stack.init();
	stack.push(2);
	stack.push(5);
	stack.push(3);
	while(!stack.empty())
	{
		std::cout << stack.pop() << std::endl;
	}ddd
	return 0;
}
