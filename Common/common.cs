using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class common
    {
        //public const string DbPath = "Data Source=222.235.141.8; Initial Catalog=TEAM2; User ID= 2JO ; Password = 1234 ";
        public const string DbPath = "Data Source = (local); Initial Catalog  = TEAM2; Integrated Security = SSPI;";
        public static string sTimer = "";
        
        public static void SetComboControl(string sMajorcode, ComboBox cboTemp)
        {
            SqlConnection Connect = new SqlConnection(DbPath);
            DataTable dtTemp = new DataTable();
            try
            {
                // 데이터베이스에 공통기준정보(TB_Standard) 중 품목 유형(ITEMTYPE) 의 정보를
                // 받아 와서 콤보박스에 등록 하기.

                // 1. 데이터베이스 접속 클래스 설정.
                // Common.sConn : Assamble 에 등록 되어 있는 데이터베이스 접속 주소.
                // 데이터 베이스 오픈.
                Connect.Open();
                // 2. 품목유형 데이터 리스트 조회 SQL
                string sSqlSelect = " SELECT ''                         AS ITEMTYPE  ";
                sSqlSelect += "             ,'ALL'                      AS ITEMTYPE  ";
                sSqlSelect += "       UNION ALL                                      ";
                sSqlSelect += "       SELECT ITEMTYPE                   AS ITEMTYPE  ";
                sSqlSelect += "         FROM TB_ITEMMASTER                           ";
                sSqlSelect += $"        GROUP BY ITEMTYPE                            ";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, Connect);
                adapter.Fill(dtTemp);

                cboTemp.DataSource = dtTemp;
                cboTemp.ValueMember = "CODENAME";
                cboTemp.DisplayMember = "CODE_NAME"; // 사용자에게 보여줄 컬럼.
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

        public static void SetComboControl(ComboBox cboItemMaster)
        {
            SqlConnection Connect = new SqlConnection(DbPath);
            DataTable dtTemp = new DataTable();
            try
            {
                // 데이터베이스에 공통기준정보(TB_Standard) 중 품목 유형(ITEMTYPE) 의 정보를
                // 받아 와서 콤보박스에 등록 하기.

                // 1. 데이터베이스 접속 클래스 설정.
                // Common.sConn : Assamble 에 등록 되어 있는 데이터베이스 접속 주소.
                // 데이터 베이스 오픈.
                Connect.Open();
                // 2. 품목유형 데이터 리스트 조회 SQL
                string sSqlSelect = string.Empty;
                sSqlSelect += "       SELECT  ITEMCODE                   AS CODE_ID  ";
                sSqlSelect += "             ,'['+ ITEMCODE + ']' + ITEMNAME AS CODE_NAME ";
                sSqlSelect += "         FROM TB_ITEMMASTER2                          ";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, Connect);
                adapter.Fill(dtTemp);

                cboItemMaster.DataSource = dtTemp;
                cboItemMaster.ValueMember = "CODE_ID";
                cboItemMaster.DisplayMember = "CODE_NAME"; // 사용자에게 보여줄 컬럼.
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

        private DataTable dtTemp = new DataTable();

        public void InitCoilumnGrid(DataGridView dgvTemp, string sColumID, string sColumnText, Type ColumType, int ColumWidth, DataGridViewContentAlignment Align, bool Editable)
        {
            // 그리드를 셋팅하는 함수(메서드)

            // 1. 데이터 테이브에 컬럼과 타입 셋팅
            dtTemp.Columns.Add(sColumID, ColumType);
            // 2. 그리드뷰에 컬럼 셋팅
            dgvTemp.DataSource = dtTemp;
            // 3. 컬럼에 한글 명칭 TEXT 설정
            dgvTemp.Columns[sColumID].HeaderText = sColumnText;
            // 4. 컬럼의 폭 지정
            dgvTemp.Columns[sColumID].Width = ColumWidth;
            // 5. 컬럼 데이터 정렬
            dgvTemp.Columns[sColumID].DefaultCellStyle.Alignment = Align;
            // 6. 컬럼의 수정 여부
            dgvTemp.Columns[sColumID].ReadOnly = !Editable;
        }
    }
}
