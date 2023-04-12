using System;
using System.Collections.Generic;
using System.IO;
using CaseStudy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuestionTwo
{
    public class Program
    {
        public static void Main()
        {
            string? jsonData = File.ReadAllText(@"./QuestionTwoJSonData.json");
            List<ReceiptEntity> veriler = JsonConvert.DeserializeObject<List<ReceiptEntity>>(jsonData);
            List<ReceiptEntity> siraliVeriler = veriler.Skip(1).ToList();

            List<string> result = new List<string>();
            var currentRow = new List<string>();
            var previousY = -1;

            foreach (ReceiptEntity item in siraliVeriler)
            {
                if (item.BoundingPoly == null || item.BoundingPoly.Vertices == null) continue;

                int currentX = item.BoundingPoly.Vertices[0].y;

                if (previousY == -1 || Math.Abs(currentX - previousY) < 10)
                {
                    currentRow.Add(item.Description);
                }
                else
                {
                    result.Add(string.Join(" ", currentRow));
                    currentRow = new List<string>() { item.Description };
                }

                previousY = currentX;
            }


            result.Add(string.Join(" ", currentRow));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }

}
