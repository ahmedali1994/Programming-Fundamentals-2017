﻿using System;
using System.Linq;
using System.Text;

public class EnduranceRally
{
    public static void Main()
    {
        string[] driversNames = Console.ReadLine().Split();
        double[] zones = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToList();

        StringBuilder result = new StringBuilder();

        foreach (string driver in driversNames)
        {
            char firstLetter = char.Parse(driver.Substring(0, 1));
            double driverFuel = firstLetter;
            bool hasFuel = true;
            for (int i = 0; i < zones.Length; i++)
            {
                if (checkpoints.Contains(i))
                {
                    driverFuel += zones[i];
                }
                else
                {
                    driverFuel -= zones[i];
                }

                if (driverFuel <= 0)
                {
                    result.Append($"{driver} - reached {i}{Environment.NewLine}");
                    hasFuel = false;
                    break;
                }
            }

            if (hasFuel)
            {
                result.Append($"{driver} - fuel left {driverFuel:f2}{Environment.NewLine}");
            }
        }

        Console.Write(result);
    }
}