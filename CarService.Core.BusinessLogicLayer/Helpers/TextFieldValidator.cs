using System;
using System.Text.RegularExpressions;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Helper to validate entered in a field data
    /// </summary>
    public static class TextFieldValidator
    {
        // checks if entered name is valid
        public static bool IsValidFullName(this string fullName)
        {
            Regex r = new Regex("^[\\p{L} .'-]+$");
            if (!string.IsNullOrEmpty(fullName) && r.IsMatch(fullName))
            {
                return true;
            }
            return false;
        }

        // checks if entered phone number is valid
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            Regex r = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            if (string.IsNullOrEmpty(phoneNumber) || r.IsMatch(phoneNumber))
            {
                return true;
            }
            return false;
        }

        // checks if user entered a valid data
        //ToDO come back here when discuss validation
        public static bool IsValidClientPassport(this string data)
        {
            if (data == null || (data.Length > 0 && data.Length < 9))
            {
                return true;
            }
            return false;
        }

        //TODo come back here when discuss validation
        public static bool IsValidClientAddress(this string address)
        {
            if (address == null || (address.Length > 0 && address.Length < 90))
            {
                return true;
            }
            return false;
        }

        //TODo come back here when discuss validation
        public static bool IsValidVinNumber(this string vinNumber)
        {
            if (vinNumber != null && (vinNumber.Length > 0 && vinNumber.Length < 30))
            {
                return true;
            }
            return false;
        }

        //TODo come back here when discuss validation
        public static bool IsValidReleaseYear(this string releaseYear)
        {
            if (releaseYear != null && (releaseYear.Length > 0 && releaseYear.Length < 5))
            {
                return true;
            }
            return false;
        }

        //TODo come back here when discuss validation
        public static bool IsValidCarNumber(this string carNumber)
        {
            if (carNumber != null && (carNumber.Length > 0 && carNumber.Length < 20))
            {
                return true;
            }
            return false;
        }
    }
}