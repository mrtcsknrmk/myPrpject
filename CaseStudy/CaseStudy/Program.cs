using System;
using System.Linq;

namespace QuestionOne
{
    public class Program
    {
        public static void Main()
        {
            string characterSet = "ACDEFGHKLMNPRTXYZ234579";
            string testCode = "";

            GenerateCampaignCode(characterSet);

            TestCodeInRule(testCode);

            CheckCampaingCode(characterSet, testCode);

        }

        private static void CheckCampaingCode(string characterSet, string testCode)
        {
            bool isValid = true;
            if (testCode.Length != 8)
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < testCode.Length; i++)
                {
                    char currentChar = testCode[i];
                    if (i == 0 && !characterSet.Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }

                    if (i > 0 && i < 5 && !characterSet.Substring(0, 17).Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }

                    if (i > 4 && !characterSet.Substring(characterSet.Length - 6).Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("Geçerli bir kampanya kodu girdiniz.");
            }
            else
            {
                Console.WriteLine("Geçersiz bir kampanya kodu girdiniz.");
            }

            Console.ReadKey();
        }

        private static void TestCodeInRule(string testCode)
        {
            Console.Write("Kodunuzu test edin: ");
            testCode = Console.ReadLine();
        }

        private static void GenerateCampaignCode(string characterSet)
        {
            string code = "";
            Random random = new Random();

            // İlk karakter rastgele seçilir
            code += characterSet[random.Next(0, characterSet.Length)];

            // İkinci, üçüncü, dördüncü ve beşinci karakterler karakterSet'in ilk 17 karakteri arasından seçilir
            for (int i = 0; i < 4; i++)
            {
                code += characterSet[random.Next(0, 17)];
            }

            // Son üç karakter ise karakterSet'in son 6 karakteri arasından seçilir
            for (int i = 0; i < 3; i++)
            {
                code += characterSet.Substring(characterSet.Length - 6)[random.Next(0, 6)];
            }

            Console.WriteLine($"Üretilen Kod: {code}");
        }
    }
}
