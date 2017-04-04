package HelloWorld;

public class HelloWorld 
{
	public static void main(String args[]) 
	{
		Person person = new Person("asdf","fdsa",123);
		Computer computer = new Computer(3200, 8192, "SNSV");
		
		System.out.println("Klasa Person : " + person.getName() + ", " + person.getSurname() + ", " + person.getAge());
		System.out.println("Klasa Computer : " + computer.getCpuSpeed() + ", " + computer.getRam() + ", " + computer.getManufacturer());
		
	}

}
