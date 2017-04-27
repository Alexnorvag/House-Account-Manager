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
    public class Household
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _mortgage;
        [DisplayName("Ипотека / Аренда"), RefreshProperties(RefreshProperties.All)]
        public decimal mortgage
        {
            get { return _mortgage; }
            set
            {
                _mortgage = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _groceries;
        [DisplayName("Продовольственные товары"), RefreshProperties(RefreshProperties.All)]
        public decimal groceries
        {
            get { return _groceries; }
            set
            {
                _groceries = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _clothing;
        [DisplayName("Одежда"), RefreshProperties(RefreshProperties.All)]
        public decimal clothing
        {
            get { return _clothing; }
            set
            {
                _clothing = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _laundry;
        [DisplayName("Прачечная / Химчистка"), RefreshProperties(RefreshProperties.All)]
        public decimal laundry
        {
            get { return _laundry; }
            set
            {
                _laundry = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _homehelp;
        [DisplayName("Уборка дома"), RefreshProperties(RefreshProperties.All)]
        public decimal homehelp
        {
            get { return _homehelp; }
            set
            {
                _homehelp = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _totalHousehold;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего домашних расходов")]
        public decimal totalHousehold
        {
            get { return _totalHousehold; }
            set
            {
                _totalHousehold = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Дом",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalHousehold.ToString("c2");
        }


    }
}
