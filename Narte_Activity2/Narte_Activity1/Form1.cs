using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Narte_Activity1
{
    public partial class Form1 : Form
    {
        private string filePath = @"Z:\II429\NARTE, Bridget D\3_Semifinal\Narte_Activity2\UserEntries.txt";
        private Dictionary<TextBox, string> defaultText = new Dictionary<TextBox, string>();
        private Panel selectedPanel = null;

        public Form1()
        {
            InitializeComponent();

            for (int i = 18; i <= 100; i++)
                comboBoxAge.Items.Add(i.ToString());

            SetDefaultText(txtFirstName, "First Name");
            SetDefaultText(txtMiddleName, "Middle Name");
            SetDefaultText(txtFamilyName, "Family Name");
            SetDefaultText(txtEmailAdd, "Email Address");
            SetDefaultText(txtCourse, "Course");
        }

        private void SetDefaultText(TextBox textBox, string text)
        {
            textBox.Text = text;
            textBox.ForeColor = Color.Gray;
            defaultText[textBox] = text;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == defaultText[textBox])
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = defaultText[textBox];
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void ResetFields()
        {
            foreach (var kvp in defaultText)
            {
                kvp.Key.Text = kvp.Value;
                kvp.Key.ForeColor = Color.Gray;
            }
            comboBoxAge.SelectedIndex = -1;
        }

        private string GetSafeText(TextBox box) => box.Text == defaultText[box] ? "" : box.Text;

        private void bttnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = GetSafeText(txtFirstName);
            string middleName = GetSafeText(txtMiddleName);
            string familyName = GetSafeText(txtFamilyName);
            string emailAdd = GetSafeText(txtEmailAdd);
            string course = GetSafeText(txtCourse);
            if (!int.TryParse(comboBoxAge.Text, out int age))
            {
                MessageBox.Show("Please select a valid age.");
                return;
            }

            string record =
                $"First Name: {firstName}\n" +
                $"Middle Name: {middleName}\n" +
                $"Family Name: {familyName}\n" +
                $"Age: {age}\n" +
                $"Email: {emailAdd}\n" +
                $"Course: {course}";

            File.AppendAllText(filePath, record + "\n");
            AddRecordToPanel(record);
            ResetFields();
        }

        private void AddRecordToPanel(string record)
        {
            Font font = new Font("Segoe UI", 9);

            Panel panel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 250,
                Height = 110,
                Margin = new Padding(10)
            };

            Label label = new Label
            {
                Text = record,
                Font = font,
                AutoSize = false,
                Size = panel.Size,
                Location = new Point(5, 5)
            };

            panel.Controls.Add(label);

            panel.Click += (s, e) => SelectRecord(panel, record);
            label.Click += (s, e) => SelectRecord(panel, record);

            resultPanel.Controls.Add(panel);
        }

        private void SelectRecord(Panel panel, string record)
        {
            if (selectedPanel != null)
                selectedPanel.BackColor = Color.White;

            selectedPanel = panel;
            selectedPanel.BackColor = Color.LightBlue;

            var lines = record.Split('\n');
            txtFirstName.Text = lines[0].Replace("First Name: ", "");
            txtMiddleName.Text = lines[1].Replace("Middle Name: ", "");
            txtFamilyName.Text = lines[2].Replace("Family Name: ", "");
            comboBoxAge.Text = lines[3].Replace("Age: ", "");
            txtEmailAdd.Text = lines[4].Replace("Email: ", "");
            txtCourse.Text = lines[5].Replace("Course: ", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 6)
                {
                    if (i + 5 < lines.Length)
                    {
                        string record = string.Join("\n", lines.Skip(i).Take(6));
                        AddRecordToPanel(record);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (selectedPanel == null) return;

            string oldText = selectedPanel.Controls[0].Text;
            var lines = File.ReadAllLines(filePath).ToList();

            int start = lines.FindIndex(l => oldText.Contains(l));
            if (start >= 0)
            {
                lines.RemoveRange(start, 6);

                string updated =
                    $"First Name: {GetSafeText(txtFirstName)}\n" +
                    $"Middle Name: {GetSafeText(txtMiddleName)}\n" +
                    $"Family Name: {GetSafeText(txtFamilyName)}\n" +
                    $"Age: {comboBoxAge.Text}\n" +
                    $"Email: {GetSafeText(txtEmailAdd)}\n" +
                    $"Course: {GetSafeText(txtCourse)}";

                var updatedLines = updated.Split(new[] { '\n' }, StringSplitOptions.None);
                lines.InsertRange(start, updatedLines);
                File.WriteAllLines(filePath, lines);

                selectedPanel.Controls[0].Text = updated;
                selectedPanel.BackColor = Color.White;
                selectedPanel = null;
                ResetFields();
                MessageBox.Show("Record updated!");
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (selectedPanel == null) return;

            string selectedText = selectedPanel.Controls[0].Text;
            var lines = File.ReadAllLines(filePath).ToList();

            int start = lines.FindIndex(l => selectedText.Contains(l));
            if (start >= 0)
            {
                lines.RemoveRange(start, 6);
                File.WriteAllLines(filePath, lines);
                resultPanel.Controls.Remove(selectedPanel);
                selectedPanel = null;
                ResetFields();
                MessageBox.Show("Record deleted!");
            }
        }
    }
}
