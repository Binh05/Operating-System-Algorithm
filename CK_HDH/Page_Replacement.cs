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
    public partial class Page_ReplacementForm : Form
    {
        public Page_ReplacementForm()
        {
            InitializeComponent();
        }

        List<int> referenceString = new List<int>();

        private void Exit_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void Page_ReplacementForm_Load(object sender, EventArgs e)
        {
            cbAlgorithm.Items.Add("OPT");
            cbAlgorithm.Items.Add("LRU");
            cbAlgorithm.Items.Add("FIFO");
            cbAlgorithm.Items.Add("CLOCK");
            cbAlgorithm.SelectedIndex = 0;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtFrame.Text, out int frames) || frames <= 0)
            {
                MessageBox.Show("Số frame không hợp lệ.");
                return;
            }

            if (cbAlgorithm.SelectedItem?.ToString() == "OPT")
            {
                RunOptimal(frames, referenceString);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNum.Text, out int page))
            {
                referenceString.Add(page);
                lblArray.Text = string.Join(" ", referenceString); // Ghi đè chuỗi
                txtNum.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ.");
            }
        }

        private void RunOptimal(int frameCount, List<int> pages)
        {
            dgvSimulation.Rows.Clear();
            dgvSimulation.Columns.Clear();

            // Tạo cột tiêu đề cho từng thời điểm
            for (int i = 0; i < pages.Count; i++)
            {
                dgvSimulation.Columns.Add($"col{i}", pages[i].ToString());
            }

            List<int?> frames = new List<int?>(new int?[frameCount]);
            List<List<int?>> history = new List<List<int?>>();

            int pageFaults = 0;

            for (int t = 0; t < pages.Count; t++)
            {
                int page = pages[t];

                if (frames.Contains(page))
                {
                    // Hit
                }
                else
                {
                    pageFaults++;

                    if (frames.Contains(null))
                    {
                        int emptyIndex = frames.IndexOf(null);
                        frames[emptyIndex] = page;
                    }
                    else
                    {
                        // Tìm frame cần thay theo OPT
                        int replaceIndex = 0;
                        int farthest = -1;

                        for (int i = 0; i < frames.Count; i++)
                        {
                            int? f = frames[i];
                            int nextUse = pages.FindIndex(t + 1, x => x == f);

                            if (nextUse == -1)
                            {
                                replaceIndex = i;
                                break;
                            }
                            else if (nextUse > farthest)
                            {
                                farthest = nextUse;
                                replaceIndex = i;
                            }
                        }

                        frames[replaceIndex] = page;
                    }
                }

                // Lưu trạng thái frame tại thời điểm t
                history.Add(new List<int?>(frames));
            }

            // Vẽ lên dgv
            for (int i = 0; i < frameCount; i++)
            {
                dgvSimulation.Rows.Add();
                dgvSimulation.Rows[i].HeaderCell.Value = $"Frame {i + 1}";

                for (int j = 0; j < history.Count; j++)
                {
                    dgvSimulation.Rows[i].Cells[j].Value = history[j][i]?.ToString() ?? "";
                }
            }

            // Thêm dòng page faults
            dgvSimulation.Rows.Add();
            dgvSimulation.Rows[frameCount].HeaderCell.Value = "Page Fault";
            for (int j = 0; j < pages.Count; j++)
            {
                bool isFault = (j == 0 || !history[j - 1].Contains(pages[j]));
                dgvSimulation.Rows[frameCount].Cells[j].Value = isFault ? "F" : "";
            }
        }

    }
}
