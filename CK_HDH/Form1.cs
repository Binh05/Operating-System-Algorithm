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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankerForm bankerForm = new BankerForm();
            bankerForm.Tag = this;
            bankerForm.Show(this);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Page_ReplacementForm pageForm = new Page_ReplacementForm();
            pageForm.Tag = this;
            pageForm.Show(this);
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CPU_Distribution_Click(object sender, EventArgs e)
        {
            CPU_DistributionForm cpuForm = new CPU_DistributionForm();
            cpuForm.Tag = this;
            cpuForm.Show(this);
            Hide();
        }

        private void Dish_Scheduling_Click(object sender, EventArgs e)
        {
            Dish_SchedulingForm dishForm = new Dish_SchedulingForm();
            dishForm.Tag = this;
            dishForm.Show(this);
            Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
