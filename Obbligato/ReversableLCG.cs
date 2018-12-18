using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;

namespace Obbligato
{
    public class ReversableLCG
    {
        private uint modulus; //m
        private uint multiplier; // a
        private uint increment; //c
        private uint seed; //x
        private ReversableLCG instance; 
        

        public ReversableLCG(uint seed)
        {
            this.modulus = modulus;
            this.multiplier = multiplier;
            this.increment = increment;
            this.seed = seed;
            VerifyFields();
        }

        private void VerifyFields()
        {
            byte verified = 0;
            bool multiplierFlag = false;
            bool incrementFlag = false;

            if (multiplier < modulus)
            {
                verified++;
            }
            else
            {
                multiplierFlag = true;
            }

            if (multiplier == 0)
            {
                verified++;
            }
            else
            {
                multiplierFlag = true;
            }

            if (increment < modulus)
            {
                verified++;
            }
            else
            {
                incrementFlag = true;
            }

            if (verified != 3)
            {
                instance = null;
            }
        }

    }
}