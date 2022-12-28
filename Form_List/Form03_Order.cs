using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
    public partial class Form03_Order : Form
    {
        public Form03_Order()
        {
            InitializeComponent();
        }

        private void Form03_Order_Load(object sender, EventArgs e)
        {
            common Cm = new common();
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"     , "품목코드"    , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"     , "품목명"      , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "MATERIALCOUNT", "재고수량"    , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "REGISTRANT"   , "입고자"      , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "WEARINGDATE"  , "입고일자"    , typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ORDERFLAG"    , "발주대상여부", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "NOWORDERCOUNT", "현재발주수량", typeof(string), 150, DataGridViewContentAlignment.MiddleRight, false);

            cboOderFlag.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender = null, EventArgs e = null)
        {
            string sItemCode = txtItemCode.Text;
            string sItemName = txtItemName.Text;
            string sOderFlag = cboOderFlag.SelectedItem.ToString();

            if (sOderFlag == "ALL") sOderFlag = "";

            SqlConnection sCon = new SqlConnection(common.DbPath);

            try
            {
                sCon.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ORDER_S1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME", sItemName);
                Adapter.SelectCommand.Parameters.AddWithValue("@OderFlag", sOderFlag);

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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dgvGrid.RowCount == 0) return;
            string sItemCode = Convert.ToString(dgvGrid.CurrentRow.Cells["ITEMCODE"].Value);
            string sBusiness = txtBusiness.Text;
            string sOrderCount = txtOrderCount.Text;
            string sOrderCode = sItemCode;
            if (sOrderCount == "") 
            {
                MessageBox.Show("수량을 입력해여합니다.");
                return;
            }
            else if (Convert.ToInt32(sOrderCount) < 0)
            {
                MessageBox.Show("0 보다 작은 수는 입력할 수 없습니다.");
                return;
            }
            bool bFlag = false;
            SqlConnection sCon = new SqlConnection(common.DbPath);
            try
            {
                sCon.Open();
                SqlDataAdapter ADPT = new SqlDataAdapter("SP_ORDERFLAG_S1", sCon);
                ADPT.SelectCommand.CommandType = CommandType.StoredProcedure;

                ADPT.SelectCommand.Parameters.AddWithValue("@OrderCount", sOrderCount);
                ADPT.SelectCommand.Parameters.AddWithValue("@ItemCode"  , sItemCode);



                DataTable dtTable = new DataTable();
                ADPT.Fill(dtTable);

                if (Convert.ToString(dtTable.Rows[0][0]) == "0")
                {
                    if (MessageBox.Show("안정재고보다 적게 입력하였습니다. 발주하시겠습니까?", "발주여부", MessageBoxButtons.YesNo) == DialogResult.No) return;
                }
                if (Convert.ToString(dtTable.Rows[0][0]) == "1")
                {
                    if (MessageBox.Show("적정재고보다 높게 입력하였습니다. 발주하시겠습니까?", "발주여부", MessageBoxButtons.YesNo) == DialogResult.No) return;
                }
                if (MessageBox.Show($"{sItemCode}를 {sOrderCount}개 발주하겠습니까?", "발주등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

                int iTest = Convert.ToInt32(dtTable.Rows[1][0]);
                sOrderCode += Convert.ToString(iTest + 1);

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ORDER_I1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@OrderCode", sOrderCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@ItemCode", sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@Business", sBusiness);
                Adapter.SelectCommand.Parameters.AddWithValue("@OrderCount", sOrderCount);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                bFlag = true;
                btnSearch_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
                if (bFlag) MessageBox.Show("발주가 완료되었습니다.");
            }
        }
    }
}
