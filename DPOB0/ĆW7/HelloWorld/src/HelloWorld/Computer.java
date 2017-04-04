package HelloWorld;

public class Computer
{
	private int cpuSpeed;
	private int ram;
	private String manufacturer;
	
	public Computer(int CpuSpeed, int Ram, String Manufacturer)
	{
		this.cpuSpeed = CpuSpeed;
		this.ram = Ram;
		this.manufacturer = Manufacturer;
	}
	
	public void setCpuSpeed(int CpuSpeed)
	{
		cpuSpeed = CpuSpeed;
	}
	
	public void setRam(int Ram)
	{
		ram = Ram;
	}
	
	public void setManufacturer(String Manufacturer)
	{
		manufacturer = Manufacturer;
	}
	
	public int getCpuSpeed()
	{
		return cpuSpeed;
	}
	
	public int getRam()
	{
		return ram;
	}
	
	public String getManufacturer()
	{
		return manufacturer;
	}
}