using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        RoleViewModel vmRole = new RoleViewModel();

        public WindowRole()
        {
            InitializeComponent();
            lvRole.ItemsSource = vmRole.ListRole;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewRole wnRole = new WindowsNewRole
            {
                Title = "Новая должность",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdRole = vmRole.MaxId() + 1;
            Role role = new Role
            {
                Id = maxIdRole
            };
            wnRole.DataContext = role;
            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(role);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Role role = (Role)lvRole.SelectedItem;
            if (role != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " +
                role.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmRole.ListRole.Remove(role);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewRole wnRole = new WindowsNewRole
            {
                Title = "Редактирование должности",
                Owner = this
            };

            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role.ShallowCopy();
                wnRole.DataContext = tempRole;
                
            if (wnRole.ShowDialog() == true)
                {
                    // сохранение данных
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
