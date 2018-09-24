using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Eliminacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            var directorio = new DirectoryInfo(path: ConfigurationManager.AppSettings.Get("path"));
            var comando = new StringBuilder("/C del "); // Comando usado para eliminar archivos desde la consola

            // Obtengo las ubicaciones de los archivos que deseo eliminar
            foreach (FileInfo archivo in directorio.GetFiles())
                comando.Append($"\"{archivo.FullName}\" ");
            
            Imprimir($"Intentando eliminar los archivos a través del comando {comando.ToString()}");
            System.Diagnostics.Process.Start("CMD.exe", comando.ToString());
            Imprimir("-------- Eliminado -------------");

            Console.ReadLine();
        }

        public static void Imprimir(string mensaje) => Console.WriteLine(mensaje);
    }
}
