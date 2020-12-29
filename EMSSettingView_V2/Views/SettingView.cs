using EMSSettingView_V2.Configuration;
using EMSSettingView_V2.Enums;
using EMSSettingView_V2.Methods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSSettingView_V2.Views
{
    public partial class SettingView : Field4UserControl
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static new string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 縣市區域Json
        /// </summary>
        private List<Taiwan_DistricsSetting> taiwan_DistricsSetting = new List<Taiwan_DistricsSetting>();
        /// <summary>
        /// 產生EMS程式所需的Json
        /// </summary>
        private GateWaySetting gateWay = new GateWaySetting();
        /// <summary>
        /// 啟動ToggleSwitch集合
        /// </summary>
        private List<DevExpress.XtraEditors.ToggleSwitch> toggleSwitches = new List<DevExpress.XtraEditors.ToggleSwitch>();
        /// <summary>
        /// 總錶ToggleSwitch集合
        /// </summary>
        private List<DevExpress.XtraEditors.ToggleSwitch> toggleSwitches2 = new List<DevExpress.XtraEditors.ToggleSwitch>();
        /// <summary>
        /// 設備名稱TextEdit集合
        /// </summary>
        private List<DevExpress.XtraEditors.TextEdit> textEdits = new List<DevExpress.XtraEditors.TextEdit>();
        /// <summary>
        /// 設備ID的SpinEdit集合
        /// </summary>
        private List<DevExpress.XtraEditors.SpinEdit> spinEdits = new List<DevExpress.XtraEditors.SpinEdit>();
        /// <summary>
        /// 電表廠牌ComboBox集合
        /// </summary>
        private List<DevExpress.XtraEditors.ComboBoxEdit> comboBoxEdits = new List<DevExpress.XtraEditors.ComboBoxEdit>();
        /// <summary>
        /// 電表類型ComboBox集合
        /// </summary>
        private List<DevExpress.XtraEditors.ComboBoxEdit> comboBoxEdits2 = new List<DevExpress.XtraEditors.ComboBoxEdit>();
        /// <summary>
        /// 迴路ComboBox集合
        /// </summary>
        private List<DevExpress.XtraEditors.ComboBoxEdit> comboBoxEdits3 = new List<DevExpress.XtraEditors.ComboBoxEdit>();
        /// <summary>
        /// 相位ComboBox集合
        /// </summary>
        private List<DevExpress.XtraEditors.ComboBoxEdit> comboBoxEdits4 = new List<DevExpress.XtraEditors.ComboBoxEdit>();
        public SettingView()
        {
            InitializeComponent();
        }
        private void SettingView_Load(object sender, EventArgs e)
        {
            gateWay = InitialMethod.GateWayLoad();
            taiwan_DistricsSetting = InitialMethod.Taiwan_DistricsLoad();
            #region 產生電錶填入欄位
            for (int i = 0; i < 30; i++) //toggleSwitch = 啟動, toggleSwitch2 = 總錶
            {
                DevExpress.XtraEditors.ToggleSwitch toggleSwitch = new DevExpress.XtraEditors.ToggleSwitch
                {
                    Name = $"toggleSwitch{ 1 + i * 2}",
                    Location = new Point(10, 8 + 25 * i),
                    Size = new Size(48, 19),
                    IsOn = false
                };
                toggleSwitch.Properties.ShowText = false;
                xtraScrollableControl1.Controls.Add(toggleSwitch);
                DevExpress.XtraEditors.ToggleSwitch toggleSwitch2 = new DevExpress.XtraEditors.ToggleSwitch
                {
                    Name = $"toggleSwitch{ 2 + i * 2}",
                    Location = new Point(600, 8 + 25 * i),
                    Size = new Size(48, 19),
                    IsOn = false
                };
                toggleSwitch2.Properties.ShowText = false;
                xtraScrollableControl1.Controls.Add(toggleSwitch2);
                toggleSwitches.Add(toggleSwitch);
                toggleSwitches2.Add(toggleSwitch2);
            }
            for (int i = 0; i < 30; i++) //設備名稱
            {
                DevExpress.XtraEditors.TextEdit textEdit = new DevExpress.XtraEditors.TextEdit
                {
                    Name = $"textEdit{1 + i}",
                    Location = new Point(65, 6 + 25 * i),
                    Size = new Size(105, 22)
                };
                xtraScrollableControl1.Controls.Add(textEdit);
                textEdits.Add(textEdit);
            }
            for (int i = 0; i < 30; i++) //設備ID
            {
                DevExpress.XtraEditors.SpinEdit spinEdit = new DevExpress.XtraEditors.SpinEdit
                {
                    Name = $"spinEdit{1 + i}",
                    Location = new Point(185, 6 + 25 * i),
                    Size = new Size(55, 20)
                };
                spinEdit.Properties.MaxValue = 254;
                spinEdit.Properties.MinValue = 1;
                spinEdit.Properties.IsFloatValue = false;
                xtraScrollableControl1.Controls.Add(spinEdit);
                spinEdits.Add(spinEdit);
            }
            for (int i = 0; i < 30; i++) //電錶廠牌
            {
                DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit
                {
                    Name = $"comboBoxEdit{1 + i * 4}",
                    Location = new Point(250, 6 + 25 * i),
                    Size = new Size(105, 22),
                    Tag = i
                };
                comboBoxEdit.SelectedIndexChanged += ComboBoxEdit1_SelectedIndexChanged;
                comboBoxEdit.Properties.Items.Add("PA310");
                comboBoxEdit.Properties.Items.Add("HC6600");
                comboBoxEdit.Properties.Items.Add("CPM6");
                comboBoxEdit.Properties.Items.Add("PA60");
                comboBoxEdit.Properties.Items.Add("ABBM2M");
                comboBoxEdit.Properties.AllowFocused = false;
                comboBoxEdit.Properties.AllowMouseWheel = false;
                comboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                xtraScrollableControl1.Controls.Add(comboBoxEdit);
                comboBoxEdits.Add(comboBoxEdit);
            }
            for (int i = 0; i < 30; i++) //comboBoxEdit2 = 電錶類型, comboBoxEdit3 = 迴路, comboBoxEdit4 = 相位
            {
                DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit
                {
                    Name = $"comboBoxEdit{2 + i * 4}",
                    Location = new Point(365, 6 + 25 * i),
                    Size = new Size(68, 22),
                    Tag = i
                };
                comboBoxEdit2.SelectedIndexChanged += ComboBoxEdit2_SelectedIndexChanged;
                comboBoxEdit2.Properties.Items.Add("三相");
                comboBoxEdit2.Properties.Items.Add("單相");
                comboBoxEdit2.Properties.AllowFocused = false;
                comboBoxEdit2.Properties.AllowMouseWheel = false;
                comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                xtraScrollableControl1.Controls.Add(comboBoxEdit2);
                DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit3 = new DevExpress.XtraEditors.ComboBoxEdit
                {
                    Name = $"comboBoxEdit{3 + i * 4}",
                    Location = new Point(442, 6 + 25 * i),
                    Size = new Size(68, 22),
                    Tag = i
                };
                comboBoxEdit3.Properties.Items.Add("迴路1");
                comboBoxEdit3.Properties.Items.Add("迴路2");
                comboBoxEdit3.Properties.Items.Add("迴路3");
                comboBoxEdit3.Properties.Items.Add("迴路4");
                comboBoxEdit3.Properties.AllowFocused = false;
                comboBoxEdit3.Properties.AllowMouseWheel = false;
                comboBoxEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                xtraScrollableControl1.Controls.Add(comboBoxEdit3);
                DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit4 = new DevExpress.XtraEditors.ComboBoxEdit
                {
                    Name = $"comboBoxEdit{4 + i * 4}",
                    Location = new Point(518, 6 + 25 * i),
                    Size = new Size(68, 22),
                    Tag = i
                };
                comboBoxEdit4.Properties.Items.Add("R相");
                comboBoxEdit4.Properties.Items.Add("S相");
                comboBoxEdit4.Properties.Items.Add("T相");
                comboBoxEdit4.Properties.AllowFocused = false;
                comboBoxEdit4.Properties.AllowMouseWheel = false;
                comboBoxEdit4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                xtraScrollableControl1.Controls.Add(comboBoxEdit4);
                comboBoxEdits2.Add(comboBoxEdit2);
                comboBoxEdits3.Add(comboBoxEdit3);
                comboBoxEdits4.Add(comboBoxEdit4);
            }
            #endregion
        }

        private void ComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 僅三相表邏輯
            DevExpress.XtraEditors.ComboBoxEdit comboBox = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            int Index = Convert.ToInt32(comboBox.Tag);
            if (comboBox.Text == "ABBM2M")
            {
                comboBoxEdits2[Index].SelectedIndex = 0;
                comboBoxEdits2[Index].Enabled = false;
            }
            if (comboBox.Text == "CPM6")
            {
                comboBoxEdits2[Index].SelectedIndex = 0;
                comboBoxEdits2[Index].Enabled = false;
            }
            #endregion
        }

        private void ComboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 單三相表邏輯
            DevExpress.XtraEditors.ComboBoxEdit comboBox = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            int Index = Convert.ToInt32(comboBox.Tag);
            if (comboBox.Text == "三相")
            {
                if (comboBoxEdits[Index].Text == "PA60")
                {
                    comboBoxEdits4[Index].Enabled = false;
                    comboBoxEdits4[Index].SelectedIndex = -1;
                    comboBoxEdits3[Index].Enabled = true;
                }
                else
                {
                    comboBoxEdits4[Index].Enabled = false;
                    comboBoxEdits4[Index].SelectedIndex = -1;
                    comboBoxEdits3[Index].SelectedIndex = 0;
                    comboBoxEdits3[Index].Enabled = false;
                }
            }
            else
            {
                if (comboBoxEdits[Index].Text == "PA310")
                {
                    comboBoxEdits4[Index].Enabled = false;
                    comboBoxEdits4[Index].SelectedIndex = 0;
                    comboBoxEdits3[Index].SelectedIndex = 0;
                    comboBoxEdits3[Index].Enabled = false;
                }
                else if (comboBoxEdits[Index].Text == "PA60")
                {
                    comboBoxEdits3[Index].Enabled = true;
                    comboBoxEdits4[Index].Enabled = true;
                }
                else
                {
                    comboBoxEdits4[Index].Enabled = true;
                    comboBoxEdits3[Index].SelectedIndex = 0;
                    comboBoxEdits3[Index].Enabled = false;
                }
            }
            #endregion
        }

        private void StoresimpleButton_Click(object sender, EventArgs e)
        {
            #region 寫入Json資料
            #region 寫入上層資訊進Json
            gateWay.ControlFlag = ComtoggleSwitch.IsOn;
            gateWay.RecordFlag = RecordtoggleSwitch.IsOn;
            if (ComcomboBoxEdit.SelectedIndex == 0)
            {
                gateWay.GateWays[0].ModbusRTULocation = ComPortcomboBoxEdit.Text;
                gateWay.GateWays[0].ModbusRTURate = Convert.ToInt32(RTURatetextEdit.Text);
                gateWay.GateWays[0].GatewayEnumType = Convert.ToInt32(ComcomboBoxEdit.SelectedIndex);
            }
            else if (ComcomboBoxEdit.SelectedIndex == 1)
            {
                gateWay.GateWays[0].ModbusTCPLocation = ComTCPtextEdit.Text;
                gateWay.GateWays[0].ModbusTCPRate = Convert.ToInt32(RatetextEdit.Text);
                gateWay.GateWays[0].GatewayEnumType = Convert.ToInt32(ComcomboBoxEdit.SelectedIndex);
            }
            else if (ComcomboBoxEdit.SelectedIndex == 2)
            {
                gateWay.GateWays[0].APILocation = HTTPtextEdit.Text;
                gateWay.GateWays[0].GatewayEnumType = Convert.ToInt32(ComcomboBoxEdit.SelectedIndex);
            }
            else if (ComcomboBoxEdit.SelectedIndex == 3)
            {
                gateWay.GateWays[0].EMSLocation = ComTCPtextEdit.Text;
                gateWay.GateWays[0].EMSRate = Convert.ToInt32(RatetextEdit.Text);
                gateWay.GateWays[0].GatewayEnumType = Convert.ToInt32(ComcomboBoxEdit.SelectedIndex);
            }

            #endregion
            #region 寫入天氣感測器資訊進Json
            if (ATMtextEdit.Text == null)
            {
                gateWay.GateWays[0].Authorization = ATMtextEdit.Text;
            }
            gateWay.GateWays[0].LocationName = CitycomboBoxEdit.Text;
            gateWay.GateWays[0].WeatherTypeEnum = Convert.ToInt32(CitycomboBoxEdit.SelectedIndex);
            gateWay.GateWays[0].DistrictName = ZonecomboBoxEdit.Text;
            gateWay.GateWays[0].GateWaySenserIDs[0].DeviceID = Convert.ToByte(IDspinEdit.Text);
            gateWay.GateWays[0].GateWaySenserIDs[0].DeviceIndex = (Convert.ToByte(IDspinEdit.Text) - 1);
            gateWay.GateWays[0].GateWaySenserIDs[0].SenserEnumType = Convert.ToInt32(DeviceTypecomboBoxEdit.SelectedIndex);
            gateWay.GateWays[0].GateWaySenserIDs[0].DeviceName = DeviceNametextEdit.Text;
            #endregion
            #region 寫入電錶項目進Json
            gateWay.GateWays[0].GateWayElectricIDs.Clear();
            int j = 1;
            for (int i = 0; i < toggleSwitches.Count; i++)
            {
                if (toggleSwitches[i].IsOn == true)
                {
                    gateWay.GateWays[0].GateWayElectricIDs.Add(new GateWayElectricID() { TotalMeterFlag = toggleSwitches2[i].IsOn, DeviceID = Convert.ToByte(spinEdits[i].Text), DeviceIndex = Convert.ToByte(j), ElectricEnumType = comboBoxEdits[i].SelectedIndex, LoopEnumType = comboBoxEdits3[i].SelectedIndex, PhaseEnumType = comboBoxEdits2[i].SelectedIndex, PhaseAngleEnumType = comboBoxEdits4[i].SelectedIndex, DeviceName = textEdits[i].Text });
                    j += 1;
                }
            }
            #endregion
            string setFile = $"{MyWorkPath}\\stf\\GateWay.json";
            string output = JsonConvert.SerializeObject(gateWay, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(setFile, output, Encoding.UTF8);
            MessageBox.Show("儲存成功!!");
            #endregion
        }
        private void CitycomboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 行政區的值帶入
            if (CitycomboBoxEdit.Text != null)
            {
                ZonecomboBoxEdit.Enabled = true;
                ZonecomboBoxEdit.Properties.Items.Clear();
                ZonecomboBoxEdit.Text = null;
                var zzone = taiwan_DistricsSetting.Where(g => g.CityName == CitycomboBoxEdit.Text).Select(g => g.AreaList).ToArray();
                for (int i = 0; i < zzone.Length; i++)
                {
                    for (int j = 0; j < zzone[0].Length; j++)
                    {
                        ZonecomboBoxEdit.Properties.Items.Add(zzone[i][j].AreaName);
                    }
                }
            }
            #endregion
        }
        private void DeviceTypecomboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 感測器設備ID不需填寫的例外狀況
            if (DeviceTypecomboBoxEdit.SelectedIndex == 2)
            {
                IDspinEdit.Enabled = false;
            }
            #endregion
        }
        private void ComcomboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 通訊填入項目邏輯
            labelControl4.Visible = false;
            labelControl19.Visible = false;
            labelControl20.Visible = false;
            labelControl21.Visible = false;
            labelControl22.Visible = false;
            ComPortcomboBoxEdit.Visible = false;
            ComTCPtextEdit.Visible = false;
            HTTPtextEdit.Visible = false;
            RatetextEdit.Visible = false;
            RTURatetextEdit.Visible = false;
            ComPortcomboBoxEdit.Text = null;
            ComTCPtextEdit.Text = null;
            HTTPtextEdit.Text = null;
            RatetextEdit.Text = null;
            RTURatetextEdit.Text = null;
            if (ComcomboBoxEdit.SelectedIndex == 0)
            {
                labelControl4.Visible = true;
                labelControl22.Visible = true;
                ComPortcomboBoxEdit.Visible = true;
                RTURatetextEdit.Visible = true;
                if (ComPortcomboBoxEdit.Properties.Items.Count > 0)
                {
                    ComPortcomboBoxEdit.Properties.Items.Clear();
                }
                string[] ports2 = SerialPort.GetPortNames();
                ComPortcomboBoxEdit.Properties.Items.AddRange(ports2);
            }
            else if (ComcomboBoxEdit.SelectedIndex == 1)
            {
                labelControl19.Visible = true;
                labelControl21.Visible = true;
                ComTCPtextEdit.Visible = true;
                RatetextEdit.Visible = true;
            }
            else if (ComcomboBoxEdit.SelectedIndex == 2)
            {
                labelControl20.Visible = true;
                HTTPtextEdit.Visible = true;
            }
            else if (ComcomboBoxEdit.SelectedIndex == 3)
            {
                labelControl19.Visible = true;
                labelControl21.Visible = true;
                ComTCPtextEdit.Visible = true;
                RatetextEdit.Visible = true;
            }
            #endregion
        }
    }
}
