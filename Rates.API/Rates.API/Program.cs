using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace Rates.API
{
    public class Program
    {       
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Playboy playboy = new Playboy();
            var bus = playboy.GetConnectionBus();
            bus.Start();
            var startTimeSpan = TimeSpan.Zero; //
            var periodTimeSpan = TimeSpan.FromMinutes(60); //     
            var timer = new Timer(async(e) => //    �������� ����������� getModel, publishRates � logRates ����� ������� elapsed
            { //
                await playboy.PublishRates(bus); //
            }, null, startTimeSpan, periodTimeSpan); //
            Console.ReadKey();
            bus.Stop();
        }
    }
}
    