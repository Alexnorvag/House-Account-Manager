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
    public class Leisure
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _eatingOut;
        [DisplayName("Рестораны"), RefreshProperties(RefreshProperties.All)]
        public decimal eatingOut
        {
            get { return _eatingOut; }
            set
            {
                _eatingOut = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _cinema;
        [DisplayName("Кино"), RefreshProperties(RefreshProperties.All)]
        public decimal cinema
        {
            get { return _cinema; }
            set
            {
                _cinema = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _holidays;
        [DisplayName("Выходные"), RefreshProperties(RefreshProperties.All)]
        public decimal holidays
        {
            get { return _holidays; }
            set
            {
                _holidays = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _sports;
        [DisplayName("Спорт"), RefreshProperties(RefreshProperties.All)]
        public decimal sports
        {
            get { return _sports; }
            set
            {
                _sports = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _cigarettesAndAlcohol;
        [DisplayName("Сигареты/Алкоголь"), RefreshProperties(RefreshProperties.All)]
        public decimal cigarettesAndAlcohol
        {
            get { return _cigarettesAndAlcohol; }
            set
            {
                _cigarettesAndAlcohol = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _totalLeisure;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Всего расходов на отдых")]
        public decimal totalLeisure
        {
            get { return _totalLeisure; }
            set
            {
                _totalLeisure = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Свободное время",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalLeisure.ToString("c2");
        }


    }
}
