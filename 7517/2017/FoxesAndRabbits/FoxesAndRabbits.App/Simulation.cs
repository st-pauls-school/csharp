﻿using System;

namespace FoxesAndRabbits.App
{
    class Simulation
    {
        private Location[,] Landscape;
        private int TimePeriod = 0;
        private int WarrenCount = 0;
        private int FoxCount = 0;
        private bool ShowDetail = false;
        private int LandscapeSize;
        private int Variability;
        private static Random Rnd = new Random();

        public Simulation(int LandscapeSize, int InitialWarrenCount, int InitialFoxCount, int Variability, bool FixedInitialLocations)
        {
            int menuOption;
            int x;
            int y;
            string viewRabbits;
            this.LandscapeSize = LandscapeSize;
            this.Variability = Variability;
            Landscape = new Location[LandscapeSize, LandscapeSize];
            CreateLandscapeAndAnimals(InitialWarrenCount, InitialFoxCount, FixedInitialLocations);
            DrawLandscape();
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Advance to next time period showing detail");
                Console.WriteLine("2. Advance to next time period hiding detail");
                Console.WriteLine("3. Inspect fox");
                Console.WriteLine("4. Inspect warren");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Select option: ");
                menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 1)
                {
                    TimePeriod++;
                    ShowDetail = true;
                    AdvanceTimePeriod();
                }
                if (menuOption == 2)
                {
                    TimePeriod++;
                    ShowDetail = false;
                    AdvanceTimePeriod();
                }
                if (menuOption == 3)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    if (Landscape[x, y].Fox != null)
                    {
                        Landscape[x, y].Fox.Inspect();
                    }
                }
                if (menuOption == 4)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    if (Landscape[x, y].Warren != null)
                    {
                        Landscape[x, y].Warren.Inspect();
                        Console.Write("View individual rabbits (y/n)?");
                        viewRabbits = Console.ReadLine();
                        if (viewRabbits == "y")
                        {
                            Landscape[x, y].Warren.ListRabbits();
                        }
                    }
                }
            } while (((WarrenCount > 0) || (FoxCount > 0)) && (menuOption != 5));
            Console.ReadKey();
        }


        // todo: no validation on the 
        private int InputCoordinate(char Coordinatename)
        {
            int Coordinate;
            Console.Write("  Input " + Coordinatename + " coordinate: ");
            Coordinate = Convert.ToInt32(Console.ReadLine());
            return Coordinate;
        }

        private void AdvanceTimePeriod()
        {
            int NewFoxCount = 0;
            if (ShowDetail)
            {
                Console.WriteLine();
            }
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    if (Landscape[x, y].Warren != null)
                    {
                        if (ShowDetail)
                        {
                            Console.WriteLine("Warren at (" + x + "," + y + "):");
                            Console.Write("  Period Start: ");
                            Landscape[x, y].Warren.Inspect();
                        }
                        if (FoxCount > 0)
                        {
                            FoxesEatRabbitsInWarren(x, y);
                        }
                        if (Landscape[x, y].Warren.NeedToCreateNewWarren())
                        {
                            CreateNewWarren();
                        }
                        Landscape[x, y].Warren.AdvanceGeneration(ShowDetail);
                        if (ShowDetail)
                        {
                            Console.Write("  Period End: ");
                            Landscape[x, y].Warren.Inspect();
                            Console.ReadKey();
                        }
                        if (Landscape[x, y].Warren.WarrenHasDiedOut())
                        {
                            Landscape[x, y].Warren = null;
                            WarrenCount--;
                        }
                    }
                }
            }
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    if (Landscape[x, y].Fox != null)
                    {
                        if (ShowDetail)
                        {
                            Console.WriteLine("Fox at (" + x + "," + y + "): ");
                        }
                        Landscape[x, y].Fox.AdvanceGeneration(ShowDetail);
                        if (Landscape[x, y].Fox.CheckIfDead())
                        {
                            Landscape[x, y].Fox = null;
                            FoxCount--;
                        }
                        else
                        {
                            if (Landscape[x, y].Fox.ReproduceThisPeriod())
                            {
                                if (ShowDetail)
                                {
                                    Console.WriteLine("  Fox has reproduced. ");
                                }
                                NewFoxCount++;
                            }
                            if (ShowDetail)
                            {
                                Landscape[x, y].Fox.Inspect();
                            }
                            Landscape[x, y].Fox.ResetFoodConsumed();
                        }
                    }
                }
            }
            if (NewFoxCount > 0)
            {
                if (ShowDetail)
                {
                    Console.WriteLine("New foxes born: ");
                }
                for (int f = 0; f < NewFoxCount; f++)
                {
                    CreateNewFox();
                }
            }
            if (ShowDetail)
            {
                Console.ReadKey();
            }
            DrawLandscape();
            Console.WriteLine();
        }

        private void CreateLandscapeAndAnimals(int InitialWarrenCount, int InitialFoxCount, bool FixedInitialLocations)
        {
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    Landscape[x, y] = new Location();
                }
            }
            if (FixedInitialLocations)
            {
                Landscape[1, 1].Warren = new Warren(Variability, 38);
                Landscape[2, 8].Warren = new Warren(Variability, 80);
                Landscape[9, 7].Warren = new Warren(Variability, 20);
                Landscape[10, 3].Warren = new Warren(Variability, 52);
                Landscape[13, 4].Warren = new Warren(Variability, 67);
                WarrenCount = 5;
                Landscape[2, 10].Fox = new Fox(Variability);
                Landscape[6, 1].Fox = new Fox(Variability);
                Landscape[8, 6].Fox = new Fox(Variability);
                Landscape[11, 13].Fox = new Fox(Variability);
                Landscape[12, 4].Fox = new Fox(Variability);
                FoxCount = 5;
            }
            else
            {
                for (int w = 0; w < InitialWarrenCount; w++)
                {
                    CreateNewWarren();
                }
                for (int f = 0; f < InitialFoxCount; f++)
                {
                    CreateNewFox();
                }
            }
        }

        private void CreateNewWarren()
        {
            int x, y;
            do
            {
                x = Rnd.Next(0, LandscapeSize);
                y = Rnd.Next(0, LandscapeSize);
            } while (Landscape[x, y].Warren != null);
            if (ShowDetail)
            {
                Console.WriteLine("New Warren at (" + x + "," + y + ")");
            }
            Landscape[x, y].Warren = new Warren(Variability);
            WarrenCount++;
        }

        private void CreateNewFox()
        {
            int x, y;
            do
            {
                x = Rnd.Next(0, LandscapeSize);
                y = Rnd.Next(0, LandscapeSize);
            } while (Landscape[x, y].Fox != null);
            if (ShowDetail)
            {
                Console.WriteLine("  New Fox at (" + x + "," + y + ")");
            }
            Landscape[x, y].Fox = new Fox(Variability);
            FoxCount++;
        }

        private void FoxesEatRabbitsInWarren(int WarrenX, int WarrenY)
        {
            int FoodConsumed;
            int PercentToEat;
            double Dist;
            int RabbitsToEat;
            int RabbitCountAtStartOfPeriod = Landscape[WarrenX, WarrenY].Warren.GetRabbitCount();
            for (int FoxX = 0; FoxX < LandscapeSize; FoxX++)
            {
                for (int FoxY = 0; FoxY < LandscapeSize; FoxY++)
                {
                    if (Landscape[FoxX, FoxY].Fox != null)
                    {
                        Dist = DistanceBetween(FoxX, FoxY, WarrenX, WarrenY);
                        if (Dist <= 3.5)
                        {
                            PercentToEat = 20;
                        }
                        else if (Dist <= 7)
                        {
                            PercentToEat = 10;
                        }
                        else
                        {
                            PercentToEat = 0;
                        }
                        RabbitsToEat = (int)Math.Round((double)(PercentToEat * RabbitCountAtStartOfPeriod / 100.0));
                        FoodConsumed = Landscape[WarrenX, WarrenY].Warren.EatRabbits(RabbitsToEat);
                        Landscape[FoxX, FoxY].Fox.GiveFood(FoodConsumed);
                        if (ShowDetail)
                        {
                            Console.WriteLine("  " + FoodConsumed + " rabbits eaten by fox at (" + FoxX + "," + FoxY + ").");
                        }
                    }
                }
            }
        }

        private double DistanceBetween(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        private void DrawLandscape()
        {
            Console.WriteLine();
            Console.WriteLine("TIME PERIOD: " + TimePeriod);
            Console.WriteLine();
            Console.Write("    ");
            for (int x = 0; x < LandscapeSize; x++)
            {
                if (x < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(x + " |");
            }
            Console.WriteLine();
            for (int x = 0; x <= LandscapeSize * 4 + 3; x++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int y = 0; y < LandscapeSize; y++)
            {
                if (y < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(" " + y + "|");
                for (int x = 0; x < LandscapeSize; x++)
                {
                    if (Landscape[x, y].Warren != null)
                    {
                        if (Landscape[x, y].Warren.GetRabbitCount() < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(Landscape[x, y].Warren.GetRabbitCount());
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (Landscape[x, y].Fox != null)
                    {
                        Console.Write("F");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}
