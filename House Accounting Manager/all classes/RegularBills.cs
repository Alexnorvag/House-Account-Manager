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
    public class RegularBills
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _councilTax;
        [DisplayName("Налоги"), RefreshProperties(RefreshProperties.All)]
        public decimal councilTax
        {
            get { return _councilTax; }
            set
            {
                _councilTax = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _amenities;
        [DisplayName("Газ / Электричество / Вода"), RefreshProperties(RefreshProperties.All)]
        public decimal amenities
        {
            get { return _amenities; }
            set
            {
                _amenities = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _communications;
        [DisplayName("Телефон / Телевидение"), RefreshProperties(RefreshProperties.All)]
        public decimal communications
        {
            get { return _communications; }
            set
            {
                _communications = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _totalRegularBills;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Общие расходы на постоянные платежи")]
        public decimal totalRegularBills
        {
            get { return _totalRegularBills; }
            set
            {
                _totalRegularBills = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Постоянные платежи",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalRegularBills.ToString("c2");
        }

    }
}
