using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class Base_Form : Form
    {
        public Base_Form()
        {
            InitializeComponent();
        }

        public virtual void DoInquire()
        {

        }
        public virtual void DoNew()
        {

        }
        public virtual void DoDelete()
        {

        }
        public virtual void DoSave() { }
    }
}

