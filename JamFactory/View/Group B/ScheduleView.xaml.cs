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
        List<ListBox> listBox;

        public ScheduleView() {
            InitializeComponent();

            // Adds 
            listBox = new List<ListBox>();
            listBox.Add(day1);
            listBox.Add(day2);
            listBox.Add(day3);
            listBox.Add(day4);
            listBox.Add(day5);
            listBox.Add(day6);
            listBox.Add(day7);

            WeekNumber = ProductionController.GetWeekNumber();
            FillSchedule();
            
        }

        private void NextWeek1_Click(object sender, RoutedEventArgs e) {
            WeekNumber = ProductionController.JumpToNextWeek();
            FillSchedule();
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e) {
            WeekNumber = ProductionController.JumpToPreviousWeek();
            FillSchedule();
        }
        private void FillSchedule() {
            int EmployeeID = ProductionController.GetEmployeeID();

            DateTime FirstDateOfWeek = Dates.FirstDateOfWeek(WeekNumber);
            DateTime LastDateOfWeek = Dates.LastDateOfWeek(WeekNumber);

            Controller.ProductionController.GetTasks(EmployeeID, FirstDateOfWeek, LastDateOfWeek, WeekNumber);
            Mondaylabel.Content = "Mandag: " + FirstDateOfWeek.Day + "/" + FirstDateOfWeek.Month;
            Tuesdaylabel.Content = "Tirsdag: " + FirstDateOfWeek.AddDays(1).Day + "/" + FirstDateOfWeek.AddDays(1).Month;
            Wednesdaylabel.Content = "Onsdag: " + FirstDateOfWeek.AddDays(2).Day + "/" + FirstDateOfWeek.AddDays(2).Month;
            Thursdaylabel.Content = "Torsdag: " + FirstDateOfWeek.AddDays(3).Day + "/" + FirstDateOfWeek.AddDays(3).Month;
            Fridaylabel.Content = "Fredag: " + FirstDateOfWeek.AddDays(4).Day + "/" + FirstDateOfWeek.AddDays(4).Month;
            Saturdaylabel.Content = "Lørdag: " + FirstDateOfWeek.AddDays(5).Day + "/" + FirstDateOfWeek.AddDays(5).Month;
            Sundaylabel.Content = "Søndag: " + LastDateOfWeek.Day + "/" + LastDateOfWeek.Month;
            //for each listbox in the list
            for (int i = 0; i < listBox.Count; i++) {
                listBox[i].Items.Clear();
                for (int j = 0; j < Controller.ProductionController.ListOfLists[i].Count; j++) {
                    listBox[i].Items.Add(Helper.Dates.GetHoursFromDateTime(Controller.ProductionController.ListOfLists[i][j].StartTime) + " - " + Helper.Dates.GetHoursFromDateTime(Controller.ProductionController.ListOfLists[i][j].EndTime) + "\nMaskine:\n" + Controller.ProductionController.ListOfLists[i][j].Machine.Name + "\nBeskrivelse: \n" + Controller.ProductionController.ListOfLists[i][j].Description + "\n");
                }
            }

            WeekNumberInput.Text = WeekNumber + "";
            Year.Content = ProductionController.GetCurrentYear();
        }

        private void WeekNumberInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                try {
                    WeekNumber = int.Parse(WeekNumberInput.Text);
                }catch (FormatException) {
                    MessageBox.Show("Skal være et tal");
                }

                ProductionController.JumpToWeek(WeekNumber);
                FillSchedule();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Start S = new Start();
            S.Show();
            Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Arbejdsplan sendt til printer.");
        }
    }
}               
