using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace USBMediaController
{
    public class Container_ControllerConfig
    {
        public List<Container_ControllerConfig> list = new List<Container_ControllerConfig>();

        Container_SingleCommand[] profileSetting = new Container_SingleCommand[10];
        string label;
        string selectedLabel;
        bool gamepadMode;

        #region CONSTRUCTORS
        public Container_ControllerConfig(Container_SingleCommand[] ps, string label)
        {
            this.profileSetting = ps;

        }

        public Container_ControllerConfig()
        {
        }
        #endregion

        #region GET SET



        public bool getGamepadStatusByID(string listLabel)
        {
            int id = 0;
            for (int clk = 0; clk < list.Count; clk++) if (list[clk].getLabel() == listLabel) id = clk;            
            return list[id].getGamepadMode();
        }

        public string getCommandByID(string command, string listLabel)
        {
            int id=0;
            for (int clk = 0; clk < list.Count; clk++) if (list[clk].getLabel() == listLabel) id = clk;
            for (int clk = 0; clk < profileSetting.Length; clk++)
            {
                if (list[id].profileSetting[clk].getField() == command) return list[id].profileSetting[clk].getCommand();
            }
            return "";
        }
        public Container_SingleCommand getProfileSetting(int num) { return profileSetting[num]; }

        public Container_SingleCommand[] getProfileSetting() { return profileSetting; }
        public string getLabel() { return label; }
        public string getSelectedLabel() { return selectedLabel; }
        public bool getGamepadMode() { return gamepadMode; }

        public void setProfileSetting(int num, Container_SingleCommand opt) { profileSetting[num] = opt; }
        public void setLabel(string val) { label = val; }
        public void setSelectedLabel(string val) { selectedLabel = val; }

        public void setGamepadMode(bool val) { gamepadMode = val; }

        #endregion


    }
}
