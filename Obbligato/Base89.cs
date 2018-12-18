using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obbligato
{
    public class Base89 : IEquatable<Base89>
    
    {
        //Fields
        public uint Base10Equivalent = UInt32.MaxValue;
        public char Base89Character = '\0';

        public static char[] EquivalenceTable { get; } = new char[89]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
            'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
            'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '!',
            '<', '#', '$', '%', '&', '>', '(', ')', '*', '+', ',', '-', '.', '/', '[', '?', ']', '^', '_', '`', '{',
            '|', '}', '~', '@', '\\'
        };

        //Constructors
        public Base89(uint base10Equivalent)
        {
            Base10Equivalent = base10Equivalent % 89;
            if (this.Base89Character == '\0')
            {
                Base89Character = CalculateBase89();
            }
        }

        public Base89(char base89character)
        {
            Base89Character = base89character;
            if (this.Base10Equivalent == UInt32.MaxValue)
            {
                Base10Equivalent = CalculateBase10();
            }
        }

        //Methods
        private uint CalculateBase10()
        {
            uint base10 = UInt32.MaxValue;
            //TODO replace the for loop with a binary search tree
            for (uint i = 0; i < EquivalenceTable.Length; i++)
            {
                if (Base89Character == EquivalenceTable[i])
                {
                    base10 = i;
                }
            }

            if (base10 == UInt32.MaxValue)
            {
                throw new System.ArgumentOutOfRangeException("Base89 match not found.");
            }

            return base10;
        }

        private char CalculateBase89()
        {
            uint remainder = Base10Equivalent % 89;
            var base89 = EquivalenceTable[remainder];
            return base89;
        }

        public override string ToString()
        {
            string returnString = Base89Character.ToString();
            return returnString;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Base89);
        }

        public bool Equals(Base89 other)
        {
            return other != null &&
                   Base10Equivalent == other.Base10Equivalent &&
                   Base89Character == other.Base89Character;
        }

        public static bool operator ==(Base89 base1, Base89 base2)
        {
            return EqualityComparer<Base89>.Default.Equals(base1, base2);
        }

        public static bool operator !=(Base89 base1, Base89 base2)
        {
            return !(base1 == base2);
        }
    
    }
}