using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project2test
{
    public partial class Detailticket : Form
    {
        public Detailticket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `tingticket`(`namelastname`, `location`, `seatnum`, `price`) VALUES (@nm, @lc, @sn, @pc)", db.GetConnection());

            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@lc", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@sn", MySqlDbType.Text).Value = textBox3.Text;
            command.Parameters.Add("@pc", MySqlDbType.VarChar).Value = textBox4.Text;


            db.openConnection();

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=user");
            connection.Open();
            string sql = "UPDATE seat SET status = '" + textBox1.Text + "' WHERE seatno = '" + textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteReader();

            connection.Close();




            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("จองตั๋วสำเร็จ", "ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR!");
            }
            db.closeConnection();
        }


    }

        
        
}

