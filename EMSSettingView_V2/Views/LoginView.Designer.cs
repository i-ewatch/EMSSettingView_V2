
namespace EMSSettingView_V2.Views
{
    partial class LoginView
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.LoginsimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.PasswordtextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AccounttextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordtextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccounttextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.LoginsimpleButton);
            this.groupControl1.Controls.Add(this.PasswordtextEdit);
            this.groupControl1.Controls.Add(this.AccounttextEdit);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(319, 224);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(234, 210);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "登入";
            // 
            // LoginsimpleButton
            // 
            this.LoginsimpleButton.Appearance.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginsimpleButton.Appearance.Options.UseFont = true;
            this.LoginsimpleButton.Location = new System.Drawing.Point(140, 161);
            this.LoginsimpleButton.Name = "LoginsimpleButton";
            this.LoginsimpleButton.Size = new System.Drawing.Size(85, 36);
            this.LoginsimpleButton.TabIndex = 4;
            this.LoginsimpleButton.Text = "確定";
            this.LoginsimpleButton.Click += new System.EventHandler(this.LoginsimpleButton_Click);
            // 
            // PasswordtextEdit
            // 
            this.PasswordtextEdit.Location = new System.Drawing.Point(87, 85);
            this.PasswordtextEdit.Name = "PasswordtextEdit";
            this.PasswordtextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordtextEdit.Properties.Appearance.Options.UseFont = true;
            this.PasswordtextEdit.Properties.UseSystemPasswordChar = true;
            this.PasswordtextEdit.Size = new System.Drawing.Size(139, 30);
            this.PasswordtextEdit.TabIndex = 3;
            // 
            // AccounttextEdit
            // 
            this.AccounttextEdit.Location = new System.Drawing.Point(87, 36);
            this.AccounttextEdit.Name = "AccounttextEdit";
            this.AccounttextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccounttextEdit.Properties.Appearance.Options.UseFont = true;
            this.AccounttextEdit.Size = new System.Drawing.Size(139, 30);
            this.AccounttextEdit.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(8, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密碼:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "帳號:";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(898, 692);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordtextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccounttextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton LoginsimpleButton;
        private DevExpress.XtraEditors.TextEdit PasswordtextEdit;
        private DevExpress.XtraEditors.TextEdit AccounttextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
