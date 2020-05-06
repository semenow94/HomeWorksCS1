using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. По аналогии с датой сделать класс времени
//Семенов Дмитрий

namespace HomeWork3
{
    partial class Tasks
    {
        class Time
        {
            int hours, minutes, seconds;

            public Time()
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            }

            public Time(int hours, int minutes, int seconds)
            {

                this.Hours = hours;
                this.Minutes = minutes;
                this.Seconds = seconds;
            }

            public int Hours
            {
                get
                {
                    return hours;
                }
                set
                {
                    if (value < 0 || value > 23) throw new ArgumentException("Не правильное время");
                    hours = value;
                }
            }
            public int Minutes
            {
                get
                {
                    return minutes;
                }
                set
                {
                    if (value < 0 || value > 59) throw new ArgumentException("Не правильное время");
                    minutes = value;
                }
            }

            public int Seconds
            {
                get
                {
                    return seconds;
                }

                set
                {
                    if (value < 0 || value > 59) throw new ArgumentException("Не правильное время");
                    minutes = value;
                }
            }
            public void PrintTime()
            {
                Console.WriteLine($"Время - {hours} : {minutes} : {seconds}");
            }

        }
        public static void Task1()
        {
            Time time = new Time();
            Time time2 = new Time(23, 59, 59);
            //Time time3 = new Time(24, 59, 59); //Выкинет ошибку
            time.PrintTime();
            time2.PrintTime();
        }
    }
}
