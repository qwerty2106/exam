using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<Partner> partnersList = DBLib.GetData();
            ListViewPartners.ItemsSource = partnersList;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreatePartner createPartner = new CreatePartner();
            createPartner.ShowDialog();
            LoadData();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var partner = (Partner)btn.DataContext;

            ChangeWindow changeWindow = new ChangeWindow(partner);
            changeWindow.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var partner = (Partner)btn.DataContext;

            int result = DBLib.DeleteData(partner);
            MessageBox.Show($"Строк обновлено: {result}", null, MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();
        }
    }
}
