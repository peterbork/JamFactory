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

namespace JamFactory.View.Group_B {
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window {
        public Start() {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            View.Group_B.ScheduleView Schedule = new View.Group_B.ScheduleView();
            Schedule.Show();
        }

        private void LogInbutton_Click(object sender, RoutedEventArgs e)
        {
            int PersonID = int.Parse(PersonIDTextBox.Text);
            string Password = PasswordBox.Password;
            
            Controller.ProductionController.CheckLogin(PersonID, Password);
        }

        private void Closebutton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
