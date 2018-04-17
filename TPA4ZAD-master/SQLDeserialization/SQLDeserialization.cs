using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekt.Context;
using Projekt.Model;
using Projekt.Services;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace Zycie.Services
{
    [Export(typeof(IDeserialize))]
    public  class SQLDeserialization : IDeserialize
    {
        public SQLDeserialization()
        {
            asmMetadata = new AssemblyMetadata();
            asm = new AssemblyContext();
        }

        private AssemblyMetadata asmMetadata=null;
        private AssemblyContext asm;
        private Task<List<AssemblyMetadata>> DeserializeMetadata()
        {
            return asm.Set<AssemblyMetadata>().ToListAsync();
        }

        private async void fillAssembly(int assemblyid)
        {
            foreach (var VARIABLE in await DeserializeMetadata())
            {
                if (VARIABLE.AssemblyMetadataId == assemblyid)
                {
                    asmMetadata.m_Namespaces = VARIABLE.m_Namespaces;
                    asmMetadata.m_Name = VARIABLE.m_Name;
                    asmMetadata.IsExpanded = VARIABLE.IsExpanded;
                }
            }
            if (asmMetadata.m_Name == null) MessageBox.Show("Niestety nie ma Assembly z takim id");
        }
        public AssemblyMetadata Deserialize()
        {
            string UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Wprowadz sciezke ", "Serialization", "");
            if (UserAnswer == "")
            {
                MessageBox.Show("nic nie wprowadziles");
            }
            else
            {
                string path = UserAnswer;
                fillAssembly(Convert.ToInt32(path));
            }
            return asmMetadata;
        }
        public string ToString()
        {
            return "SqlDeserialization";
        }
    }
}
