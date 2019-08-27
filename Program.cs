using System;
using System.Threading;
using Temperature.Models;
using Unosquare.RaspberryIO.Abstractions;

namespace Temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var dht = new DHT(BcmPin.Gpio17, DHTSensorTypes.DHT22);
                while (true) {
                    try {
                        var d = dht.ReadData();
                        Console.WriteLine(DateTime.UtcNow);
                        Console.WriteLine(" temp: " + d.TempCelcius);
                        Console.WriteLine(" hum: " + d.Humidity);
                    } catch (DHTException) {
                    }
                    Thread.Sleep(10000);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message + " - " + e.StackTrace);
            }
        }
    }
}
