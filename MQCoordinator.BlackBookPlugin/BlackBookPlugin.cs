using System;
using System.IO;
using MQCoordinator.Plugins.Interfaces;
using ProtoBuf;

namespace MQCoordinator.BlackBookPlugin
{
    public class BlackBookPlugin : IMessageDispatchPlugin
    {
        public void HandleMessage(ExampleMessage exampleMessage)
        {
            var toSerialize = new ProtoTestMessage() {MessageBody = exampleMessage.BodyText};
            var testFile = File.Create(Directory.GetCurrentDirectory() + "\\BlackBook.txt");
            Serializer.Serialize(testFile, toSerialize);
            testFile.Close();
        }

        [ProtoContract]
        public class ProtoTestMessage
        {
            [ProtoMember(1)]
            public string MessageBody { get; set; }
        }
    }
}
