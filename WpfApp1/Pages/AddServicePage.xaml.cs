using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using WpfApp1.Components;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        Components.Service service;
        public AddServicePage(Components.Service _service)
        {
            InitializeComponent();
            service = _service;
            DataContext = service;
            service.DurationInSeconds = service.DurationInSeconds /= 60;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            service.DurationInSeconds *= 60;
            if (service.ID == 0)
                DBConnect.db.Service.Add(service);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Успешно выполнено!");
            Navigation.NextPage(new Nav("Список услуг", new ServicesListPage()));
        }
    }
}
