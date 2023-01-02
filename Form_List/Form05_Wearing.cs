using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Runtime.Remoting.Contexts;


namespace Form_List
{
    public partial class Form05_Wearing : Common.Base_Form
    {
        public Form05_Wearing()
        {
            InitializeComponent();
        }

        private void Form1_Order_Load(object sender, EventArgs e)
        {
            common Cm = new common();

            Cm.InitCoilumnGrid(dgvGrid, "ORDERCODE"   , "발주코드"    , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"    , "품목코드"    , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "OWNER"       , "발주자"      , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ORDERDATE"   , "발주일자"    , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"    , "품목명"      , typeof(string), 250, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ORDERCOUNT"  , "발주수량"    , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "REMAINCOUNT" , "발주진행수량", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "BUSINESS"    , "거래처"      , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);

            dtpEnd.Text = common.sTimer;
        }

        public override void DoInquire()
        {
            string sItemCode  = txtItemCode.Text; // 품목코드 일력 정보
            string sItemName  = txtItemName.Text; // 품목명 입력 정보
            string sStartDate = dtpStart.Text;    // 출시 일자 시작 일자
            string sEndDate   = dtpEnd.Text;      // 출시 일자 종료 일자

            SqlConnection Connect = new SqlConnection(common.DbPath);

            try
            {
                Connect.Open();

                // 품목 마스터 테이블에서 데이터 를 조회 할 SQL 구문 작성
                

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ORDER_S2", Connect);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE" , sItemCode );
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME" , sItemName );
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
                Connect.Close();
            }
        }

        private void btnWearing_Click(object sender, EventArgs e)
        {
            if (dgvGrid.RowCount == 0) return;
            string sOrderCode = Convert.ToString(dgvGrid.CurrentRow.Cells["ORDERCODE"].Value);
            string sItemCode = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMCODE"].Value);
            string sRegistrant   = txtRegistrant.Text;   // 입고자
            int i = 0;
            if (sRegistrant == "")
            {
                MessageBox.Show("입고자를 입력해야합니다.");
                return;
            }
            bool iFlag = int.TryParse(txtWearingCount.Text,out i);
            if(!iFlag)
            {
                MessageBox.Show("값을 입력해야합니다.");
                return;
            }
            string sWearingCount = txtWearingCount.Text; // 입고수량
            bool bFlag = false;

            if (Convert.ToInt32(sWearingCount) <= 0)
            {
                MessageBox.Show("0이하의 값을 입력할 수 없습니다.");
                return;
            }
            SqlConnection Connect = new SqlConnection(common.DbPath);
            try
            {
                Connect.Open();
                SqlDataAdapter ADPT = new SqlDataAdapter("SP_ORDERFLAG_S2", Connect);
                ADPT.SelectCommand.CommandType = CommandType.StoredProcedure;
                ADPT.SelectCommand.Parameters.AddWithValue("@ItemCode", sItemCode);
                ADPT.SelectCommand.Parameters.AddWithValue("@WearingCount", sWearingCount);
                DataTable dtTable = new DataTable();
                ADPT.Fill(dtTable);

                if (Convert.ToString(dtTable.Rows[0][0]) == "1")
                {
                    if (MessageBox.Show("발주요구수량보다 높게 입력하였습니다. 입고하시겠습니까?", "입고여부", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    bFlag = true;
                }
                if (!bFlag)
                {
                    if (MessageBox.Show($"발주코드 {sOrderCode}에 {sWearingCount}개를 입고하시겠습니까?", "입고여부", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        bFlag = false;
                        return;
                    }
                }
                bFlag = false;

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ORDER_I2", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;



                Adapter.SelectCommand.Parameters.AddWithValue("@ItemCode"    , sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@OrderCode"   , sOrderCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@Registrant"  , sRegistrant);
                Adapter.SelectCommand.Parameters.AddWithValue("@WearingCount", sWearingCount);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                bFlag = true;
                DoInquire();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
                if(bFlag) MessageBox.Show("정상적으로 입고되었습니다.");
            }

        }
    }
}
