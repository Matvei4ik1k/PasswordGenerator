using System;
using System.Collections.Generic;

namespace PasswordGenerator.AppData
{
    internal class GenerationService
    {
        private readonly Random _random = new Random();
        private readonly string _numbers = "1234567890";
        private readonly string _simbols = "!@#$%^&*()-_+";
        private readonly string _lowerCharacters = "qwertyuiopasdfghjklzxcvbnm";
        private readonly string _upperCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private readonly string[] _words = new string[] { "Кот", "Ёж", "Лес" };
        public int count = 0;

        private readonly List<string> _patterns;
        public GenerationService(bool useNumbers, bool useSymbols, bool useLower, bool useUpper, bool useWords)
        {
            _patterns = new List<string>();
            if (useNumbers)
            {
                _patterns.Add(_numbers);
                count++;
            }
            if (useSymbols)
            {
                _patterns.Add(_simbols);
                count++;
            }
            if (useLower)
            {
                _patterns.Add(_lowerCharacters);
                count++;
            }
            if (useUpper)
            {
                count++;
                _patterns.Add(_upperCharacters);
            }
        }

        public List<string> Start(int length, int passwordsCount)
        {
            var passwordSets = new List<string>();

            for (int i = 0; i < passwordsCount; i++)
            {
                string password = string.Empty;
                while (password.Length < length)
                {
                    int words = _random.Next(0, _words.Length);

                    int patternIndex = _random.Next(0, _patterns.Count);
                    int charIndexFromPattern = _random.Next(0, _patterns[patternIndex].Length);
                    password += _patterns[patternIndex][charIndexFromPattern];
                }
                password = password.Insert(0, _words[0]);
                passwordSets.Add(password);
            }
            return passwordSets;
        }
    }
}
