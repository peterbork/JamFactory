﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamFactory.Model;
using System.Globalization;
using System.Windows;

// Controller for group B
namespace JamFactory.Controller {

    public class ProductionController {
        static int EmployeeID;
        static DateTime currentDate;
        public static List<List<Model.Task>> ListOfLists;

        public static void CheckLogin(int personID, string password)
        {
            EmployeeID = personID;
            bool LogIn = Database.ProductionDB.CheckLogin(personID, password);

            if (LogIn == true) {
                View.Group_B.ScheduleView scheduleView = new View.Group_B.ScheduleView();
                if (password == "Admin")
                {
                    scheduleView.MakeSchedule.Visibility = Visibility.Visible;
                }
                scheduleView.Show();
                App.Current.Windows[0].Close();

            }
            else {
                System.Windows.MessageBox.Show("PersonID og Password er forkert!");
            }
        }
        public static int GetEmployeeID() {
            //stores employee id, for use later
            return EmployeeID;
        }

        public static string GetCurrentYear() {
            if (currentDate.Year != currentDate.AddDays(5).Year)
                return currentDate.Year + "/" + currentDate.AddDays(5).Year;
            else
                return currentDate.Year + "";
        }

        public static int GetWeekNumber() {
            if (currentDate == DateTime.MinValue) {
                System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
                DayOfWeek today = DateTime.Now.DayOfWeek;
                currentDate = DateTime.Now.AddDays(-(today - fdow)).Date;
            }
            return Helper.Dates.GetWeekNumberFromDate(currentDate);
        }

        public static void JumpToWeek(int week) {
            if (Helper.Dates.ValidWeekNumber(week, currentDate.Year)) {
                currentDate = Helper.Dates.FirstDateOfWeek(week, currentDate.Year);
            }
            else {
                MessageBox.Show("Ikke en gyldig uge");
            }
        }

        public static int JumpToNextWeek() {
            currentDate = currentDate.AddDays(7);
            return Helper.Dates.GetWeekNumberFromDate(currentDate);
        }

        public static int JumpToPreviousWeek() {
            currentDate = currentDate.AddDays(-7);
            return Helper.Dates.GetWeekNumberFromDate(currentDate);
        }

        public static void GetTasks(int EmployeeID, DateTime starttime, DateTime endtime, int WeekNumber) {

            // Gets all tasks within the given parameters (EmployeeID, StartTime, EndTime)
            List<Model.Task> _Tasks = Database.ProductionDB.GetTasks(EmployeeID, starttime, endtime);

            // Uses helper class to find first date from weeknumber
            DateTime StartOfWeekDate = Helper.Dates.FirstDateOfWeek(WeekNumber);

            // Adds list of tasks to the list of lists
            List<List<Model.Task>> ListOfTasksInList  = GetTasksForEachDay(_Tasks, StartOfWeekDate);

            // Returns a list within a list of all tasks;
            ListOfLists = ListOfTasksInList;
        }

        public static List<List<Model.Task>> GetTasksForEachDay( List<Model.Task> _Tasks, DateTime StartOfWeekDate){
            // Creates new list with lists
            List<List<Model.Task>> ListOfTaskInList = new List<List<Model.Task>>();
            
            // Store first date in weeknumber, as MondayDate
            DateTime MondayDate = StartOfWeekDate;

            // Runs loop 7 times, for each weekday
            for (int i = 1; i <= 7; i++)
			{
                // Create new list of Tasks
                List<Model.Task> ListOfTasks = new List<Model.Task>();
                foreach (Model.Task t in _Tasks) 
                {
                    if (t.StartTime > MondayDate && t.EndTime < MondayDate.AddDays(1)) 
                    {
                        ListOfTasks.Add(t);
                    }
                }
            ListOfTaskInList.Add(ListOfTasks);

            // Add 1 day for every loop through
            MondayDate = StartOfWeekDate.AddDays(i);
			}
            return ListOfTaskInList;
        }
        public List<Model.Task> MakeSchedule(int weekNumber)
        {
            List<Model.TaskType> taskTypes = Database.ProductionDB.GetTaskTypes(0);
            List<Model.Employee> employees = Database.ProductionDB.GetEmployees(0);
            List<Model.Machine> machines = Database.ProductionDB.GetMachines(0);
            List<DateTime> daysInWeek = new List<DateTime>();
            daysInWeek.Add(Helper.Dates.FirstDateOfWeek(weekNumber));
            daysInWeek.Add(Helper.Dates.FirstDateOfWeek(weekNumber).AddDays(1));
            daysInWeek.Add(Helper.Dates.FirstDateOfWeek(weekNumber).AddDays(2));
            daysInWeek.Add(Helper.Dates.FirstDateOfWeek(weekNumber).AddDays(3));
            daysInWeek.Add(Helper.Dates.FirstDateOfWeek(weekNumber).AddDays(4));

            List<Model.Task> Schedule = new List<Model.Task>();
            foreach (DateTime date in daysInWeek)
            {
                foreach (Model.Machine machine in machines)
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        foreach (Model.TaskType taskType in taskTypes)
                        {
                            if (employees[i].WorkShift == "Day")
                            {
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Linie")
                                {
                                    if (taskType.Description == "Påfyldning")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        i++;
                                        Model.Task assign3 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        i++;
                                        Model.Task assign4 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                        Schedule.Add(assign3);
                                        Schedule.Add(assign4);
                                    }
                                }
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Kar")
                                {
                                    if (taskType.Description == "Fremstilling")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(6), date.AddHours(14), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                    }
                                }
                            }
                            if (employees[i].WorkShift == "Evening")
                            {
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Linie")
                                {
                                    if (taskType.Description == "Påfyldning")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        i++;
                                        Model.Task assign3 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        i++;
                                        Model.Task assign4 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                        Schedule.Add(assign3);
                                        Schedule.Add(assign4);
                                    }
                                }
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Kar")
                                {
                                    if (taskType.Description == "Fremstilling")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(14), date.AddHours(22), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                    }
                                }
                            }
                            if (employees[i].WorkShift == "Night")
                            {
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Linie")
                                {
                                    if (taskType.Description == "Påfyldning")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        i++;
                                        Model.Task assign3 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        i++;
                                        Model.Task assign4 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                        Schedule.Add(assign3);
                                        Schedule.Add(assign4);
                                    }
                                }
                                if (machine.Name.Substring(0, machine.Name.Length - 2) == "Kar")
                                {
                                    if (taskType.Description == "Fremstilling")
                                    {
                                        Model.Task assign1 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        i++;
                                        Model.Task assign2 = new Model.Task(machine, taskType, date.AddHours(22), date.AddHours(30), employees[i]);
                                        Schedule.Add(assign1);
                                        Schedule.Add(assign2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Database.ProductionDB.AddTask(Schedule);
            return Schedule;
        }
    }
}
