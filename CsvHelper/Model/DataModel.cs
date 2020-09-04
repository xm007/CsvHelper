using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace CsvHelper.Model
{
    public static class DataModel
    {
        static DataModel()
        {
            Dic = DataProcess.ProcessDic();
            Attribute = DataProcess.ProcessAttr();
            IdToAttrDic = DataProcess.CreateDicIdToAttrList(Dic, Attribute);
            IdToFileNameDic = DataProcess.CreateDicIdToFileName(Dic);
        }
        private static ObservableCollection<DicModel> _dic;

        public static ObservableCollection<DicModel> Dic
        {
            get { return _dic; }
            set
            {
                _dic = value; ;
            }
        }
        private static ObservableCollection<ObservableCollection<AttrModel>> _attribute;

        public static ObservableCollection<ObservableCollection<AttrModel>> Attribute
        {
            get { return _attribute; }
            set
            {
                _attribute = value;
            }
        }

        private static Dictionary<int, ObservableCollection<AttrModel>> _idToAttrDic;

        public static Dictionary<int, ObservableCollection<AttrModel>> IdToAttrDic
        {
            get { return _idToAttrDic; }
            set { _idToAttrDic = value; }
        }

        private static Dictionary<int, string> _idToFileNameDic;

        public static Dictionary<int, string> IdToFileNameDic
        {
            get { return _idToFileNameDic; }
            set { _idToFileNameDic = value; }
        }

    }
}
