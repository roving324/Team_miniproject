using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            Form_Login _Login = new Form_Login();
            _Login.ShowDialog();
            if(_Login.Tag == null) Environment.Exit(0);
            Form_SVConnect SVC = new Form_SVConnect();
            SVC.ShowDialog();
            InitializeComponent();
        }

        private void ToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.Dll");
            // 클릭한 매뉴의 CS 파일 타입 확인 및 추출
            Type typeform = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);
            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeform);
            // 탭 페이지에 폼을 추가하여 오픈한다.

            bool bFlag = false;
            for (int i = 0; i <= myTabControlr.TabPages.Count - 1; i++)
            {
                // 클릭한 매뉴의 이름과 오픈되어있는 페이지의 이름이 같다면.
                if (myTabControlr.TabPages[i].Name == $"{e.ClickedItem.Name}")
                {
                    myTabControlr.SelectedTab = myTabControlr.TabPages[i];
                    bFlag = true;
                    break;
                }
            }
            if (!bFlag) myTabControlr.AddForm(FormMdi);
            stsFormName.Text = e.ClickedItem.Name.ToString(); // 품 클릭 시 품이름 띄우기
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            stsFormName.Text = "";
            common.sTimer = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }

        private void TSButton_Click(object sender, EventArgs e)
        {
            if (myTabControlr.TabPages.Count == 0) return;
            ToolStripButton tsButton = (ToolStripButton)sender;
            string sBtnName = tsButton.Text;
            DoFuncition(sBtnName);
        }

        void DoFuncition(string sName)
        {
            if (myTabControlr.SelectedTab.Controls[0] is Base_Form == false) return;
            Base_Form Child = (Base_Form)myTabControlr.SelectedTab.Controls[0];
            switch (sName)
            {
                case "조회": Child.DoInquire();
                    break;
                case "닫기":
                    if (myTabControlr.TabPages.Count > 0) myTabControlr.SelectedTab.Dispose();
                    break;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();
        }
    }
}
