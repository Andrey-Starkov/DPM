using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2_1_1
{
    static class Program
    {

        static bool Paralleli(int[] nums)
        {
            var primeNumbers = new ConcurrentBag<int>();
            ParallelLoopResult result = 
            Parallel.ForEach(nums, (num,pls) =>
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        pls.Break();
                    }
                }

            });

            return !result.IsCompleted;
        }

        static bool Single(int[] nums)
        {
            foreach (var num in nums)
            {

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        static bool MultiThread(int n,int[] nums)
        {
            int step = nums.Length/n;
            int ost = nums.Length % n;
            int start = 0;
            BestThread[] best = new BestThread[n];
            for (int i = 0; i < n; i++)
            {
                if (i < ost)
                {
                    best[i] = new BestThread();
                    best[i].StartThread(SubArray(nums, start, step+1));
                    start += step + 1;
                }
                else
                {
                    best[i] = new BestThread();
                    best[i].StartThread(SubArray(nums, start, step));
                    start += step;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (best[i].GetThread())
                {
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            int[] test1 = new int[11] { 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,4 };
            int[] test2 = new int[]
            {
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437,
                27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437, 27644437
            };
            var sw = new Stopwatch();
            sw.Start();
            //Console.WriteLine("Однопоточный: "+Single(test2));
            //Console.WriteLine("Сделано за "+sw.ElapsedMilliseconds+ " миллисекунд");
            //sw.Stop();
            
            //sw.Restart();
            Console.WriteLine("Многопоточный: "+MultiThread(40,test2));

            Console.WriteLine("Сделано за " + sw.ElapsedMilliseconds + " миллисекунд");
            sw.Stop();

            //sw.Restart();

            //Console.WriteLine("С помощью Parallel: "+Paralleli(test2));
            //Console.WriteLine("Сделано за " + sw.ElapsedMilliseconds + " миллисекунд");
            //Thread.Sleep(1000);
        }
    }
}
