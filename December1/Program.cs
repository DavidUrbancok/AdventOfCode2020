﻿using System;
using System.IO;
using System.Linq;

namespace December1
{
    public static class Program
    {
        public static void Main()
        {
            const int Year = 2020;

            using var fileStream = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream);

            var numbers = streamReader.ReadToEnd()
                .Split(Environment.NewLine)
                .Select(number => Convert.ToInt32(number))
                .OrderBy(number => number)
                .ToList();

            var beginningPosition = 0;
            var endPosition = numbers.Count - 1;
            var sum = 0;

            do
            {
                sum = numbers.ElementAt(beginningPosition) + numbers.ElementAt(endPosition);

                if (sum > Year)
                {
                    --endPosition;
                }
                else if (sum < Year)
                {
                    ++beginningPosition;
                }
            }
            while (sum != 2020);

            var number1 = numbers.ElementAt(beginningPosition);
            var number2 = numbers.ElementAt(endPosition);

            Console.WriteLine($"{number1} + {number2} = {sum}");
            Console.WriteLine($"Product: {number1} * {number2} = {number1 * number2}");

            Console.WriteLine("==========");

            for (int i = 0; i < numbers.Count - 2; i++)
            {
                var num = numbers[i];
                beginningPosition = i + 1;
                endPosition = numbers.Count - 1;

                while (numbers[beginningPosition] < numbers[endPosition])
                {
                    sum = num + numbers.ElementAt(beginningPosition) + numbers.ElementAt(endPosition);
                    
                    if (sum == Year)
                    {
                        number1 = numbers.ElementAt(beginningPosition);
                        number2 = numbers.ElementAt(endPosition);

                        Console.WriteLine($"{num} + {number1} + {number2} = {sum}");
                        Console.WriteLine($"Product: {num} * {number1} * {number2} = {num * number1 * number2}");

                        return;
                    }
                    else if (sum > Year)
                    {
                        --endPosition;
                    }
                    else
                    {
                        ++beginningPosition;
                    }
                }
            }
        }
    }
}
