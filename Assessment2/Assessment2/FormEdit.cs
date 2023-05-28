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

namespace Assessment2
{
    public partial class FormEdit : Form
    {
        CLogin cLog;
        string filePath = null;

        public FormEdit()
        {
            InitializeComponent();
            
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            cLog = CLogin.GetInstance();
            toolStripLabelCurrentUser.Text = cLog.currentUser.FirstName + " " + cLog.currentUser.LastName;
            try
            {
                if (cLog.currentUser.UserType == 1)
                {
                    EditBox.ReadOnly = true;
                }
                else if (cLog.currentUser.UserType == 2)
                {
                    EditBox.ReadOnly = false;
                }
            }
            catch
            {
                MessageBox.Show("Incorrect User");
            }
            toolStripComboBoxFont.SelectedIndex = 0;    // 8
        }

        private void FormEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            cLog.SaveUsers();
            this.Owner.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    EditBox.Text = null;
                    string[] strs = filePath.Split('.');
                    if (strs[1] == "rtf")
                    {
                        //Read the contents of the file into a stream
                        EditBox.LoadFile(filePath);
                    }
                    else if (strs[1] == "txt")
                    {
                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            EditBox.AppendText(fileContent);
                        }
                    }
                }
            }
        }

        private void toolStripBtnBold_Click(object sender, EventArgs e)
        {
            EditBox.SelectionFont = new Font(EditBox.SelectionFont, EditBox.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void toolStripBtnItalic_Click(object sender, EventArgs e)
        {
            EditBox.SelectionFont = new Font(EditBox.SelectionFont, EditBox.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void toolStripBtnUnderline_Click(object sender, EventArgs e)
        {
            EditBox.SelectionFont = new Font(EditBox.SelectionFont, EditBox.SelectionFont.Style ^ FontStyle.Underline);
        }

        private void toolStripComboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditBox.SelectionFont = new Font(EditBox.SelectionFont.Name, toolStripComboBoxFont.SelectedIndex+8, EditBox.SelectionFont.Style);
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(EditBox.SelectedRtf, TextDataFormat.Rtf);
            }
            catch { } //If null is copied, to make sure the program doen't end
        }


        private void btnPaste_Click(object sender, EventArgs e)
        {
            EditBox.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            EditBox.Copy();
            EditBox.SelectedRtf = string.Empty;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EditBox.Text = null;
            filePath = null;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EditBox.Text != String.Empty)
            {
                if (filePath == null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = ".\\";
                        saveFileDialog.Filter = "rtf file|*.rtf";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = saveFileDialog.FileName;
                            EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        }
                    }
                }
                else
                {
                    EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }

            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = ".\\";
                    saveFileDialog.Filter = "rtf file|*.rtf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    }
                }
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fb = new FormAbout();
            fb.ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(EditBox.SelectedRtf, TextDataFormat.Rtf);
            }
            catch { } //If null is copied, to make sure the program doen't end
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBox.Copy();
            EditBox.SelectedRtf = string.Empty;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBox.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditBox.Text != String.Empty)
            {
                if (filePath == null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = ".\\";
                        saveFileDialog.Filter = "rtf file|*.rtf";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = saveFileDialog.FileName;
                            EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        }
                    }
                }
                else
                {
                    EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = ".\\";
                    saveFileDialog.Filter = "rtf file|*.rtf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        EditBox.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    }
                }
            }
            catch { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLog.SaveUsers();
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBox.Text = null;
            filePath = null;
        }
    }
}
