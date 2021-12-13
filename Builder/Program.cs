using System;

namespace Builder {
    class Program {
        static void Main(string[] args) {
            //  Section 7
            //  We need the reference to this concrete builder
            var awsBuilder = new AWSServerBuilder();

            //  Section 8
            //  Client has to coordinate the dependency for the Director here
            ServerDirector director = new ServerDirector(awsBuilder);

            //  Section 9
            //  Director kicks off the representation customization
            director.Construct();

            //  Section 10
            //  The final object is still in the concrete builder
            Server server = awsBuilder.GetServer();
            Console.WriteLine(server);
        }
    }

    //  Section: 1
    //  Constituent classes for the final object
    class CPU {
        public string Description { get; set; }
    }

    class RAM {
        public string Description { get; set; }
    }

    class NIC {
        public string Description { get; set; }
    }

    class SSD {
        public string Description { get; set; }
    }

    //  Section 2
    //  Final complex object
    class Server {
        //  This is the representation
        public CPU CPU { get; set; }
        public RAM RAM { get; set; }
        public NIC NIC { get; set; }
        public SSD SSD { get; set; }

        public override string ToString() {
            return $"Server: \n\tCPU: {CPU.Description}\n\tRAM: {RAM.Description}\n\tNIC: {NIC.Description}\n\tSSD: {SSD.Description}";
        }
    }

    //  Section 3
    //  Builder interface exposes the API for customizing representation
    interface IServerBuilder {
        void AddCPU(string description);
        void AddRAM(string description);
        void AddNIC(string description);
        void AddSSD(string description);
    }

    //  Section 4
    //  Concrete builder
    class AWSServerBuilder : IServerBuilder {
        //  Creation
        private readonly Server _server = new Server();

        //  Representation
        public void AddCPU(string description) {
            _server.CPU = new CPU { Description = description };
        }

        public void AddRAM(string description) {
            _server.RAM = new RAM { Description = description };
        }

        public void AddNIC(string description) {
            _server.NIC = new NIC { Description = description };
        }

        public void AddSSD(string description) {
            _server.SSD = new SSD { Description = description };
        }

        //  Conventionally: GetResult()
        public Server GetServer() {
            return _server;
        }
    }

    //  Section 5
    //  Director deals with customizing the representation
    class ServerDirector {
        private readonly IServerBuilder _builder;

        public ServerDirector(IServerBuilder builder) {
            _builder = builder;
        }

        //  Section 6
        //  Customizing the representation
        //  Consider abstracting Director for polymorphic Construct
        public void Construct() {
            _builder.AddCPU("Intel Core i5 @ 2GHz");
            _builder.AddRAM("8GB DDR4 @ 2333MHz");
            _builder.AddNIC("Broadcom Gigabit NIC");
            _builder.AddSSD("250GB Samsung EVO SSD");
        }
    }
}
