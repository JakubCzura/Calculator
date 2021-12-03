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
            try
            {
                using (StreamWriter StreamWriter = new StreamWriter(DataPath, false))
                {
                    StreamWriter.WriteLine(theme.ToString());               
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public static string ReadTheme()
        {
            try
            {
                using (StreamReader StreamReader = new StreamReader(DataPath))
                {
                    ThemeName = StreamReader.ReadLine();
                    return ThemeName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return "Standard.xaml";              
            }
           
        }

        public static void SetTheme()
        {
            try
            {
                App.Current.Resources.Clear();
                App.Current.Resources.Source = new Uri($"/Themes/{ThemeData.ReadTheme()}.xaml", UriKind.Relative);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
