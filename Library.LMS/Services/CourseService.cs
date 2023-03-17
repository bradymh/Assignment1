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
            course.Roster.Add(student);
        }

        public void AddModule(Module module, Course course)
        {
            course.Modules.Add(module);
        }
        //using course name
        public Course findCourse(string courseName)
        {
            Course course = new Course();

            foreach(var a in courses)
            {
                if(a.Name == courseName || a.Description == courseName)
                {
                    course = a;
                    break;
                }
            }
            return course;
        }
        
        public void removeStudent(Person student,Course course)
        {
            int index = 0;
            for (int i = 0; i < course.Roster.Count;i++)
            {
                if(course.Roster.ElementAt(i) == student)
                {
                    index = i;
                }
            }
            course.Roster.RemoveAt(index);
        }

        public List<Course> getCourseList()
        {
            return courses;
        }

        public void AddAssignment(Course course,Assignment assignment)
        {
            course.Assignments.Add(assignment);
        }

        public void AddAnnouncment(Course course, string announcment)
        {
            course.Announcments.Add(announcment);
        }
    }
}
