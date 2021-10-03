using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO.Ports;
using Hardcodet.Wpf.TaskbarNotification;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Animation;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls.Primitives;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Threading;

namespace USBMediaController
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //------------------------------------------------------------------------------------
        #region VARIABLES

        Containter_ConnectionInfo connectionInfo = new Containter_ConnectionInfo();
        Container_ControllerConfig controllerConfig = new Container_ControllerConfig();
        string recivedData;
        string commandTmp="";
        string uartReciverBuffer = "";

        private delegate void UpdateUiTextDelegate(string text);
        #endregion

        //------------------------------------------------------------------------------------
        #region CONSTRUCTOR
        public MainWindow()
        {
            InitializeComponent();
           

            if(File.Exists(@"C:\USBMediaControllerv2\icon.ico")) tray_main.Icon = new System.Drawing.Icon(@"C:\USBMediaControllerv2\icon.ico");
            else ConsoleWrite("#Error Load Icon");

            if (!LoadCommunicationConfig())
            {
                ConsoleWrite("#Error Load Connection Config");
                ShowSysTrayInfo("USBMediaController", "Error Load Connection Config", BalloonIcon.Error);
            }
            else
            {
                btn_connect.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
            if (!LoadControllerConfig())
            {
                ConsoleWrite("#Error Load Controller Config");
                ShowSysTrayInfo("USBMediaController", "Error Load Controller Config", BalloonIcon.Error);
            }
            if (!LoadControllerCurrentSelected())
            {
                ConsoleWrite("#Error Load Controller Current Selected Profile Config");
                ShowSysTrayInfo("USBMediaController", "Error Load Controller Current Selected Profile Config", BalloonIcon.Error);
            }
            CheckFirstRun();
            SetAllInfoControls();
            //CenterWindowOnScreen();
            this.Hide();
        }

        #endregion

        //------------------------------------------------------------------------------------
        #region METHODS

        /*private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }*/

        private void SendUART(string data, int count)
        {
            if (connectionInfo.serial.IsOpen)
            {
                try
                {
                    byte[] hexstring = Encoding.ASCII.GetBytes(data);
                    foreach (byte hexval in hexstring)
                    {
                        byte[] _hexval = new byte[] { hexval };
                        connectionInfo.serial.Write(_hexval, 0, count);
                        Thread.Sleep(1);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleWrite("#Failed send: " + data + "(" + ex.Message + ")");
                }
            }
            else
            {
            }
        }

     
        private string getConnectionStatus()
        {
            if (connectionInfo.serial.IsOpen) return "Connected at port " + connectionInfo.getPortName();
            else return "Disconnected";
        }

        private void SetConnectionInfoFields()
        {
            lbl_connectionStatus.Content = getConnectionStatus();
            lbl_trayInfoConnection.Content = getConnectionStatus();
        }

        private void SetProfileInfoFields()
        {
            lbl_selectedProfile.Content = controllerConfig.getSelectedLabel();
            lbl_trayInfoProfile.Content = "Profile: " + controllerConfig.getSelectedLabel();
        }

        private void SetAllInfoControls()
        {
            SetConnectionInfoFields();
            SetProfileInfoFields();
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;


        public void ExecuteCommand(string command, bool state)
        {
            // comands list: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN

            Dictionary<string, byte> scanCodes = new Dictionary<string, byte>();
            #region ScanCodes

            scanCodes.Add("A", (byte)0x41);
            scanCodes.Add("B", (byte)0x42);
            scanCodes.Add("C", (byte)0x43);
            scanCodes.Add("D", (byte)0x44);
            scanCodes.Add("E", (byte)0x45);
            scanCodes.Add("F", (byte)0x46);
            scanCodes.Add("G", (byte)0x47);
            scanCodes.Add("H", (byte)0x48);
            scanCodes.Add("I", (byte)0x49);
            scanCodes.Add("J", (byte)0x4A);
            scanCodes.Add("K", (byte)0x4B);
            scanCodes.Add("L", (byte)0x4C);
            scanCodes.Add("M", (byte)0x4D);
            scanCodes.Add("N", (byte)0x4E);
            scanCodes.Add("O", (byte)0x4F);
            scanCodes.Add("P", (byte)0x50);
            scanCodes.Add("Q", (byte)0x51);
            scanCodes.Add("R", (byte)0x52);
            scanCodes.Add("S", (byte)0x53);
            scanCodes.Add("T", (byte)0x54);
            scanCodes.Add("U", (byte)0x55);
            scanCodes.Add("V", (byte)0x56);
            scanCodes.Add("W", (byte)0x57);
            scanCodes.Add("X", (byte)0x58);
            scanCodes.Add("Y", (byte)0x59);
            scanCodes.Add("Z", (byte)0x5A);
            scanCodes.Add("1", (byte)0x31);
            scanCodes.Add("2", (byte)0x32);
            scanCodes.Add("3", (byte)0x33);
            scanCodes.Add("4", (byte)0x34);
            scanCodes.Add("5", (byte)0x35);
            scanCodes.Add("6", (byte)0x36);
            scanCodes.Add("7", (byte)0x37);
            scanCodes.Add("8", (byte)0x38);
            scanCodes.Add("9", (byte)0x39);
            scanCodes.Add("0", (byte)0x30);

            scanCodes.Add("[", (byte)0xDB);
            scanCodes.Add("]", (byte)0xDD);
            scanCodes.Add("\\", (byte)0xDC);
            scanCodes.Add(";", (byte)0xBA);
            scanCodes.Add("'", (byte)0xDE);
            scanCodes.Add(",", (byte)0xBC);
            scanCodes.Add(".", (byte)0xBE);
            scanCodes.Add("/", (byte)0xBF);
            scanCodes.Add("-", (byte)0xBD);
            //scanCodes.Add("=", (byte));
            scanCodes.Add("`", (byte)0xC0);

            scanCodes.Add("F1", (byte)0x70);
            scanCodes.Add("F2", (byte)0x71);
            scanCodes.Add("F3", (byte)0x72);
            scanCodes.Add("F4", (byte)0x73);
            scanCodes.Add("F5", (byte)0x74);
            scanCodes.Add("F6", (byte)0x75);
            scanCodes.Add("F7", (byte)0x76);
            scanCodes.Add("F8", (byte)0x77);
            scanCodes.Add("F9", (byte)0x78);
            scanCodes.Add("F10", (byte)0x79);
            scanCodes.Add("F11", (byte)0x7A);
            scanCodes.Add("F12", (byte)0x7B);

            scanCodes.Add("LCTRL", (byte)0xA2);
            scanCodes.Add("RCTRL", (byte)0xA3);
            scanCodes.Add("LSHIFT", (byte)0xA0);
            scanCodes.Add("RSHIFT", (byte)0xA1);
            scanCodes.Add("LALT", (byte)0x12);
            //scanCodes.Add("RALT", (byte));
            scanCodes.Add("BACKSPACE", (byte)0x08);
            scanCodes.Add("ESC", (byte)0x1B);
            scanCodes.Add("INSERT", (byte)0x2D);
            scanCodes.Add("DELETE", (byte)0x2E);
            scanCodes.Add("HOME", (byte)0x24);
            scanCodes.Add("END", (byte)0x23);
            scanCodes.Add("PGUP", (byte)0x21);
            scanCodes.Add("PGDOWN", (byte)0x22);
            scanCodes.Add("PRTSCR", (byte)0x2C);
            scanCodes.Add("SCRLCK", (byte)0x91);
            scanCodes.Add("PAUSE", (byte)0x13);
            scanCodes.Add("NUMLCK", (byte)0x90);
            scanCodes.Add("CAPSLCK", (byte)0x14);
            scanCodes.Add("TAB", (byte)0x09);
            scanCodes.Add("SPACE", (byte)0x20);
            scanCodes.Add("ENTER", (byte)0x0D);

            scanCodes.Add("NUMERIC/", (byte)0x6F);
            scanCodes.Add("NUMERIC*", (byte)0x6A);
            scanCodes.Add("NUMERIC-", (byte)0x6D);
            scanCodes.Add("NUMERIC1", (byte)0x61);
            scanCodes.Add("NUMERIC2", (byte)0x62);
            scanCodes.Add("NUMERIC3", (byte)0x63);
            scanCodes.Add("NUMERIC4", (byte)0x64);
            scanCodes.Add("NUMERIC5", (byte)0x65);
            scanCodes.Add("NUMERIC6", (byte)0x66);
            scanCodes.Add("NUMERIC7", (byte)0x67);
            scanCodes.Add("NUMERIC8", (byte)0x68);
            scanCodes.Add("NUMERIC9", (byte)0x69);
            scanCodes.Add("NUMERIC0", (byte)0x60);
            scanCodes.Add("NUMERIC+", (byte)0x6B);
            scanCodes.Add("NUMERIC,", (byte)0x6E);

            scanCodes.Add("UPARROW", (byte)0x26);
            scanCodes.Add("DOWNARROW", (byte)0x28);
            scanCodes.Add("LEFTARROW", (byte)0x25);
            scanCodes.Add("RIGHTARROW", (byte)0x27);

            #endregion

            byte currentScanCode = 0;
            scanCodes.TryGetValue(command, out currentScanCode);

                if(state)                    
                    keybd_event(currentScanCode, 0, 0, 0);
                else
                    keybd_event(currentScanCode, 0, KEYEVENTF_KEYUP | 0, 0);         
        }


        public void CheckInputCommand(string command)
        {
            command = command.Replace("\r", "");

            if(command=="d1" || command == "u1")
            {
                if (command == "d1")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("UP", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u1")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("UP", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d2" || command == "u2")
            {
                if (command == "d2")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("LEFT", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u2")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("LEFT", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d3" || command == "u3")
            {
                if (command == "d3")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("RIGHT", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u3")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("RIGHT", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d4" || command == "u4")
            {
                if (command == "d4")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("DOWN", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u4")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("DOWN", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d5" || command == "u5")
            {
                if (command == "d5")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A1", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u5")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A1", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d6" || command == "u6")
            {
                if (command == "d6")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A2", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u6")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A2", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d7" || command == "u7")
            {
                if (command == "d7")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A3", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u7")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A3", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d8" || command == "u8")
            {
                if (command == "d8")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A4", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u8")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A4", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d9" || command == "u9")
            {
                if (command == "d9")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A5", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u9")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A5", controllerConfig.getSelectedLabel()), false);
                }
            }

            else if (command == "d10" || command == "u10")
            {
                if (command == "d10")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A6", controllerConfig.getSelectedLabel()), true);
                }
                else if (command == "u10")
                {
                    ExecuteCommand(controllerConfig.getCommandByID("A6", controllerConfig.getSelectedLabel()), false);
                }
            }           
            //Thread.Sleep(10);
            
        }


        private void CheckFirstRun()
        {
            if(controllerConfig.list.Count == 0)
            {
                Container_ControllerConfig tmp = new Container_ControllerConfig();
                tmp.setLabel("Default");
                controllerConfig.setSelectedLabel("Default");

                tmp.setProfileSetting(0, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(1, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(2, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(3, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(4, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(5, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(6, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(7, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(8, new Container_SingleCommand("---", "---"));
                tmp.setProfileSetting(9, new Container_SingleCommand("---", "---"));

                controllerConfig.list.Add(tmp);
            }
        }


        private void ShowSysTrayInfo(string title, string text, BalloonIcon icon)
        {
            tray_main.ShowBalloonTip(title, text, icon);
        }

        private void Recieve(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            recivedData = connectionInfo.serial.ReadLine();
            Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(UseRecivedData), recivedData);
        }



        private void UseRecivedData(string text)
        {
            uartReciverBuffer += text;
            if (uartReciverBuffer.Contains("d1") ||
                uartReciverBuffer.Contains("d2") ||
                uartReciverBuffer.Contains("d3") ||
                uartReciverBuffer.Contains("d4") ||
                uartReciverBuffer.Contains("d5") ||
                uartReciverBuffer.Contains("d6") ||
                uartReciverBuffer.Contains("d7") ||
                uartReciverBuffer.Contains("d8") ||
                uartReciverBuffer.Contains("d9") ||
                uartReciverBuffer.Contains("d10") ||
                uartReciverBuffer.Contains("u1") ||
                uartReciverBuffer.Contains("u2") ||
                uartReciverBuffer.Contains("u3") ||
                uartReciverBuffer.Contains("u4") ||
                uartReciverBuffer.Contains("u5") ||
                uartReciverBuffer.Contains("u6") ||
                uartReciverBuffer.Contains("u7") ||
                uartReciverBuffer.Contains("u8") ||
                uartReciverBuffer.Contains("u9") ||
                uartReciverBuffer.Contains("u10"))
            {
                CheckInputCommand(uartReciverBuffer);
                ConsoleWrite(uartReciverBuffer);
                uartReciverBuffer = "";
            }
        }

        private void ConsoleWrite(string val)
        {
            tbx_console.Text += val + "\n";


            tbx_console.SelectionStart = tbx_console.Text.Length;
            tbx_console.ScrollToEnd();
        }

        #endregion

        //------------------------------------------------------------------------------------
        #region SAVE OPERATION METHODS

        private void SaveCommunicationConfig()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) Directory.CreateDirectory(@"C:\USBGameStick\");
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\USBGameStick\ConfigConnection.bin", FileMode.Create)))
            {
                binWriter.Write(connectionInfo.getPortName());
                binWriter.Write(connectionInfo.getBaudRate());
                binWriter.Write(connectionInfo.getHandshake());
                binWriter.Write(connectionInfo.getParity());
                binWriter.Write(connectionInfo.getDataBits());
                binWriter.Write(connectionInfo.getStopBits());
                binWriter.Write(connectionInfo.getReadTimeout());
                binWriter.Write(connectionInfo.getWriteTimeout());
            }
        }

        private bool LoadCommunicationConfig()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) return false;
            if (!File.Exists(@"C:\USBGameStick\ConfigConnection.bin")) return false;
            using (BinaryReader binReader = new BinaryReader(File.Open(@"C:\USBGameStick\ConfigConnection.bin", FileMode.Open)))
            {
                connectionInfo.setPortName(binReader.ReadString());
                connectionInfo.setBaudRate(binReader.ReadInt32());
                connectionInfo.setHandshake(binReader.ReadString());
                connectionInfo.setParity(binReader.ReadString());
                connectionInfo.setDataBits(binReader.ReadInt32());
                connectionInfo.setStopBits(binReader.ReadString());
                connectionInfo.setReadTimeout(binReader.ReadInt32());
                connectionInfo.setWriteTimeout(binReader.ReadInt32());
            }
            connectionInfo.SetSerial();

            return true;
        }


        private void SaveControllerConfig()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) Directory.CreateDirectory(@"C:\USBGameStick\");
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\USBGameStick\ConfigController.bin", FileMode.Create)))
            {
                for(int clk = 0; clk < controllerConfig.list.Count; clk++)
                {
                    binWriter.Write(controllerConfig.list[clk].getLabel());

                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(0).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(0).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(1).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(1).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(2).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(2).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(3).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(3).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(4).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(4).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(5).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(5).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(6).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(6).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(7).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(7).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(8).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(8).getField());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(9).getCommand());
                    binWriter.Write(controllerConfig.list[clk].getProfileSetting(9).getField());
                }
            }
        }

        private bool LoadControllerConfig()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) return false;
            if (!File.Exists(@"C:\USBGameStick\ConfigController.bin")) return false;
            using (BinaryReader binReader = new BinaryReader(File.Open(@"C:\USBGameStick\ConfigController.bin", FileMode.Open)))
            {
                int size = LoadControllerListSize();

                for (int clk = 0; clk < size; clk++)
                {
                    Container_ControllerConfig tmp = new Container_ControllerConfig();
                    tmp.setLabel(binReader.ReadString());

                    tmp.setProfileSetting(0, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(1, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(2, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(3, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));

                    tmp.setProfileSetting(4, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(5, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(6, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(7, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));

                    tmp.setProfileSetting(8, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));
                    tmp.setProfileSetting(9, new Container_SingleCommand(binReader.ReadString(), binReader.ReadString()));  

                    controllerConfig.list.Add(tmp);
                }
            }
            return true;
        }

        private void SaveControllerCurrentSelected()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) Directory.CreateDirectory(@"C:\USBGameStick\");
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\USBGameStick\ConfigConnectionCurrent.bin", FileMode.Create)))
            {
                binWriter.Write(controllerConfig.getSelectedLabel());
            }
        }

        private bool LoadControllerCurrentSelected()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) return false;
            if (!File.Exists(@"C:\USBGameStick\ConfigConnectionCurrent.bin")) return false;
            using (BinaryReader binReader = new BinaryReader(File.Open(@"C:\USBGameStick\ConfigConnectionCurrent.bin", FileMode.Open)))
            {
                controllerConfig.setSelectedLabel(binReader.ReadString());
            }
            return true;
        }

        private void SaveControllerListSize()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) Directory.CreateDirectory(@"C:\USBGameStick\");
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\USBGameStick\ConfigConnectionSize.bin", FileMode.Create)))
            {
                binWriter.Write(controllerConfig.list.Count);
            }
        }

        private int LoadControllerListSize()
        {
            if (!Directory.Exists(@"C:\USBGameStick\")) return 0;
            if (!File.Exists(@"C:\USBGameStick\ConfigConnectionSize.bin")) return 0;
            int size = 0;
            using (BinaryReader binReader = new BinaryReader(File.Open(@"C:\USBGameStick\ConfigConnectionSize.bin", FileMode.Open)))
            {
                size = binReader.ReadInt32();
            }
            return size;
        }


        #endregion

        //------------------------------------------------------------------------------------
        #region SLOTS

 

        private void btn_ConnectionSettings_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings(connectionInfo);
            connectionSettings.ShowDialog();
            if (connectionSettings.AcceptChanges())
            {
                connectionInfo = connectionSettings.getConnectionInfo();
                SaveCommunicationConfig();
            }
            SetAllInfoControls();
        }

        private void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connectionInfo.serial.IsOpen)
                {
                    connectionInfo.serial.Close();
                    if (!connectionInfo.serial.IsOpen)
                    {
                        btn_connect.Content = "Connect";
                        ShowSysTrayInfo("USBMediaController", "Disconnected", BalloonIcon.Info);
                        ConsoleWrite("#Disconnected");
                    }
                }
                else
                {
                    connectionInfo.serial.Open();
                    if (connectionInfo.serial.IsOpen)
                    {
                        connectionInfo.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Recieve);
                        btn_connect.Content = "Disconnect";
                        ShowSysTrayInfo("USBMediaController", "Connected at port " + connectionInfo.getPortName(), BalloonIcon.Info);
                        ConsoleWrite("#Connected at port " + connectionInfo.getPortName());
                    }
                }
                SetAllInfoControls();
            }
            catch (Exception exception)
            {
                ShowSysTrayInfo("USBMediaController", exception.Message, BalloonIcon.Error);
                ConsoleWrite("#ERROR: " + exception.Message);
            }
        }

        private void btn_CommandSettings_Click(object sender, RoutedEventArgs e)
        {
            ControllerConfig window = new ControllerConfig(controllerConfig);
            window.ShowDialog();
            if (window.Apply())
            {
                controllerConfig = window.GetConfig();
                SaveControllerConfig();
                SaveControllerCurrentSelected();
                SaveControllerListSize();
            }
            SetAllInfoControls();
        }

        private void btn_trayClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_minimalise_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_hideToTray_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btn_trayShow_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void btn_clearConsole_Click(object sender, RoutedEventArgs e)
        {
            tbx_console.Clear();
        }



        #endregion

    }
}
