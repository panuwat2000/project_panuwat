﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2test
{
    public partial class Createticket : Form
    {
        string[] status_seat = { "", "", "", "", "", "", "", "", "", "" };
        
        public Createticket()
        {
            InitializeComponent();
        }

        private void Createticket_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=user");
            try 
            {
                connection.Open();
                string sql = "SELECT * FROM seat";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while(reader.Read())
                {
                    status_seat[i] = reader.GetString("status");
                    i = i + 1;
                }
                connection.Close();
                if(status_seat[0] == "")
                {
                    comboBox2.Items.Add("A01");
                    
                }
                if(status_seat[1] == "")
                {
                    comboBox2.Items.Add("A02");
                }
                if(status_seat[2] == "")
                {
                    comboBox2.Items.Add("A03");

                }
                if(status_seat[3] == "")
                {
                    comboBox2.Items.Add("A04");
                }
                if(status_seat[4] == "")
                {
                    comboBox2.Items.Add("A05");

                }
                if(status_seat[5] == "")
                {
                    comboBox2.Items.Add("A06");
                }
                if(status_seat[6] == "")
                {
                    comboBox2.Items.Add("A07");

                }
                if (status_seat[7] == "")
                {
                    comboBox2.Items.Add("A08");
                }
                if(status_seat[8] == "")
                {
                    comboBox2.Items.Add("A09");

                }
                if(status_seat[9] == "")
                {
                    comboBox2.Items.Add("A10");
                }



            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูลที่นั่ง");
            }
            



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = comboBox1.SelectedItem.ToString();
            switch (str)
            {
                case "กรุงเทพฯ": textBox2.Text = "300"; break;
                case "เชียงใหม่": textBox2.Text = "310"; break;
                case "สมุทรปราการ": textBox2.Text = "320"; break;
                case "ลำปาง": textBox2.Text = "330"; break;
                case "เชียงราย": textBox2.Text = "340"; break;
                case "ยะลา": textBox2.Text = "350"; break;
                case "อุบลราชธานี": textBox2.Text = "360"; break;
                case "มหาสารคาม": textBox2.Text = "370"; break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rakabus = 500;
            int food = 0;
            int drink = 0;
            int fooddrink = 0;
            int special;
            int sum = 0;

            if(checkBox1.Checked)
            {
                food = 100;
            }
            if(checkBox2.Checked)
            {
                drink = 50;
            }
            if(checkBox3.Checked)
            {
                fooddrink = 120;
            }

            special = food + drink + fooddrink;
            sum =  rakabus + special; 

            textBox3.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Detailticket dtfrm = new Detailticket();
            dtfrm.textBox1.Text = textBox1.Text;
            dtfrm.textBox2.Text = comboBox1.Text;
            dtfrm.textBox3.Text = comboBox2.Text;
            dtfrm.textBox4.Text = textBox3.Text;
            dtfrm.Show();
        }
    }
}
