using Microsoft.Win32;
using CsvHelper.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CsvHelper.View
{
    /// <summary>
    /// DicView.xaml 的交互逻辑
    /// </summary>
    public partial class DicView : Window
    {
        public DicView()
        {
            InitializeComponent();
        }

        private void TheComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataModel = TheComboBox.SelectedItem as DicModel;
            var id = Convert.ToInt32(dataModel.Id);
            ObservableCollection<AttrModel> attrs;
            DataModel.IdToAttrDic.TryGetValue(id, out attrs);

            AttrDataGrid.ItemsSource = attrs;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog window = new SaveFileDialog()
            {
                Title = "Save Your File",
                Filter = "Csv lists (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files|*.*",
                DefaultExt = ".csv",
                FileName = ""
            };

            var dataModel = TheComboBox.SelectedItem as DicModel;
            var id = Convert.ToInt32(dataModel.Id);
            string fileName;
            DataModel.IdToFileNameDic.TryGetValue(id, out fileName);

            //int index = 0;
            //foreach (var item in DataModel.Dic)
            //{
            //    index++;
            //    if (Convert.ToInt32(item.Id) == id)
            //    {
            //        break;
            //    }
            //}

            ObservableCollection<AttrModel> attrs;
            DataModel.IdToAttrDic.TryGetValue(id, out attrs);

            List<string> attributeNamesTemp = new List<string>();
            List<string> attributeContentsTemp = new List<string>();
            foreach (var item in attrs)
            {
                attributeNamesTemp.Add(item.AttributeName);
                attributeContentsTemp.Add(item.DefaultValue);
            }
            string attributeNamesForWrite = string.Join(",", attributeNamesTemp);
            string attributeContentsForWrite = string.Join(",", attributeContentsTemp);

            if (window.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(window.FileName))
                {
                    sw.WriteLine(id);
                    sw.WriteLine("0");
                    sw.WriteLine($"Assets/Illusion/assetbundle/chara/list/characustom/{id}/{fileName}{id}");
                    sw.WriteLine(attributeNamesForWrite);
                    sw.WriteLine(attributeContentsForWrite);
                }
            }
        }

        private void AttrDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var evertArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            evertArg.RoutedEvent = UIElement.MouseWheelEvent;
            evertArg.Source = sender;
            AttrDataGrid.RaiseEvent(evertArg);
        }
    }
}
