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
        //------------------------------------------------------------------------------------
        #region VARIABLE

        private Container_ControllerConfig container = new Container_ControllerConfig();
        private bool apply = false;

        #endregion

        //------------------------------------------------------------------------------------
        #region CONSTRUCTOR
        public ControllerConfig()
        {
            InitializeComponent();
            FillComboBox();
            //CenterWindowOnScreen();
            Refresh();
        }

        public ControllerConfig(Container_ControllerConfig container)
        {
            InitializeComponent();
            FillComboBox();
            this.container = container;
            //CenterWindowOnScreen();
            Refresh();
        }

        #endregion

        //------------------------------------------------------------------------------------
        #region METHODS

        /* private void CenterWindowOnScreen()
         {
             double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
             double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
             double windowWidth = this.Width;
             double windowHeight = this.Height;
             this.Left = (screenWidth / 2) - (windowWidth / 2);
             this.Top = (screenHeight / 2) - (windowHeight / 2);
         }
 */

        private void Refresh()
        {
            cbx_profile.Items.Clear();
            for (int clk = 0; clk < container.list.Count; clk++) cbx_profile.Items.Add(container.list[clk].getLabel());
            cbx_profile.SelectedItem = container.getSelectedLabel();

            for (int clk = 0; clk < container.list.Count; clk++)
            {
                if (container.list[clk].getLabel() == container.getSelectedLabel())
                {
                    cbx_upAction.SelectedItem = container.list[clk].getProfileSetting(0).getCommand();
                    cbx_downAction.SelectedItem = container.list[clk].getProfileSetting(1).getCommand();
                    cbx_leftAction.SelectedItem = container.list[clk].getProfileSetting(2).getCommand();
                    cbx_rightAction.SelectedItem = container.list[clk].getProfileSetting(3).getCommand();

                    cbx_act1Action.SelectedItem = container.list[clk].getProfileSetting(4).getCommand();
                    cbx_act2Action.SelectedItem = container.list[clk].getProfileSetting(5).getCommand();
                    cbx_act3Action.SelectedItem = container.list[clk].getProfileSetting(6).getCommand();
                    cbx_act4Action.SelectedItem = container.list[clk].getProfileSetting(7).getCommand();
                    cbx_act5Action.SelectedItem = container.list[clk].getProfileSetting(8).getCommand();
                    cbx_act6Action.SelectedItem = container.list[clk].getProfileSetting(9).getCommand();
                }
            }
        }
   

        private void FillComboBox()
        {
            List<string> actions = new List<string>();

            #region FILLACTIONS
            actions.Add("A");
            actions.Add("B");
            actions.Add("C");
            actions.Add("D");
            actions.Add("E");
            actions.Add("F");
            actions.Add("G");
            actions.Add("H");
            actions.Add("I");
            actions.Add("J");
            actions.Add("K");
            actions.Add("L");
            actions.Add("M");
            actions.Add("N");
            actions.Add("O");
            actions.Add("P");
            actions.Add("Q");
            actions.Add("R");
            actions.Add("S");
            actions.Add("T");
            actions.Add("U");
            actions.Add("V");
            actions.Add("W");
            actions.Add("X");
            actions.Add("Y");
            actions.Add("Z");
            actions.Add("1");
            actions.Add("2");
            actions.Add("3");
            actions.Add("4");
            actions.Add("5");
            actions.Add("6");
            actions.Add("7");
            actions.Add("8");
            actions.Add("9");
            actions.Add("0");

            actions.Add("[");
            actions.Add("]");
            actions.Add("\\");
            actions.Add(";");
            actions.Add("'");
            actions.Add(",");
            actions.Add(".");
            actions.Add("/");
            actions.Add("-");
            //actions.Add("=");         
            actions.Add("`");

            actions.Add("F1");
            actions.Add("F2");
            actions.Add("F3");
            actions.Add("F4");
            actions.Add("F5");
            actions.Add("F6");
            actions.Add("F7");
            actions.Add("F8");
            actions.Add("F9");
            actions.Add("F10");
            actions.Add("F11");
            actions.Add("F12");

            actions.Add("LCTRL");
            actions.Add("RCTRL");
            actions.Add("LSHIFT");
            actions.Add("RSHIFT");
            actions.Add("LALT");
            //actions.Add("RALT");         
            actions.Add("BACKSPACE");
            actions.Add("ESC");
            actions.Add("INSERT");
            actions.Add("DELETE");
            actions.Add("HOME");
            actions.Add("END");
            actions.Add("PGUP");
            actions.Add("PGDOWN");
            actions.Add("PRTSCR");
            actions.Add("SCRLCK");
            actions.Add("PAUSE");
            actions.Add("NUMLCK");
            actions.Add("CAPSLCK");
            actions.Add("TAB");
            actions.Add("SPACE");
            actions.Add("ENTER");

            actions.Add("NUMERIC/");
            actions.Add("NUMERIC*");
            actions.Add("NUMERIC-");
            actions.Add("NUMERIC1");
            actions.Add("NUMERIC2");
            actions.Add("NUMERIC3");
            actions.Add("NUMERIC4");
            actions.Add("NUMERIC5");
            actions.Add("NUMERIC6");
            actions.Add("NUMERIC7");
            actions.Add("NUMERIC8");
            actions.Add("NUMERIC9");
            actions.Add("NUMERIC0");
            actions.Add("NUMERIC+");
            actions.Add("NUMERIC,");

            actions.Add("UPARROW");
            actions.Add("DOWNARROW");
            actions.Add("LEFTARROW");
            actions.Add("RIGHTARROW");
            #endregion




            for (int clk = 0; clk < actions.Count; clk++)
            {
                cbx_upAction.Items.Add(actions[clk]);
                cbx_downAction.Items.Add(actions[clk]);
                cbx_leftAction.Items.Add(actions[clk]);
                cbx_rightAction.Items.Add(actions[clk]);
                cbx_act1Action.Items.Add(actions[clk]);
                cbx_act2Action.Items.Add(actions[clk]);
                cbx_act3Action.Items.Add(actions[clk]);
                cbx_act4Action.Items.Add(actions[clk]);
                cbx_act5Action.Items.Add(actions[clk]);
                cbx_act6Action.Items.Add(actions[clk]);      
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

        //------------------------------------------------------------------------------------
        #region SLOTS

        private void btn_profileLoad_Click(object sender, RoutedEventArgs e)
        {
            container.setSelectedLabel(cbx_profile.Text);
            Refresh();
        }



        private void btn_profileSave_Click(object sender, RoutedEventArgs e)
        {
            ControlerConfigAddItem window = new ControlerConfigAddItem();
            window.ShowDialog();
            if (window.Apply()) {
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
            if (index <= container.list.Count-1) cbx_profile.SelectedIndex = index;
            else cbx_profile.SelectedIndex = index - 1;
            Object tmpObj=null;
            RoutedEventArgs tmpREA=null;
            btn_profileLoad_Click(tmpObj, tmpREA);
        }

        private void btn_profileOverwrite_Click(object sender, RoutedEventArgs e)
        {
            int index = cbx_profile.SelectedIndex;

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

        //------------------------------------------------------------------------------------
        #region GET SET

        public bool Apply() { return apply; }

        public Container_ControllerConfig GetConfig() { return container; }








        #endregion


    }
}
