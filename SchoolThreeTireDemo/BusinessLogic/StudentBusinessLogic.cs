using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntites;
using DataAccess;


namespace BusinessLogic
{
    public class StudentBusinessLogic
    {
        StudentDataAccess _studentDataAccess = new StudentDataAccess();
         
        //Method for insert 
        public int StudentEntry(StudentEntites entites)
        {
            //bool status = false;
            return _studentDataAccess.StudentEntry(entites);
        }

        //Method for get all student 
        public DataTable GetAllStudent()
        {
            return _studentDataAccess.GetAllStudent();
        }

        //Method for update student 
        public void UpdateStudent(int id, StudentEntites entites)
        {
            _studentDataAccess.UpdateStudent(id, entites.FName, entites.LName, entites.Age, entites.Sex);
        }

        //Method for delete student 
        public void DeleteStudent(int id)
        {
            _studentDataAccess.DeleteStudent(id);
        }
    }
}
