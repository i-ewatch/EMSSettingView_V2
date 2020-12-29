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
    public partial class Field4UserControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        public string MyWorkPath = AppDomain.CurrentDomain.BaseDirectory;
        public Field4UserControl()
        {
            InitializeComponent();
        }
    }
}
