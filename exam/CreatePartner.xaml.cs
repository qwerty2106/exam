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
    /// Логика взаимодействия для CreatePartner.xaml
    /// </summary>
    public partial class CreatePartner : Window
    {
        public CreatePartner()
        {
            InitializeComponent();
            cmbType.ItemsSource = DBLib.GetTypes();
            cmbType.SelectedIndex = 0;
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


            Partner partner = new Partner
            {
                PartnerType = cmbType.SelectedItem.ToString(),
                Name = txtName.Text.Trim(),
                Director = txtDirector.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Inn = txtInn.Text.Trim(),
                Rating = Convert.ToInt32(txtRating.Text.Trim()),
            };

            int result = DBLib.CreateData(partner);
            MessageBox.Show($"Строк обновлено: {result}", null, MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
