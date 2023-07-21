using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Window
    {
        public Confirmation(string message, string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();
            SetContent(message);
            
        }

		private void SetContent(string message)
		{
			lbMessage.Content = message;
            btnCancel.Content = Properties.Resources.Cancel;
            btnOk.Content = Properties.Resources.Yes;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
            DialogResult = false;
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
            DialogResult = true;
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				DialogResult = true;
			}
			else if (e.Key == Key.Escape)
			{
				DialogResult = false;
			}
		}
	}
}
