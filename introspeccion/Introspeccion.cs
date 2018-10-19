using System;
using System.Diagnostics;
using System.Reflection;

/*
 * lorenzo ramírez hernández <telemaco230@gmail.com> 
 */
namespace es.sysonline.lib.introspeccion
{
    /// <summary>
    /// Métodos de introspección sobre la aplicación
    /// </summary>
    public class Introspeccion
    {
        /// <summary>
        /// Arquitectura de la aplicación
        /// </summary>
        public static String Arquitectura
        {
            get { return typeof(string).Assembly.GetName().ProcessorArchitecture.ToString(); }
        }

        /// <summary>
        /// Nombre de la compañía
        /// </summary>
        public static String CompanyName
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.CompanyName;
            }
        }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public static String ProductName
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.ProductName;
            }
        }

        /// <summary>
        /// Nombre interno de producto
        /// </summary>
        public static String InternalName
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.InternalName;
            }
        }

        /// <summary>
        /// Ubicación del ejecutable
        /// </summary>
        public static String FileName
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.FileName;
            }
        }

        /// <summary>
        /// Versión de compilación
        /// </summary>
        public static String Version
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.ProductVersion;
            }
        }

        public static String FileDescription
        {
            get
            {
                FileVersionInfo informacion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return informacion.FileDescription.ToString();
            }
        }

        /// <summary>
        /// Información de copyright
        /// </summary>
        public static String Copyright
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                object[] obj = asm.GetCustomAttributes(false);
                foreach (object o in obj)
                {
                    if (o.GetType() ==
                        typeof(System.Reflection.AssemblyCopyrightAttribute))
                    {
                        AssemblyCopyrightAttribute aca =
                (AssemblyCopyrightAttribute)o;
                        return aca.Copyright;
                    }
                }
                return string.Empty;
            }
        }
    }
}
