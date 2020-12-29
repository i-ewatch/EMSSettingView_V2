using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using EMSSettingView_V2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMSSettingView_V2
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 畫面物件整理
        /// </summary>
        private List<Field4UserControl> field4UserControls = new List<Field4UserControl>();
        public NavigationFrame navigationFrame;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 150);//視窗起始位置
            navigationFrame = new NavigationFrame() { Dock = DockStyle.Fill, Parent = MainpanelControl };//切換畫面動畫
            #region 顯示畫面
            LoginView screenView = new LoginView() { Dock = DockStyle.Fill, mainForm = this };
            field4UserControls.Add(screenView);
            navigationFrame.AddPage(screenView);

            SettingView settingView = new SettingView() { Dock = DockStyle.Fill };
            field4UserControls.Add(settingView);
            navigationFrame.AddPage(settingView);
            #endregion
        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            #region Help畫面
            FlyoutAction action = new FlyoutAction();
            action.Description = "版權聲明 Copyright©\r\n著作權© 2020 新茂能源實業有限公司 版權所有。\r\nCopyright© 2020 SIN MAO Energy CO.,LTD All right reserved.\r\n \r\n工程版本:1.0.0";
            action.Commands.Add(FlyoutCommand.OK);
            { FlyoutDialog.Show(FindForm(), action); };
            #endregion
        }
    }
}
