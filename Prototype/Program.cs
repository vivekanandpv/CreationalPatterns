using System;
using System.Collections;
using System.Collections.Generic;

namespace Prototype {
    class Program {
        static void Main(string[] args) {
            //  Section 6
            //  Getting the manager
            ServerManager serverManager = new ServerManager();

            //  Section 7
            //  Loading the manager with prototypes
            serverManager.AddPrototype(
                "aws",
                new AwsServer {
                    DiskCapacity = 500,
                    MemoryCapacity = 8,
                    NCpuCores = 4
                });

            serverManager.AddPrototype(
                "azure",
                new AzureServer() {
                    DiskCapacity = 250,
                    MemoryCapacity = 4,
                    NCpuCores = 4
                });

            //  Section 8
            //  Getting the initial prototypes
            IServerPrototype awsPrototype = serverManager.GetPrototype("aws");
            IServerPrototype azurePrototype = serverManager.GetPrototype("azure");

            //  Section 9
            //  Crux: asking the prototypes to clone themselves
            IServerPrototype anotherAwsPrototype = awsPrototype.Clone();
            IServerPrototype anotherAzurePrototype = azurePrototype.Clone();
        }
    }

    //  Section 1
    //  Define the prototype interface
    //  If the objects do not have a common interface, this can be skipped
    interface IServerPrototype {
        IServerPrototype Clone();
        void Start();
        void Stop();
    }

    class AwsServer : IServerPrototype {
        public int NCpuCores { get; set; }
        public int MemoryCapacity { get; set; }
        public int DiskCapacity { get; set; }

        public IServerPrototype Clone() {
            //  Section 2
            //  Object uses itself to clone
            //  several avenues from here
            //  some use reflection
            //  You may have to deal with deep-copy complexities here
            return new AwsServer {
                NCpuCores = this.NCpuCores,
                MemoryCapacity = this.MemoryCapacity,
                DiskCapacity = this.DiskCapacity
            };
        }

        public void Start() {
            Console.WriteLine("AWS server starts");
        }

        public void Stop() {
            Console.WriteLine("AWS server stops");
        }
    }

    class AzureServer : IServerPrototype {
        public int NCpuCores { get; set; }
        public int MemoryCapacity { get; set; }
        public int DiskCapacity { get; set; }

        public IServerPrototype Clone() {
            return new AzureServer {
                NCpuCores = this.NCpuCores,
                MemoryCapacity = this.MemoryCapacity,
                DiskCapacity = this.DiskCapacity
            };
        }

        public void Start() {
            Console.WriteLine("Azure server starts");
        }

        public void Stop() {
            Console.WriteLine("Azure server stops");
        }
    }

    //  Section 3
    //  This may not be required all the time
    //  This example is more tuned to portray the abstract factory like functionality
    //  Conventionally called a prototype manager
    class ServerManager {
        private readonly IDictionary<string, IServerPrototype> _registry;

        public ServerManager() {
            _registry = new Dictionary<string, IServerPrototype>();
        }

        //  Section 4
        //  client decides the prototypes in the manager
        public void AddPrototype(string identifier, IServerPrototype prototype) {
            _registry.Add(identifier, prototype);
        }

        public bool RemovePrototype(string identifier) {
            var exists = _registry.ContainsKey(identifier);

            if (exists) {
                _registry.Remove(identifier);
                return true;
            }

            return false;
        }

        //  Section 5
        //  client uses this for initial objects
        public IServerPrototype GetPrototype(string identifier) {
            return _registry[identifier];
        }
    }
}
