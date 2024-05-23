
//Bir nesneyi klonlamak demek arka planda new operatörüyle onu yeniden üretmek demek değildir. Bu sebeple prototype patternda constructor sadece ilk nesne üretildiğinde tetiklenir.

//Person person1 = new("Pinar","Aliogullari",Department.C,100,10);
//Person person2 = new("Ufuk","Aliogullari",Department.C,100,10); yerine;

Person person1 = new("Pinar", "Aliogullari", Department.C, 100, 10); //ilk nesne üretildi.
Person person2= person1.Clone();// ilk nesne üzerinden klonlama yapıldı.
person2.Name = "Ufuk";// yeni nesnenin istenen değeri değiştirildi.

//Abstract Prototype
interface IPersonCloneable
{
	Person Clone();
}

//Concrete Prototype
class Person:IPersonCloneable
{
	public Person(string name, string surname, Department department, int salary, int premium)
	{
		Name = name;
		Surname = surname;
		Department = department;
		Salary = salary;
		Premium = premium;
		Console.WriteLine("Person nesnesi oluşturuldu");
	}

	public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

	public Person Clone()
	{
		return (Person)base.MemberwiseClone();
	}
}

enum Department
{
	A,B,C
}
