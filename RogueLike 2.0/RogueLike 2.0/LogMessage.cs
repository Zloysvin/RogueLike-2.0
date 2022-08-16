using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_2._0_
{
    public class LogMessage
    {
        public string Text;
        public int MessageCode;

        public LogMessage(string text, int messageCode)
        {
            Text = text;
            MessageCode = messageCode;
        }

        public LogMessage()
        {
        }
    }
}
