using System;

namespace Singleton {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }

    sealed class SingletonVariant1 {
        private static volatile SingletonVariant1 _instance;
        private static readonly object LockObject = new object();

        private SingletonVariant1() {

        }

        public static SingletonVariant1 Instance {
            get {
                if (_instance == null) {
                    lock (LockObject) {
                        if (_instance == null) {
                            _instance = new SingletonVariant1();
                        }
                    }
                }

                return _instance;
            }
        }
    }

    sealed class SingletonVariant2 {
        private static readonly SingletonVariant2 _instance = new SingletonVariant2();

        private SingletonVariant2() {

        }

        public static SingletonVariant2 Instance {
            get {
                return _instance;
            }
        }

        //public static SingletonVariant2 Instance => _instance;
    }
}
