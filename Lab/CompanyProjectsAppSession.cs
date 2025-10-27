using MyFunctions;
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

            int i = InputInt("Project board number: ", InputType.With, 1, company.ProjectBoards.Count);
            ProjectBoard? projectBoard = company.ProjectBoards[i - 1];
            if (projectBoard == null) throw new Exception("Project board not found");

            BoardInteractionMenu(projectBoard);
        }

        public void InteractWithTask(ProjectBoard projectBoard, Task task)
        {
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
            if (projectBoard.Tasks.Count == 0) throw new Exception("No tasks found");

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

                //Selecting column than task
                List<Task> column = new List<Task>();
                
                int col = Menu.DisplayMenu("Select column: ", new string[] { "ToDo", "In Progress", "In Review", "Done", "(Exit), None" }, false, true, false);
                switch (col)
                {
                    case 1:
                        column = ToDoTasks;
                        break;
                    case 2:
                        column = InReviewTasks;
                        break;
                    case 3:
                        column = DoneTasks;
                        break;
                    case 4:
                        column = InReviewTasks;
                        break;
                    case 5:
                        return;
                    case -1:
                        return;
                }

                if (column.Count == 0) throw new Exception("No tasks found");
                int j = InputInt("Task number: ", InputType.With, 1, column.Count);
                Task? task = column[j - 1];
                if (task == null) throw new Exception("Task not found");
                
                InteractWithTask(projectBoard, task);
            }
        }

        public void PrintTasksColumn(List<Task> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine(i + ". "+ tasks[i]);
            }
        }

        public void AddTask(ProjectBoard projectBoard)
        {
            string name = InputString("Task name: ");
            Task task = projectBoard.AddTask(userSessionUser, name);

            if (MessageBox.Show("Do you want assign task to Employee", "Question", MessageBox.Buttons.YesNo) == MessageBox.Button.Yes)
            {
                AssignTask(projectBoard, task);
            }
        }

        public void RemoveTask(ProjectBoard projectBoard)
        {
            ViewTasks(projectBoard);
            int i = InputInt("Task number: ", InputType.With, 1, projectBoard.Tasks.Count);
            Task? task = projectBoard.Tasks[i - 1];
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
            int i = InputInt("Employee number: ", InputType.With, 1, company.Employees.Count);
            IUserInfo? employee = company.Employees[i - 1];
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
            if (company.ProjectBoards.Count == 0) throw new Exception("No project boards");
            Console.WriteLine("Project boards: ");
            for (int i = 0; i < company.ProjectBoards.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + company.ProjectBoards[i].Name);
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

            int i = InputInt("Project board number: ", InputType.With, 1, company.ProjectBoards.Count);
            ProjectBoard? projectBoard = company.ProjectBoards[i - 1];
            if (projectBoard == null) throw new Exception("Project board not found");
            company.RemoveProjectBoard(userSessionUser, projectBoard);
            Console.WriteLine("Project board removed");
        }

        public void ViewEmployees()
        {
            if (company.Employees.Count == 0) throw new Exception("No employees");
            Console.WriteLine("Employees: ");
            for (int i = 0; i < company.Employees.Count; i++) { 
                Console.WriteLine( (i + 1) + ". " + company.Employees[i].Name + " - " + company.Employees[i].GetType().Name);
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

            int j = InputInt("Employee number: ", InputType.With, 1, company.Employees.Count);
            IUserInfo? employee = company.Employees[j - 1];
            if (employee == null) throw new Exception("Employee not found");
            company.RemoveEmployee(userSessionUser, employee);

            Console.WriteLine("Employee removed");
        }

        public void ChangeUser()
        {
            ViewEmployees();

            int i = InputInt("Employee number: ", InputType.With, 1, company.Employees.Count);
            IUserInfo? user = company.Employees[i - 1];
            if (user == null) throw new Exception("User not found");
            userSessionUser = user;
        }
    }
}
