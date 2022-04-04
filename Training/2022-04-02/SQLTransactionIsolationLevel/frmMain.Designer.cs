namespace SQLTransactionIsolationLevel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtUncommited = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCommitted = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtRepeatable = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtSerializable = new System.Windows.Forms.RichTextBox();
            this.ucUncommitted = new SQLTransactionIsolationLevel.UserControls.CRUD();
            this.ucCommitted = new SQLTransactionIsolationLevel.UserControls.CRUD();
            this.ucRepeatable = new SQLTransactionIsolationLevel.UserControls.CRUD();
            this.ucSerializable = new SQLTransactionIsolationLevel.UserControls.CRUD();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtUncommited);
            this.tabPage1.Controls.Add(this.ucUncommitted);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Read Uncommitted";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtUncommited
            // 
            this.txtUncommited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUncommited.Location = new System.Drawing.Point(3, 3);
            this.txtUncommited.Name = "txtUncommited";
            this.txtUncommited.Size = new System.Drawing.Size(786, 388);
            this.txtUncommited.TabIndex = 0;
            this.txtUncommited.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCommitted);
            this.tabPage2.Controls.Add(this.ucCommitted);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Read Committed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCommitted
            // 
            this.txtCommitted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommitted.Location = new System.Drawing.Point(3, 3);
            this.txtCommitted.Name = "txtCommitted";
            this.txtCommitted.Size = new System.Drawing.Size(786, 388);
            this.txtCommitted.TabIndex = 2;
            this.txtCommitted.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtRepeatable);
            this.tabPage3.Controls.Add(this.ucRepeatable);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Repeatable Read";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtRepeatable
            // 
            this.txtRepeatable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRepeatable.Location = new System.Drawing.Point(0, 0);
            this.txtRepeatable.Name = "txtRepeatable";
            this.txtRepeatable.Size = new System.Drawing.Size(792, 394);
            this.txtRepeatable.TabIndex = 2;
            this.txtRepeatable.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtSerializable);
            this.tabPage5.Controls.Add(this.ucSerializable);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Serializable";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtSerializable
            // 
            this.txtSerializable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerializable.Location = new System.Drawing.Point(0, 0);
            this.txtSerializable.Name = "txtSerializable";
            this.txtSerializable.Size = new System.Drawing.Size(792, 394);
            this.txtSerializable.TabIndex = 2;
            this.txtSerializable.Text = "";
            // 
            // ucUncommitted
            // 
            this.ucUncommitted.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucUncommitted.IsolationManager = null;
            this.ucUncommitted.Location = new System.Drawing.Point(3, 391);
            this.ucUncommitted.Name = "ucUncommitted";
            this.ucUncommitted.Size = new System.Drawing.Size(786, 30);
            this.ucUncommitted.TabIndex = 1;
            // 
            // ucCommitted
            // 
            this.ucCommitted.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucCommitted.IsolationManager = null;
            this.ucCommitted.Location = new System.Drawing.Point(3, 391);
            this.ucCommitted.Name = "ucCommitted";
            this.ucCommitted.Size = new System.Drawing.Size(786, 30);
            this.ucCommitted.TabIndex = 3;
            // 
            // ucRepeatable
            // 
            this.ucRepeatable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucRepeatable.IsolationManager = null;
            this.ucRepeatable.Location = new System.Drawing.Point(0, 394);
            this.ucRepeatable.Name = "ucRepeatable";
            this.ucRepeatable.Size = new System.Drawing.Size(792, 30);
            this.ucRepeatable.TabIndex = 3;
            // 
            // ucSerializable
            // 
            this.ucSerializable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucSerializable.IsolationManager = null;
            this.ucSerializable.Location = new System.Drawing.Point(0, 394);
            this.ucSerializable.Name = "ucSerializable";
            this.ucSerializable.Size = new System.Drawing.Size(792, 30);
            this.ucSerializable.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Isolation Level";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox txtUncommited;
        private UserControls.CRUD ucUncommitted;
        private System.Windows.Forms.RichTextBox txtCommitted;
        private UserControls.CRUD ucCommitted;
        private System.Windows.Forms.RichTextBox txtRepeatable;
        private UserControls.CRUD ucRepeatable;
        private System.Windows.Forms.RichTextBox txtSerializable;
        private UserControls.CRUD ucSerializable;
    }
}