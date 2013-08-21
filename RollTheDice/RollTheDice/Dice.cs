using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice
{
    class Dice
    {
        public int GetRollResult()
        {
            Random randomNumber = new Random();
            int face;

            face = randomNumber.Next(1, 7);

            return face;

        }
    }
}
