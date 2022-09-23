using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noppapeli
{
    class Noppa
    {
        // property
        public int Luku;
        public int Koko;

        // method
        public Noppa(int koko) // constructor
        {
            Koko = koko;
            Heitto();
        }
        public void Heitto()
        {
            Random rng = new Random();
            Luku = rng.Next(1, Koko+1);
        }
    }
}
