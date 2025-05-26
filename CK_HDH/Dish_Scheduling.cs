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
    public partial class Dish_SchedulingForm : Form
    {
        int processCount = 1;
        int defautWidth = 150;

        public Dish_SchedulingForm()
        {
            InitializeComponent();
        }

        private void Dish_SchedulingForm_Load(object sender, EventArgs e)
        {
            SetupDgvInput(processCount);
            SetupDgvOutput(processCount);
            SetupAVG(processCount);
            rdbFCFS.Checked = true; 
        }

        private void SetupDgvInput(int processcount)
        {
            dgvInput.Rows.Clear();
            dgvInput.Columns.Clear();
            dgvInput.AllowUserToAddRows = false;
            dgvInput.Columns.Add("Process", "Process");
            dgvInput.Columns.Add("ArrivalTime", "Arrival Time");
            dgvInput.Columns.Add("BurstTime", "Burst Time");
            dgvInput.Columns["Process"].Width = defautWidth;
            dgvInput.Columns["Process"].ReadOnly = true;
            dgvInput.Columns["ArrivalTime"].Width = defautWidth;
            dgvInput.Columns["BurstTime"].Width = defautWidth;

            for (int i = 0; i < processcount; i++)
            {
                dgvInput.Rows.Add($"P{i}", "0", "0");
            }
        }

        private void SetupDgvOutput(int processcount)
        {
            dgvOutput.Rows.Clear();
            dgvOutput.Columns.Clear();
            dgvOutput.AllowUserToAddRows = false;
            dgvOutput.Columns.Add("TAT", "Turn Around Time");
            dgvOutput.Columns.Add("WT", "Waiting Time");
            dgvOutput.Columns["TAT"].Width = defautWidth;
            dgvOutput.Columns["WT"].Width = defautWidth;
            dgvOutput.Columns["TAT"].ReadOnly = true;
            dgvOutput.Columns["WT"].ReadOnly = true;
            dgvOutput.Columns["TAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOutput.Columns["WT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < processcount; i++)
            {
                dgvOutput.Rows.Add("0", "0");
            }
        }

        private void SetupAVG(int processcount)
        {
            dgvAVG.Rows.Clear();
            dgvAVG.Columns.Clear();
            dgvAVG.AllowUserToAddRows = false;
            dgvAVG.Columns.Add("TAT", "Turn Around Time");
            dgvAVG.Columns.Add("WT", "Waiting Time");
            dgvAVG.Columns["TAT"].Width = defautWidth;
            dgvAVG.Columns["WT"].Width = defautWidth;
            dgvAVG.Columns["TAT"].ReadOnly = true;
            dgvAVG.Columns["WT"].ReadOnly = true;
            dgvAVG.Columns["TAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAVG.Columns["WT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAVG.Rows.Add("0", "0");
        }

        public class ProcessData
        {
            public string Name { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int CompletionTime { get; set; }
            public int TurnAroundTime { get; set; }
            public int WaitingTime { get; set; }
        }

        private List<ProcessData> GetProcesses()
        {
            var processes = new List<ProcessData>();

            for (int i = 0; i < processCount; i++)
            {
                var name = dgvInput.Rows[i].Cells["Process"].Value.ToString();
                var arrival = int.Parse(dgvInput.Rows[i].Cells["ArrivalTime"].Value.ToString());
                var burst = int.Parse(dgvInput.Rows[i].Cells["BurstTime"].Value.ToString());

                processes.Add(new ProcessData
                {
                    Name = name,
                    ArrivalTime = arrival,
                    BurstTime = burst
                });
            }

            return processes;
        }

        private List<ProcessData> FCFS(List<ProcessData> processes)
        {
            // Sắp xếp theo ArrivalTime
            var sorted = processes.OrderBy(p => p.ArrivalTime).ToList();

            int currentTime = 0;
            foreach (var p in sorted)
            {
                if (currentTime < p.ArrivalTime)
                    currentTime = p.ArrivalTime;

                p.CompletionTime = currentTime + p.BurstTime;
                p.TurnAroundTime = p.CompletionTime - p.ArrivalTime;
                p.WaitingTime = p.TurnAroundTime - p.BurstTime;

                currentTime = p.CompletionTime;
            }

            return sorted;
        }

        private void DisplayOutput(List<ProcessData> processes)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                dgvOutput.Rows[i].Cells["TAT"].Value = processes[i].TurnAroundTime;
                dgvOutput.Rows[i].Cells["WT"].Value = processes[i].WaitingTime;
            }
        }

        private void DisplayAVGOutput(List<ProcessData> processes)
        {
            int totalTAT = processes.Sum(p => p.TurnAroundTime);
            int totalWT = processes.Sum(p => p.WaitingTime);
            int count = processes.Count;
            dgvAVG.Rows[0].Cells["TAT"].Value = (double)totalTAT / count;
            dgvAVG.Rows[0].Cells["WT"].Value = (double)totalWT / count;
        }

        private void DrawGanttChart(List<ProcessData> processes)
        {
            pnGantt.Controls.Clear();

            int x = 0;
            int unitWidth = 30;
            int height = 50;

            foreach (var p in processes)
            {
                int width = p.BurstTime * unitWidth;

                // Thời gian bắt đầu
                Label startTime = new Label();
                startTime.Text = (p.CompletionTime - p.BurstTime).ToString();
                startTime.Location = new Point(x, height + 15);
                startTime.AutoSize = true;
                pnGantt.Controls.Add(startTime);

                Label box = new Label();
                box.Text = p.Name;
                box.TextAlign = ContentAlignment.MiddleCenter;
                box.BackColor = Color.LightBlue;
                box.BorderStyle = BorderStyle.FixedSingle;
                box.Location = new Point(x, 10);
                box.Size = new Size(width, height);

                pnGantt.Controls.Add(box);

                x += width;
            }

            // Thời gian kết thúc cuối cùng
            Label endTime = new Label();
            endTime.Text = processes.Last().CompletionTime.ToString();
            endTime.Location = new Point(x, height + 15);
            endTime.AutoSize = true;
            pnGantt.Controls.Add(endTime);
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void rdbFCFS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbSJF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbSRT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbRR_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            processCount++;
            SetupDgvInput(processCount);
            SetupDgvOutput(processCount);

        }

        private void btnRemoveProcess_Click(object sender, EventArgs e)
        {
            processCount--;
            if (processCount < 1)
            {
                processCount = 1;
            }
            SetupDgvInput(processCount);
            SetupDgvOutput(processCount);
        }

        private void btnRunFCFS_Click(object sender, EventArgs e)
        {
            var processes = GetProcesses();

            if (rdbFCFS.Checked)
            {
                var result = FCFS(processes);
                DisplayOutput(result);
                DrawGanttChart(result);
                DisplayAVGOutput(result);
            }
        }
    }
}
