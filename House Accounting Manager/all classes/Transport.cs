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
    public class Transport
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _petrol;
        [DisplayName("Топливо"), RefreshProperties(RefreshProperties.All)]
        public decimal petrol
        {
            get { return _petrol; }
            set
            {
                _petrol = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _commuting;
        [DisplayName("Общественный транспорт"), RefreshProperties(RefreshProperties.All)]
        public decimal commuting
        {
            get { return _commuting; }
            set
            {
                _commuting = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _carCosts;
        [DisplayName("Автомобильные расходы"), RefreshProperties(RefreshProperties.All)]
        public decimal carCosts
        {
            get { return _carCosts; }
            set
            {
                _carCosts = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _totalTransport;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Общие расходы на транспорт")]
        public decimal totalTransport
        {
            get { return _totalTransport; }
            set
            {
                _totalTransport = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Транспорт",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalTransport.ToString("c2");
        }
    }
}

