﻿using System;

namespace FoxesAndRabbits.App
{
    class Fox : Animal
    {
        private int FoodUnitsNeeded = 10;
        private int FoodUnitsConsumedThisPeriod = 0;
        private const int DefaultLifespan = 7;
        private const double DefaultProbabilityDeathOtherCauses = 0.1;

        public Fox(int Variability)
            : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
        {
            FoodUnitsNeeded = (int)(10 * base.CalculateRandomValue(100, Variability) / 100);
        }

        public void AdvanceGeneration(bool ShowDetail)
        {
            if (FoodUnitsConsumedThisPeriod == 0)
            {
                IsAlive = false;
                if (ShowDetail)
                {
                    Console.WriteLine("  Fox dies as has eaten no food this period.");
                }
            }
            else
            {
                if (CheckIfKilledByOtherFactor())
                {
                    IsAlive = false;
                    if (ShowDetail)
                    {
                        Console.WriteLine("  Fox killed by other factor.");
                    }
                }
                else
                {
                    if (FoodUnitsConsumedThisPeriod < FoodUnitsNeeded)
                    {
                        CalculateNewAge();
                        if (ShowDetail)
                        {
                            Console.WriteLine("  Fox ages further due to lack of food.");
                        }
                    }
                    CalculateNewAge();
                    if (!IsAlive)
                    {
                        if (ShowDetail)
                        {
                            Console.WriteLine("  Fox has died of old age.");
                        }
                    }
                }
            }
        }

        public void ResetFoodConsumed()
        {
            FoodUnitsConsumedThisPeriod = 0;
        }

        public bool ReproduceThisPeriod()
        {
            const double ReproductionProbability = 0.25;
            if (Rnd.Next(0, 100) < ReproductionProbability * 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GiveFood(int FoodUnits)
        {
            FoodUnitsConsumedThisPeriod = FoodUnitsConsumedThisPeriod + FoodUnits;
        }

        public override void Inspect()
        {
            base.Inspect();
            Console.Write("Food needed " + FoodUnitsNeeded + " ");
            Console.Write("Food eaten " + FoodUnitsConsumedThisPeriod + " ");
            Console.WriteLine();
        }
    }
}
