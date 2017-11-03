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
                //判断连接状态
                if (conn.State == ConnectionState.Open || textBox1.Text != "")
                {
                    //创建一个command对象
                    SqlCommand cmd = new SqlCommand();
                    //选择连接属性
                    cmd.Connection = conn;
                    //设置命令文本
                    cmd.CommandText = "select count(*) from " + textBox1.Text.Trim();
                    //设置应用类型
                    cmd.CommandType = CommandType.Text;
                    //执行select 语句
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
            //创建数据库连接对象
            conn = new SqlConnection("server =DESKTOP-SEGMED4;database=db_test;uid=sa;pwd=123456");
            conn.Open();
        }
    }
}
