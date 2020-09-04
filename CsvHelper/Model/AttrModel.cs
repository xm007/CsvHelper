using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace CsvHelper.Model
{
    public class AttrModel : ObservableObject
    {
        private string _attributeName;

        public string AttributeName
        {
            get { return _attributeName; }
            set
            {
                _attributeName = value;
                RaisePropertyChanged(() => AttributeName);
            }
        }

        private string _defaultValue;

        public string DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                _defaultValue = value;
                RaisePropertyChanged(() => DefaultValue);
            }
        }

    }
}
