using System;

namespace Singleton {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }

    //  Section 1
    //  Classic approach with lazy initializing
    //  Generally, subclassing is prevented
    sealed class SingletonVariant1 {
        //  volatile guards against processor level caching
        //  This is the singleton
        private static volatile SingletonVariant1 _instance;

        //  classic monitor lock object
        private static readonly object LockObject = new object();

        //  constructor access is prevented to the outside world
        private SingletonVariant1() {

        }

        //  global access point
        public static SingletonVariant1 Instance {
            //  This is the double-check locking mechanism
            get {
                if (_instance == null) {
                    lock (LockObject) { //  prevent race conditions
                        if (_instance == null) {
                            _instance = new SingletonVariant1();
                        }
                    }
                }

                return _instance;  
            }
        }
    }

    //  Section 2
    //  Straightforward approach
    //  Thread-safe, but not lazily initialized
    sealed class SingletonVariant2 {
        //  static fields are initialized before the constructor call
        private static readonly SingletonVariant2 _instance = new SingletonVariant2();

        private SingletonVariant2() {

        }

        //  singleton is initialized before this call
        public static SingletonVariant2 Instance {
            get {
                return _instance;
            }
        }

        //  can also use expression body
        //public static SingletonVariant2 Instance => _instance;
    }
}
