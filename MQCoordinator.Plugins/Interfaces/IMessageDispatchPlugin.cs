namespace MQCoordinator.Plugins.Interfaces
{
    public interface IMessageDispatchPlugin
    {
        void HandleMessage(ExampleMessage exampleMessage);
    }
}