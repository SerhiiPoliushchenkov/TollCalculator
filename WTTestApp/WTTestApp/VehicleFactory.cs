using Models;
using System;
using System.Linq;

namespace TollFeeCalculator
{
	public class VehicleFactory
	{
		private Enum[] TollFreeVehicleTypes = new Enum[] {
			EnumVehicleTypes.Motorbike,
			EnumVehicleTypes.Tractor,
			EnumVehicleTypes.Emergency,
			EnumVehicleTypes.Diplomat,
			EnumVehicleTypes.Foreign,
			EnumVehicleTypes.Military
		};

		private bool IsTollFreeVehicle(Enum type)
		{
			if (type == null) return false;

			return TollFreeVehicleTypes.Contains(type);
		}

		public Vehicle CreateVehicle(Enum type)
		{
			if (Equals(type, null))
			{
				throw new ArgumentNullException("VehicleType");
			}

			return new Vehicle{ IsTollFree = IsTollFreeVehicle(type)};
		}
	}
}
