using System.IO;
using System.Linq;
using GoogleMapsApi.Entities.Directions.Request;
using MQCoordinator.Plugins.Interfaces;

namespace MQCoordinator.KbbPlugin
{
    public class KbbPlugin : IMessageDispatchPlugin
    {
        public void HandleMessage(ExampleMessage exampleMessage)
        {
            //var client = new Facebook.FacebookClient();
            //var url = client.GetLoginUrl("zuck");
            //var zuckerberg = client.Get("zuck");

            var directionRequest = new DirectionsRequest()
            {
                Origin = "607 clear spring ln. leander tx 78641",
                Destination = exampleMessage.BodyText //TODO: JSON Deserialization? Common message format? Unsure here
            };

            var directions = GoogleMapsApi.GoogleMaps.Directions.Query(directionRequest);

            var testFile = File.CreateText(Directory.GetCurrentDirectory() + "\\ItWorks.txt");
            foreach (var step in directions?.Routes?.FirstOrDefault()?.Legs?.FirstOrDefault()?.Steps)
            {
                testFile.WriteLine(step.HtmlInstructions); 
            }
            testFile.Close();
        }
    }
}
