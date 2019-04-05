
namespace Jalasoft.Kitti.Mravi

{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static bool VerifyNode(List<int> aEndPipe)
        {
            foreach (var item in aEndPipe)
            {
                if (item != 1)
                    return false;
            }
            return true;
        }
        static double GetPercent(List<int> tSuperPipe, List<double> arrayAmount, List<int> cFlow, int aux)
        {
            double div = 0;
            if (tSuperPipe[aux] == 1)
                div = (Math.Sqrt(arrayAmount[aux + 1]) / (Convert.ToDouble(cFlow[aux])));
            else
                div = (arrayAmount[aux + 1] / (Convert.ToDouble(cFlow[aux])));
            return div;
        }

        static void Main(string[] args)
        {
            string pipe, endLine;
            double max = 0;
            double div = 0;
            double sum = 0;
            double porcentage = 0;
            int n = Int32.Parse(Console.ReadLine());
            int i = 0;
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

            if (VerifyNode(aEndPipe))
            {
                int count = cFlow.Count;
                for (i = 0; i < count; i++)
                {
                    div = GetPercent(tSuperPipe, arrayAmount, cFlow, i);
                    if (div > max)
                        max = div;
                }
                foreach (var item in cFlow)
                {
                    sum += item * max;
                }
            }

            else
            { 
            bool sw = false;
            int index = aEndPipe[n - 2];
            i = n - 2;
            while (i > -1)
            {

                for (int aux = 0; aux < i + 1; aux++)
                {
                    if (index == aEndPipe[aux])
                    {
                        div = GetPercent(tSuperPipe, arrayAmount, cFlow, aux);
                        //if (tSuperPipe[aux] == 1)
                        //    div = (Math.Sqrt(arrayAmount[aux + 1]) / (Convert.ToDouble(cFlow[aux])));
                        //else
                        //    div = (arrayAmount[aux + 1] / (Convert.ToDouble(cFlow[aux])));
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
                    max = 0;
                    sw = true;
                }
                if (porcentage < max)
                    porcentage = max;
                index = aEndPipe[i];
                i--;
            }
            i++;
            while (i < n - 1 && aEndPipe[i] == 1)
            {
                if (sw == true)
                {
                    if (tSuperPipe[i] == 1)
                        sum += Math.Sqrt(cFlow[i] * porcentage);
                    else
                        sum += cFlow[i] * porcentage;
                }
                else
                    sum += max * (Convert.ToDouble(cFlow[i]));
                i++;
            }
            }
            Console.Write(sum);
        }
    }
}
