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
    
    public partial class Form1 : Form
    {
        public static int no_of_cylinders, no_of_requests, curr_req, prev_req, start_cylinder, temp;
        public static int[] Requests;
        public static int[] sstfr;
        public static int[] tempo;
        public static int[] drawingseq;
        Form active = null;
        bool flag = true;
        int mode = 0;
        int[] removed;
        public static List<lines> line = new List<lines>();
        bool didSwap;
        public Form1()
        {
            InitializeComponent();
        }
        void clook()
        {
            //Variables
            int seektime = 0;
            drawingseq = new int[Requests.Length + 1];
            int[] sortedreq = new int[Requests.Length + 1];
            int current = curr_req;
            int k = 0;
            //=============================================================
            //Algorithm
            //sorting
            for (int i = 0; i < Requests.Length; i++)
            {
                sortedreq[i] = Requests[i];
                k = i;
            }
            sortedreq[k + 1] = curr_req;
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
            for (int i = 0; i < sortedreq.Length; i++)
            {
                if (sortedreq[i] == curr_req)
                {
                    current = i;
                    break;
                }
            }
            k = 0;
            //Mashy Shemal
            if (prev_req > curr_req)
            {
                for (int i = current; i >= 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i =sortedreq.Length-1 ; i > current + 1; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Mashy ymen
            else if (prev_req < curr_req)
            {
                for (int i = current; i < sortedreq.Length; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = 0; i <= current - 1; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Seek time
            int currentt = curr_req;
            for (int i = 0; i < drawingseq.Length; i++)
            {
                seektime += Math.Abs(current - drawingseq[i]);
                currentt = drawingseq[i];
            }
            textBox12.Text = "" + seektime;
            //=============================================================
            //Graph
            Clook clookgrapgh = new Clook();
            clookgrapgh.Show();
            active = clookgrapgh;
            //=============================================================
        }
        void cscan()
        {
            //Variables
            int seektime = 0;
            drawingseq = new int[Requests.Length + 3];
            int[] sortedreq = new int[Requests.Length + 3];
            int current = curr_req;
            int k = 0;
            //=============================================================
            //Algorithm
            //sorting
            for (int i = 0; i < Requests.Length; i++)
            {
                sortedreq[i] = Requests[i];
                k = i;
            }
            sortedreq[k + 1] = curr_req;
            sortedreq[k + 2] = start_cylinder;
            sortedreq[k + 3] = no_of_cylinders;
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
            for (int i = 0; i < sortedreq.Length; i++)
            {
                if (sortedreq[i] == curr_req)
                {
                    current = i;
                    break;
                }
            }
            k = 0;
            //Mashy Shemal
            if (prev_req > curr_req)
            {
                for (int i = current; i >= 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = sortedreq.Length-1; i > current + 1; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Mashy ymen
            else if (prev_req < curr_req)
            {
                for (int i = current; i < sortedreq.Length; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = 0; i < current ; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Seek time
            int currentt = curr_req;
            for (int i = 0; i < drawingseq.Length; i++)
            {
                seektime += Math.Abs(current - drawingseq[i]);
                currentt = drawingseq[i];
            }
            textBox10.Text = "" + seektime;
            //=============================================================
            //Graph
            Cscan cscangrapgh = new Cscan();
            cscangrapgh.Show();
            active = cscangrapgh;
            //=============================================================
        }
        void look()
        {
            //Variables
            int seektime = 0;
            drawingseq = new int[Requests.Length +1];
            int[] sortedreq = new int[Requests.Length +1];
            int current = curr_req;
            int k = 0;
            //=============================================================
            //Algorithm
            //sorting
            for (int i = 0; i < Requests.Length; i++)
            {
                sortedreq[i] = Requests[i];
                k = i;
            }
            sortedreq[k + 1] = curr_req;
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
            for (int i = 0; i < sortedreq.Length; i++)
            {
                if (sortedreq[i] == curr_req)
                {
                    current = i;
                    break;
                }
            }
            k = 0;
            //Mashy Shemal
            if (prev_req > curr_req)
            {
                for (int i = current; i >= 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = current + 1; i < sortedreq.Length; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Mashy ymen
            else if (prev_req < curr_req)
            {
                for (int i = current; i < sortedreq.Length; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = current - 1; i >= 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Seek time
            int currentt = curr_req;
            for (int i = 0; i < drawingseq.Length; i++)
            {
                seektime += Math.Abs(current - drawingseq[i]);
                currentt = drawingseq[i];
            }
            textBox11.Text = "" + seektime;
            //=============================================================
            //Graph
            Look lookgrapgh = new Look();
            lookgrapgh.Show();
            active = lookgrapgh;
            //=============================================================
        }
        void scan()
        {
            //Variables
            int seektime = 0;
            drawingseq = new int[Requests.Length + 2];
            int[] sortedreq = new int[Requests.Length + 3];
            int current=curr_req;
            int k=0;
            //=============================================================
            //Algorithm
            //sorting
            for (int i = 0; i <Requests.Length; i++)
            {
                sortedreq[i] =Requests[i];
                k = i;
            }
            sortedreq[k + 1] = curr_req;
            sortedreq[k + 2] = start_cylinder;
            sortedreq[k + 3] = no_of_cylinders;
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
            for (int i=0;i<sortedreq.Length;i++)
            {
                if (sortedreq[i]==curr_req)
                {
                    current=i;
                    break;
                }
            }
            k = 0;
            //Mashy Shemal
            if (prev_req > curr_req)
            {
                for (int i = current; i >= 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i=current+1;i<sortedreq.Length-1;i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Mashy ymen
            else if (prev_req < curr_req)
            {
                for (int i = current; i < sortedreq.Length; i++)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
                for (int i = current-1; i > 0; i--)
                {
                    drawingseq[k] = sortedreq[i];
                    k++;
                }
            }
            //Seek time
            int currentt = curr_req;
            for (int i = 0; i < drawingseq.Length; i++)
            {
                seektime += Math.Abs(current - drawingseq[i]);
                currentt = drawingseq[i];
            }
            textBox9.Text = "" + seektime;
            //=============================================================
            //Graph
            Scan scangrapgh = new Scan();
            scangrapgh.Show();
            active = scangrapgh;
            //=============================================================
        }
        void sstf()
        {
            //Variables
            int seektime = 0;
            //=============================================================
            //Algorithm
            //Sorting
            removed = new int[no_of_requests + 2];
            drawingseq = new int[no_of_requests + 1];
            for (int i=0;i<removed.Length;i++)
            {
                removed[i] = -1;
            }
            int current = curr_req;
            int min = 999;
            int diff = 0;
            int currentless = 0;
            int z = 0;
            drawingseq[0] = curr_req;
            for (int i=0;i<Requests.Length;i++)
            {
                for (int k=0;k<Requests.Length;k++)
                {
                    if (!removed.Contains(Requests[k]))
                    {
                        diff = Math.Abs(current - Requests[k]);
                        if (diff<min)
                        {
                            min = diff;
                            currentless = Requests[k];
                        }
                    }
                }
                current = currentless;
                drawingseq[z+1] = currentless;
                removed[z] = currentless;
                min = 999;
                z++;
            }
            //Seek time
            int currentt = curr_req;
            for (int i = 0; i < drawingseq.Length; i++)
            {
                seektime += Math.Abs(current - drawingseq[i]);
                current = drawingseq[i];
            }
            textBox8.Text = "" + seektime;
            //=============================================================
            //Graph
            SSTFGraph sstfgrapgh = new SSTFGraph();
            sstfgrapgh.Show();
            active = sstfgrapgh;
            //=============================================================
        }
        void fcfs()
        {
            //Variables
            int seektime = 0;
            //=============================================================
            //Algorithm
            for (int i=0;i<no_of_requests;i++)
            {
                lines pnn = new lines();
                if (i != 0)
                {
                    pnn.start = i - 1;
                }
                else
                {
                    pnn.start = -1;
                }
                pnn.end = i;
                line.Add(pnn);
            }
            //Seek time
            int current = curr_req;
            for (int i=0;i<Requests.Length;i++)
            {
                seektime += Math.Abs(current - Requests[i]);
                current = Requests[i];
            }
            textBox7.Text = "" + seektime;
            //=============================================================
            //Graph
            Graph fcfsgrapgh = new Graph(line);
            fcfsgrapgh.Show();
            active = fcfsgrapgh;
            //=============================================================
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Enter" && textBox2.Text != "Enter" && textBox3.Text != "Enter" && textBox4.Text != "Enter" && textBox5.Text != "Enter" && textBox6.Text != "Enter")
            {
                    if (radioButton7.Checked)
                    {
                        mode = 1;
                    }
                    else if (radioButton8.Checked)
                    {
                        mode = 2;
                        if (active != null)
                        {
                            active.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Mode");
                    }
                if (mode != 0)
                {
                    flag = true;
                    try
                    {
                        no_of_cylinders = Convert.ToInt32(textBox3.Text);
                        no_of_requests = Convert.ToInt32(textBox4.Text);
                        curr_req = Convert.ToInt32(textBox1.Text);
                        prev_req = Convert.ToInt32(textBox2.Text);
                        start_cylinder = Convert.ToInt32(textBox6.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Non-Integer Number Found");
                        flag = false;
                    }
                    string[] refrence = textBox5.Text.Split(',');
                    Requests = new int[no_of_requests];
                    if (refrence.Length != no_of_requests)
                    {
                        MessageBox.Show("Error not same number");
                    }
                    else
                    {
                        for (int i = 0; i < no_of_requests; i++)
                        {
                            try
                            {
                                Requests[i] = Convert.ToInt32(refrence[i]);
                            }
                            catch
                            {
                                MessageBox.Show("Non-Integer Number Found");
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            if (radioButton1.Checked)
                            {
                                fcfs();
                            }
                            else if (radioButton2.Checked)
                            {
                                sstf();
                            }
                            else if (radioButton3.Checked)
                            {
                                scan();
                            }
                            else if (radioButton4.Checked)
                            {
                                cscan();
                            }
                            else if (radioButton5.Checked)
                            {
                                look();
                            }
                            else if (radioButton6.Checked)
                            {
                                clook();
                            }
                            else
                            {
                                MessageBox.Show("Please Select An Algorithm");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Data Correctly");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*no_of_cylinders = 199;
            no_of_requests = 8;
            curr_req = 53;
            prev_req = 52;
            start_cylinder = 0;
            Requests = new int [8];
            Requests[0] = 98; Requests[1] = 183; Requests[2] = 37; Requests[3] = 122; Requests[4] = 14; Requests[5] = 124; Requests[6] = 65; Requests[7] = 67;
            clook();*/
            this.Dispose();
        }
        public class lines
        {
            public int start, end;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Main Window";
            this.CenterToScreen();
        }
    }
}
