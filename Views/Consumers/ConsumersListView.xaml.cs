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
using WaterNetworkProject.ViewModels.Consumers;

namespace WaterNetworkProject.Views.Consumers
{
    /// <summary>
    /// Interaction logic for ConsumersListView.xaml
    /// </summary>
    public partial class ConsumersListView : UserControl
    {
        public ConsumersListView()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as ConsumerViewModel).Id;
        }
    }
}
