using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CsvHelper.Model
{
    class DataProcess
    {
        public static ObservableCollection<DicModel> ProcessDic()
        {
            string fNameDicPath = @"E:\CSharplearn\FileHelperTest\FileHelper7\FileHelper7\Dics\FileNameDictionary.csv";
            string idDicPath = @"E:\CSharplearn\FileHelperTest\FileHelper7\FileHelper7\Dics\IdDictionary.csv";
            string[] fNameDicData = File.ReadAllLines(fNameDicPath);
            string[] idDicData = File.ReadAllLines(idDicPath);
            ObservableCollection<DicModel> dics = new ObservableCollection<DicModel>();
            DataProcessMethod.InitializeDicForDic(idDicData, dics);
            DataProcessMethod.ReadDataAndSetForDic(idDicData, fNameDicData, dics);
            DataProcessMethod.CombineString(dics);
            return dics;
        }
        public static ObservableCollection<ObservableCollection<AttrModel>> ProcessAttr()
        {
            string attrDicPath = @"E:\CSharplearn\FileHelperTest\FileHelper7\FileHelper7\Dics\AttributeDictionary.csv";
            string deValueDicPath = @"E:\CSharplearn\FileHelperTest\FileHelper7\FileHelper7\Dics\DefaultDictionary.csv";
            string[] attrDicData = File.ReadAllLines(attrDicPath);
            string[] deValueDicData = File.ReadAllLines(deValueDicPath);
            // Every dic's line should be a collection,and should have a bundle to contain these collections.So here I used doulbe layers of collection.
            ObservableCollection<ObservableCollection<AttrModel>> attributes = new ObservableCollection<ObservableCollection<AttrModel>>();
            DataProcessMethod.InitializeDicForAttr(attrDicData, attributes);
            DataProcessMethod.ReadDataAndSetForAttr(attrDicData, deValueDicData, attributes);
            return attributes;

        }
        public static Dictionary<int, ObservableCollection<AttrModel>> CreateDicIdToAttrList(ObservableCollection<DicModel> data1,
                                                                                             ObservableCollection<ObservableCollection<AttrModel>> data2)
        {
            var MainDic = new Dictionary<int, ObservableCollection<AttrModel>>();
            for (int index = 0; index < data1.Count(); index++)
            {
                MainDic.Add(Convert.ToInt32(data1[index].Id), data2[index]);
            }
            return MainDic;
        }

        public static Dictionary<int, string> CreateDicIdToFileName(ObservableCollection<DicModel> data1)
        {
            var MainDic = new Dictionary<int, string>();
            for (int index = 0; index < data1.Count(); index++)
            {
                MainDic.Add(Convert.ToInt32(data1[index].Id), data1[index].FileName);
            }
            return MainDic;
        }
    }
}