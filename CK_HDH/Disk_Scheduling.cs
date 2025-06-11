using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CK_HDH
{
    public partial class Dish_SchedulingForm : Form
    {
        int trackTotal = 0;
        int currentHeadPos = -1;

        public Dish_SchedulingForm()
        {
            InitializeComponent();
        }

        private void Dish_SchedulingForm_Load(object sender, EventArgs e)
        {
            cbxAlgorithm.Items.Add("FCFS");
            cbxAlgorithm.Items.Add("SSTF");
            cbxAlgorithm.Items.Add("SCAN");
            cbxAlgorithm.Items.Add("C-SCAN");
            cbxAlgorithm.SelectedIndex = 0;
            label4.Left = (this.ClientSize.Width - label1.Width) / 2 - label4.Width / 3;
        }

        public class Process
        {
            public int cylinder { get; set; }
            public int track { get; set; }
            public int totalTrack {  get; set; }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            List<int> Re = getRequest();
            if (Re == null) return;
            if (string.IsNullOrEmpty(txtHead.Text))
            {
                MessageBox.Show("Vui long nhap Initial cylinder");
                return;
            }
            else
            {
                if (!Regex.IsMatch(txtHead.Text, "^\\d+$")) {
                    MessageBox.Show("Nhập 1 số hợp lệ");
                    return;
                }
                currentHeadPos = int.Parse(txtHead.Text);
            }
            var al = cbxAlgorithm.SelectedItem.ToString();
            trackTotal = 0;

            
            switch (al)
            {
                case "FCFS":
                    AlFCFS(Re);
                    break;
                case "SSTF":
                    AlSSTF(Re);
                    break;
                case "SCAN":
                    AlSCAN(Re);
                    break;
                case "C-SCAN":
                    AlC_SCAN(Re);
                    break;
                default:
                    MessageBox.Show("Vui long chon thuat toan");
                    return;
            }
        }
        private List<int> getRequest()
        {
            string Re = txtRequest.Text.Trim();

            string pattern = @"^\d+( \d+)*$";

            if (string.IsNullOrEmpty(Re))
            {
                MessageBox.Show("Vui long nhap requests");
                return null;
            }
            else if (!Regex.IsMatch(Re, pattern))
            {
                MessageBox.Show("Vui long nhap request hop le");
                return null;
            }

            List<int> request = Re.Split(' ').Select(s => int.Parse(s)).ToList();

            return request;
        }
        private void AlFCFS(List<int> requests)
        {
            requests.Insert(0, currentHeadPos);
            List<Process> processs = new List<Process>();
            
            foreach (int req in requests)
            {
                int track = Math.Abs(currentHeadPos - req); 
                trackTotal += track;
                currentHeadPos = req;
                processs.Add(new Process { cylinder = req, track = track, totalTrack = trackTotal });
            }
            VeBieuDoGantt(processs);
        }
        private void AlSSTF(List<int> req)
        {
            List<Process> processes = new List<Process>();
            
            int current = currentHeadPos;
            processes.Add(new Process { cylinder = current, track = 0, totalTrack = 0 });

            while (req.Any())
            {
                int closest = req.OrderBy(x => Math.Abs(x - current)).First();

                int track = Math.Abs(closest - current);
                trackTotal += track;
                current = closest;
                processes.Add(new Process { cylinder = current, totalTrack = trackTotal, track = track });
                req.Remove(closest);
            }
            VeBieuDoGantt(processes);
        }
        private void AlSCAN(List<int> req)
        {
            List<Process> process = new List<Process>();

            req.Add(currentHeadPos);
            req.Sort();
            int index = req.BinarySearch(currentHeadPos);

            process.Add(new Process { cylinder = currentHeadPos, track = 0, totalTrack = 0 });

            while (index < req.Count - 1)
            {
                int track = Math.Abs(req[index + 1] - req[index]);
                trackTotal += track;
                req.RemoveAt(index);
                process.Add(new Process { cylinder = req[index], totalTrack = trackTotal, track = track });
            }

            while (req.Count > 1)
            {
                int track = Math.Abs(req[index - 1] - req[index]);
                trackTotal += Math.Abs(req[index - 1] - req[index]);
                req.RemoveAt(index);
                index--;
                process.Add(new Process { cylinder = req[index], totalTrack = trackTotal, track = track });
            }

            VeBieuDoGantt(process);
        }
        private void AlC_SCAN(List<int> req)
        {
            List<Process> processs = new List<Process>();
            processs.Add(new Process { cylinder = currentHeadPos, totalTrack = 0, track = 0 });

            req.Add(currentHeadPos);
            req.Sort();
            int index = req.BinarySearch(currentHeadPos);

            while (req.Count > 1)
            {
                if (index == req.Count - 1)
                {

                    int track2 = Math.Abs(req[0] - req[index]);
                    trackTotal += track2;
                    req.RemoveAt(index);
                    index = 0;
                    processs.Add(new Process { cylinder = req[index], totalTrack = trackTotal, track = track2 });
                    continue;
                }

                int track = Math.Abs(req[index + 1] - req[index]);
                trackTotal += track;
                req.RemoveAt(index);
                processs.Add(new Process { cylinder = req[index], totalTrack = trackTotal, track = track });
            }

            VeBieuDoGantt(processs);
        }
        private void print_Kq(string kq)
        {
            MessageBox.Show("Kq = " + kq);
            lbTotalTrack.Text = trackTotal.ToString();
        }
        private void VeBieuDoGantt(List<Process> processes)
        {
            lbTotalTrack.Text = trackTotal.ToString();

            panelGanttChart.Controls.Clear(); // Xoá biểu đồ cũ
            panelGanttChart.AutoScroll = true;

            int pixelPerUnit = 3; // Mỗi đơn vị thời gian = 3px
            int currentLeft = 10; // Vị trí bắt đầu
            int margin = 2;


            foreach (var p in processes)
            {
                // Tạo label đại diện tiến trình
                Label lbl = new Label();
                lbl.Text = p.track.ToString();
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.BackColor = Color.LightBlue;
                lbl.Width = p.track * pixelPerUnit;
                lbl.Height = 40;
                lbl.Left = currentLeft;
                lbl.Top = 15;

                panelGanttChart.Controls.Add(lbl);

                // Thêm cylinder tren mỗi tiến trình
                Label timeLabel = new Label();
                timeLabel.Text = p.cylinder.ToString();
                timeLabel.Left = currentLeft + lbl.Width - 15;

                timeLabel.Top = lbl.Bottom - margin - lbl.Height - 25;
                timeLabel.TextAlign = ContentAlignment.BottomCenter;
                timeLabel.Width = 30;
                timeLabel.Font = new Font(timeLabel.Font.FontFamily, 8);

                panelGanttChart.Controls.Add(timeLabel);

                // Thêm track dưới mỗi tiến trình
                Label trackLabel = new Label();
                trackLabel.Text = p.totalTrack.ToString();
                trackLabel.Left = currentLeft + lbl.Width - 15;

                trackLabel.Top = lbl.Bottom + margin;
                trackLabel.TextAlign = ContentAlignment.TopCenter;
                trackLabel.Width = 30;
                trackLabel.Font = new Font(timeLabel.Font.FontFamily, 8);

                panelGanttChart.Controls.Add(trackLabel);

                currentLeft += lbl.Width;
            }

            // Căn giữa panelGanttChart theo chiều ngang trong Form
            panelGanttChart.Width = Math.Min(782, currentLeft + 30);
            panelGanttChart.Left = Math.Max(0, (panelGanttChart.Parent.Width - panelGanttChart.Width) / 2);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panelGanttChart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
