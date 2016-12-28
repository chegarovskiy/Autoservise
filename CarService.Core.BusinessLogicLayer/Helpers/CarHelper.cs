using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Helper to check if a car which is to be added to the DB is valid
    /// </summary>
    public static class CarHelper
    {
        public static bool IsValidCar(this Car car)
        {
            // check if entered name is valid
            if (!car.Vin.IsValidVinNumber())
            {
                return false;
            }

            // check if it is a valid year of production
            if (!car.ReleaseYear.IsValidReleaseYear())
            {
                return false;
            }

            // check if it is a valid year of production
            if (!car.NumberCar.IsValidCarNumber())
            {
                return false;
            }

            return true;
        }
    }
}