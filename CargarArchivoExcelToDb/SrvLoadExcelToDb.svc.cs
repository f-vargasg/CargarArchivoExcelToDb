using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CargarArchivoExcelToDb
{

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SrvLoadExcelToDb : ISrvLoadExcelToDb
    {
        string path = string.Empty;

        public string Upload(Stream input)
        {
            path = ConfigurationManager.AppSettings["uploadPath"];
            string filename = String.Format(@"{0}\{1}.dat", path, Guid.NewGuid().ToString());
            using (var fname = File.Create(filename))
            {
                input.CopyTo(fname);
            }
            return filename;
        }
    }
}
