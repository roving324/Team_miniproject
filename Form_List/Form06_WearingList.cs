using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
    public partial class Form06_WearingList : Common.Base_Form
    {
        public Form06_WearingList()
        {
            InitializeComponent();
        }

        public override void DoInquire()
        {


            string sItemCode  = cboItem.SelectedValue.ToString();
            string sStartDate = dtpStart.Text;   // 출시 일자 시작 일자
            string sEndDate   = dtpEnd.Text;     // 출시 일자 종료 일자
            
            SqlConnection Connect = new SqlConnection(common.DbPath);

            try
            {
                Connect.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_WearingList_S1", Connect);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE" , sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@StartDate", sStartDate);
                Adapter.SelectCommand.Parameters.AddWithValue("@EndDate"  , sEndDate);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                dgvGrid.DataSource = dtTemp;

                if (dtTemp.Rows.Count == 0 )
                {
                    MessageBox.Show("조회된 내역이 없습니다.");
                    return;
                }

                // 차트에 표현
                
                // 1. 차트의 초기화
                // Series : 차트를 표현하는 연속된 데이터의 모음.
                chartItem.Series.Clear();
                
                //2. 조회된 DataTable 의 가장 큰 생산 수량을 Y 축에 셋팅
                int iMaxQty = 0;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtTemp.Rows[i]["WEARINGCOUNT"]) > iMaxQty)
                    {
                        iMaxQty = Convert.ToInt32(dtTemp.Rows[i]["WEARINGCOUNT"]);
                    }
                }
                //iMaxQty: 최대수량
                
                DataRow[] dr = dtTemp.Select("WEARINGCOUNT = MAX(WEARINGCOUNT)"); // [] MAX 값이 여러개라면

                chartItem.ChartAreas[0].AxisY.Minimum = 0;
                chartItem.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(dr[0]["WEARINGCOUNT"]) + 5;
                
                // 3. 데이터 테이블을 차트에 바인딩 (매핑)
                chartItem.DataBindTable(dtTemp.DefaultView, "WEARINGDATE");

                // 4. 막대 차트로 표현해야 하는 데이터의 이름과 설정 정보 등록.
                chartItem.Series[0].Name = Convert.ToString(dtTemp.Rows[0]["ITEMNAME"]); // 표현해야 할 데이터의 이름.
                chartItem.Series[0].Color = Color.Blue; // 표현될 차트의 색상.
                chartItem.Series[0].IsValueShownAsLabel = true; // 컬럼 차트 위에 수량을 숫자로 표기.
                
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

        private void Form05_WearingList_Load(object sender, EventArgs e)
        {
            common Cm = new common();

            Cm.InitCoilumnGrid(dgvGrid, "ORDERCODE"   , "발주코드", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"    , "품목코드", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"    , "품목명"  , typeof(string), 250, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "REGISTRANT"  , "입고자"  , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "WEARINGDATE" , "입고일자", typeof(string), 200, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "WEARINGCOUNT", "입고수량", typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "BUSINESS"    , "거래처"  , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);

            dtpEnd.Text = common.sTimer;

            SqlConnection Connect = new SqlConnection(common.DbPath);
            try
            {

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_WearingCbo_S1", Connect);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                cboItem.DataSource    = dtTemp;
                cboItem.ValueMember   = "ITEM_CODE";
                cboItem.DisplayMember = "ITEMCODE"; // 사용자에게 보여줄 컬럼.
                cboItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}
