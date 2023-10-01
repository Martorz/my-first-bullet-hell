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
    public partial class Form3 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=base.mdb;";
        private OleDbConnection connect;
        public int mon, p1, p2;
        int tim1;
        public Form3()
        {
            InitializeComponent();
            connect = new OleDbConnection(connectString);
            connect.Open();
            string mon1 = "SELECT m_money FROM meh WHERE m_num = 1";
            OleDbCommand command1 = new OleDbCommand(mon1, connect);
            mon = Convert.ToInt32(command1.ExecuteScalar().ToString());
            label1.Text = "Ваши деньги: " + mon;
            string pt1 = "SELECT m_p1 FROM meh WHERE m_num = 1";
            OleDbCommand command2 = new OleDbCommand(pt1, connect);
            p1 = Convert.ToInt32(command2.ExecuteScalar().ToString());
            string pt2 = "SELECT m_p2 FROM meh WHERE m_num = 1";
            OleDbCommand command3 = new OleDbCommand(pt2, connect);
            p2 = Convert.ToInt32(command3.ExecuteScalar().ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if ((mon >= 5) && (p1 < 6))
            {
                pictureBox3.Visible = false;
                mon -= 5;
                label1.Text = "Ваши деньги: " + mon;
                string money = "UPDATE meh SET m_money = " + mon + " WHERE m_num = 1";
                OleDbCommand command1 = new OleDbCommand(money, connect);
                command1.ExecuteNonQuery();
                p1 += 1;
                string pt = "UPDATE meh SET m_p1 = " + p1 + " WHERE m_num = 1";
                OleDbCommand command2 = new OleDbCommand(pt, connect);
                command2.ExecuteNonQuery();
                pictureBox1.Image = igOraOraOra.Properties.Resources.mmagg2;
                timer1.Enabled = true;
            }
            else if (mon < 5)
                MessageBox.Show("Не хватает монет.");
            else if (p1 >= 6)
                MessageBox.Show("Не хватает места для зелий.");
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (mon >= 10)
            {
                if (p2 >= 8)
                    MessageBox.Show("Вы выпили слишком много зелий. Монстры стали сильнее.");
                pictureBox4.Visible = false;
                mon -= 10;
                label1.Text = "Ваши деньги: " + mon;
                string money = "UPDATE meh SET m_money = " + mon + " WHERE m_num = 1";
                OleDbCommand command1 = new OleDbCommand(money, connect);
                command1.ExecuteNonQuery();
                p2 *= 2;
                string pt = "UPDATE meh SET m_p2 = " + p2 + " WHERE m_num = 1";
                OleDbCommand command2 = new OleDbCommand(pt, connect);
                command2.ExecuteNonQuery();
                pictureBox1.Image = igOraOraOra.Properties.Resources.mmagg2;
                timer1.Enabled = true;
            }
            else if (mon < 10)
                MessageBox.Show("Не хватает монет.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tim1 == 1)
            {
                pictureBox1.Image = igOraOraOra.Properties.Resources.mmagg1;
                timer1.Enabled = false;
                tim1 = 0;
            }
            else
                tim1++;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}
