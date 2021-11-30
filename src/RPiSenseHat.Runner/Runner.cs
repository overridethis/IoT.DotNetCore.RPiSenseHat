using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Iot.Device.SenseHat;

namespace RPiSenseHat.Runner
{
    public class Runner
    {
        public Task RunAsync(CancellationToken token)
            => Task.Run(() =>
            {
                using var hat = new SenseHat();

                var colors =  new [] {Color.Red, Color.Green, Color.Blue};
                hat.Fill(Color.White);

                while (true)
                {
                    foreach (var color in colors)
                    {
                        hat.Fill(color);
                        Console.WriteLine($"[HAT:ENV] Temperature: {hat.Temperature.DegreesFahrenheit:f2}F, Humidity: {hat.Humidity.Percent:f2}");
                        Thread.Sleep(250);
                    }
                        
                    if (token.IsCancellationRequested)
                    {
                        hat.Fill(Color.FromArgb(0,0,0,0));
                        hat.Dispose();
                        break;
                    }    
                }
            }, token);
    }
}