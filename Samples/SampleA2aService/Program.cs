﻿using Topshelf;

namespace SampleA2aService
{
    static class Program
    {
        static void Main()
        {
            ConfigUtils.ConfigureLogging();

            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<SampleService>(service =>
                {
                    service.ConstructUsing(c => new SampleService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                hostConfig.UseSerilog();
                hostConfig.StartAutomaticallyDelayed();
                hostConfig.SetDisplayName("SampleA2aService");
                hostConfig.SetServiceName("SampleA2aService");
                hostConfig.SetDescription("Simple application to notify when a password changes.");
            });
        }
    }
}
