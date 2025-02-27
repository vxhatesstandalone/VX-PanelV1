using cxapi;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace VX_PanelV1
{
    public partial class VXPanelV1 : Form
    {
        public VXPanelV1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Api.Attach();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Api.Execute(richTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Api.UserAgent("VX Panel", 1);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Api.IsRobloxOpen())
            {
                Api.KillRoblox();
            }
            else
            {
                MessageBox.Show("Roblox is not open");
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|C# files (*.cs)|*.cs|All files (*.*)|*.*";
            openFileDialog.Title = "Select a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    richTextBox1.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Define the folder path (create a "Scripts" folder in the user's "Documents" directory)
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Scripts");

            // Check if the "Scripts" folder exists, and if not, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create the save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = folderPath;  // Set the initial directory to the "Scripts" folder
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|C# files (*.cs)|*.cs|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Your Code";

            // Show the save file dialog
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Save the file in the selected directory
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Clear button functionality
        private void guna2ButtonClear_Click(object sender, EventArgs e)
        {
            // Clear the richTextBox
            richTextBox1.Clear();
        }

        // Close button functionality
        private void guna2ButtonClose_Click(object sender, EventArgs e)
        {
            // Close the application
            this.Close();
        }

        // Minimize button functionality
        private void guna2ButtonMinimize_Click(object sender, EventArgs e)
        {
            // Minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        // MouseDown event for dragging the form
        private bool dragging = false;
        private Point offset;

        private void guna2PanelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = new Point(e.X, e.Y);
        }

        // MouseMove event for dragging the form
        private void guna2PanelDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point newLocation = this.Location;
                newLocation.X += e.X - offset.X;
                newLocation.Y += e.Y - offset.Y;
                this.Location = newLocation;
            }
        }

        // MouseUp event to stop dragging the form
        private void guna2PanelDrag_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Open button functionality (open the Scripts folder)
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Define the folder path (Scripts folder in the user's Documents directory)
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Scripts");

            // Check if the "Scripts" folder exists, then open it
            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                MessageBox.Show("Scripts folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
