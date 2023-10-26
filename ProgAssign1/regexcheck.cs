using System;
using System.Text.RegularExpressions;

namespace ProgAssign1
{
    public class DataValidator
    {
        public static bool ValidateData(MyCsvStructure record)
        {
            // 1
            if (string.IsNullOrWhiteSpace(record.FirstName) || !Regex.IsMatch(record.FirstName, "^[A-Za-z]+$"))
            {
                return false;
            }

            //2
            if (string.IsNullOrWhiteSpace(record.LastName) || !Regex.IsMatch(record.LastName, "^[A-Za-z]+$"))
            {
                return false;
            }


            // 3
            if (string.IsNullOrWhiteSpace(record.StreetNumber) || !Regex.IsMatch(record.StreetNumber, "^[0-9]+$"))
            {
                return false;
            }




            // 4
            if (string.IsNullOrWhiteSpace(record.Street) || !Regex.IsMatch(record.Street, @"^[A-Za-z\s]+$"))
            {
                return false;
            }

         


            //5
            if (string.IsNullOrWhiteSpace(record.City) || !Regex.IsMatch(record.City, "^[A-Za-z]+$"))
            {
                return false;
            }


            //6
            if (string.IsNullOrWhiteSpace(record.Province) || !Regex.IsMatch(record.Province, "^[A-Za-z\\s]+$"))
            {
                return false;
            }

            // 7


            if (!Regex.IsMatch(record.PostalCode, @"^[A-Za-z0-9]{3} [A-Za-z0-9]{3}$"))
            {
                return false;
            }

            // 8
            if (!string.IsNullOrWhiteSpace(record.Country) && !Regex.IsMatch(record.Country, "^[A-Za-z]+$"))
            {
                return false;
            }

            // 9
            if (!string.IsNullOrWhiteSpace(record.PhoneNumber) && !Regex.IsMatch(record.PhoneNumber, @"^\d{10}$"))
            {
                return false;
            }


            // 10
            if (!string.IsNullOrWhiteSpace(record.EmailAddress) && !Regex.IsMatch(record.EmailAddress, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
            {
                return false;
            }
            return true;
        }
    }
}

