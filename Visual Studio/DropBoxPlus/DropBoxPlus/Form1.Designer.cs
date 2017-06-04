namespace DropBoxPlus
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblDropboxUsage = new System.Windows.Forms.Label();
            this.pbDropboxUsage = new System.Windows.Forms.PictureBox();
            this.lblNASStatusLabel = new System.Windows.Forms.Label();
            this.lblNASStatus = new System.Windows.Forms.Label();
            this.pbFilesMoved = new System.Windows.Forms.PictureBox();
            this.lblFilesMoved = new System.Windows.Forms.Label();
            this.lblCurFileLabel = new System.Windows.Forms.Label();
            this.lblCurFile = new System.Windows.Forms.Label();
            this.butnMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDropboxUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilesMoved)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDropboxUsage
            // 
            this.lblDropboxUsage.AutoSize = true;
            this.lblDropboxUsage.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropboxUsage.Location = new System.Drawing.Point(12, 13);
            this.lblDropboxUsage.Name = "lblDropboxUsage";
            this.lblDropboxUsage.Size = new System.Drawing.Size(116, 15);
            this.lblDropboxUsage.TabIndex = 2;
            this.lblDropboxUsage.Text = "Dropbox usage [0%]";
            // 
            // pbDropboxUsage
            // 
            this.pbDropboxUsage.Location = new System.Drawing.Point(12, 32);
            this.pbDropboxUsage.Name = "pbDropboxUsage";
            this.pbDropboxUsage.Size = new System.Drawing.Size(260, 22);
            this.pbDropboxUsage.TabIndex = 3;
            this.pbDropboxUsage.TabStop = false;
            // 
            // lblNASStatusLabel
            // 
            this.lblNASStatusLabel.AutoSize = true;
            this.lblNASStatusLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNASStatusLabel.Location = new System.Drawing.Point(12, 67);
            this.lblNASStatusLabel.Name = "lblNASStatusLabel";
            this.lblNASStatusLabel.Size = new System.Drawing.Size(68, 15);
            this.lblNASStatusLabel.TabIndex = 4;
            this.lblNASStatusLabel.Text = "NAS Status:";
            // 
            // lblNASStatus
            // 
            this.lblNASStatus.AutoSize = true;
            this.lblNASStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNASStatus.Location = new System.Drawing.Point(86, 67);
            this.lblNASStatus.Name = "lblNASStatus";
            this.lblNASStatus.Size = new System.Drawing.Size(58, 15);
            this.lblNASStatus.TabIndex = 5;
            this.lblNASStatus.Text = "unknown";
            // 
            // pbFilesMoved
            // 
            this.pbFilesMoved.Location = new System.Drawing.Point(12, 115);
            this.pbFilesMoved.Name = "pbFilesMoved";
            this.pbFilesMoved.Size = new System.Drawing.Size(260, 22);
            this.pbFilesMoved.TabIndex = 6;
            this.pbFilesMoved.TabStop = false;
            // 
            // lblFilesMoved
            // 
            this.lblFilesMoved.AutoSize = true;
            this.lblFilesMoved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesMoved.Location = new System.Drawing.Point(12, 97);
            this.lblFilesMoved.Name = "lblFilesMoved";
            this.lblFilesMoved.Size = new System.Drawing.Size(99, 15);
            this.lblFilesMoved.TabIndex = 7;
            this.lblFilesMoved.Text = "Files moved [0%]";
            // 
            // lblCurFileLabel
            // 
            this.lblCurFileLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurFileLabel.Location = new System.Drawing.Point(12, 151);
            this.lblCurFileLabel.Name = "lblCurFileLabel";
            this.lblCurFileLabel.Size = new System.Drawing.Size(260, 15);
            this.lblCurFileLabel.TabIndex = 8;
            this.lblCurFileLabel.Text = "Current file:";
            // 
            // lblCurFile
            // 
            this.lblCurFile.AutoSize = true;
            this.lblCurFile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurFile.Location = new System.Drawing.Point(89, 150);
            this.lblCurFile.Name = "lblCurFile";
            this.lblCurFile.Size = new System.Drawing.Size(0, 15);
            this.lblCurFile.TabIndex = 9;
            // 
            // butnMove
            // 
            this.butnMove.Location = new System.Drawing.Point(197, 63);
            this.butnMove.Name = "butnMove";
            this.butnMove.Size = new System.Drawing.Size(75, 23);
            this.butnMove.TabIndex = 10;
            this.butnMove.Text = "Move";
            this.butnMove.UseVisualStyleBackColor = true;
            this.butnMove.Click += new System.EventHandler(this.butnMove_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.butnMove);
            this.Controls.Add(this.lblCurFile);
            this.Controls.Add(this.lblCurFileLabel);
            this.Controls.Add(this.lblFilesMoved);
            this.Controls.Add(this.pbFilesMoved);
            this.Controls.Add(this.lblNASStatus);
            this.Controls.Add(this.lblNASStatusLabel);
            this.Controls.Add(this.pbDropboxUsage);
            this.Controls.Add(this.lblDropboxUsage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Infinite Dropbox";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDropboxUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilesMoved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDropboxUsage;
        private System.Windows.Forms.PictureBox pbDropboxUsage;
        private System.Windows.Forms.Label lblNASStatusLabel;
        private System.Windows.Forms.Label lblNASStatus;
        private System.Windows.Forms.PictureBox pbFilesMoved;
        private System.Windows.Forms.Label lblFilesMoved;
        private System.Windows.Forms.Label lblCurFileLabel;
        private System.Windows.Forms.Label lblCurFile;
        private System.Windows.Forms.Button butnMove;
    }
}

