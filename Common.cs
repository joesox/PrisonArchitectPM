using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Prison_Architect_Prison_Manager
{
    class Common
    {
        public static String gLogFile = Application.StartupPath + "\\Log.txt";
        public static String sxAdminGuide = Application.StartupPath + "\\AdminGuide.pdf";
        public static String ReadMe = Application.StartupPath + "\\ReadMe.txt";
        public static String savesDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Introversion\\Prison Architect\\saves";
        public static String ConfigIniFile = Application.StartupPath + "\\config.ini";
        public static String TEMPDIR = System.IO.Path.GetTempPath() + "papm";
    }
}
