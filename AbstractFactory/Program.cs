using System;

namespace AbstractFactory {
    class Program {
        static void Main(string[] args) {
            //  Section 4
            //  Get the factory objects
            ICloudFactory awsFactory = new AwsCloudFactory();
            ICloudFactory azureFactory = new AzureCloudFactory();

            //  Section 5
            //  Get the products
            //  Products are themed by the factory implementers
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

    //  Section 1
    //  Defining a product interfaces and implementations
    //  Note that there are two distinct products (VirtualMachine and AppService)
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

    //  Section 2
    //  Abstract factory interface
    //  This deals with creation of distinct products of a common theme (theme is defined by the implementer)
    interface ICloudFactory {
        IVirtualMachine CreateVirtualMachine();
        IAppService CreateAppService();
    }

    //  Section 3
    //  Implementations that define products of the factory on a theme
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
