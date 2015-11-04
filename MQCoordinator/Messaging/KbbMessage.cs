using MQCoordinator.Plugins.Interfaces;

namespace MQCoordinator.Messaging
{
    public class KbbMessage : ExampleMessage
    {
        public KbbMessage(string destination)
        {
            BodyText = destination;
        }
    }
}
