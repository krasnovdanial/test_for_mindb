using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfShapes.Shapes
{
    public class Circle : Interfaces.IShape
    {
        public double Radius { get; private set; }
        internal Circle GetCircle(double[] parameters)
        {
            if (parameters == null || parameters.Length != 1)
            {
                throw new ArgumentException("Parameters are incorrect: a circle must have radius.", "parameters");
            }
            return new Circle(parameters[0]);
        }
        public double Area =>  Math.PI*Math.Pow(Radius, 2);

        public Circle()
        {
            Radius = default(int);
        }
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Please, enter only positive values.");
            }
            Radius = radius;  
        }
       
    }
}
