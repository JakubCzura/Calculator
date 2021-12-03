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
        private static string ThemeName { get; set; } = "Standard";
        private static string DataPath = Path.Combine(Environment.CurrentDirectory, "ThemesData.txt");
        
        public static void Show()
        {
            MessageBox.Show(DataPath);
        }

        public static void SaveTheme(EnumThemes.Themes theme)
        {           
            using(StreamWriter StreamWriter = new StreamWriter(DataPath, false))
            {
                StreamWriter.WriteLine(theme.ToString());
            }
        }

        public static string ReadTheme()
        {
            using(StreamReader StreamReader = new StreamReader(DataPath))
            {
                ThemeName = StreamReader.ReadLine();
                return ThemeName;   
            }
        }

        public static void SetTheme()
        {
            App.Current.Resources.Clear();
            App.Current.Resources.Source = new Uri($"/Themes/{ThemeData.ReadTheme()}.xaml", UriKind.Relative);
        }
    }
}
