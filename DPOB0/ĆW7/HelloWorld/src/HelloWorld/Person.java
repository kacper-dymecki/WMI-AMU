package HelloWorld;

public class Person
{
	
	public Person(String Name, String Surname, int Age)
	{
		this.name = Name;
		this.surname = Surname;
		this.age = Age;
	}
	
	private String name;
	private String surname;
	private int age;
	
	public void setName(String Name)
	{
		name = Name;
	}
	
	public void setSurname(String Surname)
	{
		surname = Surname;
	}
	
	public void setAge(int Age)
	{
		age = Age;
	}
	
	public String getName()
	{
		return name; 
	}
	
	public String getSurname()
	{
		return surname;
	}
	
	public int getAge()
	{
		return age;
	}
}
