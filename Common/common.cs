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
        public static string sTimer = "";
        public static string DbPath = "";
        //public const string DbPath = "Data Source=222.235.141.8; Initial Catalog=TEAM2; User ID= 2JO ; Password = 1234 ";
        //public const string DbPath = "Data Source = (local); Initial Catalog  = TEAM2; Integrated Security = SSPI;";

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
