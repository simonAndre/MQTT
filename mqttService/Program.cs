using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace mqttService
{
    static class Program
    {
      
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            /* ServiceBase[] ServicesToRun;
             ServicesToRun = new ServiceBase[]
             {
                 new Service1()
             };
             ServiceBase.Run(ServicesToRun);*/

            Host host = HostFactory.New(x =>
            {
                x.Service<mqttservice>(sc =>
                {
                    sc.ConstructUsing(() => new mqttservice());

                    // the start and stop methods for the service
                    sc.WhenStarted((s, hostControl)  => s.Start(hostControl));
                    sc.WhenStopped((s, hostControl) => s.Stop(hostControl));

                    // optional pause/continue methods if used
                    //sc.WhenPaused((s, hostControl) => s.Pause());
                    //sc.WhenContinued((s, hostControl) => s.Continue());

                    // optional, when shutdown is supported
                    //sc.WhenShutdown((s, hostControl) => s.Shutdown());
                });
            });

            /*
            Host host = HostFactory.New(
            x =>
            {
                x.Service<mqttservice>(
                    s =>
                    {
                        s.ConstructUsing(name => new mqttservice());
                        s.WhenStarted((mqtt,hc) => mqtt.Start(hc));
                        s.WhenStopped((mqtt, hc) => mqtt.Stop(hc));
                    });

                x.RunAsNetworkService();// (identity, passwd);
                x.SetDescription(
                    "MqttService : service MQTT en mode test ");
                x.SetDisplayName("service MQTT en mode test");
                x.SetServiceName(ConfigurationManager.AppSettings["serviceName"]);
                //x.DependsOnMsmq();
                x.EnableServiceRecovery(configurator =>
            {
                configurator.RestartService(5);
                configurator.RestartService(5);
                configurator.SetResetPeriod(1);
            });
            });
*/
            host.Run();

        }

    }
}
