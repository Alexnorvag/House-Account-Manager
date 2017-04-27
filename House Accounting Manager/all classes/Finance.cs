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
    public class Finance
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _pension;
        [DisplayName("Пенсия"), RefreshProperties(RefreshProperties.All)]
        public decimal pension
        {
            get { return _pension; }
            set
            {
                _pension = value;
                totalFinance = pension + savings;
            }
        }

        private decimal _savings;
        [DisplayName("Регулярные сбережения"), RefreshProperties(RefreshProperties.All)]
        public decimal savings
        {
            get { return _savings; }
            set
            {
                _savings = value;
                totalFinance = pension + savings;
            }
        }

        private decimal _totalFinance;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего финансовых расходов")]
        public decimal totalFinance
        {
            get { return _totalFinance; }
            set
            {
                _totalFinance = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Финансы",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalFinance.ToString("c2");
        }

    }
}
