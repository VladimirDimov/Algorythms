using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main()
        {
            var timer = new Stopwatch();
            Console.WriteLine("Enter the number of elements");
            int testLength = int.Parse(Console.ReadLine());
            int[] arr = new int[testLength];

            for (int i = 0; i < testLength; i++)
            {
                arr[i] = testLength - i;
            }

            timer.Start();
            MergeSort(arr, 0, arr.Length - 1);
            timer.Stop();

            Console.WriteLine(timer.ElapsedMilliseconds);
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            var mid = (left + right) / 2;
            while (left < right)
            {
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
                break;
            }            
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            Queue<int> leftStack = GetSubStack(arr, left, mid);
            Queue<int> rightStack = GetSubStack(arr, mid + 1, right);

            for (int i = left; i <= right; i++)
            {
                var a = leftStack.Count > 0 ? leftStack.Peek() : int.MaxValue;
                var b = rightStack.Count > 0 ? rightStack.Peek() : int.MaxValue;
                if (a < b)
                {
                    arr[i] = leftStack.Dequeue();
                }
                else
                {
                    arr[i] = rightStack.Dequeue();
                }
            }
        }

        private static Queue<int> GetSubStack(int[] arr, int left, int right)
        {
            var result = new Queue<int>();

            for (int i = left; i <= right; i++)
            {
                result.Enqueue(arr[i]);
            }

            return result;
        }
    }
}
