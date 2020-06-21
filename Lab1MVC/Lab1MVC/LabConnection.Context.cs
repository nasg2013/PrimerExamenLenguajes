﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab1MVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IF4101_A95777_2020Entities : DbContext
    {
        public IF4101_A95777_2020Entities()
            : base("name=IF4101_A95777_2020Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Student> Student { get; set; }
    
        public virtual int DeleteStudent(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudent", studentIdParameter);
        }
    
        public virtual int InsertUpdateStudent(Nullable<int> studentId, string name, Nullable<int> age, Nullable<int> nationality, Nullable<int> major, string action)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var nationalityParameter = nationality.HasValue ?
                new ObjectParameter("Nationality", nationality) :
                new ObjectParameter("Nationality", typeof(int));
    
            var majorParameter = major.HasValue ?
                new ObjectParameter("Major", major) :
                new ObjectParameter("Major", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdateStudent", studentIdParameter, nameParameter, ageParameter, nationalityParameter, majorParameter, actionParameter);
        }
    
        public virtual ObjectResult<SelectMajor_Result> SelectMajor()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectMajor_Result>("SelectMajor");
        }
    
        public virtual ObjectResult<SelectNationality_Result> SelectNationality()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectNationality_Result>("SelectNationality");
        }
    
        public virtual int SpDeleteStudent(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpDeleteStudent", studentIdParameter);
        }
    
        public virtual int SpInsertUpdateStudent(Nullable<int> studentId, string name, Nullable<int> age, Nullable<int> nationality, Nullable<int> major, string action)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var nationalityParameter = nationality.HasValue ?
                new ObjectParameter("Nationality", nationality) :
                new ObjectParameter("Nationality", typeof(int));
    
            var majorParameter = major.HasValue ?
                new ObjectParameter("Major", major) :
                new ObjectParameter("Major", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpInsertUpdateStudent", studentIdParameter, nameParameter, ageParameter, nationalityParameter, majorParameter, actionParameter);
        }
    
        public virtual ObjectResult<SelectStudent_Result> SelectStudent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStudent_Result>("SelectStudent");
        }
    
        public virtual ObjectResult<SelectStudentById_Result> SelectStudentById(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStudentById_Result>("SelectStudentById", studentIdParameter);
        }
    
        public virtual ObjectResult<SelectStudentByName_Result> SelectStudentByName(string studentName)
        {
            var studentNameParameter = studentName != null ?
                new ObjectParameter("StudentName", studentName) :
                new ObjectParameter("StudentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStudentByName_Result>("SelectStudentByName", studentNameParameter);
        }
    }
}
