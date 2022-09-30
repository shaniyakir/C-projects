﻿using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowTime : IRunnable
    {
        public void Run()
        {
            Console.WriteLine(DateTime.Now.ToString().Split(' ')[1] + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }
    }
}
