using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projekt.Model;
using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.Win32;

namespace Projekt.Services
{
    [Export(typeof(IDeserialize))]
    class JsonDeserialization : IDeserialize
    {
          public AssemblyMetadata Deserialize()
          {
              OpenFileDialog test = new OpenFileDialog();
              test.Filter = "Text files (*.txt)|*.txt";
              test.ShowDialog();
              if (test.FileName.Length == 0)
              {
                  MessageBox.Show("No files selected");
              }
              else
              {
                  string path = test.FileName;
                  string json = File.ReadAllText(path);
                  AssemblyMetadata deserializedaseAssemblyMetadata = JsonConvert.DeserializeObject<AssemblyMetadata>(json,
                      new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                  return deserializedaseAssemblyMetadata;
            }
              return null;
          }
          public string ToString()
          {
            return "JsonDeserialization";
          }
    }
}
