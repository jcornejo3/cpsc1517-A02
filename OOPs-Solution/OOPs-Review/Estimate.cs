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

        public double CalculatePrice()
        {
            double numberofpanels = Panel.EstematedNumberOfPanels(LinearLegnth);
            if((int)(numberofpanels * 10.0) > ((int)numberofpanels * 10))
            {
                numberofpanels++;
            }
           
            //using properties of FencePanel 
            //using propties of Gate 
            //summing calculated prices
            //TotalPrice = the calculated value in the method;
            if(Panel.Price == null)
            {
                throw new Exception("Panel price is needed to create estimate");
            }
            else
            {
                TotalPrice += numberofpanels * (double)Panel.Price;

                foreach (var item in Gates)
                {
                    TotalPrice += item.Price;
                }
            }
            return TotalPrice;
        }

    }
}
