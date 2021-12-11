using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollFeeCalculator;
using Models;

namespace TollFeeCalculatorTest
{
	[TestClass]
	public class VehicleFactoryTest
	{
		VehicleFactory vehicleFactory = new VehicleFactory();

		[TestMethod]
		public void NotTollFreeVehicle()
		{
			Enum vehicleType = EnumVehicleTypes.Car;

			Vehicle car = vehicleFactory.CreateVehicle(vehicleType);

			Assert.IsFalse(car.IsTollFree);
		}

		[TestMethod]
		public void TollFreeVehicle()
		{
			Enum vehicleType = EnumVehicleTypes.Military;

			Vehicle car = vehicleFactory.CreateVehicle(vehicleType);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NoParameter()
		{
			Enum vehicleType = null;

			Vehicle car = vehicleFactory.CreateVehicle(vehicleType);
		}
	}
}
