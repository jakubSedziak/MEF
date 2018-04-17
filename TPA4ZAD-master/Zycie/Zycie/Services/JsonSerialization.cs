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

namespace Projekt.Services
{
    [Export(typeof(ISerialize))]
     class JsonSerialization:ISerialize
    {
       
            public void Serialize(AssemblyMetadata tree)
            {
                string path = "";
                string UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Wprowadz sciezke ", "Serialization", "");
                if (UserAnswer == "")
                {
                    MessageBox.Show("nic nie wprowadziles");
                }
                else
                {
                    if (tree == null)
                    {
                        MessageBox.Show("NAJPIERW COS WYBIERZ");
                    }
                    else
                    {
                        path = UserAnswer;
                    var json = JsonConvert.SerializeObject(tree, Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

                        File.WriteAllText(@path, json);
                }
                }
           
            }
        public string ToString()
        {
            return "JsonSerialize";
        }
        
    }
}
