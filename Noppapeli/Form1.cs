using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    // Luo luokka "Noppa", jossa on tallessa nopan arvo 1-6
    // nopalla on myös "Heitto"-metodi, joka arpoo sille arvon 1-6
    // Anna nopalle myös constructor-metodi, joka heti alussa arpoo arvon

    // Lähde tekemään Yatzi-peli

    // Lisää nopalle kuvat 1-6

    public partial class Form1 : Form
    {
        // property
        //Noppa noppa1 = new Noppa(6);
        List<Noppa> Nopat = new List<Noppa>();
        public Form1()
        {
            InitializeComponent();
            // luodaan 5 noppaa
            for (int i = 0; i < 5; i++)
            {
                PictureBox tempPB = new PictureBox();

                this.Controls.Add(tempPB);


                Noppa tempNoppa = new Noppa(6, tempPB);
                Nopat.Add(tempNoppa);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Nopat.Count; i++)
            {
                Nopat[i].Heitto();
                editPictureBox(Nopat[i], i);
            }
           
                //noppa1.Heitto();
                //addPictureBox(noppa1, 1);
                //label1.Text = noppa1.Luku.ToString();
                //addPictureBox(noppa1, 1);
            
            // lisää nopalle property "Koko", jolla määritellään
            // montako silmälukua nopalla on
            // ja käytetään sitä luvun arvonnassa
            // nopan koko annetaan sitä generoidessa
        }

        private void addPictureBox(Noppa jokuNoppa, int Luku)
        {
            const int spacing = 60;




            PictureBox tempPB = new PictureBox();
            string key = jokuNoppa.GetPictureKey();
            tempPB.Image = Noppa.GetPictureResourceX(key); 
            tempPB.Location = new Point(13, 13);
            tempPB.Size = new Size(100, 200);
            tempPB.SizeMode = PictureBoxSizeMode.Zoom;

            this.Controls.Add(tempPB);

        }
        private void editPictureBox(Noppa jokuNoppa, int Luku)
        {
            const int spacing = 60;

            string key = jokuNoppa.GetPictureKey();
            jokuNoppa.Boxi.Image = Noppa.GetPictureResourceX(key);
            jokuNoppa.Boxi.Location = new Point(13 + Luku * spacing, 13);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ones = 0;
            for (var i = 0; i < Nopat.Count; i++)
            {
                if(i == 1)
                {
                    ones += 1;
                }
            }
            txtYks.Text = ones.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6];
            // { 0, 4, 0, 0, 10, 0 }
            int[] pairValues = new int[6];
            const int multiplier = 2;

            for (int i = 0; i < pairs.Length; i++)
            {
                //LinQ kirjaston metodeja
                pairs[i] = Nopat.Where(noppa => noppa.Luku == i + 1).Count();

            }
            for (int i = 0; i <pairs.Length; i++)
            {
                if (pairs[i] > 1) //lasketaan vain parit + yli
                {
                    pairValues[i] = (i + 1) * multiplier;
                }
            }
            txtPari.Text = pairValues.Max().ToString();
        }

        
    }
}
