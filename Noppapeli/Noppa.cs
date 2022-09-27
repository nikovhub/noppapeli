using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    class Noppa
    {
        // property
        public int Luku;
        public int Koko;
        public PictureBox Boxi;
        //public PictureBox Boxi= new PictureBox();

        // method
        public Noppa(int koko, PictureBox boxi) // constructor
        {
            Boxi = boxi;
            Koko = koko;
            Heitto();
            Boxi.Size = new Size(40, 40);
            Boxi.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void Heitto()
        {
            Random rng = new Random();
            Luku = rng.Next(1, Koko+1);
        }

        public string GetPictureKey()
        {
            string returnValue = "_"; // kuvien nimet alkavat _ merkillä + nopan numeerinen luku. Tämä funktio kasaa halutun kuvan nimen
                                      // yhdistämällä _ ja nopan luvun.
            returnValue += Luku.ToString();


            return returnValue;
        }

        public static Image GetPictureResourceX(string key)
        {
            return Noppapeli.noppakuvat.ResourceManager.GetObject(key) as Image;
        }


    }
}
