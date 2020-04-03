using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAIGame
{ 
    public class Currency
    {
        private int currentCurrency;

        public Currency()
        {
            currentCurrency = 100;
        }

        public int getCurrency()
        {
            return currentCurrency;
        }

    }
}
