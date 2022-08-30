using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        private const int DECREASE_DYE_POWER = 10;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => power;
            protected set
            {
                if (value<0)
                {
                    value = 0;
                }
                power = value;
            }
        }

        public bool IsFinished() => Power == 0;

        public void Use() => Power -= DECREASE_DYE_POWER;

    }
}
