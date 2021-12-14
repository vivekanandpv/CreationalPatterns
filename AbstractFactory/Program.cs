using System;

namespace AbstractFactory {
    class Program {
        static void Main(string[] args) {
            ICloudFactory awsFactory = new AwsCloudFactory();
            ICloudFactory azureFactory = new AzureCloudFactory();

            IVirtualMachine vmAws = awsFactory.CreateVirtualMachine();
            IVirtualMachine vmAzure = azureFactory.CreateVirtualMachine();

            IAppService appServiceAws = awsFactory.CreateAppService();
            IAppService appServiceAzure = azureFactory.CreateAppService();

            vmAws.Start();
            vmAzure.Start();

            appServiceAws.Run();
            appServiceAzure.Run();
        }
    }

    interface IVirtualMachine {
        void Start();
    }

    class AwsEc2 : IVirtualMachine {
        public void Start() {
            Console.WriteLine("AWS EC2 starts...");
        }
    }

    class AzureVm : IVirtualMachine {
        public void Start() {
            Console.WriteLine("Azure VM starts...");
        }
    }

    interface IAppService {
        void Run();
    }

    class ElasticBeanstalk : IAppService {
        public void Run() {
            Console.WriteLine("AWS Elastic Beanstalk runs...");
        }
    }

    class AzureAppService : IAppService {
        public void Run() {
            Console.WriteLine("Azure App Service runs...");
        }
    }


    interface ICloudFactory {
        IVirtualMachine CreateVirtualMachine();
        IAppService CreateAppService();
    }

    class AwsCloudFactory : ICloudFactory {
        public IVirtualMachine CreateVirtualMachine() {
            return new AwsEc2();
        }

        public IAppService CreateAppService() {
            return new ElasticBeanstalk();
        }
    }

    class AzureCloudFactory : ICloudFactory {
        public IVirtualMachine CreateVirtualMachine() {
            return new AzureVm();
        }

        public IAppService CreateAppService() {
            return new AzureAppService();
        }
    }
}
