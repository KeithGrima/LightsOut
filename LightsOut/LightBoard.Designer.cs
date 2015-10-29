namespace LightsOut
{
    partial class LightBoard
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
            this.components = new System.ComponentModel.Container();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.tmrCount = new System.Windows.Forms.Timer(this.components);
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblSecondsValue = new System.Windows.Forms.Label();
            this.btnLightAll = new System.Windows.Forms.Button();
            this.grpBoxGrid = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(152, 13);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(42, 15);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 2;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(9, 18);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Size";
            // 
            // tmrCount
            // 
            this.tmrCount.Enabled = true;
            this.tmrCount.Interval = 1000;
            this.tmrCount.Tick += new System.EventHandler(this.tmrCount_Tick);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(9, 48);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(55, 13);
            this.lblSeconds.TabIndex = 4;
            this.lblSeconds.Text = "Seconds :";
            // 
            // lblSecondsValue
            // 
            this.lblSecondsValue.AutoSize = true;
            this.lblSecondsValue.Location = new System.Drawing.Point(68, 48);
            this.lblSecondsValue.Name = "lblSecondsValue";
            this.lblSecondsValue.Size = new System.Drawing.Size(0, 13);
            this.lblSecondsValue.TabIndex = 5;
            // 
            // btnLightAll
            // 
            this.btnLightAll.Location = new System.Drawing.Point(152, 39);
            this.btnLightAll.Name = "btnLightAll";
            this.btnLightAll.Size = new System.Drawing.Size(75, 23);
            this.btnLightAll.TabIndex = 6;
            this.btnLightAll.Text = "Light All";
            this.btnLightAll.UseVisualStyleBackColor = true;
            this.btnLightAll.Click += new System.EventHandler(this.btnLightAll_Click);
            // 
            // grpBoxGrid
            // 
            this.grpBoxGrid.AutoSize = true;
            this.grpBoxGrid.Location = new System.Drawing.Point(12, 77);
            this.grpBoxGrid.Name = "grpBoxGrid";
            this.grpBoxGrid.Size = new System.Drawing.Size(215, 100);
            this.grpBoxGrid.TabIndex = 8;
            this.grpBoxGrid.TabStop = false;
            this.grpBoxGrid.Text = "groupBox1";
            // 
            // LightBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(238, 200);
            this.Controls.Add(this.grpBoxGrid);
            this.Controls.Add(this.btnLightAll);
            this.Controls.Add(this.lblSecondsValue);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.btnGenerate);
            this.Name = "LightBoard";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblSecondsValue;
        private System.Windows.Forms.Timer tmrCount;
        private System.Windows.Forms.Button btnLightAll;
        private System.Windows.Forms.GroupBox grpBoxGrid;
    }
}

