using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Projekt.Services;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

namespace Zycie.Services
{
    class HostMeToTheAplicationSerialization
    {
        [ImportMany]
        private List<ISerialize> SerClases { get; set; }
        public void run()
        {
            Compose();
        }
        public List<ISerialize> GetSeres() => SerClases;

        private void Compose()
        {
            AggregateCatalog catalog = new AggregateCatalog();
               //  catalog.Catalogs.Add(new ApplicationCatalog());
            string dllPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path = Path.Combine(dllPath);
            catalog.Catalogs.Add(new DirectoryCatalog(path));

            var compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);
            compositionContainer.SatisfyImportsOnce(this);
        }
    }
}
