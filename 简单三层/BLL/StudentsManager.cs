using System;
using System.Collections.Generic;
using System.Linq;
using MySchoolModels;
using MySchoolDAL;

namespace MySchoolBLL
{
    public static class StudentsManager
    {
        private static StudentsService service = new StudentsService();

        //添加
        public static int Add(Students students)
        {
            return service.Insert(students);
        }
        
        //查询所有
        public static List<Students> GetAll()
        {
            return service.Select();
        }
    }
}
