using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulo
{
    class DisciplinaSemestral
    {
        private double n1;
        private double n2;
      
        
        public DisciplinaSemestral(double n1, double n2)
        {
              this.n1 = n1;
              this.n2 = n2;
        }

        public double GetMedia()
        {
            return (n1 + n2) / 2;
        }
    }
}
