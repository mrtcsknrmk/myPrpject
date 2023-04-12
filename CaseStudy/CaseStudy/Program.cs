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

            // Kodun uzunluğu 8 mi diye kontrol edilir
            if (testCode.Length != 8)
            {
                isValid = false;
            }
            else
            {
                // Kodun her bir karakteri kontrol edilir
                for (int i = 0; i < testCode.Length; i++)
                {
                    char currentChar = testCode[i];

                    // İlk karakter karakterSet içinde yer alıyor mu diye kontrol edilir
                    if (i == 0 && !characterSet.Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }

                    // İkinci, üçüncü, dördüncü ve beşinci karakterler karakterSet'in ilk 17 karakteri arasındamı diye kontrol edilir
                    if (i > 0 && i < 5 && !characterSet.Substring(0, 17).Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }

                    // Son üç karakter karakterSet'in son 6 karakteri arasındamı diye kontrol edilir
                    if (i > 4 && !characterSet.Substring(characterSet.Length - 6).Contains(currentChar))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("Geçerli bir kod girdiniz.");
            }
            else
            {
                Console.WriteLine("Geçersiz bir kod girdiniz.");
            }

            Console.ReadKey();
        }

        private static void TestCodeInRule(string testCode)
        {
            // Test Kontrolü
            Console.Write("Kodunuzu test edin: ");
            testCode = Console.ReadLine();
        }

        private static void GenerateCampaignCode(string characterSet)
        {
            // Kod Üretimi
            string code = "";
            Random random = new Random();

            // İlk karakter karakterSet içinden rastgele seçilir
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
