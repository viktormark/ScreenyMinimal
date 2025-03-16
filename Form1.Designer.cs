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
            this.Pause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnStart.ForeColor = System.Drawing.Color.White;
            this.BtnStart.Location = new System.Drawing.Point(56, 93);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(304, 66);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStop.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnStop.ForeColor = System.Drawing.Color.White;
            this.BtnStop.Location = new System.Drawing.Point(211, 165);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(149, 66);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(34, 33);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 18);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(148, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "logs";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkSystemAudio
            // 
            this.chkSystemAudio.AutoSize = true;
            this.chkSystemAudio.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkSystemAudio.Depth = 0;
            this.chkSystemAudio.Location = new System.Drawing.Point(56, 262);
            this.chkSystemAudio.Margin = new System.Windows.Forms.Padding(0);
            this.chkSystemAudio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSystemAudio.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSystemAudio.Name = "chkSystemAudio";
            this.chkSystemAudio.Ripple = true;
            this.chkSystemAudio.Size = new System.Drawing.Size(164, 30);
            this.chkSystemAudio.TabIndex = 7;
            this.chkSystemAudio.Text = "Capture system audio";
            this.chkSystemAudio.UseVisualStyleBackColor = false;
            this.chkSystemAudio.CheckedChanged += new System.EventHandler(this.chkSystemAudio_CheckedChanged_1);
            // 
            // chkMicrophone
            // 
            this.chkMicrophone.AutoSize = true;
            this.chkMicrophone.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkMicrophone.Depth = 0;
            this.chkMicrophone.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkMicrophone.Location = new System.Drawing.Point(56, 319);
            this.chkMicrophone.Margin = new System.Windows.Forms.Padding(0);
            this.chkMicrophone.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkMicrophone.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkMicrophone.Name = "chkMicrophone";
            this.chkMicrophone.Ripple = true;
            this.chkMicrophone.Size = new System.Drawing.Size(155, 30);
            this.chkMicrophone.TabIndex = 8;
            this.chkMicrophone.Text = "Capture microphone";
            this.chkMicrophone.UseVisualStyleBackColor = false;
            this.chkMicrophone.CheckedChanged += new System.EventHandler(this.chkMicrophone_CheckedChanged_1);
            // 
            // Pause
            // 
            this.Pause.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Pause.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Pause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pause.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pause.ForeColor = System.Drawing.Color.White;
            this.Pause.Location = new System.Drawing.Point(56, 165);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(149, 66);
            this.Pause.TabIndex = 10;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(420, 405);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.chkMicrophone);
            this.Controls.Add(this.chkSystemAudio);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button Pause;
    }
}

