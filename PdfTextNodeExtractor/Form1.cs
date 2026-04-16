using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Atalasoft.Annotate.UI;
using Atalasoft.Annotate.UI.Importers;

namespace PdfTextNoteExtractor
{
	/// <summary>
	/// Main Window
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private bool _ignoreColorChecks;
		private ArrayList _notes;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.Label lblPdfFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkAllAuthors;
		private System.Windows.Forms.ListView listAuthors;
		private System.Windows.Forms.Button btnGenerateReport;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			EnableControls();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuOpen = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.lblPdfFile = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGenerateReport = new System.Windows.Forms.Button();
			this.chkAllAuthors = new System.Windows.Forms.CheckBox();
			this.listAuthors = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuOpen,
																					 this.menuItem3,
																					 this.menuExit});
			this.menuFile.Text = "&File";
			// 
			// menuOpen
			// 
			this.menuOpen.Index = 0;
			this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuOpen.Text = "&Open";
			this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 2;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 1;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuAbout});
			this.menuHelp.Text = "&Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 0;
			this.menuAbout.Text = "&About...";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// lblPdfFile
			// 
			this.lblPdfFile.AutoSize = true;
			this.lblPdfFile.Location = new System.Drawing.Point(20, 18);
			this.lblPdfFile.Name = "lblPdfFile";
			this.lblPdfFile.Size = new System.Drawing.Size(124, 16);
			this.lblPdfFile.TabIndex = 0;
			this.lblPdfFile.Text = "PDF Document:  [None]";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Authors to extract:";
			// 
			// btnGenerateReport
			// 
			this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGenerateReport.Location = new System.Drawing.Point(84, 175);
			this.btnGenerateReport.Name = "btnGenerateReport";
			this.btnGenerateReport.Size = new System.Drawing.Size(97, 25);
			this.btnGenerateReport.TabIndex = 3;
			this.btnGenerateReport.Text = "Generate Report";
			this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
			// 
			// chkAllAuthors
			// 
			this.chkAllAuthors.Checked = true;
			this.chkAllAuthors.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAllAuthors.Location = new System.Drawing.Point(25, 63);
			this.chkAllAuthors.Name = "chkAllAuthors";
			this.chkAllAuthors.Size = new System.Drawing.Size(42, 15);
			this.chkAllAuthors.TabIndex = 4;
			this.chkAllAuthors.Text = "All";
			this.chkAllAuthors.CheckedChanged += new System.EventHandler(this.chkAllAuthors_CheckedChanged);
			// 
			// listAuthors
			// 
			this.listAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listAuthors.CheckBoxes = true;
			this.listAuthors.Location = new System.Drawing.Point(25, 81);
			this.listAuthors.Name = "listAuthors";
			this.listAuthors.Size = new System.Drawing.Size(216, 79);
			this.listAuthors.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listAuthors.TabIndex = 5;
			this.listAuthors.View = System.Windows.Forms.View.List;
			this.listAuthors.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listAuthors_ItemCheck);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(269, 215);
			this.Controls.Add(this.listAuthors);
			this.Controls.Add(this.chkAllAuthors);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPdfFile);
			this.Controls.Add(this.btnGenerateReport);
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(177, 170);
			this.Name = "Form1";
			this.Text = "PDF Text Note Extractor";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About frm = new AtalaDemos.AboutBox.About("About...", "PDF Text Note Extractor");
			frm.Description = "This project demonstrates how to extract PDF text annotations and use them to generate an edit history of the PDF document.";
			frm.ShowDialog(this);
			frm.Dispose();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "PDF Documents|*.pdf";
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					this.lblPdfFile.Text = "PDF Document:  " + System.IO.Path.GetFileName(dlg.FileName);

					ExtractTextNodes(dlg.FileName);
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
			dlg.Dispose();

			EnableControls();
		}

		private void listAuthors_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (_ignoreColorChecks) return;
			this.chkAllAuthors.Checked = false;
		}

		private void chkAllAuthors_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chkAllAuthors.Checked)
			{
				SelectAllAuthors();
			}
		}

		private void SelectAllAuthors()
		{
			_ignoreColorChecks = true;

			int count = this.listAuthors.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.listAuthors.Items[i].Checked = true;
			}

			_ignoreColorChecks = false;
		}

		private void btnGenerateReport_Click(object sender, System.EventArgs e)
		{
			if (_notes == null || _notes.Count == 0)
			{
				MessageBox.Show("Please use the 'File -> Open' menu item to load a PDF document with text annotations.", "Nothing To Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (this.listAuthors.CheckedItems.Count == 0)
			{
				MessageBox.Show("You must have at least one item checked in the list.", "Nothing To Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "HTML Files (*.html)|*.html";
			if (dlg.ShowDialog(this) == DialogResult.OK)
				GenerateReport(dlg.FileName);
			dlg.Dispose();
		}

		/// <summary>
		/// This method extracts the text annotations from the PDF file and
		/// fills an array with TextNote information that will be used to
		/// generate the HTML report.
		/// </summary>
		/// <param name="fileName">The filename of the PDF.</param>
		private void ExtractTextNodes(string fileName)
		{
			if (!File.Exists(fileName))
			{
				MessageBox.Show("The input file could not be found.", "File Not Found");
				return;
			}

			_notes = new ArrayList();
			this.listAuthors.Items.Clear();

			LayerCollection layers = null;
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				try
				{
					PdfAnnotationImporter importer = new PdfAnnotationImporter(fs);
					layers = importer.Import();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.GetType().Name + ":\r\n" + ex.Message, "Annotation Import Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			if (layers == null || layers.Count == 0)
			{
				MessageBox.Show("There are no pages in this PDF file.", "No Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int layerCount = layers.Count;
			for (int lc = 0; lc < layerCount; lc++)
			{
				LayerAnnotation layer = layers[lc];
				foreach (AnnotationUI ann in layer.Items)
				{
					TextAnnotation txt = ann as TextAnnotation;
					if (txt == null) continue;

                    // FB 12753 - Ensure that a TextAnnotation with no fill brush doesn't cause a null reference exception
                    if (txt.Fill == null)
                    {
                        txt.Fill = new Atalasoft.Annotate.AnnotationBrush(Color.White);
                    }

					_notes.Add(new TextNote(txt.UserName, txt.Text, txt.Fill.Color, txt.ModifiedTime, lc + 1));

					bool found = false;
					foreach (ListViewItem li in this.listAuthors.Items)
					{
						if (li.Text == txt.UserName)
						{
							found = true;
							break;
						}
					}

					if (!found)
					{
						ListViewItem item = new ListViewItem(txt.UserName);
						item.BackColor = txt.Fill.Color;
						this.listAuthors.Items.Add(item);
					}
				}
			}

			if (this.chkAllAuthors.Checked)
				SelectAllAuthors();

			_notes.Sort(new TextNoteComparer());

			if (_notes.Count == 0)
				MessageBox.Show("There were no text annotations found in the PDF.", "No Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Creates an HTML page with the annotation information.
		/// </summary>
		/// <param name="fileName">The filename of the HTML file to create.</param>
		private void GenerateReport(string fileName)
		{
			TextNoteReportGenerator generator = new TextNoteReportGenerator(fileName);
			try
			{
				foreach (TextNote note in _notes)
				{
					foreach (ListViewItem item in this.listAuthors.CheckedItems)
					{
						if (item.Text == note.Author)
							generator.WriteTextNote(note);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.GetType().Name + ":\r\n" + ex.Message, "Generate Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				generator.Close();
			}

			System.Diagnostics.Process.Start(fileName);
		}

		private void EnableControls()
		{
			bool enabled = (_notes != null && _notes.Count > 0);
			this.btnGenerateReport.Enabled = enabled;
			this.listAuthors.Enabled = enabled;
			this.chkAllAuthors.Enabled = enabled;
			this.label1.Enabled = enabled;
		}

	}
}
