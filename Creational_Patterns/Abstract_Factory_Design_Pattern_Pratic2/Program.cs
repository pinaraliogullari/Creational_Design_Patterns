// ABSTRACT FACTORY DESIGN PATTERN ve FACTORY METHOD DESIGN PATTERN BİRLİKTE KULLANILDI.
//aşağıda nesneyi oluşturmamak direkt olarak talep etmek için factory method design pattern kullandık.


ComputerCreator creator = new();
Computer asus = creator.CreateComputer(ComputerType.Asus);
Computer toshiba = creator.CreateComputer(ComputerType.Toshiba);
Computer msi = creator.CreateComputer(ComputerType.MSI);
class Computer
{
	public Computer(CPU cpu, RAM ram, VideoCard videoCard)
	{
		CPU = cpu;
		RAM = ram;
		VideoCard = videoCard;
	}
	public Computer()
	{

	}
	public CPU CPU { get; set; }
	public RAM RAM { get; set; }
	public VideoCard VideoCard { get; set; }
}

#region Abstract Products
interface ICPU { }
interface IRAM { }
interface IVideoCard { }
#endregion

#region Concrete Products
class CPU : ICPU
{
	public CPU(string text) => Console.WriteLine(text);
}

class RAM : IRAM
{
	public RAM(string text) => Console.WriteLine(text);
}

class VideoCard : IVideoCard
{
	public VideoCard(string text) => Console.WriteLine(text);
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
	ICPU CreateCPU();
	IRAM CreateRAM();
	IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factories
class AsusFactory : IComputerFactory
{
	public ICPU CreateCPU()
		=> new CPU("Asus CPU üretildi");

	public IRAM CreateRAM()
		=> new RAM("Asus RAM üretildi");

	public IVideoCard CreateVideoCard()
		=> new VideoCard("Asus VideoCard üretildi");
}
class ToshibaFactory : IComputerFactory
{
	public ICPU CreateCPU()
		=> new CPU("Toshiba CPU üretildi");

	public IRAM CreateRAM()
		=> new RAM("Toshiba RAM üretildi");

	public IVideoCard CreateVideoCard()
		=> new VideoCard("Toshiba VideoCard üretildi");
}
class MSIFactory : IComputerFactory
{
	public ICPU CreateCPU()
		=> new CPU("MSI CPU üretildi");

	public IRAM CreateRAM()
		=> new RAM("MSI RAM üretildi");

	public IVideoCard CreateVideoCard()
		=> new VideoCard("MSI VideoCard üretildi");
}
#endregion

#region Creator
enum ComputerType{
	Asus,
	MSI,
	Toshiba
}
class ComputerCreator
{
	ICPU _cpu;
	IRAM _ram;
	IVideoCard _videoCard;

	public Computer CreateComputer(ComputerType computerType)
	{
		IComputerFactory computerFactory = computerType switch
		{
			ComputerType.MSI =>new MSIFactory(),
			ComputerType.Toshiba=>new ToshibaFactory(),
			ComputerType.Asus=>new AsusFactory(),
		};
		_cpu = computerFactory.CreateCPU();
		_ram = computerFactory.CreateRAM();
		_videoCard = computerFactory.CreateVideoCard();
		return new(_cpu as CPU, _ram as RAM, _videoCard as VideoCard);
	}
}
#endregion
