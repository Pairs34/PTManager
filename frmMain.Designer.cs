
namespace PTManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnClearDB = new System.Windows.Forms.Button();
            this.lstApps = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(12, 12);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(157, 23);
            this.btnStartAll.TabIndex = 0;
            this.btnStartAll.Text = "Tümünü Başlat";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnClearDB
            // 
            this.btnClearDB.Location = new System.Drawing.Point(187, 12);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(159, 23);
            this.btnClearDB.TabIndex = 1;
            this.btnClearDB.Text = "Veritabanını Temizle";
            this.btnClearDB.UseVisualStyleBackColor = true;
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // lstApps
            // 
            this.lstApps.AllowDrop = true;
            this.lstApps.FormattingEnabled = true;
            this.lstApps.Location = new System.Drawing.Point(12, 42);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(334, 485);
            this.lstApps.TabIndex = 2;
            this.lstApps.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstApps_DragDrop);
            this.lstApps.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstApps_DragEnter);
            this.lstApps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstApps_KeyDown);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 542);
            this.Controls.Add(this.lstApps);
            this.Controls.Add(this.btnClearDB);
            this.Controls.Add(this.btnStartAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "Price Tracker Starter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnClearDB;
        private System.Windows.Forms.ListBox lstApps;
    }
}

