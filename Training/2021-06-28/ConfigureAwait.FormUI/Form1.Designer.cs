
namespace ConfigureAwait.FormUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMessage = new System.Windows.Forms.Button();
            this.btnCounter = new System.Windows.Forms.Button();
            this.btnGetGoogle = new System.Windows.Forms.Button();
            this.btnGetGoogleFixed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(12, 12);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(75, 23);
            this.btnMessage.TabIndex = 0;
            this.btnMessage.Text = "Message";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(93, 12);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(75, 23);
            this.btnCounter.TabIndex = 1;
            this.btnCounter.Text = "Counter";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // btnGetGoogle
            // 
            this.btnGetGoogle.Location = new System.Drawing.Point(12, 52);
            this.btnGetGoogle.Name = "btnGetGoogle";
            this.btnGetGoogle.Size = new System.Drawing.Size(75, 23);
            this.btnGetGoogle.TabIndex = 2;
            this.btnGetGoogle.Text = "Get Google";
            this.btnGetGoogle.UseVisualStyleBackColor = true;
            this.btnGetGoogle.Click += new System.EventHandler(this.btnGetGoogle_Click);
            // 
            // btnGetGoogleFixed
            // 
            this.btnGetGoogleFixed.Location = new System.Drawing.Point(93, 52);
            this.btnGetGoogleFixed.Name = "btnGetGoogleFixed";
            this.btnGetGoogleFixed.Size = new System.Drawing.Size(112, 23);
            this.btnGetGoogleFixed.TabIndex = 2;
            this.btnGetGoogleFixed.Text = "Get Google Fixed";
            this.btnGetGoogleFixed.UseVisualStyleBackColor = true;
            this.btnGetGoogleFixed.Click += new System.EventHandler(this.btnGetGoogleFixed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 104);
            this.Controls.Add(this.btnGetGoogleFixed);
            this.Controls.Add(this.btnGetGoogle);
            this.Controls.Add(this.btnCounter);
            this.Controls.Add(this.btnMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMessage;
        private System.Windows.Forms.Button btnCounter;
        private System.Windows.Forms.Button btnGetGoogle;
        private System.Windows.Forms.Button btnGetGoogleFixed;
    }
}

