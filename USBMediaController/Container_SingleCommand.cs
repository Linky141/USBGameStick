using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBMediaController
{
    public class Container_SingleCommand
    {
        private string field;
        private string command;

        public Container_SingleCommand()
        {
        }

        public Container_SingleCommand(string command, string field)
        {
            this.command = command;
            this.field = field;
        }

        public string getCommand() { return command; }
        public void setCommand(string val) { command = val; }
        public string getField() { return field; }
        public void setField(string val) { field = val; }


    }

}
