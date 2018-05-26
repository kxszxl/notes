using System;

namespace MySchoolModels
{
    [Serializable]
    public class Students
    {
        public int Id
        {get;set;}
        
        public string Name
        {get;set;}
        
        public int ClassId
        {get;set;}
        
    }
}