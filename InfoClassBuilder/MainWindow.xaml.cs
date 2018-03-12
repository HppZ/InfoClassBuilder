using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoClassBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Result.Text = DoTask(Input.Text);
            }
            catch (Exception exception)
            {
                Result.Text = "error " + exception.Message;
            }
        }

        private string DoTask(string text)
        {
            Regex rx = new Regex(@"(\b\w+\b)\s*{ get; set; }");
            MatchCollection matches = rx.Matches(text);

            foreach (Match match in matches)
            {
                var str = match.Captures[0].Value;
                var t = char.ToUpper(str.First()) + str.Substring(1).ToLower();
                text = text.Replace(str, t);
            }

            return text;
        }

    }
}
