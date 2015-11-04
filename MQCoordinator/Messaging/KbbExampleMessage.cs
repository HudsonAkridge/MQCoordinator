using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQCoordinator.Messaging
{
    public class KbbExampleMessage
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}
