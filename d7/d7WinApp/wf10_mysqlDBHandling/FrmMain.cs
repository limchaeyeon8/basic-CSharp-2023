using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf10_mysqlDBHandling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // MySQL용 연결 문자열
            string connectiongString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345;";    // 직접쳐야함
            MySqlConnection conn = new MySqlConnection(connectiongString);

            conn.Open();

            string selQuery = @"SELECT memberIdx
	                                 , Names
	                                 , Levels
                                     , Addr
                                     , Mobile
                                     , Email
                                FROM membertbl";
        
            MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);

            // 데이터셋 생성
            DataSet ds = new DataSet(); 
            adapter.Fill(ds);

            DgvMember.DataSource = ds.Tables[0];

            conn.Close();
        }
    }
}
