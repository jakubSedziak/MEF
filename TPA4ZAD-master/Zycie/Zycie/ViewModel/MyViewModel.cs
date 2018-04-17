using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Reflection;
using Projekt.Model;
using System.Collections;

using System.Linq;
using Projekt.Services;
using Zycie.CustomLoggers;
using Zycie.Services;

namespace Projekt.ViewModel
{
    /// <summary>
    /// Class MyViewModel - ViewModel implementation 
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MyViewModel : INotifyPropertyChanged
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        FileLogger flog = new FileLogger();
        HostMeToTheAplicationDeserialization hsttad;
        HostMeToTheAplicationSerialization hsttas;
        ObservableCollection<ISerialize> serializacji = new ObservableCollection<ISerialize>();
        ObservableCollection<IDeserialize> deserializacji = new ObservableCollection<IDeserialize>();
        #region constructors

        public MyViewModel()
        {
         
            HierarchicalAreas = new ObservableCollection<ITreeViewItem>();
            Click_Button = new DelegateCommand(LoadDLL);
            Click_Browse = new DelegateCommand(Browse);
      
       //     Click_DeserializeJson = new DelegateCommand(Jsondeserialize);
         
        //    Click_DeserializeSQL = new DelegateCommand(SQLdeserialize);
            hsttad = new HostMeToTheAplicationDeserialization();
            hsttas = new HostMeToTheAplicationSerialization();
            hsttas.run();
            hsttad.run();
            foreach(ISerialize ss in hsttas.GetSeres())
            {
                Serializacji.Add(ss);
            }
            foreach (IDeserialize ss in hsttad.GetDeses())
            {
                Deserializacji.Add(ss);
            }
        }

        public ObservableCollection<ISerialize> Serializacji
        {
            get { return serializacji; }
            set { serializacji = value; }
        }
        public ObservableCollection<IDeserialize> Deserializacji
        {
            get { return deserializacji; }
            set { deserializacji = value; }
        }
        #endregion

        public void OnEditSerialize(ISerialize objSerialize)
        {
            objSerialize.Serialize(assemblyMetadata);
            MessageBox.Show(objSerialize.ToString());
        }
        public void OnEditDeserialize(IDeserialize objDeserialize)
        {
           assemblyMetadata= (AssemblyMetadata)objDeserialize.Deserialize();
            pathVariable = objDeserialize.ToString();
            HierarchicalAreas.Clear();
            TreeViewLoaded(assemblyMetadata);
            MessageBox.Show(objDeserialize.ToString());
        }

        #region DataContext


        AssemblyMetadata assemblyMetadata;
        public ObservableCollection<ITreeViewItem> HierarchicalAreas { get; set; }

        public string PathVariable
        {
            get { return pathVariable; }
            set { pathVariable = value; }
        }
        public Visibility ChangeControlVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
            }
        }
        public ICommand Click_Browse { get; }
        public ICommand Click_Button { get; }
        public ICommand Click_SerializeJson { get; }
        public ICommand Click_DeserializeJson { get; }
        public ICommand Click_SerializeSQL { get; }
        public ICommand Click_DeserializeSQL { get; }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion

        #region private
      
     
        public void setPath(string path)
        {
            pathVariable = path;
        }
        private string pathVariable;
        private Visibility _visibility = Visibility.Hidden;
        public void LoadDLL()
        {
            if (System.IO.Path.GetExtension(pathVariable) == ".dll" || System.IO.Path.GetExtension(pathVariable) == ".exe")
            {
                log.Info("Zaladowano plik: " + pathVariable);
                flog.Log("Zaladowano plik: " + pathVariable);
                Assembly assembly = Assembly.LoadFrom(PathVariable);
                assemblyMetadata = new AssemblyMetadata(assembly);
                TreeViewLoaded(assemblyMetadata);
            }
        }
        private void TreeViewLoaded(AssemblyMetadata assembly)
        {
            ITreeViewItem rootItem = new AssemblyTreeViewItem(assembly) { Name = pathVariable.Substring(pathVariable.LastIndexOf('\\') + 1) };
            HierarchicalAreas.Add(rootItem);
        }
        private void Browse()
        {
            OpenFileDialog test = new OpenFileDialog();
            test.Filter = "Execute files (*.exe)|*.exe|Dynamic Library File(*.dll)| *.dll";
            test.ShowDialog();
            if (test.FileName.Length == 0)
            {
                MessageBox.Show("No files selected");
                log.Info("Wybrano pusty plik: ");
            }
            else
            {
                pathVariable = test.FileName;
                _visibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
                log.Info("Wybrano plik: " + pathVariable);
            }
        }
        #endregion

        public AssemblyMetadata GetAssemblyMetadata()
        {
            return assemblyMetadata;
        }

    }
}