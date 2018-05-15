using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Upgrade : Support
    {
        private string upgradeCriteria;
        private string upgradeType;
        private string upgradeDesc;
        private string upgradeDetails;

        public string UpgradeCriteria
        {
            get
            {
                return upgradeCriteria;
            }

            set
            {
                upgradeCriteria = value == null ? string.Empty : value.Trim();
            }
        }

        public string UpgradeType
        {
            get
            {
                return upgradeType;
            }

            set
            {
                upgradeType = value == null ? string.Empty : value.Trim();
            }
        }

        public string UpgradeDesc
        {
            get
            {
                return upgradeDesc;
            }

            set
            {
                upgradeDesc = value == null ? string.Empty : value.Trim();
            }
        }

        public string UpgradeDetails
        {
            get
            {
                return upgradeDetails;
            }

            set
            {
                upgradeDetails = value == null ? string.Empty : value.Trim();
            }
        }

        public Upgrade()
        {
        }
        public Upgrade(string _criteria, string _type, string _description, string _details)
        {
            UpgradeCriteria = _criteria;
            UpgradeType = _type;
            UpgradeDesc = _description;
            UpgradeDetails = _details;
        }
        public override bool Equals(object obj)
        {
            return obj == null ^ !(obj is Upgrade) ? false : UpgradeCriteria.Equals(((Upgrade)obj).UpgradeCriteria);
        }

        public override int GetHashCode()
        {
            return UpgradeCriteria.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(UpgradeCriteria, UpgradeDesc, upgradeType, UpgradeDetails);
        }
    }
}
