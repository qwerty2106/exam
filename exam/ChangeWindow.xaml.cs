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
using System.Windows.Shapes;

namespace exam
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        Partner partner;
        public ChangeWindow(Partner partner)
        {
            InitializeComponent();
            this.partner = partner;
            stackPanelPartner.DataContext = partner;
            cmbType.ItemsSource = DBLib.GetTypes();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Введите название!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtDirector.Text))
            {
                MessageBox.Show("Введите руководителя!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Введите почту!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Введите адрес!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtInn.Text))
            {
                MessageBox.Show("Введите ИНН!", null, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Partner partner = new Partner();
            partner = (Partner)stackPanelPartner.DataContext;
            int result = DBLib.UpdateData(partner);
            MessageBox.Show($"Строк обновлено: {result}", null, MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
