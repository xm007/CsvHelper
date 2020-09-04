using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CsvHelper.Model
{
    public class DicModel : ObservableObject
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                RaisePropertyChanged(() => FileName);
            }
        }

        private string _comboBoxItemName;

        public string ComboBoxItemName
        {
            get { return _comboBoxItemName; }
            set
            {
                _comboBoxItemName = value;
                RaisePropertyChanged(() => ComboBoxItemName);
            }
        }
    }
}
