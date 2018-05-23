using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    enum Config
    {
        Defualt,
        Express,
        Custom
    }
    class Configuration 
    {
        #region Fields
        private int configID;
        private string configCriteria;
        private string configType;
        private string configParams;
        #endregion

        #region Properties
        public int ConfigID
        {
            get
            {
                return configID;
            }

            set
            {
                configID = value;
            }
        }

        public string ConfigCriteria
        {
            get
            {
                return configCriteria;
            }

            set
            {
                configCriteria = value;
            }
        }

        public string ConfigType
        {
            get
            {
                return configType;
            }

            set
            {
                configType = value;
            }
        }

        public string ConfigParams
        {
            get
            {
                return configParams;
            }

            set
            {
                configParams = value;
            }

        }
        #endregion

        #region Constructor

        public Configuration()
        {

        }
        public Configuration(int _configID, string _configCriteria, string _configType, string _configParams)
        {
            this.ConfigID = _configID;
            this.ConfigCriteria = _configCriteria;
            this.ConfigType = _configType;
            this.ConfigParams = _configParams;
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Configuration) ? false : ConfigType.Equals(((Configuration)obj).ConfigType);
        }

        public override int GetHashCode()
        {
            return ConfigType.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(ConfigID.ToString(), ConfigCriteria, ConfigType, ConfigParams);
        }
        #endregion
    }
}
