using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BotonExp1Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new NewXP1();
            try
            {
                newWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

            //this.Hide();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotonExp3Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new Xp3();
            try
            {
                newWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void BotonExp2Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new NewXP2();
            newWindow.ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}
