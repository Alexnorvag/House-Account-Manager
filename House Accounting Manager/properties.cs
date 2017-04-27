using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House_Accounting_Manager.all_classes;
using House_Accounting_Manager.all_classes.TypeEditors;
using System.Drawing.Design;
using System.Globalization;

namespace House_Accounting_Manager
{
    [System.Serializable()]
    public class properties
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        public properties()
        {
            removeEventHandlers();
            addEventHandlers();
        }

        public void addEventHandlers()
        {
            _children.propertiesChanged += expandable_propertiesChanged;
            _finance.propertiesChanged += expandable_propertiesChanged;
            _houseHold.propertiesChanged += expandable_propertiesChanged;
            _insurance.propertiesChanged += expandable_propertiesChanged;
            _leisure.propertiesChanged += expandable_propertiesChanged;
            _otherBills.propertiesChanged += expandable_propertiesChanged;
            _regularBills.propertiesChanged += expandable_propertiesChanged;
            _transport.propertiesChanged += expandable_propertiesChanged;
        }

        public void removeEventHandlers()
        {
            _children.propertiesChanged -= expandable_propertiesChanged;
            _finance.propertiesChanged -= expandable_propertiesChanged;
            _houseHold.propertiesChanged -= expandable_propertiesChanged;
            _insurance.propertiesChanged -= expandable_propertiesChanged;
            _leisure.propertiesChanged -= expandable_propertiesChanged;
            _otherBills.propertiesChanged -= expandable_propertiesChanged;
            _regularBills.propertiesChanged -= expandable_propertiesChanged;
            _transport.propertiesChanged -= expandable_propertiesChanged;
        }

        private decimal _net;
        [CategoryAttribute("Ежемесячный доход"), RefreshProperties(RefreshProperties.All), DisplayName("Зарплата")]
        public decimal net
        {
            get { return _net; }
            set
            {
                _net = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _pension;
        [CategoryAttribute("Ежемесячный доход"), RefreshProperties(RefreshProperties.All), DisplayName("Пенсия")]
        public decimal pension
        {
            get { return _pension; }
            set
            {
                _pension = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _otherIncome1;
        [CategoryAttribute("Ежемесячный доход"), RefreshProperties(RefreshProperties.All), DisplayName("Сбережения и инвестиции")]
        public decimal otherIncome1
        {
            get { return _otherIncome1; }
            set
            {
                _otherIncome1 = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _otherIncome2;
        [CategoryAttribute("Ежемесячный доход"), RefreshProperties(RefreshProperties.All), DisplayName("Другой доход")]
        public decimal otherIncome2
        {
            get { return _otherIncome2; }
            set
            {
                _otherIncome2 = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private string _totalIncome;
        [CategoryAttribute("Ежемесячный доход"), RefreshProperties(RefreshProperties.All), ReadOnlyAttribute(true), DisplayName("Ежемесячный доход"), Editor(typeof(TypeEditor0), typeof(UITypeEditor))]
        public string totalIncome
        {
            get { return _totalIncome; }
            set
            {
                _totalIncome = value;
                decimal decValue = default(decimal);
                decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out decValue);
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Общая прибыль",
                        newValue = decValue
                    });
                }
            }
        }


        private Household _houseHold = new Household();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Дом"), Editor(typeof(TypeEditor3), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Household houseHold
        {
            get { return _houseHold; }
            set { _houseHold = value; }
        }

        private Transport _transport = new Transport();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Транспорт"), Editor(typeof(TypeEditor8), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Transport transport
        {
            get { return _transport; }
            set { _transport = value; }
        }

        private Finance _finance = new Finance();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Финансы"), Editor(typeof(TypeEditor2), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Finance finance
        {
            get { return _finance; }
            set { _finance = value; }
        }

        private Leisure _leisure = new Leisure();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Свободное время"), Editor(typeof(TypeEditor5), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Leisure leisure
        {
            get { return _leisure; }
            set { _leisure = value; }
        }

        private RegularBills _regularBills = new RegularBills();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Постоянные платежи"), Editor(typeof(TypeEditor7), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RegularBills regularBills
        {
            get { return _regularBills; }
            set { _regularBills = value; }
        }

        private Insurance _insurance = new Insurance();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Страхование"), Editor(typeof(TypeEditor4), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Insurance insurance
        {
            get { return _insurance; }
            set { _insurance = value; }
        }

        private Children _children = new Children();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Дети"), Editor(typeof(TypeEditor1), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Children children
        {
            get { return _children; }
            set
            {
                _children = value;
                System.Diagnostics.Debugger.Break();
            }
        }

        private OtherBills _otherBills = new OtherBills();
        [CategoryAttribute("Ежемесячный расход"), DisplayName("Другие счета"), Editor(typeof(TypeEditor6), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OtherBills otherBills
        {
            get { return _otherBills; }
            set { _otherBills = value; }
        }

        private void expandable_propertiesChanged(propertiesChangedEventArgs e)
        {
            if (propertiesChanged != null)
            {
                propertiesChanged(new propertiesChangedEventArgs
                {
                    propName = e.propName,
                    newValue = e.newValue
                });
            }
        }

    }
}
