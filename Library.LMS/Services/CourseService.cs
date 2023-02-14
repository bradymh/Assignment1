using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private List<Course> courses = new List<Course>();
        
        public CourseService() { }

        public void AddCourse(Course course) 
        { 
            courses.Add(course); 
        }

        public void AddStudent(Person student, Course course)
        {
            Course course1 = course;
            course1.AddStudent(student);
        }
        //using course name
        public Course findCourse(string courseName)
        {
            Course course = new Course();

            foreach(var a in courses)
            {
                if(a.Name == courseName)
                {
                    course = a;
                    break;
                }
            }
            return course;
        }
        
        public void removeStudent(Person student,Course course)
        {
            
        }
        public List<Course> getCourseList()
        {
            return courses;
        }

    }
}
