using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxStarter.Core.Models
{
    public class MessageModel
    {
                public DateTime TimeWritten { get; set; }
        public string ActiveMessage { get; set; }
        public string UserAlias { get; set; }

        public MessageModel()
        {

        }
        public MessageModel(string _activeMessage, string _userAlias)
        {
            TimeWritten = DateTime.Now;
            ActiveMessage = _activeMessage;
            UserAlias = _userAlias;


        }
    }
}
