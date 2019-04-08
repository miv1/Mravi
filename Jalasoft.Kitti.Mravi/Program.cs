using System;
using System.Collections.Generic;

namespace Jalasoft.Kitti.Mravi
{
        class Program
        {
            static void Main(string[] args)
            {
                string pipe, endLine;
                double max = 0;
                double div = 0;
                double sum = 0;

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
                        div = Math.Sqrt(arrayAmount[i + 1]) / cFlow[i];
                    else
                    {
                    double aa = arrayAmount[i + 1];
                    double bb = cFlow[i];
                        div = arrayAmount[i + 1] / cFlow[i];
                    }
                   
                    if (div > max)
                        max = div;
                }

                for (int i = 0; i < tSuperPipe.Count; i++)
                {
                    if (max * cFlow[i] > 0)
                        sum = max * cFlow[i];
                }


                //aEndPipe.Add(Int32.Parse(amountLiquid[1]));
                //bEndPipe.Add(Int32.Parse(amountLiquid[2]));
                //cFlow.Add(Int32.Parse(amountLiquid[2]));
                //tSuperPipe.Add(Int32.Parse(amountLiquid[3]));


            }
        }
}
