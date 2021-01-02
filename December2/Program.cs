using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December2
{
    public static class Program
    {
        public static void Main()
        {
            using var fileStream = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream);

            var lines = streamReader.ReadToEnd().Split('\n');
            var passwords = new List<PasswordInput>();

            foreach (var line in lines)
            {
                PasswordInput password = new PasswordInput(line);
                passwords.Add(password);
                password.Validate();
            }

            Console.WriteLine($"Valid passwords: {passwords.Count(p => p.Valid)}");
        }
    }
}
