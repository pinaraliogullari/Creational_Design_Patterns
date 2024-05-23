namespace Object_Pool_Design_Pattern_Pratic5_AspNetCore.Classes
{
	//Microsoft.Extensions.ObjectPool Asp.net core projesine default olarak yüklüdür. sadece program cs te belli bir configurasyon yapmamız gerekir.bkz. Program cs
	public class X
	{
		public int Count { get; set; }
		public void Write()
			=>Console.WriteLine(Count);
		public X()
		=> Console.WriteLine("X üretim maliyeti...");

		~X()
		=> Console.WriteLine("X imha maliyeti...");
		
    }
}
