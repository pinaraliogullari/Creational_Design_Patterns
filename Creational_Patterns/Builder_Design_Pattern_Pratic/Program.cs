////Mercedes
//Araba mercedes = new();
//mercedes.Marka = "Mercedes";
//mercedes.Model = "xyz";
//mercedes.KM = 0;
//mercedes.Vites = true;


////BMW
//Araba bmw = new();
//bmw.Marka = "BMW";
//bmw.Model = "abc";
//bmw.KM = 10;
//bmw.Vites = false;



ArabaDirector director = new();
Araba opel=director.Build(new OpelBuilder());
opel.ToString();
Araba mercedes=director.Build(new MercedesBuilder());
mercedes.ToString();
Araba bmw=director.Build(new BMWBuilder());
bmw.ToString();	



//Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double KM { get; set; }
    public bool Vites { get; set; }
	public override string ToString()
	{
		Console.WriteLine($"{Marka} marka araba {Model} modelinde  {KM} kilometrede {Vites} olarak üretilmiştir.");
		return base.ToString();
	}
}

//Abstract Builder

interface IArabaBuilder
{
	Araba Araba { get;}
	void SetMarka();
	void SetModel();
	void SetKM();
	void SetVites();
}

//Concrete Builder
class OpelBuilder : IArabaBuilder
{
	public Araba Araba { get ; }
    public OpelBuilder()
        => Araba = new Araba();

    public void SetKM()
		=> Araba.KM = 0;
	
	public void SetMarka()
		=> Araba.Marka = "Opel";
	
	public void SetModel()
	    => Araba.Model = "xyz";
	
	public void SetVites()
		=> Araba.Vites = false;
	
}

//Concrete Builder
class MercedesBuilder : IArabaBuilder
{
	public Araba Araba { get ; }
    public MercedesBuilder()
        => Araba = new Araba();

    public void SetKM()
		=> Araba.KM = 10;

	public void SetMarka()
		=> Araba.Marka = "Mercedes";
	
	public void SetModel()
		=> Araba.Model = "abc";
	
	public void SetVites()
	    => Araba.Vites = true;
	
}

//Concrete Builder
class BMWBuilder : IArabaBuilder
{
	public Araba Araba { get;  }
    public BMWBuilder()
        => Araba = new Araba();

    public void SetKM()
	   => Araba.KM = 50;

	public void SetMarka()
	   => Araba.Marka = "BMW";

	public void SetModel()
	   => Araba.Model = "qwe";

	public void SetVites()
	   => Araba.Vites = true;
}

//Director

class ArabaDirector
{
	public Araba Build(IArabaBuilder arabaBuilder)
	{
		arabaBuilder.SetMarka();
		arabaBuilder.SetModel();
		arabaBuilder.SetKM();
		arabaBuilder.SetVites();
		return arabaBuilder.Araba;
	}
}
