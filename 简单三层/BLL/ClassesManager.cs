using System;
using System.Collections.Generic;
using System.Linq;
using MySchoolModels;
using MySchoolDAL;

namespace MySchoolBLL
{
    public static class ClassesManager
    {
        private static ClassesService service = new ClassesService();

        //添加
        public static int Add(Classes classes)
        {
            return service.Insert(classes);
        }
        
        //查询所有
        public static List<Classes> GetAll()
        {
            return service.Select();
        }
    }
}
