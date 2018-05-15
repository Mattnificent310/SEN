using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Offer
    {

        private Guid offerNumber;
        private string offerOption;

        public Guid OfferNumber
        {
            get
            {
                return offerNumber;
            }

            set
            {
                offerNumber = value;
            }
        }

        public string OfferOption
        {
            get
            {
                return offerOption;
            }

            set
            {
                offerOption = value;
            }
        }
        public Offer()
        {

        }
        public Offer(string _option)
        {
            offerNumber = Guid.NewGuid();
            offerOption = _option;
        }
        public bool SelectOption()
        {
            throw new System.NotImplementedException();
        }

    }
}
