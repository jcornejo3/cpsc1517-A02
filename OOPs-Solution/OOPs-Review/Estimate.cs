using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review
{
    public class Estimate
    {
        //
        public double TotalPrice { get; private set; }
        public double LinearLegnth { get; set; }

        public FencePanel Panel{ get; set; }
        public List<Gate> Gates { get; set; }


    }
}
