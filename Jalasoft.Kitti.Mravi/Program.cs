
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
            double sum = 0;
            int i = 0;
            int n = Int32.Parse(Console.ReadLine());

            List<int> aEndPipe = new List<int>();
            List<int> bEndPipe = new List<int>();
            List<int> cFlow = new List<int>();
            List<int> tSuperPipe = new List<int>();
            List<double> arrayAmount = new List<double>();
            for (i = 1; i < n; i++)
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
            bool sw = false;
            int index = aEndPipe[n - 2];
            i = n - 2;
            while (i > -1)
            //for (i = n - 2; i > -1; i--)
            {
                
                for (int aux = 0; aux < i + 1; aux++)
                {
                    if (index == aEndPipe[aux])
                    {
                        if (tSuperPipe[aux] == 1)
                            div = (Math.Sqrt(arrayAmount[aux + 1]) / (Convert.ToDouble(cFlow[aux])));
                        else
                            div = (arrayAmount[aux + 1] / (Convert.ToDouble(cFlow[aux])));
                        if (div > max)
                            max = div;
                    }
                }               

                if (index != aEndPipe[i])
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (bEndPipe[j] == aEndPipe[index])
                            arrayAmount[j + 1] = max * 100;
                    }
                  //  index = aEndPipe[i];
                    max = 0;
                    sw = true;
                }
                index = aEndPipe[ i];
 i--;



                //if (index != aEndPipe[i])
                //{
                //    for (int j = 0; j < i + 1; j++)
                //    {
                //        if (bEndPipe[j] == aEndPipe[index])
                //            arrayAmount[j + 1] = max * 100;
                //    }
                //    index = aEndPipe[i];
                //    max = 0;
                //    sw = true;
                //}



                //if (tSuperPipe[i] == 1)
                //    div = (Math.Sqrt(arrayAmount[i + 1]) / (Convert.ToDouble(cFlow[i])));
                //else
                //    div = (arrayAmount[i + 1] / (Convert.ToDouble(cFlow[i])));
                //if (div > max)
                //    max = div;
            }
            i++;
            while (i < n - 1 && aEndPipe[i] == 1)
            {
                if (sw == true)
                {
                    if (tSuperPipe[i] == 1)
                        sum += Math.Sqrt(arrayAmount[i + 1]);
                    else
                        sum += arrayAmount[i + 1];
                }
                else
                    sum += max * (Convert.ToDouble(cFlow[i]));
                i++;
            }
            Console.Write(sum);
        }
    }
}
