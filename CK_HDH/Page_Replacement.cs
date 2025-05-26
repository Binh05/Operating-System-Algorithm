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
            string algorithm = cbAlgorithm.SelectedItem?.ToString();
            string framesText = txtFrame.Text.Trim();
            int frameCount = int.Parse(framesText);

            if (algorithm == "OPT")
                RunOptimal(frames, referenceString);
            else if (algorithm == "LRU")
                RunLRU(frames, referenceString);
            else if (algorithm == "FIFO")
                RunFIFO(referenceString, frameCount);
            else
                RunCLOCK(frames, referenceString);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input = txtNum.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int page))
                {
                    referenceString.Add(page);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ.");
                }
            }

            UpdateReferenceDisplay();
            txtNum.Clear();
            txtNum.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (referenceString.Count > 0)
            {
                referenceString.RemoveAt(referenceString.Count - 1);
                UpdateReferenceDisplay();
            }
            else
            {
                MessageBox.Show("Không còn phần tử nào để xóa.");
            }
        }

        private void UpdateReferenceDisplay()
        {
            lblArray.Text = referenceString.Count == 0 ? "No Item" : string.Join(" ", referenceString);
        }

        private void RunOptimal(int frameCount, List<int> pages)
        {
            dgvSimulation.Rows.Clear();
            dgvSimulation.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
                dgvSimulation.Columns.Add($"col{i}", pages[i].ToString());

            List<int?> frames = new List<int?>(new int?[frameCount]);
            List<List<int?>> history = new List<List<int?>>();
            List<bool> faultHistory = new List<bool>();
            int pageFaults = 0;

            for (int t = 0; t < pages.Count; t++)
            {
                int page = pages[t];
                bool isFault = false;

                if (!frames.Contains(page))
                {
                    isFault = true;
                    pageFaults++;

                    if (frames.Contains(null))
                    {
                        frames[frames.IndexOf(null)] = page;
                    }
                    else
                    {
                        int replaceIndex = 0, farthest = -1;
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

                history.Add(new List<int?>(frames));
                faultHistory.Add(isFault);
            }

            // Hiển thị
            for (int i = 0; i < frameCount; i++)
            {
                dgvSimulation.Rows.Add();
                dgvSimulation.Rows[i].HeaderCell.Value = $"Frame {i + 1}";
                for (int j = 0; j < history.Count; j++)
                    dgvSimulation.Rows[i].Cells[j].Value = history[j][i]?.ToString() ?? "";
            }

            dgvSimulation.Rows.Add();
            dgvSimulation.Rows[frameCount].HeaderCell.Value = "Page Fault";
            for (int j = 0; j < faultHistory.Count; j++)
                dgvSimulation.Rows[frameCount].Cells[j].Value = faultHistory[j] ? "F" : "";
        }

        private void RunLRU(int frameCount, List<int> pages)
        {
            dgvSimulation.Rows.Clear();
            dgvSimulation.Columns.Clear();

            for (int i = 0; i < pages.Count; i++)
            {
                dgvSimulation.Columns.Add($"col{i}", pages[i].ToString());
            }

            List<int?> frames = new List<int?>(new int?[frameCount]);
            List<List<int?>> history = new List<List<int?>>();
            List<int> recentUse = new List<int>(); // Stack theo dõi truy cập gần nhất
            List<bool> faultHistory = new List<bool>();
            int pageFaults = 0;

            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool isFault = false;

                if (frames.Contains(page))
                {
                    recentUse.Remove(page);
                    recentUse.Add(page);
                }
                else
                {
                    isFault = true;
                    pageFaults++;

                    if (frames.Contains(null))
                    {
                        int index = frames.IndexOf(null);
                        frames[index] = page;
                    }
                    else
                    {
                        int lruPage = recentUse[0];
                        int replaceIndex = frames.IndexOf(lruPage);
                        frames[replaceIndex] = page;
                        recentUse.RemoveAt(0);
                    }

                    recentUse.Add(page);
                }

                history.Add(new List<int?>(frames));
                faultHistory.Add(isFault); // lưu page fault đúng
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
                dgvSimulation.Rows[frameCount].Cells[j].Value = faultHistory[j] ? "F" : "";
            }
        }

        private void RunFIFO(List<int> referenceString, int frameCount)
        {
            dgvSimulation.Rows.Clear();
            dgvSimulation.Columns.Clear();

            for (int i = 0; i < referenceString.Count; i++)
            {
                dgvSimulation.Columns.Add("col" + i, referenceString[i].ToString());
            }

            List<int?> frames = new List<int?>(new int?[frameCount]); // danh sách cố định số frame
            Queue<int> order = new Queue<int>(); // theo dõi thứ tự đưa vào

            List<List<int?>> history = new List<List<int?>>();
            List<bool> faultHistory = new List<bool>();

            for (int i = 0; i < referenceString.Count; i++)
            {
                int page = referenceString[i];
                bool isFault = false;

                if (!frames.Contains(page))
                {
                    isFault = true;

                    if (frames.Contains(null))
                    {
                        int index = frames.IndexOf(null);
                        frames[index] = page;
                        order.Enqueue(index);
                    }
                    else
                    {
                        int indexToReplace = order.Dequeue();
                        frames[indexToReplace] = page;
                        order.Enqueue(indexToReplace);
                    }
                }

                history.Add(new List<int?>(frames));
                faultHistory.Add(isFault);
            }

            // Vẽ lên DataGridView
            for (int i = 0; i < frameCount; i++)
            {
                dgvSimulation.Rows.Add();
                dgvSimulation.Rows[i].HeaderCell.Value = $"Frame {i + 1}";

                for (int j = 0; j < history.Count; j++)
                {
                    dgvSimulation.Rows[i].Cells[j].Value = history[j][i]?.ToString() ?? "";
                }
            }

            dgvSimulation.Rows.Add();
            dgvSimulation.Rows[frameCount].HeaderCell.Value = "Page Fault";

            for (int i = 0; i < faultHistory.Count; i++)
            {
                dgvSimulation.Rows[frameCount].Cells[i].Value = faultHistory[i] ? "F" : "";
            }
        }


        private void RunCLOCK(int frameCount, List<int> pages)
        {
            dgvSimulation.Rows.Clear();
            dgvSimulation.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
                dgvSimulation.Columns.Add($"col{i}", pages[i].ToString());

            int?[] frames = new int?[frameCount];
            bool[] useBit = new bool[frameCount];
            int pointer = 0;

            List<List<int?>> history = new List<List<int?>>();
            List<List<bool>> useBitHistory = new List<List<bool>>(); // Lưu lịch sử useBit
            List<bool> faultHistory = new List<bool>();

            for (int t = 0; t < pages.Count; t++)
            {
                int page = pages[t];
                bool isFault = false;

                int index = Array.IndexOf(frames, page);
                if (index != -1)
                {
                    useBit[index] = true;
                }
                else
                {
                    isFault = true;

                    while (true)
                    {
                        if (frames[pointer] == null)
                        {
                            frames[pointer] = page;
                            useBit[pointer] = true;
                            pointer = (pointer + 1) % frameCount;
                            break;
                        }
                        else if (!useBit[pointer])
                        {
                            frames[pointer] = page;
                            useBit[pointer] = true;
                            pointer = (pointer + 1) % frameCount;
                            break;
                        }
                        else
                        {
                            useBit[pointer] = false;
                            pointer = (pointer + 1) % frameCount;
                        }
                    }
                }

                history.Add(frames.ToList());
                useBitHistory.Add(useBit.ToList());  // Lưu lại trạng thái useBit hiện tại
                faultHistory.Add(isFault);
            }

            for (int i = 0; i < frameCount; i++)
            {
                dgvSimulation.Rows.Add();
                dgvSimulation.Rows[i].HeaderCell.Value = $"Frame {i + 1}";
                for (int j = 0; j < history.Count; j++)
                {
                    var val = history[j][i];
                    var ub = useBitHistory[j][i];
                    dgvSimulation.Rows[i].Cells[j].Value = val.HasValue ? val.Value.ToString() + (ub ? "*" : "") : "";
                }
            }

            dgvSimulation.Rows.Add();
            dgvSimulation.Rows[frameCount].HeaderCell.Value = "Page Fault";
            for (int j = 0; j < faultHistory.Count; j++)
                dgvSimulation.Rows[frameCount].Cells[j].Value = faultHistory[j] ? "F" : "";
        }


    }

}
