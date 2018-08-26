using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Circle : Figure
    {
        private int fRadius;

        public Circle(int radius)
        {
            fRadius = radius;
        }

        public int Radius
        {
            get
            {
                return fRadius;
            }
            set
            {
                fRadius = value;
            }
        }
    }
}
