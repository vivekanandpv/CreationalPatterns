using System;
using System.Collections;
using System.Collections.Generic;

namespace Prototype {
    class Program {
        static void Main(string[] args) {
            ServerManager serverManager = new ServerManager();

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

            IServerPrototype awsPrototype = serverManager.GetPrototype("aws");
            IServerPrototype azurePrototype = serverManager.GetPrototype("azure");

            IServerPrototype anotherAwsPrototype = awsPrototype.Clone();
            IServerPrototype anotherAzurePrototype = azurePrototype.Clone();
        }
    }

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

    class ServerManager {
        private readonly IDictionary<string, IServerPrototype> _registry;

        public ServerManager() {
            _registry = new Dictionary<string, IServerPrototype>();
        }

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

        public IServerPrototype GetPrototype(string identifier) {
            return _registry[identifier];
        }
    }
}
