using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCW.RBAC.Entities
{
    public class A
    {
        static readonly string s = "ss";
        private string str = "";

        public A()
        {

        }
    }

    public class B : A
    {
        private static int i = 9;
        private string sna = "ddd";
        public B()
        {

        }
    }

    public class Class1
    {
        
        public void test()
        {
            B b = new B();
            var s=b.GetHashCode();
        }
    }
}
