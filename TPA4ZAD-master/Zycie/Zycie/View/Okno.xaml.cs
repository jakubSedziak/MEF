using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt.Model;
using Projekt.Services;
using Projekt.ViewModel;

namespace Projekt.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Okno : Window
    {
        private MyViewModel mvm;
        public Okno()
        {
            mvm= new MyViewModel();
            InitializeComponent();
            DataContext = mvm;
        }
        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                ITreeViewItem tr = (ITreeViewItem)TreeView.SelectedItem;
                Buton.Text = tr.ToString();

            }
            catch (Exception r)
            {

            }

        }

        private void ListOfClientsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object f = listOfSerialize.SelectedItem;
            if (f != null)
            {
                mvm.OnEditSerialize((ISerialize)f);
            }
        }

        private void ListOfDesesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object f = listOfDeserialize.SelectedItem;
            if (f != null)
            {
                mvm.OnEditDeserialize((IDeserialize)f);
            }
        }
    }
}
