using Common;
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

namespace Form_List
{
    public partial class Form04_OrderList : Form
    {
        public Form04_OrderList()
        {
            InitializeComponent();
        }

        private void Form04_OderList_Load(object sender, EventArgs e)
        {
            common Cm = new common();

            Cm.InitCoilumnGrid(dgvGrid, "ORDERCODE"   , "발주코드" , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"    , "품목코드" , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"    , "품목명"   , typeof(string), 250, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "OWNER"       , "발주자"   , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ORDERDATE"   , "발주일자" , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ORDERCOUNT"  , "발주수량" , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "WEARINGCOUNT", "입고수량" , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "BUSINESS"    , "거래처"   , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);

            dtpEnd.Text = common.sTimer;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sItemCode  = txtItemCode.Text; // 품목코드 일력 정보
            string sItemName  = txtItemName.Text; // 품목명 입력 정보
            string sOwner     = txtOwner.Text;    // 발주자 이름
            string sStartDate = dtpStart.Text;    // 출시 일자 시작 일자
            string sEndDate   = dtpEnd.Text;      // 출시 일자 종료 일자

            SqlConnection sCon = new SqlConnection(common.DbPath);
            try
            {
                sCon.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ORDERLIST_S1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE" , sItemCode );
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME" , sItemName );
                Adapter.SelectCommand.Parameters.AddWithValue("@OWNER"    , sOwner    );
                Adapter.SelectCommand.Parameters.AddWithValue("@StartDate", sStartDate);
                Adapter.SelectCommand.Parameters.AddWithValue("@EndDate"  , sEndDate  );

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                dgvGrid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }
    }
}
