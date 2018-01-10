
using System;

namespace ProblemSolving.OOPS
{
    interface ITest
    {
        int AddCount { get; set; }
        void Add();
    }

    public class Test : ITest
    {
        int ITest.AddCount
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void ITest.Add()
        {
            throw new NotImplementedException();
        }
    }

    public class Concepts
    {
        //OOPS.A a = new OOPS.A();
        //a.Menthod1(); ** "Method1 from A"
        //    OOPS.A b = new OOPS.B();
        //b.Menthod1(); ** "Method1 from B"
        //Abstract methods dont have body
    }
    public class A
    {
        public virtual void Menthod1()
        {
            Console.WriteLine("Method1 from A");
        }
        public static void StatMethod()
        {
            Console.WriteLine("Call to static Method");
            A a = new A();
            a.Menthod1();

        }

        public void CallStatic()
        {
            StatMethod();
        }

    }

    public class B : A
    {
        public override void Menthod1()
        {
            Console.WriteLine("Method1 from B");
        }
    }
}
