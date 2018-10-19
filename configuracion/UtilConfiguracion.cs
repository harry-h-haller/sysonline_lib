using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid.Views.Grid;
using es.sysonline.lib.introspeccion;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace es.sysonline.lib.configuracion
{
    public class UtilConfiguracion
    {
        public static String DirectorioConfiguracion
        {
            get
            {
                return Path.Combine(new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Introspeccion.CompanyName, Introspeccion.ProductName });
            }
        }

        public static Boolean GuardaConfiguracion(GridView gridView, String nombre)
        {
            gridView.OptionsLayout.StoreAllOptions = true;
            gridView.OptionsLayout.StoreAppearance = true;
            gridView.OptionsLayout.StoreDataSettings = true;
            gridView.OptionsLayout.StoreVisualOptions = true;

            if (!Directory.Exists(DirectorioConfiguracion))
            {
                Directory.CreateDirectory(DirectorioConfiguracion);
            }

            String ruta = Path.Combine(DirectorioConfiguracion, $"{nombre}.xml");
            gridView.SaveLayoutToXml(ruta);

            return true;
        }

        public static Boolean CargaConfiguracion(GridView gridView, String nombre)
        {

            gridView.OptionsLayout.StoreAllOptions = true;
            gridView.OptionsLayout.StoreAppearance = true;
            gridView.OptionsLayout.StoreDataSettings = true;
            gridView.OptionsLayout.StoreVisualOptions = true;

            if (!Directory.Exists(DirectorioConfiguracion))
            {
                Directory.CreateDirectory(DirectorioConfiguracion);
            }

            String ruta = Path.Combine(DirectorioConfiguracion, $"{nombre}.xml");
            if (!File.Exists(ruta))
            {
                GuardaConfiguracion(gridView, nombre);
            }
            gridView.RestoreLayoutFromXml(ruta);

            return true;
        }

        public static Boolean GuardaConfiguracion(Form formulario, String nombre)
        {
            //Properties.Settings.Default[$"{nombre}Location"] = formulario.Location;
            //Properties.Settings.Default[$"{nombre}Bounds"] = formulario.Bounds;
            //Properties.Settings.Default[$"{nombre}WindowState"] = formulario.WindowState;
            //Properties.Settings.Default.Save();

            return true;
        }

        public static Boolean CargaConfiguracion(Form formulario, String nombre)
        {
            //formulario.StartPosition = FormStartPosition.Manual;

            //Point punto = (Point)Properties.Settings.Default[$"{nombre}Location"];
            //Rectangle dimensiones = (Rectangle)Properties.Settings.Default[$"{nombre}Bounds"];

            //if (punto.X == 0 && punto.Y == 0 && dimensiones.Width == 0 && dimensiones.Height == 0)
            //{
            //    centrarFormulario(formulario);
            //    GuardaConfiguracion(formulario, nombre);
            //}

            //formulario.Location = (Point)Properties.Settings.Default[$"{nombre}Location"];
            //formulario.Bounds = (Rectangle)Properties.Settings.Default[$"{nombre}Bounds"];
            //formulario.WindowState = (FormWindowState)Properties.Settings.Default[$"{nombre}WindowState"];

            return true;
        }

        private static void centrarFormulario(Form formulario)
        {
            formulario.StartPosition = FormStartPosition.Manual;
            formulario.Location = new Point(
                Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Width - formulario.Size.Width) / 2),
                Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Height - formulario.Size.Height) / 2));
        }

        public static Boolean GuardaConfiguracion(DockManager dockManager, String nombre)
        {
            if (!Directory.Exists(DirectorioConfiguracion))
            {
                Directory.CreateDirectory(DirectorioConfiguracion);
            }

            if (!Directory.Exists(DirectorioConfiguracion))
            {
                Directory.CreateDirectory(DirectorioConfiguracion);
            }

            String ruta = Path.Combine(DirectorioConfiguracion, $"{nombre}.xml");
            dockManager.SaveLayoutToXml(ruta);

            return true;
        }

        public static Boolean CargaConfiguracion(DockManager dockManager, String nombre)
        {
            if (!Directory.Exists(DirectorioConfiguracion))
            {
                Directory.CreateDirectory(DirectorioConfiguracion);
            }

            String ruta = Path.Combine(DirectorioConfiguracion, $"{nombre}.xml");
            if (!File.Exists(ruta))
            {
                GuardaConfiguracion(dockManager, nombre);
            }

            dockManager.RestoreLayoutFromXml(ruta);

            return true;
        }
    }
}
