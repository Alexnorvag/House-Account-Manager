using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Accounting_Manager.all_classes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [System.Serializable()]
    public class Insurance
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _life;
        [DisplayName("Жизнь"), RefreshProperties(RefreshProperties.All)]
        public decimal life
        {
            get { return _life; }
            set
            {
                _life = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _motor;
        [DisplayName("Недвижимость"), RefreshProperties(RefreshProperties.All)]
        public decimal motor
        {
            get { return _motor; }
            set
            {
                _motor = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _medical;
        [DisplayName("Медицинское"), RefreshProperties(RefreshProperties.All)]
        public decimal medical
        {
            get { return _medical; }
            set
            {
                _medical = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _totalInsurance;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего страховых выплат")]
        public decimal totalInsurance
        {
            get { return _totalInsurance; }
            set
            {
                _totalInsurance = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Страховые выплаты",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalInsurance.ToString("c2");
        }

    }
}
