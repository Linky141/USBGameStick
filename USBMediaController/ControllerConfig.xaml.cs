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
using System.Windows.Shapes;

namespace USBMediaController
{
    /// <summary>
    /// Logika interakcji dla klasy ControllerConfig.xaml
    /// </summary>
    public partial class ControllerConfig : Window
    {
        #region VARIABLE
        private Container_ControllerConfig container = new Container_ControllerConfig();
        private bool apply = false;
        private bool gamepadMode = false;
        #endregion

        #region CONSTRUCTOR
        public ControllerConfig()
        {
            InitializeComponent();
            LoadProfiles();
            FillComboBox(IsCurrentGamepad());
            Refresh();
           
        }

        public ControllerConfig(Container_ControllerConfig container)
        {
            InitializeComponent();
            LoadProfiles();
            this.container = container;
            FillComboBox(IsCurrentGamepad());
            Refresh();
            
        }

        #endregion

        #region METHODS

        private void ChangeToControlerON()
        {
            this.gamepadMode = true;
            btnGamepadMode.Content = "Gamepad mode: ON";
            FillComboBox(true);
        }

        private void ChangeToControlerOFF()
        {
            this.gamepadMode = false;
            btnGamepadMode.Content = "Gamepad mode: OFF";
            FillComboBox(false);
        }


        private void LoadProfiles()
        {
            cbx_profile.Items.Clear();
            for (int clk = 0; clk < container.list.Count; clk++) cbx_profile.Items.Add(container.list[clk].getLabel());
            cbx_profile.SelectedItem = container.getSelectedLabel();
        }

        private void Refresh()
        {
            LoadProfiles();

            int current = CurrentProfile();

            if (IsCurrentGamepad())
                ChangeToControlerON();
            else
                ChangeToControlerOFF();

            cbx_upAction.SelectedItem = container.list[current].getProfileSetting(0).getCommand();
            cbx_downAction.SelectedItem = container.list[current].getProfileSetting(1).getCommand();
            cbx_leftAction.SelectedItem = container.list[current].getProfileSetting(2).getCommand();
            cbx_rightAction.SelectedItem = container.list[current].getProfileSetting(3).getCommand();

            cbx_act1Action.SelectedItem = container.list[current].getProfileSetting(4).getCommand();
            cbx_act2Action.SelectedItem = container.list[current].getProfileSetting(5).getCommand();
            cbx_act3Action.SelectedItem = container.list[current].getProfileSetting(6).getCommand();
            cbx_act4Action.SelectedItem = container.list[current].getProfileSetting(7).getCommand();
            cbx_act5Action.SelectedItem = container.list[current].getProfileSetting(8).getCommand();
            cbx_act6Action.SelectedItem = container.list[current].getProfileSetting(9).getCommand();
        }

        private int CurrentProfile()
        {
            for (int clk = 0; clk < container.list.Count; clk++)
            {
                if (container.list[clk].getLabel() == container.getSelectedLabel())
                {
                    return clk;
                }
            }
            return -1;
        }

        private bool IsCurrentGamepad()
        {
            return container.list[CurrentProfile()].getGamepadMode();
        }

        private void FillComboBox(Boolean isGamepad)
        {
            List<string> actionsKeyboard = new List<string>()
            #region fill keyboard
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "N",
                "O",
                "P",
                "Q",
                "R",
                "S",
                "T",
                "U",
                "V",
                "W",
                "X",
                "Y",
                "Z",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "0",
                "[",
                "]",
                "\\",
                ";",
                "'",
                ",",
                ".",
                "/",
                "-",
                "`",
                "F1",
                "F2",
                "F3",
                "F4",
                "F5",
                "F6",
                "F7",
                "F8",
                "F9",
                "F10",
                "F11",
                "F12",
                "LCTRL",
                "RCTRL",
                "LSHIFT",
                "RSHIFT",
                "LALT",
                "BACKSPACE",
                "ESC",
                "INSERT",
                "DELETE",
                "HOME",
                "END",
                "PGUP",
                "PGDOWN",
                "PRTSCR",
                "SCRLCK",
                "PAUSE",
                "NUMLCK",
                "CAPSLCK",
                "TAB",
                "SPACE",
                "ENTER",
                "NUMERIC/",
                "NUMERIC*",
                "NUMERIC-",
                "NUMERIC1",
                "NUMERIC2",
                "NUMERIC3",
                "NUMERIC4",
                "NUMERIC5",
                "NUMERIC6",
                "NUMERIC7",
                "NUMERIC8",
                "NUMERIC9",
                "NUMERIC0",
                "NUMERIC+",
                "NUMERIC,",
                "UPARROW",
                "DOWNARROW",
                "LEFTARROW",
                "RIGHTARROW"
            };
            #endregion
            List<string> actionsGamepad = new List<string>()
            #region fill gamepad
            {
                "DPAD UP",
                "DPAD DOWN",
                "DPAD LEFT",
                "DPAD RIGHT",
                "L STICK UP",
                "L STICK DOWN",
                "L STICK LEFT",
                "L STICK RIGHT",
                "R STICK UP",
                "R STICK DOWN",
                "R STICK LEFT",
                "R STICK RIGHT",
                "A",
                "B",
                "X",
                "Y",
                "BACK",
                "START",
                "RIGHT TRIGGER",
                "RIGHT BUMPER",
                "RIGHT STICK CLICK",
                "LEFT TRIGGER",
                "LEFT BUMPER",
                "LEFT STCIK CLICK"
            };
            #endregion


            ClearAllCombobox();
            if (!gamepadMode)
            {
                for (int clk = 0; clk < actionsKeyboard.Count; clk++)
                {
                    cbx_upAction.Items.Add(actionsKeyboard[clk]);
                    cbx_downAction.Items.Add(actionsKeyboard[clk]);
                    cbx_leftAction.Items.Add(actionsKeyboard[clk]);
                    cbx_rightAction.Items.Add(actionsKeyboard[clk]);
                    cbx_act1Action.Items.Add(actionsKeyboard[clk]);
                    cbx_act2Action.Items.Add(actionsKeyboard[clk]);
                    cbx_act3Action.Items.Add(actionsKeyboard[clk]);
                    cbx_act4Action.Items.Add(actionsKeyboard[clk]);
                    cbx_act5Action.Items.Add(actionsKeyboard[clk]);
                    cbx_act6Action.Items.Add(actionsKeyboard[clk]);
                }
            }
            else
            {
                for (int clk = 0; clk < actionsGamepad.Count; clk++)
                {
                    cbx_upAction.Items.Add(actionsGamepad[clk]);
                    cbx_downAction.Items.Add(actionsGamepad[clk]);
                    cbx_leftAction.Items.Add(actionsGamepad[clk]);
                    cbx_rightAction.Items.Add(actionsGamepad[clk]);
                    cbx_act1Action.Items.Add(actionsGamepad[clk]);
                    cbx_act2Action.Items.Add(actionsGamepad[clk]);
                    cbx_act3Action.Items.Add(actionsGamepad[clk]);
                    cbx_act4Action.Items.Add(actionsGamepad[clk]);
                    cbx_act5Action.Items.Add(actionsGamepad[clk]);
                    cbx_act6Action.Items.Add(actionsGamepad[clk]);
                }
            }

            cbx_upAction.SelectedIndex = 0;
            cbx_downAction.SelectedIndex = 0;
            cbx_leftAction.SelectedIndex = 0;
            cbx_rightAction.SelectedIndex = 0;
            cbx_act1Action.SelectedIndex = 0;
            cbx_act2Action.SelectedIndex = 0;
            cbx_act3Action.SelectedIndex = 0;
            cbx_act4Action.SelectedIndex = 0;
            cbx_act5Action.SelectedIndex = 0;
            cbx_act6Action.SelectedIndex = 0;

        }
        #endregion

        private void ClearAllCombobox()
        {
            cbx_upAction.Items.Clear();
            cbx_downAction.Items.Clear();
            cbx_leftAction.Items.Clear();
            cbx_rightAction.Items.Clear();
            cbx_act1Action.Items.Clear();
            cbx_act2Action.Items.Clear();
            cbx_act3Action.Items.Clear();
            cbx_act4Action.Items.Clear();
            cbx_act5Action.Items.Clear();
            cbx_act6Action.Items.Clear();
        }

        #region SLOTS

        private void btn_profileLoad_Click(object sender, RoutedEventArgs e)
        {
            container.setSelectedLabel(cbx_profile.Text);
            Refresh();
        }

        private void btnGamepadMode_Click(object sender, RoutedEventArgs e)
        {
            if (gamepadMode)
                ChangeToControlerOFF();
            else
                ChangeToControlerON();
        }

        private void btn_profileSave_Click(object sender, RoutedEventArgs e)
        {
            ControlerConfigAddItem window = new ControlerConfigAddItem();
            window.ShowDialog();
            if (window.Apply())
            {
                Container_ControllerConfig tmp = new Container_ControllerConfig();
                tmp.setLabel(window.getName());


                tmp.setProfileSetting(0, new Container_SingleCommand(cbx_upAction.SelectedItem.ToString(), "UP"));
                tmp.setProfileSetting(1, new Container_SingleCommand(cbx_downAction.SelectedItem.ToString(), "DOWN"));
                tmp.setProfileSetting(2, new Container_SingleCommand(cbx_leftAction.SelectedItem.ToString(), "LEFT"));
                tmp.setProfileSetting(3, new Container_SingleCommand(cbx_rightAction.SelectedItem.ToString(), "RIGHT"));
                tmp.setProfileSetting(4, new Container_SingleCommand(cbx_act1Action.SelectedItem.ToString(), "A1"));
                tmp.setProfileSetting(5, new Container_SingleCommand(cbx_act2Action.SelectedItem.ToString(), "A2"));
                tmp.setProfileSetting(6, new Container_SingleCommand(cbx_act3Action.SelectedItem.ToString(), "A3"));
                tmp.setProfileSetting(7, new Container_SingleCommand(cbx_act4Action.SelectedItem.ToString(), "A4"));
                tmp.setProfileSetting(8, new Container_SingleCommand(cbx_act5Action.SelectedItem.ToString(), "A5"));
                tmp.setProfileSetting(9, new Container_SingleCommand(cbx_act6Action.SelectedItem.ToString(), "A6"));

                container.list.Add(tmp);
                container.setSelectedLabel(tmp.getLabel());
                Refresh();
                cbx_profile.SelectedItem = tmp.getLabel();
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            apply = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            apply = false;
            this.Close();
        }

        private void btn_profileDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = cbx_profile.SelectedIndex;
            container.list.RemoveAt(index);
            Refresh();
            if (index <= container.list.Count - 1) cbx_profile.SelectedIndex = index;
            else cbx_profile.SelectedIndex = index - 1;
            Object tmpObj = null;
            RoutedEventArgs tmpREA = null;
            btn_profileLoad_Click(tmpObj, tmpREA);
        }

        private void btn_profileOverwrite_Click(object sender, RoutedEventArgs e)
        {
            int index = cbx_profile.SelectedIndex;
            container.list[index].setGamepadMode(this.gamepadMode);

            container.list[index].setProfileSetting(0, new Container_SingleCommand(cbx_upAction.SelectedItem.ToString(), "UP"));
            container.list[index].setProfileSetting(1, new Container_SingleCommand(cbx_downAction.SelectedItem.ToString(), "DOWN"));
            container.list[index].setProfileSetting(2, new Container_SingleCommand(cbx_leftAction.SelectedItem.ToString(), "LEFT"));
            container.list[index].setProfileSetting(3, new Container_SingleCommand(cbx_rightAction.SelectedItem.ToString(), "RIGHT"));
            container.list[index].setProfileSetting(4, new Container_SingleCommand(cbx_act1Action.SelectedItem.ToString(), "A1"));
            container.list[index].setProfileSetting(5, new Container_SingleCommand(cbx_act2Action.SelectedItem.ToString(), "A2"));
            container.list[index].setProfileSetting(6, new Container_SingleCommand(cbx_act3Action.SelectedItem.ToString(), "A3"));
            container.list[index].setProfileSetting(7, new Container_SingleCommand(cbx_act4Action.SelectedItem.ToString(), "A4"));
            container.list[index].setProfileSetting(8, new Container_SingleCommand(cbx_act5Action.SelectedItem.ToString(), "A5"));
            container.list[index].setProfileSetting(9, new Container_SingleCommand(cbx_act6Action.SelectedItem.ToString(), "A6"));

            Refresh();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

            string comunicat = "Special characters:\n" +
                "%> - play symbol\n" +
                "%< - reversed play symbol\n" +
                "%| - pause symbol\n" +
                "%} - desktop symbol\n" +
                "%, - speaker symbol\n" +
                "%: - padlock symbol\n" +
                "%; - standby symbol";
            NotyficationWindow window = new NotyficationWindow(true, comunicat, "Close");
            window.ShowDialog();
        }
        #endregion

        #region GET SET
        public bool Apply() { return apply; }
        public Container_ControllerConfig GetConfig() { return container; }
        #endregion


    }
}
