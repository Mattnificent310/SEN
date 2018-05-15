using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Instalation : Support
    {
        private string installCriteria;
        private Guid installNumber;
        private string installType;
        private string installDesc;
        private string installDetails;

        public string InstallCriteria
        {
            get
            {
                return installCriteria;
            }

            set
            {
                installCriteria = value;
            }
        }

        public Guid InstallNumber
        {
            get
            {
                return installNumber;
            }

            set
            {
                installNumber = value;
            }
        }

        public string InstallType
        {
            get
            {
                return installType;
            }

            set
            {
                installType = value;
            }
        }

        public string InstallDesc
        {
            get
            {
                return installDesc;
            }

            set
            {
                installDesc = value;
            }
        }

        public string InstallDetails
        {
            get
            {
                return installDetails;
            }

            set
            {
                installDetails = value;
            }
        }
        public Instalation()
        {

        }
        public Instalation(string _installCriteria, string _installType, string _installDesc, string _installDetails)
        {
            InstallNumber = Guid.NewGuid();
            installCriteria = _installCriteria;
            installType = _installType;
            installDesc = _installDesc;
            installDetails = _installDetails;
        }
    }
}
