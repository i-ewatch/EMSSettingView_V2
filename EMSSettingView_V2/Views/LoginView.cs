using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using EMSSettingView_V2.Configuration;
using EMSSettingView_V2.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSSettingView_V2.Views
{
    public partial class LoginView : Field4UserControl
    {
        public MainForm mainForm { get; set; }
        private List<UserSetting> userSetting = new List<UserSetting>();
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginsimpleButton_Click(object sender, EventArgs e)
        {
            userSetting = InitialMethod.UserSettings();
            if (AccounttextEdit.Text == userSetting[0].UserName)
            {
                if (PasswordtextEdit.Text == userSetting[0].UserPassWord)
                {
                    mainForm.navigationFrame.SelectedPageIndex = 1;
                }
                else
                {
                    FlyoutAction action = new FlyoutAction();
                    action.Description = "密碼錯誤!";
                    action.Commands.Add(FlyoutCommand.OK);
                    { FlyoutDialog.Show(FindForm(), action); };
                }
            }
            else
            {
                FlyoutAction action = new FlyoutAction();
                action.Description = "帳號密碼錯誤!";
                action.Commands.Add(FlyoutCommand.OK);
                { FlyoutDialog.Show(FindForm(), action); };
            }
        }
    }
}
