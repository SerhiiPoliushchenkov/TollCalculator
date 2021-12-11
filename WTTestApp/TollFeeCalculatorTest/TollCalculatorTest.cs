using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollFeeCalculator;
using Models;

namespace TollFeeCalculatorTest
{
	[TestClass]
	public class TollCalculatorTest
	{
		VehicleFactory vehicleFactory = new VehicleFactory();
		TollCalculator tollCalculator = new TollCalculator();

		[TestMethod]
		public void CarBeforeFeeTime()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 5, 30, 52);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Car9SEK_6_29()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 6, 29, 29);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 9);
		}

		[TestMethod]
		public void Car16SEK_6_30()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 6, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 16);
		}

		[TestMethod]
		public void Car22SEK_7_00()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 7, 0, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 22);
		}

		[TestMethod]
		public void Car16SEK_8_00()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 8, 0, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 16);
		}

		[TestMethod]
		public void Car9SEK_14_59()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 14, 59, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 9);
		}

		[TestMethod]
		public void Car16SEK_15_00()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 15, 00, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 16);
		}

		[TestMethod]
		public void Car22SEK_16_59()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 16, 59, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 22);
		}

		[TestMethod]
		public void Car16SEK_17_00()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 17, 00, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 16);
		}

		[TestMethod]
		public void Car9SEK_18_29()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 18, 29, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 9);
		}

		[TestMethod]
		public void Car0SEKAfterFeeTime()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 18, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Car0SEK31December()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 31, 10, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Car0SEK17July()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 7, 17, 10, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Car0SEKWeekend()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 11, 9, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Motorbike0SEKTollFree()
		{
			Vehicle motorbike = vehicleFactory.CreateVehicle(EnumVehicleTypes.Motorbike);
			DateTime date1 = new DateTime(2021, 6, 17, 10, 30, 0);
			DateTime[] datesArray = new DateTime[] { date1 };

			int result = tollCalculator.GetTollFee(motorbike, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void MaximumFeeForOneDay()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			DateTime date1 = new DateTime(2021, 12, 6, 8, 30, 0);
			DateTime date2 = new DateTime(2021, 12, 6, 9, 30, 0);
			DateTime date3 = new DateTime(2021, 12, 6, 10, 30, 0);
			DateTime date4 = new DateTime(2021, 12, 6, 15, 30, 0);
			DateTime date5 = new DateTime(2021, 12, 6, 16, 30, 0);
			DateTime date6 = new DateTime(2021, 12, 6, 16, 32, 0);
			DateTime date7 = new DateTime(2021, 12, 6, 16, 33, 0);
			DateTime date8 = new DateTime(2021, 12, 6, 16, 35, 0);
			DateTime date9 = new DateTime(2021, 12, 6, 16, 38, 0);
			DateTime[] datesArray = new DateTime[] { date1, date2, date3, date4, date5, date6, date7, date8, date9 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 60);
		}

		[TestMethod]
		public void FeeForFewTimesperDay()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);
			var date1 = new DateTime(2021, 12, 6, 8, 30, 0);
			var date2 = new DateTime(2021, 12, 6, 9, 30, 0);

			DateTime[] datesArray = new DateTime[] { date1, date2 };

			int result = tollCalculator.GetTollFee(car, datesArray);

			Assert.IsTrue(result == 18);
		}

		[TestMethod]
		public void TollFreeForFewTimesperDay()
		{
			Vehicle millitaryCar = vehicleFactory.CreateVehicle(EnumVehicleTypes.Military);
			var date1 = new DateTime(2021, 12, 6, 8, 30, 0);
			var date2 = new DateTime(2021, 12, 6, 9, 30, 0);

			DateTime[] datesArray = new DateTime[] { date1, date2 };

			int result = tollCalculator.GetTollFee(millitaryCar, datesArray);

			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void VehicleNotPassed()
		{
			var date1 = new DateTime(2021, 12, 6, 8, 30, 0);
			var date2 = new DateTime(2021, 12, 6, 9, 30, 0);

			DateTime[] datesArray = new DateTime[] { date1, date2 };

			int result = tollCalculator.GetTollFee(null, datesArray);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DateseNotPassed()
		{
			Vehicle car = vehicleFactory.CreateVehicle(EnumVehicleTypes.Car);

			int result = tollCalculator.GetTollFee(car, Array.Empty<DateTime>());
		}

	}
}
