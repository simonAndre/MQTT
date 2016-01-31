using mqttService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace sanMqttService
{
   public class Program
    {
        public static void Main()// string[] args)
        {
            Host host = HostFactory.New(
              x =>
              {
                  x.Service<mqttservice>(
                      s =>
                      {
                          s.ConstructUsing(name => new mqttservice());
                          s.WhenStarted((mqtt, hc) => mqtt.Start(hc));
                          s.WhenStopped((mqtt, hc) => mqtt.Stop(hc));
                      });

                  //x.RunAsLocalSystem();// (identity, passwd);
                  x.RunAs(@"azimut\simon", "k3_7Wdo8");
                  x.SetDescription("MqttService : service MQTT en mode test ");
                  x.SetDisplayName("sanMqttService");
                  x.SetServiceName("sanMqttService");
                 
                  x.EnableServiceRecovery(configurator =>
                    {
                        configurator.RestartService(5);
                      //  configurator.RestartService(5);
                        configurator.SetResetPeriod(1);
                    });
              });

            host.Run();
            //Thread.Sleep(20000);

        }
    }
}
