using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ManageStaffDB.App.Model.Data;

namespace ManageStaffDB.App.Model
{
    /// <summary>
    /// Статический класс действий с данными
    /// </summary>
    public static class DataWorker
    {
        /// <summary>
        /// Метод возврата таблицы отделов
        /// </summary> 
        /// <returns>List отделов</returns>
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }


        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Departments.Any(el => el.Name == name);
                if (!checkExist)
                {
                    Department newDepartment = new Department { Name = name };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = "Сделано.";
                }
            }
            return result;
        }
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Уже существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Positions.Any(el => el.Name == name && el.Salery == salary);
                if (!checkExist)
                {
                    Position newPosition = new Position
                    {
                        Name = name,
                        Salery = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id

                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Сделано.";
                }
            }
            return result;
        }
        public static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);
                if (!checkExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Сделано.";
                }
            }
            return result;
        }

        public static string DeleteDepartment(Department department)
        {
            string result = "Отдела не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                result = $"Отдел {department.Name} удален";
            }
            return result;
        }
        public static string DeletePosition(Position position)
        {
            string result = "Позиции не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = $"Позиция {position.Name} удалена";
            }
            return result;
        }

        public static string DeleteUser(User user)
        {
            string result = "Сотрудник не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = $"Сотрудник {user.Name} {user.SurName} уволен";
            }
            return result;
        }

        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Отдел не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                result = $"Сделано! Отдел {department.Name} изменен.";
            }
            return result;
        }

        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Позиции не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);

                position.Name = newName;
                position.MaxNumber = newMaxNumber;
                position.Salery = newSalary;
                position.DepartmentId = newDepartment.Id;
                db.SaveChanges();
                result = $"Позиция {position.Name} изменина.";
            }
            return result;
        }

        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Сотрудник не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == oldUser.Id);
                if (user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    db.SaveChanges();
                    result = $"Сотрудник {user.Name} {user.SurName} изменен.";
                }

            }
            return result;
        }

        public static Position GetPositionById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        public static Department GetDepartmentById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department dep = db.Departments.FirstOrDefault(p => p.Id == id);
                return dep;
            }
        }

        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
                return users;
            }
        }
        public static List<Position> GetAllPositionsByDepartmentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
                return positions;
            }
        }
    }
}
