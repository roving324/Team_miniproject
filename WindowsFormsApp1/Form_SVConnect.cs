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

namespace WindowsFormsApp1
{
    public partial class Form_SVConnect : Form
    {
        public Form_SVConnect()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            SqlConnection sCon = new SqlConnection(common.DbPath);
            try
            {
                sCon.Open();
            }
            catch
            {
                MessageBox.Show("서버연결에 실패하였습니다.");
                Environment.Exit(0);
            }
            finally
            {
                if (sCon != null) sCon.Close();

                this.Close();
            }
        }
    }
}
