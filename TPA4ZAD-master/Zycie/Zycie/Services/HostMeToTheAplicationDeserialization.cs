using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Projekt.Services;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Zycie.Services
{
    class HostMeToTheAplicationDeserialization
    {
        [ImportMany]
        private List<IDeserialize> DesClases { get; set; }
        public void run()
        {
            Compose();
        }
        public List<IDeserialize> GetDeses() => DesClases;

        private void Compose()
        {
            AggregateCatalog catalog = new AggregateCatalog();
           // catalog.Catalogs.Add(new ApplicationCatalog());
            string dllPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path = Path.Combine(dllPath);
            catalog.Catalogs.Add(new DirectoryCatalog(path));

            var compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);
            
        }
    }
}
