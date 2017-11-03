using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test1.Properties;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open || textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(*) from " + textBox1.Text.Trim();
                    cmd.CommandType = CommandType.Text;
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    label1.Text = "表中共有：" + i.ToString() + "条数据";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        SqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server =DESKTOP-SEGMED4;database=db_test;uid=sa;pwd=123456");
            conn.Open();
        }
    }
}
