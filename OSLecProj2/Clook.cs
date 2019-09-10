using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSLecProj2
{
    public partial class Clook : Form
    {
        Bitmap off;
        Timer tt = new Timer();
        Font drawFont = new Font("Arial", 16);
        List<liness> lines = new List<liness>();
        int start = 5, starty = 40, k, posst, posprev, zz = 0, temp;
        int[] sortedreq = new int[Form1.Requests.Length + 4];
        float factor, factory;
        int temphe = 350;
        bool didSwap;
        public Clook()
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            Size = new Size(500, 400);
            this.Load+=Clook_Load;
            this.Paint += Clook_Paint;
            this.FormClosing += Clook_FormClosing;
            this.Text = "C-LOOK";
            tt.Tick += new EventHandler(tt_Tick);
            tt.Start();
            tt.Interval = 10;
        }

        void Clook_FormClosing(object sender, FormClosingEventArgs e)
        {
            tt.Stop();
            tt.Dispose();
        }
        void tt_Tick(object sender, EventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }
        void Clook_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Clook_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.Requests.Length; i++)
            {
                sortedreq[i] = Form1.Requests[i];
                k = i;
            }
            sortedreq[k + 1] = Form1.curr_req;
            sortedreq[k + 2] = Form1.start_cylinder;
            sortedreq[k + 3] = Form1.no_of_cylinders;
            sortedreq[k + 4] = Form1.prev_req;
            do
            {
                didSwap = false;
                for (int i = 0; i < sortedreq.Length - 1; i++)
                {
                    if (sortedreq[i] > sortedreq[i + 1])
                    {
                        int temp = sortedreq[i + 1];
                        sortedreq[i + 1] = sortedreq[i];
                        sortedreq[i] = temp;
                        didSwap = true;
                    }
                }
            } while (didSwap);
            //===============================================================
            //Sequence
            for (int i = 0; i < sortedreq.Length; i++)
            {
                if (sortedreq[i] == Form1.curr_req)
                {
                    posst = i;
                }
                if (sortedreq[i] == Form1.prev_req)
                {
                    posprev = i;
                }
            }
            for (int i = 0; i < Form1.drawingseq.Length; i++)
            {
                for (int z = 0; z < sortedreq.Length; z++)
                {
                    if (sortedreq[z] == Form1.drawingseq[i])
                    {
                        zz = z;
                    }
                    if (i != 0)
                    {
                        if (sortedreq[z] == Form1.drawingseq[i - 1])
                        {
                            temp = z;
                        }
                    }
                }
                liness pnn = new liness();
                if (i == 0)
                {
                    pnn.startx = start + (posst * Convert.ToInt32(factor));
                    pnn.endx = start + (zz * Convert.ToInt32(factor));
                    pnn.starty = starty + Convert.ToInt32(factory);
                    pnn.endy = starty + 5 + Convert.ToInt32(factory);
                }
                else
                {
                    pnn.startx = start + (temp * Convert.ToInt32(factor));
                    pnn.endx = start + (zz * Convert.ToInt32(factor));
                    pnn.starty = starty + Convert.ToInt32(factory);
                    pnn.endy = starty + 5 + Convert.ToInt32(factory);
                }
                lines.Add(pnn);
                starty += 5;
            }
            starty = 40;
        }
        protected override void OnResize(EventArgs e)
        {
            off.Dispose();
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            factor = (this.ClientSize.Width - 50) / (Form1.no_of_requests + 3);
            factory = (this.ClientSize.Height - temphe) / (Form1.no_of_requests);
            //===========================================================================
            for (int i = 0; i < lines.Count; i++)
            {
                for (int z = 0; z < sortedreq.Length; z++)
                {
                    if (sortedreq[z] == Form1.drawingseq[i])
                    {
                        zz = z;
                    }
                    if (i != 0)
                    {
                        if (sortedreq[z] == Form1.drawingseq[i - 1])
                        {
                            temp = z;
                        }
                    }
                }
                if (i == 0)
                {
                    lines[i].startx = start + (posst * Convert.ToInt32(factor));
                    lines[i].endx = start + (zz * Convert.ToInt32(factor));
                    lines[i].starty = starty;
                    lines[i].endy = starty;
                }
                else
                {
                    lines[i].startx = temp + (temp * Convert.ToInt32(factor));
                    lines[i].endx = start + (zz * Convert.ToInt32(factor));
                    lines[i].starty = starty - Convert.ToInt32(factory);
                    lines[i].endy = starty;// +Convert.ToInt32(factory);
                }
                starty += Convert.ToInt32(factory);
            }
            starty = 40;
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawLine(Pens.Yellow, 0, 30, this.ClientSize.Width, 30);
            for (int i = 0; i < sortedreq.Length; i++)
            {
                g.DrawString(sortedreq[i].ToString(), drawFont, Brushes.Wheat, start + (i * Convert.ToInt32(factor)), 5);
                g.FillEllipse(Brushes.Red, start + ((i * Convert.ToInt32(factor)) + 7), 27, 5, 5);
            }
            start = 5;
            for (int i = 0; i < lines.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, lines[i].startx, lines[i].starty, 5, 5);
                g.DrawLine(Pens.DarkMagenta, lines[i].startx, lines[i].starty, lines[i].endx, lines[i].endy);
                g.FillEllipse(Brushes.Blue, lines[i].endx, lines[i].endy, 5, 5);
            }
        }
    }
}
