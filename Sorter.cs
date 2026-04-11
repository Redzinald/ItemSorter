using System.IO;

namespace SortItemsToFolders
{
    public partial class Sorter : Form
    {

        public Sorter()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == "")
            {
                label3.Text = "You have to choose valid directory";
                label3.Visible = true;
                label3.ForeColor = Color.Red;
            }
            else if (Directory.GetFiles(textBox1.Text).Length == 0)
            {
                label3.Text = "The selected folder is empty!";
                label3.ForeColor = Color.Red;
                label3.Visible = true;
            }
            else if (checkedListBox1.CheckedItems.Count == 0)
            {
                label3.Text = "Please select at least one category to sort!";
                label3.ForeColor = Color.Red;
                label3.Visible = true;
            }
            else
            {
                List<string> selectedCategories = new List<string>();
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    selectedCategories.Add(item?.ToString() ?? string.Empty);
                }

                // -> Handle Custom Sorting First
                if (selectedCategories.Contains("Custom"))
                {
                    List<string> customExtensions = new List<string>();
                    foreach (object item in checkedListBox2.CheckedItems)
                    {
                        customExtensions.Add(item?.ToString() ?? string.Empty);
                    }

                    // Use renamed custom folder if rename is checked and not empty; otherwise "Custom"
                    string customFolder = (checkBox1.Checked && !string.IsNullOrWhiteSpace(textBox7.Text)) ? textBox7.Text : "Custom";

                    TaskUtils.SortCustomFiles(textBox1.Text, customFolder, customExtensions.ToArray(), (current, total) =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = total > 0 ? total : 1;
                        progressBar1.Value = current;

                        label3.ForeColor = Color.White;
                        label3.Visible = true;
                        label3.Text = $"Custom Sorting: Processed {current} of {total} files...";
                        label3.Update();
                    });
                }
                
                // -> Handle Default Category sorting
                if (checkBox1.Checked)
                {
                    foreach (string category in selectedCategories)
                    {
                        if ((category == "Images" && string.IsNullOrWhiteSpace(textBox2.Text)) ||
                            (category == "Documents" && string.IsNullOrWhiteSpace(textBox3.Text)) ||
                            (category == "Others" && string.IsNullOrWhiteSpace(textBox4.Text)) ||
                            (category == "Videos" && string.IsNullOrWhiteSpace(textBox5.Text)) ||
                            (category == "Audio" && string.IsNullOrWhiteSpace(textBox6.Text)))
                        {
                            label3.Visible = false;
                            errorProvider1.SetError(checkBox1, "Please provide a name for all selected categories when 'Rename Folders' is checked.");
                            return;
                        }
                    } 
                    
                    TaskUtils.SortFilesWithRename(textBox1.Text, selectedCategories, (current, total) =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = total > 0 ? total : 1;
                        progressBar1.Value = current;

                        label3.ForeColor = Color.White;
                        label3.Visible = true;
                        label3.Text = $"Sorting: Processed {current} of {total} files...";
                        label3.Update();
                    }, textBox2, textBox3, textBox4, textBox5, textBox6);
                    errorProvider1.Clear();
                }
                else
                {
                    label3.ForeColor = Color.White;
                    label3.Visible = true;

                    TaskUtils.SortFiles(textBox1.Text, selectedCategories, (current, total) =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = total > 0 ? total : 1;
                        progressBar1.Value = current;

                        label3.Text = $"Sorting: Processed {current} of {total} files...";
                        label3.Update();
                    });
                    errorProvider1.Clear();
                }

                progressBar1.Value = 0;
                progressBar1.Visible = false;
                label3.Visible = false;
                MessageBox.Show("Files sorted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the folder";
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fbd.SelectedPath;
                }
            }
        }
        private void Allignment()
        {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button2.Left = (this.ClientSize.Width - button2.Width) / 2;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2 - 10;
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            progressBar1.Left = (this.ClientSize.Width - progressBar1.Width) / 2;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Allignment();
            textBox1.ReadOnly = true;
            label3.Visible = false;
            textBox1.AllowDrop = true;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];


                if (paths != null && paths.Length > 0)
                {
                    string droppedPath = paths[0];

                    if (Directory.Exists(droppedPath))
                    {
                        textBox1.Text = droppedPath;
                    }
                    else if (File.Exists(droppedPath))
                    {
                        textBox1.Text = Path.GetDirectoryName(droppedPath);
                    }
                }
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Cursor = Cursors.Hand;
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Cursor = Cursors.Default;
            label1.ForeColor = Color.White;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label3.Text = "You have to choose valid directory";
                label3.Visible = true;
                label3.ForeColor = Color.Red;
            }
            else if (Directory.GetDirectories(textBox1.Text).Length == 0)
            {
                label3.Text = "The selected folder doesnt have folders";
                label3.ForeColor = Color.Red;
                label3.Visible = true;
            }
            else if (checkedListBox1.CheckedItems.Count == 0)
            {
                label3.Text = "Please select at least one category to reverse sort!";
                label3.ForeColor = Color.Red;
                label3.Visible = true;
            }
            else
            {
                label3.ForeColor = Color.White;
                label3.Visible = true;

                List<string> selectedCategories = new List<string>();
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    selectedCategories.Add(item?.ToString() ?? string.Empty);
                }

                // -> Handle Reverse Custom Sorting First
                if (selectedCategories.Contains("Custom"))
                {
                    string customFolder = (checkBox1.Checked && !string.IsNullOrWhiteSpace(textBox7.Text)) ? textBox7.Text : "Custom";
                    
                    TaskUtils.ReverseSortCustomFiles(textBox1.Text, customFolder, (current, total) =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = total > 0 ? total : 1;
                        progressBar1.Value = current;   

                        label3.Text = $"Reverse Custom Sorting: Processed {current} of {total} files...";
                        label3.Update();
                    });
                }

                // If categories other than "Custom" are selected, process them.
                if (selectedCategories.Any(c => c != "Custom"))
                {
                    if (checkBox1.Checked)
                    {
                        TaskUtils.ReverseSortFilesWithRename(textBox1.Text, selectedCategories, (current, total) =>
                        {
                            progressBar1.Visible = true;
                            progressBar1.Maximum = total > 0 ? total : 1;
                            progressBar1.Value = current;

                            label3.Text = $"Reverse Sorting: Processed {current} of {total} folders...";
                            label3.Update();
                        }, textBox2, textBox3, textBox4, textBox5, textBox6);
                    }
                    else
                    {
                        TaskUtils.ReverseSortFiles(textBox1.Text, selectedCategories, (current, total) =>
                        {
                            progressBar1.Visible = true;
                            progressBar1.Maximum = total > 0 ? total : 1;
                            progressBar1.Value = current;

                            label3.Text = $"Reverse Sorting: Processed {current} of {total} folders...";
                            label3.Update();
                        });
                    }
                }

                progressBar1.Value = 0;
                progressBar1.Visible = false;
                MessageBox.Show("Files sorted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Visible = false;
            }
        }


        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
            if (checkBox1.Checked)
                UpdateBox();
            if(checkedListBox1.CheckedItems.Contains("Custom"))
            {
                checkedListBox2.Visible = true;
                label4.Visible = true;
            }
            else
            {
                checkedListBox2.Visible = false;
                label4.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2? existingForm2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
            if (existingForm2 != null)
            {
                existingForm2.Show();
                existingForm2.Location = this.Location;
            }
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBox();
        }
        private void UpdateBox()
        {
            if (checkBox1.Checked)
            {
                if (checkedListBox1.CheckedItems.Contains("Images"))
                {
                    textBox2.Visible = true;
                }
                else
                    textBox2.Visible = false;

                if (checkedListBox1.CheckedItems.Contains("Documents"))
                {
                    textBox3.Visible = true;
                }
                else
                    textBox3.Visible = false;

                if (checkedListBox1.CheckedItems.Contains("Others"))
                {
                    textBox4.Visible = true;
                }
                else
                    textBox4.Visible = false;
                if (checkedListBox1.CheckedItems.Contains("Videos"))
                {
                    textBox5.Visible = true;
                }
                else
                    textBox5.Visible = false;

                if (checkedListBox1.CheckedItems.Contains("Audio"))
                {
                    textBox6.Visible = true;
                }
                else
                    textBox6.Visible = false;
                if (checkedListBox1.CheckedItems.Contains("Custom"))
                {
                    textBox7.Visible = true;
                }
                else
                    textBox7.Visible = false;
            }
            else
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
            }
        }

    }
}

