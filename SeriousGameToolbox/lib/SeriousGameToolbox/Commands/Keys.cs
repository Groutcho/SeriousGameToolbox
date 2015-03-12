using SeriousGameToolbox.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    internal class Keys
    {
        public const string CTRL = "CTRL";
        public const string SHIFT = "SHIFT";
        public const string ALT = "ALT";

        public const string A = "A";
        public const string B = "B";
        public const string C = "C";
        public const string D = "D";
        public const string E = "E";
        public const string F = "F";
        public const string G = "G";
        public const string H = "H";
        public const string I = "I";
        public const string J = "J";
        public const string K = "K";
        public const string L = "L";
        public const string M = "M";
        public const string N = "N";
        public const string O = "O";
        public const string P = "P";
        public const string Q = "Q";
        public const string R = "R";
        public const string S = "S";
        public const string T = "T";
        public const string U = "U";
        public const string V = "V";
        public const string W = "W";
        public const string X = "X";
        public const string Y = "Y";
        public const string Z = "Z";

        public static bool AnyLetter(string input)
        {
            Guard.AgainstNullArgument("input", input);

            if (input.Length != 1)
            {
                return false;
            }

            return  input == A ||
                    input == B ||
                    input == C ||
                    input == D ||
                    input == E ||
                    input == F ||
                    input == G ||
                    input == H ||
                    input == I ||
                    input == J ||
                    input == K ||
                    input == L ||
                    input == M ||
                    input == N ||
                    input == O ||
                    input == P ||
                    input == Q ||
                    input == R ||
                    input == S ||
                    input == T ||
                    input == U ||
                    input == V ||
                    input == W ||
                    input == X ||
                    input == Y ||
                    input == Z;
        }
    }
}
