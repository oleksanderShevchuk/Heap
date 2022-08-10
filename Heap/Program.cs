using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Heap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            //heap.Add(20);
            //heap.Add(11);
            //heap.Add(17);
            //heap.Add(7);
            //heap.Add(4);
            //heap.Add(13);
            //heap.Add(15);
            //heap.Add(14);
            var rnd = new Random();
            var startItems = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                startItems.Add(rnd.Next(-1000, 1000));
            }
            timer.Start();
            var heap = new Heap(startItems);
            timer.Stop();
            Console.WriteLine("1) Add 1000 elements: " + timer.Elapsed);

            timer.Restart();
            for (int i = 0; i < 100; i++)
            {
                heap.Add(rnd.Next(-1000, 1000));
            }
            timer.Stop();
            Console.WriteLine("2) Add 1000 elements: " + timer.Elapsed);

            timer.Restart();
            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }
            timer.Stop();
            Console.WriteLine("3) Console 2000 elements: " + timer.Elapsed);
        }
    }
}
