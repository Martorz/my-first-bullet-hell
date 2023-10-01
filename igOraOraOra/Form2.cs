using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace igOraOraOra
{
    public partial class Form2 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=base.mdb;";
        private OleDbConnection connect;
        public int mon;
        int en, u = 100, enmoney, enemyid, enexp, timer = 0, lvl, k = 35, k2 = 5;
        int x1, y1, rotate = 1, x2, y2;
        int xb1, yb1, xb2, yb2;
        int xofbullet;
        int p2, p1;
        Random r = new Random();
        public Form2()
        {
            connect = new OleDbConnection(connectString);
            connect.Open();
            InitializeComponent();
            string pt2 = "SELECT m_p2 FROM meh WHERE m_num = 1";
            OleDbCommand command4 = new OleDbCommand(pt2, connect);
            p2 = Convert.ToInt32(command4.ExecuteScalar().ToString());

            string pt1 = "SELECT m_p1 FROM meh WHERE m_num = 1";
            OleDbCommand command3 = new OleDbCommand(pt1, connect);
            p1 = Convert.ToInt32(command3.ExecuteScalar().ToString());

            switch (p1)
            {
                case 1:
                    pictureBox11.Visible = true;
                    break;

                case 2:
                    pictureBox11.Visible = true;
                    pictureBox12.Visible = true;
                    break;

                case 3:
                    pictureBox11.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    break;

                case 4:
                    pictureBox11.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    break;

                case 5:
                    pictureBox11.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox15.Visible = true;
                    break;

                case 6:
                    pictureBox11.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox14.Visible = true;
                    pictureBox15.Visible = true;
                    pictureBox16.Visible = true;
                    break;
            }

            enemyid = r.Next(1, 3);
            switch (enemyid)
            {
                case 1:
                    if (p2 > 8)
                    {
                        label2.Text = "Очень злой питух";
                        label2.Location = new Point(37, 268);
                        pictureBox2.Image = igOraOraOra.Properties.Resources.c1e;
                    }
                    else 
                    {
                        label2.Text = "Злой питух";
                        label2.Location = new Point(53, 268);
                        pictureBox2.Image = igOraOraOra.Properties.Resources.c11;
                    }
                    
                    
                    progressBar1.Maximum = Convert.ToInt32(50 * Math.Sqrt(Convert.ToDouble(p2)));
                    progressBar1.Value = Convert.ToInt32(50 * Math.Sqrt(Convert.ToDouble(p2)));
                    en = Convert.ToInt32(50 * Math.Sqrt(Convert.ToDouble(p2)));
                    enmoney = 1 * p2;
                    enexp = 3 * p2;
                    break;

                case 2:
                    if (p2 > 8)
                    {
                        pictureBox2.Image = igOraOraOra.Properties.Resources.ze;
                        label2.Text = "Очень позорный змий";
                        label2.Location = new Point(24, 268);
                    }
                    else
                    {
                        pictureBox2.Image = igOraOraOra.Properties.Resources.z;
                        label2.Text = "Змий позорный";
                        label2.Location = new Point(40, 268);
                    }
                    progressBar1.Maximum = Convert.ToInt32(100 * Math.Sqrt(Convert.ToDouble(p2)));
                    progressBar1.Value = Convert.ToInt32(100 * Math.Sqrt(Convert.ToDouble(p2)));
                    en = Convert.ToInt32(100 * Math.Sqrt(Convert.ToDouble(p2)));
                    enmoney = 5 * p2;
                    enexp = 10 * p2;
                    break;
            }
            string lvl1 = "SELECT m_exp FROM meh WHERE m_num = 1";
            OleDbCommand command1 = new OleDbCommand(lvl1, connect);
            lvl = Convert.ToInt32(command1.ExecuteScalar().ToString());
            if (lvl >= 310)
            {
                progressBar2.Maximum = 200;
                progressBar2.Value = 200;
                k = 135;
                k2 = 10;
                u = 200;
            }
            else if (lvl >= 150)
            {
                progressBar2.Maximum = 160;
                progressBar2.Value = 160;
                k = 110;
                k2 = 8;
                u = 160;
            }
            else if (lvl >= 70)
            {
                progressBar2.Maximum = 140;
                progressBar2.Value = 140;
                k = 85;
                k2 = 7;
                u = 140;
            }
            else if (lvl >= 20)
            {
                progressBar2.Maximum = 120;
                progressBar2.Value = 120;
                k = 60;
                k2 = 6;
                u = 120;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Выйти")
            {
                
                //Form1 f1 = new Form1();
                //f1.Enabled = true;
                this.Close();

            }
            /*else
            {
                a = r.Next(0, 3);
                if (a != 0)
                {
                    en -= 10;
                    progressBar1.Value = en;
                }
                a = r.Next(0, 3);
                if (a != 0)
                {
                    u -= 10;
                    progressBar2.Value = u;
                }
                
                if ((en == 0) && (u == 0))
                {
                    MessageBox.Show("Ничья.");
                    button1.Text = "Выйти";
                    pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                    pictureBox2.Image = igOraOraOra.Properties.Resources.c1ded1;
                }
                else if (u == 0)
                {
                    MessageBox.Show("Вы проиграли.");
                    button1.Text = "Выйти";
                    pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                }
                else if (en == 0)
                {
                    MessageBox.Show("Вы победили.");
                    button1.Text = "Выйти";
                    pictureBox2.Image = igOraOraOra.Properties.Resources.c1ded1;
                }
            }
             */
            else
            {
                pictureBox8.Visible = false;
                timer1.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (enemyid == 1)
            {
                x1 = pictureBox3.Location.X;
                y1 = pictureBox3.Location.Y;
                if ((y1 != 7) && (y1 != 172))
                {
                    pictureBox3.Location = new Point(x1, y1 - rotate);
                }
                else if (y1 == 7)
                {
                    rotate = -1;
                    pictureBox3.Location = new Point(x1, y1 - rotate);
                }
                else if (y1 == 172)
                {
                    rotate = 1;
                    pictureBox3.Location = new Point(x1, y1 - rotate);
                }
                if (timer3.Enabled == false)
                {
                    x2 = pictureBox3.Location.X + 30;
                    y2 = pictureBox3.Location.Y + 15;
                    bullet();
                }
            }
            else if (enemyid == 2)
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X, r.Next(0, 172));
                pictureBox10.Location = new Point(pictureBox10.Location.X, pictureBox3.Location.Y + 10);
                timer3.Enabled = true;
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if ((pictureBox4.Location.X - 5) > 0)
                {
                    pictureBox4.Location = new Point(pictureBox4.Left - 5, pictureBox4.Top);
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if ((pictureBox4.Location.X - 5) < 167)
                {
                    pictureBox4.Location = new Point(pictureBox4.Left + 5, pictureBox4.Top);
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if ((pictureBox4.Location.Y - 5) > 5)
                {
                    pictureBox4.Location = new Point(pictureBox4.Left, pictureBox4.Top - 5);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if ((pictureBox4.Location.Y - 5) < 172)
                {
                    pictureBox4.Location = new Point(pictureBox4.Left, pictureBox4.Top + 5);
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                yourbullet();
            }
        }

        public void bullet()
        {
            if (enemyid == 1)
            {
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                xb1 = x2;
                xb2 = x2;
                yb1 = y2;
                yb2 = y2;
                pictureBox5.Location = new Point(x2, y2);
                pictureBox6.Location = new Point(x2, y2);
                pictureBox7.Location = new Point(x2, y2);
                timer3.Enabled = true;
            }
        }

        public void yourbullet()
        {
            if (timer1.Enabled == true)
            {
                pictureBox9.Visible = true;
                pictureBox9.Location = new Point(pictureBox4.Location.X - 20, pictureBox4.Location.Y + 4);
                xofbullet = pictureBox4.Location.X - 20;
                timerbullet.Enabled = true;
            }
        }

        

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        } //none

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (enemyid == 1)
            {
                xb1 += 5;
                yb1 -= 2;
                xb2 += 5;
                yb2 += 2;
                pictureBox5.Location = new Point(xb1, yb1);
                pictureBox6.Left = pictureBox6.Location.X + 5;
                pictureBox7.Location = new Point(xb2, yb2);
                if (((pictureBox5.Location.X + 17 >= pictureBox4.Location.X) && (pictureBox5.Location.Y >= pictureBox4.Location.Y)) && ((pictureBox5.Location.X + 17 <= pictureBox4.Location.X + 25) && (pictureBox5.Location.Y + 17 <= pictureBox4.Location.Y + 25)))
                {
                    pictureBox5.Visible = false;
                    if (p2 > 8)
                    {
                        u -= 3;
                    }
                    else
                        u--;
                    if (u == 0)
                    {
                        MessageBox.Show("Вы проиграли.");
                        button1.Text = "Выйти";
                        pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                        button1.Enabled = true;
                        pictureBox8.Visible = true;
                        timer2.Enabled = false;
                        timer1.Enabled = false;
                    }
                    else if (u > 0)
                        progressBar2.Value = u;

                }
                if (((pictureBox6.Location.X + 17 >= pictureBox4.Location.X) && (pictureBox6.Location.Y >= pictureBox4.Location.Y)) && ((pictureBox6.Location.X + 17 <= pictureBox4.Location.X + 25) && (pictureBox6.Location.Y + 17 <= pictureBox4.Location.Y + 25)))
                {
                    pictureBox6.Visible = false;
                    if (p2 > 8)
                    {
                        u -= 3;
                    }
                    else
                        u--;
                    if (u == 0)
                    {
                        MessageBox.Show("Вы проиграли.");
                        button1.Text = "Выйти";
                        pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                        button1.Enabled = true;
                        pictureBox8.Visible = true;
                        timer2.Enabled = false;
                        timer1.Enabled = false;
                    }
                    else if (u > 0)
                        progressBar2.Value = u;

                }
                if (((pictureBox7.Location.X + 17 >= pictureBox4.Location.X) && (pictureBox7.Location.Y >= pictureBox4.Location.Y)) && ((pictureBox7.Location.X + 17 <= pictureBox4.Location.X + 25) && (pictureBox7.Location.Y + 17 <= pictureBox4.Location.Y + 25)))
                {
                    pictureBox7.Visible = false;
                    if (p2 > 8)
                    {
                        u -= 3;
                    }
                    else
                        u--;
                    if (u == 0)
                    {
                        MessageBox.Show("Вы проиграли.");
                        button1.Text = "Выйти";
                        pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                        button1.Enabled = true;
                        pictureBox8.Visible = true;
                        timer2.Enabled = false;
                        timer1.Enabled = false;
                    }
                    else if (u > 0)
                        progressBar2.Value = u;

                }
                if (pictureBox6.Location.X > 220)
                    timer3.Enabled = false;
            }
            else if (enemyid == 2)
            {
                pictureBox10.Visible = true;
                if ((pictureBox10.Location.Y >= pictureBox4.Location.Y) && (pictureBox10.Location.Y + 10 <= pictureBox4.Location.Y + 25))
                {
                    if (p2 > 8)
                    {
                        u -= 6;
                    }
                    else
                        u -= 3;
                    if (u == 0)
                    {
                        MessageBox.Show("Вы проиграли.");
                        button1.Text = "Выйти";
                        pictureBox1.Image = igOraOraOra.Properties.Resources.a1ded;
                        button1.Enabled = true;
                        pictureBox8.Visible = true;
                        timer2.Enabled = false;
                        timer1.Enabled = false;
                    }
                    else if (u > 0)
                        progressBar2.Value = u;
                }
                timer4.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer == 0)
            {
                button1.Enabled = false;
                timer2.Enabled = true;
                if (enemyid == 1)
                {
                    timer2.Interval = 20;
                    timer3.Interval = 1;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox3.Location = new Point(20, 87);
                    pictureBox4.Location = new Point(161, 87);
                }
                else if (enemyid == 2)
                {
                    timer2.Interval = 1000;
                    timer3.Interval = 100;
                    timer4.Interval = 200;
                    pictureBox10.Visible = true;
                    pictureBox3.Location = new Point(20, 87);
                    pictureBox4.Location = new Point(161, 87);
                    pictureBox10.Location = new Point(pictureBox10.Location.X, pictureBox3.Location.Y + 10);
                }
                timer++;
            }
            else if (timer == 10)
            {
                timer = 0;
                button1.Enabled = true;
                pictureBox8.Visible = true;
                timer2.Enabled = false;
                timer1.Enabled = false;
            }
            else
            {
                timer++;
                if (enemyid == 2)
                {
                    timer2.Enabled = true;
                }
            }
        }

        private void timerbullet_Tick(object sender, EventArgs e)
        {
            pictureBox9.Location = new Point(pictureBox9.Location.X - k2, pictureBox9.Location.Y);
            if (((pictureBox9.Location.X <= pictureBox3.Location.X + 25) && (pictureBox9.Location.Y >= pictureBox3.Location.Y)) && ((pictureBox9.Location.X <= pictureBox3.Location.X + 25) && (pictureBox9.Location.Y + 17 <= pictureBox3.Location.Y + 25)))
            {
                pictureBox9.Visible = false;
                en -= 1;
                if (en == 0)
                {
                    pictureBox11.Enabled = false;
                    pictureBox12.Enabled = false;
                    pictureBox13.Enabled = false;
                    pictureBox14.Enabled = false;
                    pictureBox15.Enabled = false;
                    pictureBox16.Enabled = false;
                    MessageBox.Show("Вы победили.");
                    button1.Text = "Выйти";
                    if (enemyid == 1)
                    {
                        pictureBox2.Image = igOraOraOra.Properties.Resources.c1ded1;
                        label3.Visible = true;
                        label3.Text = "Вы получили " + 1 * p2 + " монету и \n      " + 3 * p2 + " единицы опыта";
                    }
                    else
                    {
                        pictureBox2.Image = igOraOraOra.Properties.Resources.zded;
                        label3.Visible = true;
                        label3.Text = "Вы получили " + 3 * p2 + " монеты и \n       " + 5 * p2 + " единиц опыта";
                    }
                    p2 = 1;
                    string pt = "UPDATE meh SET m_p2 = " + p2 + " WHERE m_num = 1";
                    OleDbCommand command4 = new OleDbCommand(pt, connect);
                    command4.ExecuteNonQuery();
                    string pt1 = "UPDATE meh SET m_p1 = " + p1 + " WHERE m_num = 1";
                    OleDbCommand command5 = new OleDbCommand(pt1, connect);
                    command5.ExecuteNonQuery();
                    string mon1 = "SELECT m_money FROM meh WHERE m_num = 1";
                    OleDbCommand command1 = new OleDbCommand(mon1, connect);
                    mon = Convert.ToInt32(command1.ExecuteScalar().ToString()) + enmoney;
                    string mon2 = "UPDATE meh SET m_money = " + mon + " WHERE m_num = 1";
                    OleDbCommand command2 = new OleDbCommand(mon2, connect);
                    command2.ExecuteNonQuery();
                    lvl += enexp;
                    string lvl1 = "UPDATE meh SET m_exp = " + lvl + " WHERE m_num = 1";
                    OleDbCommand command3 = new OleDbCommand(lvl1, connect);
                    command3.ExecuteNonQuery();
                    button1.Enabled = true;
                    pictureBox8.Visible = true;
                    timer2.Enabled = false;
                    timer1.Enabled = false;

                }
                else if (en > 0)
                    progressBar1.Value = en;
                else
                { }
            }
            if (pictureBox9.Location.X < (xofbullet - k)) //вот это меняй
            {
                pictureBox9.Visible = false;
                timerbullet.Enabled = false;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            pictureBox10.Visible = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void etfyb_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (u != progressBar2.Maximum)
            {
                p1 -= 1;
                u += 30;
                if (u > progressBar2.Maximum)
                    u = progressBar2.Maximum;
                progressBar2.Value = u;
                pictureBox11.Visible = false;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            p1 -= 1;
            if (u != progressBar2.Maximum)
            {
            u += 30;
            if (u > progressBar2.Maximum)
                u = progressBar2.Maximum;
            progressBar2.Value = u;
            pictureBox12.Visible = false;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            p1 -= 1;
            if (u != progressBar2.Maximum)
            {
            u += 30;
            if (u > progressBar2.Maximum)
                u = progressBar2.Maximum;
            progressBar2.Value = u;
            pictureBox13.Visible = false;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            p1 -= 1;
            if (u != progressBar2.Maximum)
            {
            u += 30;
            if (u > progressBar2.Maximum)
                u = progressBar2.Maximum;
            progressBar2.Value = u;
            pictureBox14.Visible = false;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            p1 -= 1;
            if (u != progressBar2.Maximum)
            {
            u += 30;
            if (u > progressBar2.Maximum)
                u = progressBar2.Maximum;
            progressBar2.Value = u;
            pictureBox15.Visible = false;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            p1 -= 1;
            if (u != progressBar2.Maximum)
            {
                u += 30;
                if (u > progressBar2.Maximum)
                    u = progressBar2.Maximum;
                progressBar2.Value = u;
                pictureBox16.Visible = false;
            }
        }

    }
}
