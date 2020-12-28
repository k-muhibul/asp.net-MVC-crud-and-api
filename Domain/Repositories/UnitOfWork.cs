using Domain.Models;

namespace WebApplication3.Domain.Repositories
{
    public class UnitOfWork
    {
        private AppDBContext db;

        public UnitOfWork(AppDBContext db)
        {
            this.db = db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private IRepository<Student> studentRepo;
        public IRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepo == null)
                {
                    this.studentRepo = new Repository<Student>(db);
                }
                return studentRepo;
            }
        }


        private IRepository<StudentCourse> studentcourseRepo;
        public IRepository<StudentCourse> StudentCourseRepository
        {
            get
            {
                if (this.studentcourseRepo == null)
                {
                    this.studentcourseRepo = new Repository<StudentCourse>(db);
                }
                return studentcourseRepo;
            }
        }

        private IRepository<Teacher> teacherRepo;
        public IRepository<Teacher> TeacherRepository
        {
            get
            {
                if (this.teacherRepo == null)
                {
                    this.teacherRepo = new Repository<Teacher>(db);
                }
                return teacherRepo;
            }
        }


        private IRepository<Course> courseRepo;
        public IRepository<Course> CourseRepository
        {
            get
            {
                if (this.courseRepo == null)
                {
                    this.courseRepo = new Repository<Course>(db);
                }
                return courseRepo;
            }
        }
    }
}

        /// <summary>
        /// 
        /// </summary>
        

        /// <summary>
        /// Supplier
        /// </summary>
       
