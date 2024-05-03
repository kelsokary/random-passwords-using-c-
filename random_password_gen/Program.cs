using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace random_password_gen
{
    class Program
    {
        static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        static void Main(string[] args)
        {
            int passwodAmount = 0;
            int passwordLength = 0;

            string capital_letters = "QWERTYUIOPLKJHGFDSAZXCVBNM";
            string small_letters = "qwertyuiopasdfghjklzxcvbnm";
            string digits = "0123456789";
            string special_chars = "!@#$%^&*()-_=+<,>.";
            string AllChars = capital_letters + small_letters + digits + special_chars;


            Console.WriteLine("how many passwords do you want to generate?");
            passwodAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the length of the password");
            passwordLength = int.Parse(Console.ReadLine());

            string[] all_passwords = new string[passwodAmount];
            List<string> all = new List<string>();
            for (int J=0; J<passwodAmount; J++)
            {
                StringBuilder sb = new StringBuilder();

                for (int i=0; i<passwordLength; i++)
                {
                    sb = sb.Append(GenerateChar(AllChars));
                }
                all.Add(sb.ToString());
                all_passwords = all.ToArray();
            }

            


            Console.WriteLine("this is the passwords you need:");
            foreach (string singlePassword in all_passwords)
            {
                Console.WriteLine(singlePassword);
            }
            Console.ReadKey();
        }

        //method to generate the characters
        private static char GenerateChar(string availableChars)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                provider.GetBytes(byteArray);
                c = (char)byteArray[0];

            } while (!availableChars.Any(x => x == c));

            return c;
        }
    }
}
