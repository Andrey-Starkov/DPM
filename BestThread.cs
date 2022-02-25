using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Task_2_1_1
{
    class BestThread
    {
        private bool Result;
        private Thread thread;
        void IsPrime(int[] nums)
        {
            foreach (var num in nums)
            {

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        Result = true;
                        return;
                    }
                }
            }

            Result = false;
        }
        public void StartThread(int[] nums)
        {
            thread = new Thread(x => IsPrime(nums));
            thread.Start();
        }

        public bool GetThread()
        {
            while (thread.IsAlive)
            {
            }
            return Result;
        }
    }
}
