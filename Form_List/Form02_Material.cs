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
    public partial class Form02_Material : Common.Base_Form
    {
        public Form02_Material()
        {
            InitializeComponent();
        }

        private void Form02_Material_Load(object sender, EventArgs e)
        {
            common Cm = new common();
            Cm.InitCoilumnGrid(dgvGrid, "ITEMCODE"     , "품목코드", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "ITEMNAME"     , "품목명"  , typeof(string), 300, DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "MATERIALCOUNT", "재고수량", typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "REGISTRANT"   , "입고자"  , typeof(string), 80 , DataGridViewContentAlignment.MiddleLeft, false);
            Cm.InitCoilumnGrid(dgvGrid, "WEARINGDATE"  , "입고일자", typeof(string), 150, DataGridViewContentAlignment.MiddleLeft, false);
        }

        public override void DoInquire()
        {
            string sItemCode = txtItemCode.Text;
            string sItemName = txtItemName.Text;

            SqlConnection sCon = new SqlConnection(common.DbPath);

            try
            {
                sCon.Open();

                SqlDataAdapter Adapter = new SqlDataAdapter("SP_MATERIAl_S1", sCon);

                // Adapter 에게 저장 프로시저 형식의 SQL 을 실행할 것을 등록함.
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 저장 프로시저가 받을 파라매터(인자) 값 설정
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMCODE", sItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("@ITEMNAME", sItemName);

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
