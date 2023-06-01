using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demoblaze.Auto.Template.Common
{
    class Helpers
    {
        public const string CORRESPONDENCIA = "TRWAGMYFPDXBNJZSQVHLCKE";
        public const string Test = "TEST";

        public static char GetRandomLetter()
        {
            string seats = "ABCDEF";
            Random random = new Random();
            int num = random.Next(0, seats.Length - 1);
            return seats[num];
        }

        public static int GetRandomDay()
        {
            Random random = new Random();
            int randomDay = random.Next(1, 31);
            return randomDay;
        }

        public static string GetRandomString(int length)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            var chars = Enumerable.Range(0, length)
                .Select(x => letters[random.Next(0, letters.Length)]);
            return new string(chars.ToArray());
        }

        public static char GetNifLetter(string dni)
        {
            int n;

            if ((dni == null) || (!int.TryParse(dni.Substring(0, 8), out n)))
                {
                throw new ArgumentException("Dni should be 8 digits");
                }

            return CORRESPONDENCIA[n % 23];
        }

        public static string GetRandomDniDigits()
        {
            const string digits = "0123456789";
            Random random = new Random();
            var chars = Enumerable.Range(0, 8)
                .Select(x => digits[random.Next(0, digits.Length)]);
            return new string(chars.ToArray());
        }

        public static string GetRandomDni()
        {
            string dniDigits = GetRandomDniDigits();
            char dniLetter = GetNifLetter(dniDigits);
            string dni = dniDigits + dniLetter.ToString();
            return dni;
        }

        public static int GetRandomNumberBetween(int start, int end)
        {
            Random random = new Random();
            int randomNumber = random.Next(start, end);
            return randomNumber;
        }

        public static string GenerateFirstName(int length)
        {
            string FirstName = "";
            FirstName = Test + GetRandomString(length);
            return FirstName;
        }

        public static string GenerateLastName(int length)
        {
            string LastName = Test + GetRandomString(length);
            return LastName;
        }

        public static int GetRandomPhoneNumber()
        {
            Random random = new Random();
            int randomPhoneNumber = random.Next(10000000, 99999999);
            return randomPhoneNumber;
        }
    }
}
