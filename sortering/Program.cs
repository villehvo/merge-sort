﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace sortering
{    
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stop = Stopwatch.StartNew();
            
            stop.Start();

            List<int> unsorted = new List<int>();
            List<int> sorted;

            Random random = new Random();

            Console.WriteLine("Original array elements:" );
            for(int i = 0; i< 1000;i++){
                unsorted.Add(random.Next(0,1000));
                Console.Write(unsorted[i]+" ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            stop.Stop();

            

            Console.WriteLine("Sorted array elements: ");
            foreach (int x in sorted)
            {
                Console.Write(x+" ");
            }
			Console.Write("\n");
            Console.WriteLine("Time = " + stop.ElapsedMilliseconds);
        }
		

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++) 
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First()) 
                    {
                        result.Add(left.First());
                        left.Remove(left.First());    
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count>0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());    
                }    
            }
            return result;
        }
    }
}