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
using JamFactory.Model;
using JamFactory.Controller;


namespace JamFactory.View.Group_B {
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Window {
        int WeekNumber;
        DateTime FirstDateOfWeek;
        DateTime LastDateOfWeek;
        List<ListBox> listBox;

        public ScheduleView() {
            InitializeComponent();

            listBox = new List<ListBox>();
            listBox.Add(day1);
            listBox.Add(day2);
            listBox.Add(day3);
            listBox.Add(day4);
            listBox.Add(day5);
            listBox.Add(day6);
            listBox.Add(day7);

            DateTime Today = DateTime.Now;
            WeekNumber = Dates.GetWeekNumberFromDate(Today);
            SelectedWeek.Content = "Week " + WeekNumber;
            FillSchedule(ProductionController.GetEmployeeID(), WeekNumber, listBox);
            
        }

        private void NextWeek1_Click(object sender, RoutedEventArgs e) {
            WeekNumber++;
            SelectedWeek.Content = "Week " + WeekNumber;
            EmptySchedule();
            FillSchedule(ProductionController.GetEmployeeID(), WeekNumber, listBox);
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e) {
            WeekNumber--;
            SelectedWeek.Content = "Week " + WeekNumber;
            EmptySchedule();
            FillSchedule(ProductionController.GetEmployeeID(), WeekNumber, listBox);
        }
        private void FillSchedule(int EmployeeID, int WeekNumber, List<ListBox> listBox) {
            FirstDateOfWeek = Dates.FirstDateOfWeek(WeekNumber, CultureInfo.CurrentCulture);

            LastDateOfWeek = Dates.LastDateOfWeek(WeekNumber, CultureInfo.CurrentCulture);

            //for each listbox in the list
            for (int i = 0; i < listBox.Count; i++) {
                for (int j = 0; j < Controller.ProductionController.GetTask(EmployeeID, FirstDateOfWeek, LastDateOfWeek, WeekNumber)[i].Count; j++) {
                    listBox[i].Items.Add(Helper.Dates.GetHoursFromDateTime(Controller.ProductionController.GetTask(EmployeeID, FirstDateOfWeek, LastDateOfWeek, WeekNumber)[i][j].StartTime) + " - " + Helper.Dates.GetHoursFromDateTime(Controller.ProductionController.GetTask(2, FirstDateOfWeek, LastDateOfWeek, WeekNumber)[i][j].EndTime) + "\nMaskine:\n" + Controller.ProductionController.GetTask(2, FirstDateOfWeek, LastDateOfWeek, WeekNumber)[i][j].Machine.Name + "\nBeskrivelse: \n" + Controller.ProductionController.GetTask(2, FirstDateOfWeek, LastDateOfWeek, WeekNumber)[i][j].Description + "\n");
                }
            }
        }
        private void EmptySchedule() {
            foreach (ListBox lb in listBox) {
                lb.Items.Clear();
            }
        }
    }
}
