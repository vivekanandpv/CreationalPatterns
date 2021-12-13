using System;

namespace FactoryMethod {
    class Program {
        static void Main(string[] args) {
            //  Section 6
            //  Consider DI for the concrete factory
            IServerFactory factory = new VendorServerFactory();

            //  Declarative (virtual constructor)
            IServer server = factory.Create();

            //  Get on with business
            var response = server.ServeRequest("Program");
            Console.WriteLine(response);
            
        }
    }

    //  Section 2
    //  Product interface
    //  Can also be an abstract class
    //  Be careful about having the fields in abstract classes
    //  An interface is generally recommended
    interface IServer {
        string ServeRequest(string message);
    }

    //  Section 1
    //  Factory interface
    //  Can also be an abstract class
    //  Create() name is conventional (Make and GetInstance are good names as well)
    //  A variation can be to pass some bit of configuration so that the implementing class
    //  can fine-tune the product. But this sometimes creates needless inflexibility.
    interface IServerFactory {
        IServer Create();
    }

    //  Section 3
    //  Concrete product classes
    class AWSServer : IServer {
        public string ServeRequest(string message) {
            return $"AWS Server Responding: {message}";
        }
    }

    class GCPServer : IServer {
        public string ServeRequest(string message) {
            return $"GCP Server Responding: {message}";
        }
    }

    //  Section 4
    //  Concrete factory implementation
    class VendorServerFactory : IServerFactory {

        //  Section 5
        //  Can use external configuration to fine-tune the object
        public IServer Create() {
            return new AWSServer();
        }
    }
}
