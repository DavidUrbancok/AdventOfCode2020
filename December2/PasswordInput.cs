using System;
using System.Linq;

namespace December2
{
    public class PasswordInput
    {
        public char Character { get; }

        public Range CharacterRange { get; }

        public string Password { get; }

        public bool Valid { get; private set; } = false;

        public PasswordInput(string line)
        {
            var segments = line.Split(' ');
            Character = segments[1][0];
            Password = segments[2];

            var ranges = segments[0].Split('-');
            CharacterRange = new Range(Convert.ToInt32(ranges[0]), Convert.ToInt32(ranges[1]));
        }

        public void Validate()
        {
            var charOccurences = Password.ToList().Count(c => c == Character);

            Valid = CharacterRange.Start.Value <= charOccurences
                 && CharacterRange.End.Value >= charOccurences;
        }
    }
}
