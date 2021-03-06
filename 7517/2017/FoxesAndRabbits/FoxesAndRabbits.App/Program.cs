﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxesAndRabbits.App
{
    // Skeleton Program code for the AQA A Level Paper 1 2017 examination
    // this code whould be used in conjunction with the Preliminary Material
    // written by the AQA Programmer Team
    // developed in the Visual Studio 2008 programming environment

    class Program
    {
        static void Main(string[] args)
        {
            Simulation Sim;
            int MenuOption;
            int LandscapeSize;
            int InitialWarrenCount;
            int InitialFoxCount;
            int Variability;
            bool FixedInitialLocations;
            do
            {
                Console.WriteLine("Predator Prey Simulation Main Menu");
                Console.WriteLine();
                Console.WriteLine("1. Run simulation with default settings");
                Console.WriteLine("2. Run simulation with custom settings");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Select option: ");
                MenuOption = Convert.ToInt32(Console.ReadLine());
                if ((MenuOption == 1) || (MenuOption == 2))
                {
                    if (MenuOption == 1)
                    {
                        LandscapeSize = 15;
                        InitialWarrenCount = 5;
                        InitialFoxCount = 5;
                        Variability = 0;
                        FixedInitialLocations = true;
                    }
                    else
                    {
                        Console.Write("Landscape Size: ");
                        LandscapeSize = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Initial number of warrens: ");
                        InitialWarrenCount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Initial number of foxes: ");
                        InitialFoxCount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Randomness variability (percent): ");
                        Variability = Convert.ToInt32(Console.ReadLine());
                        FixedInitialLocations = false;
                    }
                    Sim = new Simulation(LandscapeSize, InitialWarrenCount, InitialFoxCount, Variability, FixedInitialLocations);
                }
            } while (MenuOption != 3);
            Console.ReadKey();
        }
    }
}
