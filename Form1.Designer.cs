namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chkSystemAudio = new MaterialSkin.Controls.MaterialCheckBox();
            this.chkMicrophone = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Location = new System.Drawing.Point(246, 99);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(128, 50);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "BtnStart";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(431, 99);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "BtnStop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(351, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "lblStatus";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(603, 354);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "logs";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkSystemAudio
            // 
            this.chkSystemAudio.AutoSize = true;
            this.chkSystemAudio.Depth = 0;
            this.chkSystemAudio.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkSystemAudio.Location = new System.Drawing.Point(208, 161);
            this.chkSystemAudio.Margin = new System.Windows.Forms.Padding(0);
            this.chkSystemAudio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSystemAudio.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSystemAudio.Name = "chkSystemAudio";
            this.chkSystemAudio.Ripple = true;
            this.chkSystemAudio.Size = new System.Drawing.Size(150, 30);
            this.chkSystemAudio.TabIndex = 7;
            this.chkSystemAudio.Text = "materialCheckBox1";
            this.chkSystemAudio.UseVisualStyleBackColor = true;
            this.chkSystemAudio.CheckedChanged += new System.EventHandler(this.chkSystemAudio_CheckedChanged_1);
            // 
            // chkMicrophone
            // 
            this.chkMicrophone.AutoSize = true;
            this.chkMicrophone.Depth = 0;
            this.chkMicrophone.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkMicrophone.Location = new System.Drawing.Point(457, 161);
            this.chkMicrophone.Margin = new System.Windows.Forms.Padding(0);
            this.chkMicrophone.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkMicrophone.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkMicrophone.Name = "chkMicrophone";
            this.chkMicrophone.Ripple = true;
            this.chkMicrophone.Size = new System.Drawing.Size(125, 30);
            this.chkMicrophone.TabIndex = 8;
            this.chkMicrophone.Text = "chkMicrophone";
            this.chkMicrophone.UseVisualStyleBackColor = true;
            this.chkMicrophone.CheckedChanged += new System.EventHandler(this.chkMicrophone_CheckedChanged_1);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.BackColor = System.Drawing.SystemColors.Highlight;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.materialFlatButton1.Location = new System.Drawing.Point(146, 290);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(172, 36);
            this.materialFlatButton1.TabIndex = 9;
            this.materialFlatButton1.Text = "materialFlatButton1";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.chkMicrophone);
            this.Controls.Add(this.chkSystemAudio);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private MaterialSkin.Controls.MaterialCheckBox chkSystemAudio;
        private MaterialSkin.Controls.MaterialCheckBox chkMicrophone;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}

