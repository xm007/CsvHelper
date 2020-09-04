using CsvHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace CsvHelper.ViewModel
{
    public class DicViewModel : ViewModelBase
    {
        public DicViewModel()
        {
            TheComboBoxItem = DataModel.Dic;
            AttrList = DataModel.Attribute;

        }
        private ObservableCollection<DicModel> _theComboBoxItem;

        public ObservableCollection<DicModel> TheComboBoxItem
        {
            get { return _theComboBoxItem; }
            set
            {
                _theComboBoxItem = value;
                RaisePropertyChanged(() => TheComboBoxItem);
            }
        }

        private ObservableCollection<ObservableCollection<AttrModel>> _attrList;

        public ObservableCollection<ObservableCollection<AttrModel>> AttrList
        {
            get { return _attrList; }
            set
            {
                _attrList = value;
                RaisePropertyChanged(() => AttrList);
            }
        }
    }
}
