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
    public partial class Form01_ItemMaster : Common.Base_Form
    {
        public Form01_ItemMaster()
        {
            InitializeComponent();
        }

        private void Form01_ItemMaster_Load(object sender, EventArgs e)
        {
            common Cm = new common();
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"   , "품목코드", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"   , "품목명"  , typeof(string), 300, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMTYPE"   , "품목타입", typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "STABLESTOCK", "안정재고", typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "PROPERSTOCK", "적정재고", typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);

            SqlConnection Connect = new SqlConnection(common.DbPath);
            try
            {

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ITEMCbo_S1", Connect);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                cboItemType.DataSource    = dtTemp;
                cboItemType.ValueMember   = "ITEM_TYPE";
                cboItemType.DisplayMember = "ITEMTYPE"; // 사용자에게 보여줄 컬럼.
                cboItemType.SelectedIndex = 0;

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

        public override void DoInquire()
        {
            string sItemCode = txtItemCode.Text;
            string sItemName = txtItemName.Text;
            string sItemType = cboItemType.SelectedValue.ToString();

            SqlConnection sCon = new SqlConnection(common.DbPath);

            try
            {
                sCon.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_ITEMMASTER_S1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME", sItemName);
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMTYPE", sItemType);

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
