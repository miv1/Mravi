
namespace Jalasoft.Kitti.Mravi

{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            string pipe, endLine;
            double max = 0;
            double div = 0;

            int n = Int32.Parse(Console.ReadLine());

            List<int> aEndPipe = new List<int>();
            List<int> bEndPipe = new List<int>();
            List<int> cFlow = new List<int>();
            List<int> tSuperPipe = new List<int>();
            List<int> arrayAmount = new List<int>();
            for (int i = 1; i < n; i++)
            {
                pipe = Console.ReadLine();
                string[] split = pipe.Split(new string[] { " " }, StringSplitOptions.None);
                aEndPipe.Add(Int32.Parse(split[0]));
                bEndPipe.Add(Int32.Parse(split[1]));
                cFlow.Add(Int32.Parse(split[2]));
                tSuperPipe.Add(Int32.Parse(split[3]));

            }
            endLine = Console.ReadLine();
            string[] amountLiquid = endLine.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (var item in amountLiquid)
            {
                arrayAmount.Add(Int32.Parse(item));
            }

            for (int i = 0; i < tSuperPipe.Count; i++)
            {
                if (tSuperPipe[i] == 1)
                {
                    double dd = Convert.ToDouble(cFlow[i]) / 100;
                    double ee = Math.Sqrt(arrayAmount[i + 1]);
                    div = ee / dd;
                    //div = Math.Sqrt(arrayAmount[i + 1])/Convert.ToDouble(cFlow[i])/100;
                }
                else
                {
                    double aa = arrayAmount[i + 1];
                    double bb = Convert.ToDouble(cFlow[i]) / 100;
                    div = aa / bb;
                    //div = Convert.ToDouble(arrayAmount[i + 1])/ Convert.ToDouble(cFlow[i]) / 100;
                }

                if (div > max)
                    max = div;
            }
            
        }
    }
}
