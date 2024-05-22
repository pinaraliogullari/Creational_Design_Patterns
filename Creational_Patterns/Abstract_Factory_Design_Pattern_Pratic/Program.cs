//SADECE ABSTRACT FACTORY DESIGN PATTERN KULLANILDI


//üreteceğimiz nesnenin alt parçacıklarına da ihitacımız varsa yani onlardan da nesne üretmemiz söz konusu ise Abstract Factory Design Pattern kullanmalıyız. Herhangi bir sınıf başka herhangi bir sınıftan constructor/ property vs vasıtasıyla nesne alabilir ancak burda kontrol etmemiz gereken bu nesneler ilişki nesneler midir, bir ürün ailesine bağlı mıdır? eğer değilse sadece işlevsel amaçla kullanılan dış kaynak bir nesne ise  abstract factory söz konusu değildir.

//Computer computer1 = new();

//CPU cpu = new();
//computer1.CPU = cpu;

//RAM ram = new();
//computer1.RAM = ram;

//VideoCard videoCard = new();
//computer1.VideoCard = videoCard;

//Computer computer2 = new(new(), new(), new());

//CPU cpu2 = ;
//computer2.CPU = cpu2;

//RAM ram2 = new();
//computer2.RAM = ram2;

//VideoCard videoCard2 = new();
//computer2.VideoCard = videoCard2;

ComputerCreator creator = new();
Computer asus=creator.CreateComputer(new AsusFactory());
Computer toshiba=creator.CreateComputer(new ToshibaFactory());
class Computer
{
    public Computer(CPU cpu,RAM ram,VideoCard videoCard)
    {
        CPU = cpu;
		RAM = ram;
		VideoCard= videoCard;
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
class CPU:ICPU
{
	public CPU(string text) => Console.WriteLine(text);
}

class RAM:IRAM
{
	public RAM(string text) => Console.WriteLine(text);
}

class VideoCard:IVideoCard
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
class ComputerCreator
{
	ICPU _cpu;
	IRAM _ram;
	IVideoCard _videoCard;

	public Computer CreateComputer(IComputerFactory computerFactory)
	{
		_cpu = computerFactory.CreateCPU();
		_ram = computerFactory.CreateRAM();
		_videoCard = computerFactory.CreateVideoCard();
		return new(_cpu as CPU, _ram as RAM, _videoCard as VideoCard);
	}
}
#endregion
