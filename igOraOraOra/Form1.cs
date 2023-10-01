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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            connect = new OleDbConnection(connectString);
            connect.Open();
            string mon = "UPDATE meh SET m_money = " + money + " WHERE m_num = 1";
            OleDbCommand command1 = new OleDbCommand(mon, connect);
            command1.ExecuteNonQuery();
            label1.Text = "Деньги: " + money;
            string exp = "UPDATE meh SET m_exp = " + lvl + " WHERE m_num = 1";
            OleDbCommand command2 = new OleDbCommand(exp, connect);
            command2.ExecuteNonQuery();
            string pt = "UPDATE meh SET m_p1 = " + p1 + " WHERE m_num = 1";
            OleDbCommand command3 = new OleDbCommand(pt, connect);
            command3.ExecuteNonQuery();
            string potion = "UPDATE meh SET m_p2 = " + p2 + " WHERE m_num = 1";
            OleDbCommand command4 = new OleDbCommand(potion, connect);
            command4.ExecuteNonQuery();
        }
        bool img = true;
        public int money = 99999, lvl = 500, p1 = 0, p2 = 1;
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=base.mdb;";
        private OleDbConnection connect;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Location = new Point(pictureBox1.Left - 10, pictureBox1.Top);
                image();
            }
            if (e.KeyCode == Keys.Right)
            {
                image();
                pictureBox1.Location = new Point(pictureBox1.Left + 10, pictureBox1.Top);
            }
            if (e.KeyCode == Keys.Up)
            {
                image();
                pictureBox1.Location = new Point(pictureBox1.Left, pictureBox1.Top - 10);
            }
            if (e.KeyCode == Keys.Down)
            {
                image();
                pictureBox1.Location = new Point(pictureBox1.Left, pictureBox1.Top + 10);
            }

            if ((pictureBox1.Right >= 260) && (pictureBox1.Top <= 125))
            {
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
            }

            if ((pictureBox1.Left <= 126) && (pictureBox1.Bottom >= 297))
            {
                pictureBox5.Visible = true;
            }
            else
            {
                pictureBox5.Visible = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        public void image()
        {
            if (img)
            {
                pictureBox1.Image = igOraOraOra.Properties.Resources._2;
                img = false;
            }
            else
            {
                img = true;
                pictureBox1.Image = igOraOraOra.Properties.Resources._1;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            //this.Enabled = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            string mon1 = "SELECT m_money FROM meh WHERE m_num = 1";
            OleDbCommand command1 = new OleDbCommand(mon1, connect);
            money = Convert.ToInt32(command1.ExecuteScalar().ToString());
            label1.Text = "Деньги: " + money;
            string lvl1 = "SELECT m_exp FROM meh WHERE m_num = 1";
            OleDbCommand command2 = new OleDbCommand(lvl1, connect);
            lvl = Convert.ToInt32(command2.ExecuteScalar().ToString());
            
            if (lvl >= 310)
                label2.Text = "Уровень: 5";
            else if (lvl >= 150)
                label2.Text = "Уровень: 4";
            else if (lvl >= 70)
                label2.Text = "Уровень: 3";
            else if (lvl >= 20)
                label2.Text = "Уровень: 2";

            string pt1 = "SELECT m_p1 FROM meh WHERE m_num = 1";
            OleDbCommand command3 = new OleDbCommand(pt1, connect);
            p1 = Convert.ToInt32(command3.ExecuteScalar().ToString());
            label3.Text = "Зелья: " + p1;

            string pt2 = "SELECT m_p2 FROM meh WHERE m_num = 1";
            OleDbCommand command4 = new OleDbCommand(pt2, connect);
            p2 = Convert.ToInt32(command4.ExecuteScalar().ToString());
            label4.Text = "х" + p2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }
        

        
    }
}
