using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;    // SQL Server용 DB연결 클라이언트 네임스페이스
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf09_dbHandling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {   
            // 1. 연결문자열 생성
            string connectionString     
                = "Data Source=localhost;Initial Catalog=Northwind;" +
                "Persist Security Info=True;User ID=sa;Password=12345";
            // 2. DB 연결을 위해서 Connection 객체 생성                 - 연결문자열 없이 객체 생성X 
            SqlConnection conn = new SqlConnection(connectionString);   // 첫 번째 방법
            // conn.ConnectionString = connectionString;                // 두 번째 방법

            // 3. 객체를 통해서 DB 연결
            conn.Open();

            // 4. DB 처리를 위한 쿼리 작성
            // 5. SqlDataAdapter 생성
            string selQuery = @"SELECT CustomerID
                                     , CompanyName
                                     , ContactName
                                     , ContactTitle
                                     , Address
                                     , City
                                     , Region
                                     , PostalCode
                                     , Country
                                     , Phone
                                     , Fax
                                  FROM Customers";  // @ : 여러줄( == ''' ''')

            //SqlCommand selCmnd = new SqlCommand(selQuery, conn);
            ////selCmnd.Connection = conn;    // 위에 두 번재 매개변수로 합침
            ///
            SqlDataAdapter adapter = new SqlDataAdapter(selQuery, conn);        // Query를 어댑터 객체로 보냄

            /* 패스
             5. 리더객체 생성 <--- 값 넘겨줌
            //SqlDataReader reader = selCmnd.ExecuteReader();

             6. 데이터 reader에 있는 데이터(Read)를 데이터셋으로 보내기
            //DataSet ds = new DataSet();
            */

            // 6. 데이터셋으로 전달
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // 7. 데이터그리드뷰에 바인딩하기 위한 BindingSource 생성
            BindingSource source = new BindingSource();

            // 8. 데이터그리드뷰의 DataSource에 데이터셋 할당
            source.DataSource = ds.Tables[0];       // DataSet은 여러개의 테이블 담을 수 있음 
            DgvNorthwind.DataSource = source;

            // 9. DB close
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
