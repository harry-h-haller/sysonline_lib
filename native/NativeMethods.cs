using System.Drawing;
using System.Runtime.InteropServices;

/*
 * lorenzo ramírez hernández <telemaco230@gmail.com> 
 */
/// <summary>
/// Llamadas a métodos nativos de sistema operativo
/// </summary>
namespace es.sysonline.lib.native
{
    /// <summary>
    /// Estructura de punto para las operaciones de sistema sobre el ratón
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }

    /// <summary>
    /// Métodos nativos
    /// </summary>
    public class NativeMethods
    {
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        /// <summary>
        /// Configurar el escalado para el soporte de DPI
        /// </summary>
        /// <returns>éxito de la operación</returns>
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        /// <summary>
        /// Recupera la posición absoluta del ratón
        /// </summary>
        /// <param name="lpPoint">variable de entrada/salida dónde almacenar la posición recuperada</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "4")]
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        /// <summary>
        /// Abstracción para recuperar la posicíón del ratón
        /// </summary>
        /// <returns>posición del ratón</returns>
        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            if (!GetCursorPos(out lpPoint))
            {
                lpPoint.X = int.MinValue;
                lpPoint.Y = int.MinValue;
            }
            return lpPoint;
        }
    }
}
