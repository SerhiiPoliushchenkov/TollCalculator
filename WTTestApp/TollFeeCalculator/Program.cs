using System;
using Models;

namespace TollFeeCalculator
{
	public class Program
	{
		public static int Main() {
			VehicleFactory vehicleFactory = new VehicleFactory();
			TollCalculator tollCalculator = new TollCalculator();

			Console.WriteLine("Please enter vehicle type: ");
			Console.WriteLine(" ");
			string? vehicleType = Console.ReadLine();
			Vehicle car = vehicleFactory.CreateVehicle((Enum)Enum.Parse(typeof(EnumVehicleTypes), vehicleType));

			Console.WriteLine("Please enter year: ");
			Console.WriteLine(" ");
			string? year = Console.ReadLine();

			Console.WriteLine("Please enter month: ");
			Console.WriteLine(" ");
			string? month = Console.ReadLine();

			Console.WriteLine("Please enter day: ");
			Console.WriteLine(" ");
			string? day = Console.ReadLine();

			Console.WriteLine("Please enter hour: ");
			Console.WriteLine(" ");
			string? hour = Console.ReadLine();

			Console.WriteLine("Please enter minute: ");
			Console.WriteLine(" ");
			string? minute = Console.ReadLine();

			Console.WriteLine("Please enter seconds: ");
			Console.WriteLine(" ");
			string? seconds = Console.ReadLine();

			DateTime date1 = new DateTime(Int16.Parse(year), Int16.Parse(month), Int16.Parse(day), Int16.Parse(hour), Int16.Parse(minute), Int16.Parse(seconds));

			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Console.WriteLine($"Your fee is {result}");

			return result;
		}
	}
}
