using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Calc
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {       
                //Netadress & Invertmask & broadcast
                string ipadress = textBox3.Text;
                string subnet = textBox2.Text;

                string[] ipokt = ipadress.Split('.');
                string[] subnetok = subnet.Split('.');
                string[] invertmask = new string[4];
                string[] netzadress = new string[4];
                string[] broadcast = new string[4];
                
                for (int i = 0; i < 4; i++)
                {
                    byte ipOct = Convert.ToByte(ipokt[i]);
                    byte subnetoct = Convert.ToByte(subnetok[i]);                    
                    netzadress[i] = (ipOct & subnetoct).ToString();
                    invertmask[i] = (255 - subnetoct).ToString();
                    broadcast[i] = (ipOct | (255 -subnetoct)).ToString();
                    subnetok[i] = Convert.ToString(subnetoct, 2).PadLeft(0, '0');
                } 
                
                label2.Text = string.Join(".", netzadress);
                label9.Text = string.Join(".", invertmask);
                label6.Text = string.Join(".", broadcast);
                label13.Text = string.Join("" , subnetok);
                string prefix = label13.Text.Replace("0", string.Empty);
                label13.Text = prefix.Length.ToString();

                //firsthost               
                string netadress = label2.Text.Replace(".", "99");
                netadress = (Int64.Parse(netadress) + 1).ToString();               
                netadress = netadress.Replace("99", ".");
                label5.Text = netadress;

                //lasthost
                string brdcast = label6.Text.Replace(".", "99");
                brdcast = (Int64.Parse(brdcast) - 1).ToString();
                label7.Text = brdcast.Replace("99", ".");

            }
            // Helloooooo Test LOL
        }   
    }

