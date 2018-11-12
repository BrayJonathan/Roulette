using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Roulette
    {
        private Random _Rdn = new Random();
        private int _GenerateNumber;

        public Roulette()
        {
            _GenerateNumber = _Rdn.Next(0, 36);
        } 

        public int GetGenerateNumber()
        {
            return _GenerateNumber;
        }

        public int GenerateNumber()
        {
            _GenerateNumber = _Rdn.Next(0, 36);
            return _GenerateNumber;
        }
    }
}
