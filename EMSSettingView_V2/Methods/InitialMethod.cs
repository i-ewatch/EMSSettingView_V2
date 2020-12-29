using EMSSettingView_V2.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSSettingView_V2.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        #region 設備通訊資訊
        /// <summary>
        /// 設備通訊資訊
        /// </summary>
        /// <returns></returns>
        public static GateWaySetting GateWayLoad()
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\GateWay.json";
            GateWaySetting setting;
            if (File.Exists(SettingPath))
            {
                string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                setting = JsonConvert.DeserializeObject<GateWaySetting>(json);
            }
            else
            {
                setting =new GateWaySetting()
                {
                    ControlFlag = true,
                    RecordFlag = true,
                    UploadFlag = false,
                    GateWays =
                            {
                                new GateWay()
                                {
                                    GatewayIndex = 0,
                                    ModbusRTULocation = "COM4",
                                    ModbusRTURate = 9600,
                                    ModbusTCPLocation = "127.0.0.1",
                                    ModbusTCPRate = 502,
                                    APILocation = "通訊網址",
                                    EMSLocation = "127.0.0.1",
                                    EMSRate = 502,
                                    WeatherAPILocation = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?",
                                    Authorization = "氣象開放資料平台會員授權碼",
                                    LocationName = "臺北市",
                                    WeatherTypeEnum = 1,
                                    DistrictName = "中正區",
                                    GatewayEnumType = 1,
                                    GateWaySenserIDs =
                                    {
                                        new GateWaySenserID()
                                        {
                                            DeviceIndex = 1,
                                            DeviceID = 1,
                                            SenserEnumType = 0,
                                            DeviceName = "環境感測器1"
                                        }
                                    },
                                    GateWayElectricIDs =
                                    {
                                        new GateWayElectricID()
                                        {
                                            TotalMeterFlag = false,
                                            DeviceIndex = 0,
                                            DeviceID = 1,
                                            ElectricEnumType = 0,
                                            LoopEnumType = 0,
                                            PhaseEnumType = 0,
                                            PhaseAngleEnumType = 0,
                                            DeviceName = "電表1"
                                        }
                                    },
                                    GatewayName = "通道名稱1"
                                }
                            }

                };
                string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                File.WriteAllText(SettingPath, output);
            }
            return setting;
        }
        #endregion
        #region 台灣縣市區資訊
        /// <summary>
        /// 台灣縣市區資訊
        /// </summary>
        /// <returns></returns>
        public static List<Taiwan_DistricsSetting> Taiwan_DistricsLoad()
        {
            List<Taiwan_DistricsSetting> setting = new List<Taiwan_DistricsSetting>();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Taiwan_Districts.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.Default);
                    setting = JsonConvert.DeserializeObject<List<Taiwan_DistricsSetting>>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 台灣縣市區資訊設定載入錯誤");
            }
            return setting;
        }
        #endregion
        #region 使用者帳號密碼
        public static List<UserSetting> UserSettings()
        {
            List<UserSetting> setting = new List<UserSetting>();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\UserDate.json";
            if (File.Exists(SettingPath))
            {
                string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                setting = JsonConvert.DeserializeObject<List<UserSetting>>(json);
            }
            else
            {
                setting = new List<UserSetting>()
                {
                    new UserSetting()
                    {
                        UserName = "sa",
                        UserPassWord = "1234"
                    }
                };
                string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                File.WriteAllText(SettingPath, output);
            }
            return setting;
        }
        #endregion
    }
}
