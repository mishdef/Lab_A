using MyFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyFunctions.Tools;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class CompanyProjectsAppSession
    {
        public Company company;
        public IUserInfo userSessionUser;

        public CompanyProjectsAppSession(Company company, IUserInfo userSessionUser)
        {
            this.company = company;
            this.userSessionUser = userSessionUser;
        }

        public void DisplayMenu()
        {
            bool exit = false;
            do
            {
                try
                {
                    Tools.DrawLine(50);
                    Console.WriteLine($"Company name: {company.Name}");
                    Console.WriteLine($"Logged in as: {userSessionUser.Name} - {userSessionUser.GetType().Name}");
                    Tools.DrawLine(50);
                    switch (Menu.DisplayMenu("     Company Menu     ", new string[] {
                        "View Project Boards",
                        "Create Project Board",
                        "Open Project Board",
                        "View Employees",
                        "Add Employee",
                        "Remove Employee",
                        "Remove Project Board",
                        "Change User",
                        "Exit" }, false, true))
                    {
                        case 1:
                            Tools.DrawLine(50);
                            ViewProjectBoards();
                            Tools.DrawLine(50);
                            break;
                        case 2:
                            Tools.DrawLine(50);
                            CreateProjectBoard();
                            Tools.DrawLine(50);
                            break;
                        case 3:
                            Tools.DrawLine(50);
                            OpenProjectBoard();
                            Tools.DrawLine(50);
                            break;
                        case 4:
                            Tools.DrawLine(50);
                            ViewEmployees();
                            Tools.DrawLine(50);
                            break;
                        case 5:
                            Tools.DrawLine(50);
                            AddEmployee();
                            Tools.DrawLine(50);
                            break;
                        case 6:
                            Tools.DrawLine(50);
                            RemoveEmployee();
                            Tools.DrawLine(50);
                            break;
                        case 7:
                            Tools.DrawLine(50);
                            RemoveProjectBoard();
                            Tools.DrawLine(50);
                            break;
                        case 8:
                            Tools.DrawLine(50);
                            ChangeUser();
                            Tools.DrawLine(50);
                            break;
                        case 9:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!exit);
        }

        public void BoardInteractionMenu(ProjectBoard projectBoard)
        {
            bool exit = false;
            do
            {
                try
                {
                    Console.WriteLine($"Project: {projectBoard.Name}");
                    switch (Menu.DisplayMenu("     Project Board Menu     ", new string[]
                    {
                    "View Tasks",
                    "Add Task",
                    "Remove Task",
                    "Exit"
                    }, false, true))
                    {
                        case 1:
                            ViewTasks(projectBoard);
                            InteractWithTask(projectBoard);
                            break;
                        case 2:
                            Tools.DrawLine(50);
                            AddTask(projectBoard);
                            Tools.DrawLine(50);
                            break;
                        case 3:
                            Tools.DrawLine(50);
                            RemoveTask(projectBoard);
                            Tools.DrawLine(50);
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                }catch (Exception ex) { Console.WriteLine(ex.Message);
                }
            } while (!exit);
        }

        public void OpenProjectBoard()
        {
            ViewProjectBoards();
            string name = InputString("Project board name: ");
            ProjectBoard? projectBoard = company.ProjectBoards.Find(x => x.Name == name);
            if (projectBoard == null) throw new Exception("Project board not found");

            BoardInteractionMenu(projectBoard);
        }

        public void InteractWithTask(ProjectBoard projectBoard)
        {
            string name = InputString("Task to interact with: ");
            Task? task = projectBoard.Tasks.Find(x => x.Name == name);
            if (task == null) throw new Exception("Task not found");

            bool exit = false;

            do
            {
                try
                {
                    switch (Menu.DisplayMenu("     Task Menu     ", new string[] {
                        "View Task",
                        "Assign Task",
                        "Change Task",
                        "Change Status",
                        "Exit"
                    }, false, true))
                    {
                        case 1:
                            Tools.DrawLine(50);
                            ViewTask(task);
                            Tools.DrawLine(50);
                            break;
                        case 2:
                            Tools.DrawLine(50);
                            AssignTask(projectBoard, task);
                            Tools.DrawLine(50);
                            break;
                        case 3:
                            Tools.DrawLine(50);
                            ChangeTask(projectBoard, task);
                            Tools.DrawLine(50);
                            break;
                        case 4:
                            Tools.DrawLine(50);
                            ChangeTaskStatus(projectBoard, task);
                            Tools.DrawLine(50);
                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.ToString()); }
            } while (!exit);
        }

        public void ViewTasks(ProjectBoard projectBoard)
        {
            List<Task> ToDoTasks = projectBoard.Tasks.FindAll(x => x.CurrentStatus == TaskStat.ToDo);
            List<Task> InProgressTasks = projectBoard.Tasks.FindAll(x => x.CurrentStatus == TaskStat.InProgress);
            List<Task> InReviewTasks = projectBoard.Tasks.FindAll(x => x.CurrentStatus == TaskStat.InReview);
            List<Task> DoneTasks = projectBoard.Tasks.FindAll(x => x.CurrentStatus == TaskStat.Done);

            int maxRows = Math.Max(ToDoTasks.Count, Math.Max(InProgressTasks.Count, Math.Max(InReviewTasks.Count, DoneTasks.Count)));
            DrawLine(104);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("        ToDo             |     In Progress         |      In Review          |        Done             ");
            Console.ResetColor();
            DrawLine(104);

            int Width = 20;

            for (int i = 0; i < maxRows; i++)
            {
                if (i < ToDoTasks.Count)
                {
                    Console.Write($" {i + 1}. {ToDoTasks[i].Name,-20} |");
                }
                else
                {
                    Console.Write($" {"",-(20+ 3)} |");
                }

                if (i < InProgressTasks.Count)
                {
                    Console.Write($" {i + 1}. {InProgressTasks[i].Name,-20} ");
                }
                else
                {
                    Console.Write($" {"",-(20+ 3)} |");
                }

                if (i < InReviewTasks.Count)
                {
                    Console.Write($" {i + 1}. {InReviewTasks[i].Name,-20} |");
                }
                else
                {
                    Console.Write($" {"",-(20+ 3)} |");
                }

                if (i < DoneTasks.Count)
                {
                    Console.Write($" {i + 1}. {DoneTasks[i].Name,-20} |");
                }
                else
                {
                    Console.Write($" {"",-(20+ 3)} ");
                }

                Console.WriteLine();

                Width = 10;

    
                if (i < ToDoTasks.Count && ToDoTasks[i].Assignee != null)
                {
                    Console.Write($" Assigned to: {ToDoTasks[i].Assignee.Name,-10} |");
                }
                else
                { 
                    Console.Write($" {"",-(20 + 3)} |");
                }

                if (i < InProgressTasks.Count && InProgressTasks[i].Assignee != null)
                {
                    Console.Write($" Assigned to: {InProgressTasks[i].Assignee.Name,-10} |");
                }
                else
                {
                    Console.Write($" {"",-(20 + 3)} |");
                }

                if (i < InReviewTasks.Count && InReviewTasks[i].Assignee != null)
                {
                    Console.Write($" Assigned to: {InReviewTasks[i].Assignee.Name,-10} |");
                }
                else
                {
                    Console.Write($" {"",-(20 + 3)} |");
                }

                if (i < DoneTasks.Count && DoneTasks[i].Assignee != null)
                {
                    Console.Write($" Assigned to: {DoneTasks[i].Assignee.Name,-10} |");
                }
                else
                {
                    Console.Write($" {"",-(20 + 3)} ");
                }

                Console.WriteLine();
                DrawLine(104);


            }
        }

        public void AddTask(ProjectBoard projectBoard)
        {
            string name = InputString("Task name: ");
            Task task = new Task(name);
            projectBoard.AddTask(userSessionUser, task);

            if (MessageBox.Show("Do you want assign task to Employee", "Question", MessageBox.Buttons.YesNo) == MessageBox.Button.Yes)
            {
                AssignTask(projectBoard, task);
            }
        }

        public void RemoveTask(ProjectBoard projectBoard)
        {
            string name = InputString("Task name: ");
            Task? task = projectBoard.Tasks.Find(x => x.Name == name);
            if (task == null) throw new Exception("Task not found");
            projectBoard.RemoveTask(userSessionUser, task);
        }

        public void ViewTask(Task task)
        {
            Console.WriteLine(task.GetInfo());
        }

        public void AssignTask(ProjectBoard projectBoard, Task task)
        {
            ViewEmployees();
            string name = InputString("Employee name: ");
            IUserInfo? employee = company.Employees.Find(x => x.Name == name);
            if (employee == null) throw new Exception("Employee not found");
            task.AssignEmployee(userSessionUser, employee);
        }

        public void ChangeTask(ProjectBoard projectBoard, Task task)
        {
            string name = InputString("Task name: ");
            task.ChangeName(userSessionUser, name);
        }

        public void ChangeTaskStatus(ProjectBoard projectBoard, Task task)
        {
            int status = InputInt("1 - To do, 2 - In progress, 3 - In review, 4 - Done \nTask status: ", InputType.With, 1, 4);
            task.MoveTask(userSessionUser, (TaskStat)status);
        }

        public void ViewProjectBoards()
        {
            Console.WriteLine("Project boards: ");
            foreach (var projectBoard in company.ProjectBoards)
            {
                Console.WriteLine(projectBoard.Name);
            }
        }

        public void CreateProjectBoard()
        {
            string name = InputString("Project board name: ");
            company.CreateProjectBoard(userSessionUser, name);
            Console.WriteLine("Project board created");
        }

        public void RemoveProjectBoard()
        {
            ViewProjectBoards();

            string name = InputString("Project board name: ");
            ProjectBoard? projectBoard = company.ProjectBoards.Find(x => x.Name == name);
            if (projectBoard == null) throw new Exception("Project board not found");
            company.RemoveProjectBoard(userSessionUser, projectBoard);
            Console.WriteLine("Project board removed");
        }

        public void ViewEmployees()
        {
            Console.WriteLine("Employees: ");
            foreach (var employee in company.Employees)
            {
                Console.WriteLine(employee.Name + " - " + employee.GetType().Name);
            }
        }

        public void AddEmployee()
        {
            string name = InputString("Employee name: ");
            int status = InputInt("1 - Employee, 2 - Project Manager, 3 - CEO \nEmployee status: ", InputType.With, 1, 3);

            switch (status)
            {
                case 1:
                    company.AddEmployee(userSessionUser, new Employee(name));
                    break;
                case 2:
                    company.AddEmployee(userSessionUser, new ProjectManager(name));
                    break;
                case 3:
                    company.AddEmployee(userSessionUser, new CEO(name));
                    break;
            }
            Console.WriteLine("Employee added");
        }

        public void RemoveEmployee()
        {
            for (int i = 0; i < company.Employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {company.Employees[i].Name}");
            }
            string name = InputString("Employee name: ");
            IUserInfo? employee = company.Employees.Find(x => x.Name == name);
            if (employee == null) throw new Exception("Employee not found");
            company.RemoveEmployee(userSessionUser, employee);

            Console.WriteLine("Employee removed");
        }

        public void ChangeUser()
        {
            ViewEmployees();

            string name = InputString("User name: ");
            IUserInfo? user = company.Employees.Find(x => x.Name == name);
            if (user == null) throw new Exception("User not found");
            userSessionUser = user;
        }
    }
}
