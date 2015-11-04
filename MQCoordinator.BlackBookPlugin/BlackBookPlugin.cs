using System;
using System.IO;
using System.Linq;
using MQCoordinator.Plugins.Interfaces;

namespace MQCoordinator.BlackBookPlugin
{
    public class BlackBookPlugin : IMessageDispatchPlugin
    {
        public void HandleMessage(ExampleMessage exampleMessage)
        {
            var mapsClient = new Bing.MapsClient("Aie4GnH1NkuoK3nOebPAyhn-65xgsAWY3k8l4bVgtKvIvOFZvLa22fA1i_SAlpnW");
            var locationResponse = mapsClient.LocationQuery(exampleMessage.BodyText).Result;
            var coords = locationResponse.GetCoordinates()
                .FirstOrDefault()?
                .Coordinates.Select(x => x.ToString()).Aggregate((curr, next) => curr.ToString() + Environment.NewLine + next.ToString());

            var testFile = File.CreateText(Directory.GetCurrentDirectory() + "\\BingLocation.txt");
            testFile.WriteLine(coords);
            testFile.Close();
        }
    }
}
