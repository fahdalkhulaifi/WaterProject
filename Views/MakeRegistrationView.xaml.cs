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

namespace WaterNetworkProject.Views
{
    /// <summary>
    /// Interaction logic for MakeRegistrationView.xaml
    /// </summary>
    public partial class MakeRegistrationView : UserControl
    {
        int previous, current, arrears, payments, price;
        public MakeRegistrationView()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            previous = Convert.ToInt32(TextBox1.Text);
            current = Convert.ToInt32(TextBox2.Text);
            arrears = Convert.ToInt32(TextBox3.Text);
            payments = Convert.ToInt32(TextBox4.Text);


            price = (current - previous) * 400 + (arrears) - (payments);


            label3.Content = " المبلغ المطلوب " + price + " ريال ";
            label4.Content = "فارق القراءة: " + (current - previous);
            label6.Content = "المتأخرات:" + arrears;
            label8.Content = ":  المدفوعات" + payments;
            // label8.Content = TextBox4;
        }
    }
}
