using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace WindowsFormsApp1
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender = null, EventArgs e = null)
        {
            common.DbPath = $"Data Source=27.35.129.96; Initial Catalog=TEAM2; User ID= {txtUserID.Text} ; Password = {txtUserPW.Text} ";
            this.Tag = true;
            this.Close();
        }

        private void txtUserPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click();
        }
    }
}
