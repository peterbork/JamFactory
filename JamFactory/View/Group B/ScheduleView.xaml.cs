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
using System.Globalization;
using JamFactory.Helper;

namespace JamFactory.View.Group_B {
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Window {
        int CurrentWeekNumber;
        public ScheduleView() {
            InitializeComponent();
            DateTime Today = DateTime.Now;

            CurrentWeekNumber = Dates.GetWeekNumberFromDate(Today);
            CurrentWeek.Content = "Week " + CurrentWeekNumber;
            WeekStartDate.Content = Dates.FirstDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);
            WeekEndDate.Content = Dates.LastDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);

            //Controller.ProductionController.GetTask(2, Convert.ToDateTime("2002-09-24 08:00:00.000"), Convert.ToDateTime("2002-09-24 08:00:00.000"));
        }

        private void NextWeek1_Click(object sender, RoutedEventArgs e) {
            CurrentWeekNumber++;
            CurrentWeek.Content = "Week " + CurrentWeekNumber;
            WeekStartDate.Content = Dates.FirstDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);
            WeekEndDate.Content = Dates.LastDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e) {
            CurrentWeekNumber--;
            CurrentWeek.Content = "Week " + CurrentWeekNumber;
            WeekStartDate.Content = Dates.FirstDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);
            WeekEndDate.Content = Dates.LastDateOfWeek(CurrentWeekNumber, CultureInfo.CurrentCulture);
        }
    }
}
