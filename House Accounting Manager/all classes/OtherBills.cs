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
    public class OtherBills
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _cc;
        [DisplayName("Кредитные карты"), RefreshProperties(RefreshProperties.All)]
        public decimal cc
        {
            get { return _cc; }
            set
            {
                _cc = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _loans;
        [DisplayName("Погашение кредитов"), RefreshProperties(RefreshProperties.All)]
        public decimal loans
        {
            get { return _loans; }
            set
            {
                _loans = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _maintenance;
        [DisplayName("Техобслуживание"), RefreshProperties(RefreshProperties.All)]
        public decimal maintenance
        {
            get { return _maintenance; }
            set
            {
                _maintenance = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _opticalAndDental;
        [DisplayName("Стоматологические расходы"), RefreshProperties(RefreshProperties.All)]
        public decimal opticalAndDental
        {
            get { return _opticalAndDental; }
            set
            {
                _opticalAndDental = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _miscellaneous;
        [DisplayName("Разное"), RefreshProperties(RefreshProperties.All)]
        public decimal miscellaneous
        {
            get { return _miscellaneous; }
            set
            {
                _miscellaneous = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _totalOtherBills;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего прочих выплат")]
        public decimal totalOtherBills
        {
            get { return _totalOtherBills; }
            set
            {
                _totalOtherBills = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Прочие выплаты",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalOtherBills.ToString("c2");
        }

    }
}
