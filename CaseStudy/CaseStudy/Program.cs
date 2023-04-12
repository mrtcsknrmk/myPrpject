using System;
using System.Collections;

namespace CaseStudy;
public class Program
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        const String POOL = "ACDEFGHKLMNPRTXYZ234579";

        String generateCode = GetGenerateUniqueCode(POOL);

        bool checkCode = CheckUniqueCode(generateCode, POOL);

        if (checkCode)
        {
            System.Console.WriteLine(generateCode);
        }
        else
        {
            System.Console.WriteLine("hssss");
        }

    }

    private static string GetGenerateUniqueCode(string pool)
    {
        //Get first index
        String firstIndex = new(Enumerable.Repeat(pool, 1)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        //Get last index
        String lastIndex = firstIndex;

        //Generate random code
        String codeIndex = new(Enumerable.Repeat(pool, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return firstIndex + codeIndex + lastIndex;
    }

    private static bool CheckUniqueCode(string generateCode, string pool)
    {
        int codeLen = generateCode.Length;
        List<string> arrCode = new List<string>();

        //String[] arrCode = Array.Empty<string>();
        int cnt = 0;
        String codeCheck = "";

        if (codeLen != 8)
        {
            System.Console.WriteLine("Kod 8 karakterli olmalıdır!");
            return false;
        }

        //String[] arr = Array.Empty<string>();
        List<string> arr = new List<string>();

        for (int i = 0; i < pool.Length; i++)
        {
            //List<string> list = new List<string>();
            //list.Add("Hi");
            //String[] str = list.ToArray();
            arr.Add(pool[i].ToString());
        }

        for (int j = 0; j < codeLen; j++)
        {
            arrCode.Add(generateCode[j].ToString());
        }

        Decimal ind = pool.IndexOf(arrCode[cnt]);
        while (cnt < 8)
        {
            codeCheck += arr[(int)ind];
            if (ind < 12)
            {
                ind += cnt;
            }
            else
            {
                ind -= cnt;
            }

            if (ind >= 12 && ind < 24)
            {
                ind = ind;
            }
            else if (ind < 12)
            {
                ind *= 2;
            }
            else if (ind > 24)
            {
                ind = Math.Floor(ind / 2);
            }

            cnt++;
        }

        if (generateCode == codeCheck)
        {
            System.Console.WriteLine("Kod doğrulandı");
            return true;
        }
        else
        {
            System.Console.WriteLine("KOD DOĞRULANAMADI!!!");
            return false;
        }
    }
}

