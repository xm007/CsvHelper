using System.Collections.ObjectModel;
using System.Linq;

namespace CsvHelper.Model
{
    class DataProcessMethod
    {
        internal static void ReadDataAndSetForAttr(string[] dicdata1, string[] dicdata2, ObservableCollection<ObservableCollection<AttrModel>> data)
        {
            for (int lines = 0; lines < data.Count(); lines++)
            {
                for (int index = 0; index < data[lines].Count(); index++)
                {
                    var attrtemp = dicdata1[lines].Split(',');
                    var deValuetemp = dicdata2[lines].Split(',');
                    data[lines][index].AttributeName = attrtemp[index];
                    data[lines][index].DefaultValue = deValuetemp[index];
                }
            }
        }
        internal static void ReadDataAndSetForDic(string[] dicdata1, string[] dicdata2, ObservableCollection<DicModel> data)
        {
            for (int index = 0; index < data.Count(); index++)
            {
                data[index].Id = dicdata1[index];
                data[index].FileName = dicdata2[index];
            }
        }
        internal static void InitializeDicForAttr(string[] dicdata, ObservableCollection<ObservableCollection<AttrModel>> data)
        {
            for (int i = 0; i < dicdata.Count(); i++)
            {
                data.Add(new ObservableCollection<AttrModel>());
                for (int j = 0; j < dicdata[i].Split(',').Count(); j++)
                {
                    data[i].Add(new AttrModel());
                }
            }
        }
        internal static void InitializeDicForDic(string[] dicdata, ObservableCollection<DicModel> data)
        {
            for (int count = 0; count < dicdata.Count(); count++)
            {
                data.Add(new DicModel());
            }
        }
        internal static void CombineString(ObservableCollection<DicModel> data)
        {
            int count = 0;
            foreach (var item in data)
            {
                string temp = $"{item.Id}({item.FileName})";
                data[count].ComboBoxItemName = temp;
                count++;
            }
        }

    }
}
