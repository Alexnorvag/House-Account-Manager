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
    public class Children
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _care;
        [DisplayName("Няня"), RefreshProperties(RefreshProperties.All)]
        public decimal care
        {
            get { return _care; }
            set
            {
                _care = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _schooling;
        [DisplayName("Школьное образование"), RefreshProperties(RefreshProperties.All)]
        public decimal schooling
        {
            get { return _schooling; }
            set
            {
                _schooling = value;
                totalChildren = care + schooling + clothing + treats;
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
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _treats;
        [DisplayName("Развлечения"), RefreshProperties(RefreshProperties.All)]
        public decimal treats
        {
            get { return _treats; }
            set
            {
                _treats = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _totalChildren;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего расходов на детей")]
        public decimal totalChildren
        {
            get { return _totalChildren; }
            set
            {
                _totalChildren = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Дети",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalChildren.ToString("c2");
        }

    }
}
