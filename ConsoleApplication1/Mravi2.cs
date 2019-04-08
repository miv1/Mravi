using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Mravi2
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            string pipe;
            List<double[]> pipeArray = new List<double[]>();
            double aux = 0;
            double perc = 0;
            double max = 0;
            double req = 0;
            int curr = 0;
            int sup = 0;
            for (int i = 1; i < n; i++)
            {
                pipe = Console.ReadLine();
                //   arrayInput = new double[4];
                double[] arrayInput = pipe.Split(' ').Select(Double.Parse).ToArray();
                arrayInput[2] = arrayInput[2] / 100;
                aux = arrayInput[1];
                arrayInput[1] = arrayInput[0];
                arrayInput[0] = aux;
                pipeArray.Add(arrayInput);
            }
            string litr = Console.ReadLine();
            int[] arrayLit = litr.Split(' ').Select(int.Parse).ToArray();

            for (int i = 1; i <= arrayLit.Count()-1; i++)
            {
                if (arrayLit[i] != -1)
                {
                    curr = i + 1;
                    while (curr != 1)
                    {
                        foreach (var item in pipeArray)
                        {
                            if (item[0] == curr)
                                curr = Convert.ToInt32(item[1]);
                        }
                        perc = pipeArray[curr][2];
                        //sup = Convert.ToInt32(pipeArray[curr+1][3]);
                        sup = Convert.ToInt32(pipeArray[i-1][3]);

                        if (sup == 1)
                            req = Convert.ToInt32(Math.Sqrt(arrayLit[i ]));
                        else
                            req = arrayLit[i];
                        req = req / perc;
                    }
                    if (max < req)
                        max = req;
                }
            }
        }


    }
}

