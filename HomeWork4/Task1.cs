using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
//Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
//В данной задаче под парой подразумевается два подряд идущих элемента массива.
//Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
//Семенов Дмитрий
namespace HomeWork4
{
    partial class Tasks
    {
        public static void Task1()
        {
            Random rand = new Random();
            int couples = 0;
            int[] arr = new int[20];
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = rand.Next(-10000, 10001);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i]%3==0 || arr[i-1]%3==0)
                {
                    couples++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"В данном массиве {couples} пар, в которых хотя бы одно число делится на 3");
        }
    }
}
