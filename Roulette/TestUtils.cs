using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class TestUtils
    {
        private int _Trial;
        private int _Bet;

        public int StackPlayerTest(string stackPlayerStr, int stackBank)
        {
            bool isConvert = Int32.TryParse(stackPlayerStr, out int stackPlayer);
            if(isConvert && stackPlayer <= stackBank)
            {
                return stackPlayer;
            }
            else
            {
                return -1;
            }
        }

        public int TrialTest(string trialStr)
        {
            bool isConvert = Int32.TryParse(trialStr, out int trial);
            if (isConvert && (trial >= 0 && trial <= 36))
            {
                _Trial = trial;
                return _Trial;
            }
            else
            {
                return -1;
            }
        }

        public int BetTest(string betStr, int maxPlayer, int maxBank)
        {
            bool isConvert = Int32.TryParse(betStr, out int bet);
            if(isConvert && (bet <= maxPlayer && bet * 50 <= maxBank))
            {
                _Bet = bet;
                return bet;
            }
            else
            {
                return -1;
            }
        }

        public int GameTest(int response, int trial, out bool hasWin)
        {
            //savoir si pair
            bool trialIsPeer = trial % 2 == 0 ? true : false;
            bool responseIsPeer = response % 2 == 0 ? true : false;

            if((response == trial) && (trial != 0))
            {
                hasWin = true;
                return _Bet * 36;
            }
            else if((response == trial)&&(trial == 0))
            {
                hasWin = true;
                return _Bet * 50;
            }
            else if(trialIsPeer == responseIsPeer)
            {
                hasWin = true;
                return _Bet * 20;
            }
            else
            {
                hasWin = false;
                return _Bet;
            }
        }
    }
}
