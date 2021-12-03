using Calculator.Themes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.ViewModel.DataFile
{
    public class ThemeData
    {
       static string DataPath = Path.Combine("DataFile", "ThemesData.txt");

        public static void Show()
        {
            MessageBox.Show(DataPath);
        }

        static void SaveTheme(EnumThemes.Themes theme)
        {           
            using(StreamWriter StreamWriter = new StreamWriter(DataPath, false))
            {
                StreamWriter.WriteLine(theme.ToString());
            }
        }
    }
}
