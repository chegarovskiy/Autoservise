using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// Helper to validate input fields
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static class ClientHelper
    {
        public static bool IsValidClient(this Client client)
        {
            // check if entered name is valid
            if (!client.FullName.IsValidFullName())
            {
                return false;
            }

            // check if entered phone number is correct
            if (!client.Phone.IsValidPhoneNumber())
            {
                return false;
            }

            // check entered passport
            if (!client.PassportData.IsValidClientPassport())
            {
                return false;
            }

            // check entered passport
            if (!client.Address.IsValidClientAddress())
            {
                return false;
            }
            return true;
        }
    }
}