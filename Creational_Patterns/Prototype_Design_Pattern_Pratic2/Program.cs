
//Bu yöntemde abstract prototype interfacei oluşturmadım, system sınıfında  yer alan IClonable interfaceini kullandım.

//Person person1 = new("Pinar","Aliogullari",Department.C,100,10);
//Person person2 = new("Ufuk","Aliogullari",Department.C,100,10); yerine;

Person person1 = new("Pinar", "Aliogullari", Department.C, 100, 10); //ilk nesne üretildi.
Person person2 = (Person)person1.Clone();// ilk nesne üzerinden klonlama yapıldı. veya Person? person2= person1.Clone() as Person;
person2.Name = "Ufuk";// yeni nesnenin istenen değeri değiştirildi.


//Concrete Prototype
class Person : ICloneable
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

	public object Clone()
	{
		return this.MemberwiseClone();
	}
}

enum Department
{
	A, B, C
}

