namespace Aolyn.NuGetTools.ProxySwitcher
{
    partial class FormProxySwitch
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
			this.chkUseProxy = new System.Windows.Forms.CheckBox();
			this.txtProxyAddress = new System.Windows.Forms.TextBox();
			this.lsbProxyList = new System.Windows.Forms.ListBox();
			this.txtConfigFile = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// chkUseProxy
			// 
			this.chkUseProxy.AutoSize = true;
			this.chkUseProxy.Location = new System.Drawing.Point(8, 10);
			this.chkUseProxy.Name = "chkUseProxy";
			this.chkUseProxy.Size = new System.Drawing.Size(71, 17);
			this.chkUseProxy.TabIndex = 1;
			this.chkUseProxy.Text = "UseProxy";
			this.chkUseProxy.UseVisualStyleBackColor = true;
			this.chkUseProxy.Click += new System.EventHandler(this.chkUseProxy_Click);
			// 
			// txtProxyAddress
			// 
			this.txtProxyAddress.Location = new System.Drawing.Point(85, 8);
			this.txtProxyAddress.Name = "txtProxyAddress";
			this.txtProxyAddress.Size = new System.Drawing.Size(297, 20);
			this.txtProxyAddress.TabIndex = 2;
			this.txtProxyAddress.Text = "http://localhost:1080";
			// 
			// lsbProxyList
			// 
			this.lsbProxyList.FormattingEnabled = true;
			this.lsbProxyList.Location = new System.Drawing.Point(8, 59);
			this.lsbProxyList.Name = "lsbProxyList";
			this.lsbProxyList.Size = new System.Drawing.Size(374, 212);
			this.lsbProxyList.TabIndex = 3;
			this.lsbProxyList.DoubleClick += new System.EventHandler(this.lsbProxyList_DoubleClick);
			// 
			// txtConfigFile
			// 
			this.txtConfigFile.Location = new System.Drawing.Point(8, 33);
			this.txtConfigFile.Name = "txtConfigFile";
			this.txtConfigFile.Size = new System.Drawing.Size(374, 20);
			this.txtConfigFile.TabIndex = 2;
			// 
			// FormProxySwitch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 284);
			this.Controls.Add(this.lsbProxyList);
			this.Controls.Add(this.txtConfigFile);
			this.Controls.Add(this.txtProxyAddress);
			this.Controls.Add(this.chkUseProxy);
			this.Name = "FormProxySwitch";
			this.Text = "NuGet Proxy Switcher";
			this.Load += new System.EventHandler(this.FormProxySwitch_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.TextBox txtProxyAddress;
        private System.Windows.Forms.ListBox lsbProxyList;
        private System.Windows.Forms.TextBox txtConfigFile;
    }
}

