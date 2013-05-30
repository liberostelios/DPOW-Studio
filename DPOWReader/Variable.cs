using System;
using System.Collections.Generic;
using System.Text;

namespace DPOW.Reader
{
    public class Variable
    {
        private string name;
        private bool enabled = true;

        public Variable()
        {
        }

        public Variable(string name)
        {
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }
    }
}
