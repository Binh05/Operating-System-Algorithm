using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_HDH
{
    public partial class BankerForm : Form
    {
        public BankerForm()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
}
