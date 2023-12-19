﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 12/19/2023 9:22:37 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Complaint;

namespace Complaint.Datas
{

    public partial class ComplaintModel : DbContext
    {

        public ComplaintModel() :
            base()
        {
            OnCreated();
        }

        public ComplaintModel(DbContextOptions<ComplaintModel> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(@"Data Source=IT201;Initial Catalog=Db_Complaint;Integrated Security=True;Persist Security Info=False;Password=");
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<Costomer> Costomers
        {
            get;
            set;
        }

        public virtual DbSet<Department> Departments
        {
            get;
            set;
        }

        public virtual DbSet<Employee> Employees
        {
            get;
            set;
        }

        public virtual DbSet<Form> Forms
        {
            get;
            set;
        }

        public virtual DbSet<Manager> Managers
        {
            get;
            set;
        }

        public virtual DbSet<Position> Positions
        {
            get;
            set;
        }

        public virtual DbSet<Problem> Problems
        {
            get;
            set;
        }

        public virtual DbSet<Product> Products
        {
            get;
            set;
        }

        public virtual DbSet<Section> Sections
        {
            get;
            set;
        }

        public virtual DbSet<TypeFrom> TypeFroms
        {
            get;
            set;
        }

        public virtual DbSet<VEmployee> VEmployees
        {
            get;
            set;
        }

        public virtual DbSet<VForm> VForms
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CostomerMapping(modelBuilder);
            this.CustomizeCostomerMapping(modelBuilder);

            this.DepartmentMapping(modelBuilder);
            this.CustomizeDepartmentMapping(modelBuilder);

            this.EmployeeMapping(modelBuilder);
            this.CustomizeEmployeeMapping(modelBuilder);

            this.FormMapping(modelBuilder);
            this.CustomizeFormMapping(modelBuilder);

            this.ManagerMapping(modelBuilder);
            this.CustomizeManagerMapping(modelBuilder);

            this.PositionMapping(modelBuilder);
            this.CustomizePositionMapping(modelBuilder);

            this.ProblemMapping(modelBuilder);
            this.CustomizeProblemMapping(modelBuilder);

            this.ProductMapping(modelBuilder);
            this.CustomizeProductMapping(modelBuilder);

            this.SectionMapping(modelBuilder);
            this.CustomizeSectionMapping(modelBuilder);

            this.TypeFromMapping(modelBuilder);
            this.CustomizeTypeFromMapping(modelBuilder);

            this.VEmployeeMapping(modelBuilder);
            this.CustomizeVEmployeeMapping(modelBuilder);

            this.VFormMapping(modelBuilder);
            this.CustomizeVFormMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region Costomer Mapping

        private void CostomerMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costomer>().ToTable(@"Costomer", @"dbo");
            modelBuilder.Entity<Costomer>().Property(x => x.CostomerId).HasColumnName(@"Costomer_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Costomer>().Property(x => x.CostomerName).HasColumnName(@"Costomer_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Costomer>().Property(x => x.Telephone).HasColumnName(@"Telephone").HasColumnType(@"nvarchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<Costomer>().Property(x => x.Address).HasColumnName(@"Address").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Costomer>().Property(x => x.ProductId).HasColumnName(@"Product_Id").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Costomer>().HasKey(@"CostomerId");
        }

        partial void CustomizeCostomerMapping(ModelBuilder modelBuilder);

        #endregion

        #region Department Mapping

        private void DepartmentMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable(@"Department", @"dbo");
            modelBuilder.Entity<Department>().Property(x => x.DepartmentId).HasColumnName(@"department_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Department>().Property(x => x.DepartmentName).HasColumnName(@"department_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Department>().HasKey(@"DepartmentId");
        }

        partial void CustomizeDepartmentMapping(ModelBuilder modelBuilder);

        #endregion

        #region Employee Mapping

        private void EmployeeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable(@"Employee", @"dbo");
            modelBuilder.Entity<Employee>().Property(x => x.EmpId).HasColumnName(@"Emp_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Employee>().Property(x => x.EmpName).HasColumnName(@"Emp_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.EmpDepartment).HasColumnName(@"Emp_department").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.EmpSection).HasColumnName(@"Emp_section").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.EmpPosition).HasColumnName(@"Emp_position").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Employee>().HasKey(@"EmpId");
        }

        partial void CustomizeEmployeeMapping(ModelBuilder modelBuilder);

        #endregion

        #region Form Mapping

        private void FormMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>().ToTable(@"Form", @"dbo");
            modelBuilder.Entity<Form>().Property(x => x.FromId).HasColumnName(@"From_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.FromData).HasColumnName(@"From_data").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<Form>().Property(x => x.ToId).HasColumnName(@"To_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.CCId).HasColumnName(@"CC_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.FromName).HasColumnName(@"From_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Form>().Property(x => x.CostomerId).HasColumnName(@"Costomer_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.Lot).HasColumnName(@"lot").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<Form>().Property(x => x.ProblemId).HasColumnName(@"Problem_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.Number).HasColumnName(@"number").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.Price).HasColumnName(@"Price").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.Co).HasColumnName(@"Co").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Form>().Property(x => x.TypeId).HasColumnName(@"Type_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.Image).HasColumnName(@"Image").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Form>().Property(x => x.Note).HasColumnName(@"Note").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Form>().Property(x => x.OperatorId).HasColumnName(@"Operator_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().Property(x => x.MgId).HasColumnName(@"Mg_Id").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Form>().HasKey(@"FromId");
        }

        partial void CustomizeFormMapping(ModelBuilder modelBuilder);

        #endregion

        #region Manager Mapping

        private void ManagerMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().ToTable(@"Manager", @"dbo");
            modelBuilder.Entity<Manager>().Property(x => x.MngId).HasColumnName(@"Mng_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Manager>().Property(x => x.MngName).HasColumnName(@"Mng_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Manager>().Property(x => x.MngMail).HasColumnName(@"Mng_mail").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Manager>().HasKey(@"MngId");
        }

        partial void CustomizeManagerMapping(ModelBuilder modelBuilder);

        #endregion

        #region Position Mapping

        private void PositionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().ToTable(@"Position", @"dbo");
            modelBuilder.Entity<Position>().Property(x => x.PositionId).HasColumnName(@"position_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Position>().Property(x => x.PositionName).HasColumnName(@"position_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Position>().HasKey(@"PositionId");
        }

        partial void CustomizePositionMapping(ModelBuilder modelBuilder);

        #endregion

        #region Problem Mapping

        private void ProblemMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>().ToTable(@"Problem", @"dbo");
            modelBuilder.Entity<Problem>().Property(x => x.ProblemId).HasColumnName(@"Problem_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Problem>().Property(x => x.ProblemName).HasColumnName(@"Problem_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Problem>().HasKey(@"ProblemId");
        }

        partial void CustomizeProblemMapping(ModelBuilder modelBuilder);

        #endregion

        #region Product Mapping

        private void ProductMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(@"Product", @"dbo");
            modelBuilder.Entity<Product>().Property(x => x.ProductId).HasColumnName(@"Product_Id").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName(@"Product_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<Product>().HasKey(@"ProductId");
        }

        partial void CustomizeProductMapping(ModelBuilder modelBuilder);

        #endregion

        #region Section Mapping

        private void SectionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().ToTable(@"Section", @"dbo");
            modelBuilder.Entity<Section>().Property(x => x.SectionId).HasColumnName(@"section_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Section>().Property(x => x.SectionName).HasColumnName(@"section_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<Section>().HasKey(@"SectionId");
        }

        partial void CustomizeSectionMapping(ModelBuilder modelBuilder);

        #endregion

        #region TypeFrom Mapping

        private void TypeFromMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeFrom>().ToTable(@"Type From", @"dbo");
            modelBuilder.Entity<TypeFrom>().Property(x => x.TypeId).HasColumnName(@"Type_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<TypeFrom>().Property(x => x.TypeName).HasColumnName(@"Type_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<TypeFrom>().HasKey(@"TypeId");
        }

        partial void CustomizeTypeFromMapping(ModelBuilder modelBuilder);

        #endregion

        #region VEmployee Mapping

        private void VEmployeeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VEmployee>().ToTable(@"VEmployee", @"dbo");
            modelBuilder.Entity<VEmployee>().Property(x => x.EmpId).HasColumnName(@"Emp_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<VEmployee>().Property(x => x.EmpName).HasColumnName(@"Emp_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VEmployee>().Property(x => x.PositionName).HasColumnName(@"position_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VEmployee>().Property(x => x.DepartmentName).HasColumnName(@"department_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VEmployee>().Property(x => x.SectionName).HasColumnName(@"section_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VEmployee>().HasKey(@"EmpId");
        }

        partial void CustomizeVEmployeeMapping(ModelBuilder modelBuilder);

        #endregion

        #region VForm Mapping

        private void VFormMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VForm>().ToTable(@"VForm", @"dbo");
            modelBuilder.Entity<VForm>().Property(x => x.TypeName).HasColumnName(@"Type_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.ProblemName).HasColumnName(@"Problem_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.FromId).HasColumnName(@"From_Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<VForm>().Property(x => x.FromData).HasColumnName(@"From_data").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().Property(x => x.FromName).HasColumnName(@"From_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().Property(x => x.Lot).HasColumnName(@"lot").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().Property(x => x.Number).HasColumnName(@"number").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<VForm>().Property(x => x.Price).HasColumnName(@"Price").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<VForm>().Property(x => x.EmpName).HasColumnName(@"Emp_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.PositionName).HasColumnName(@"position_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.DepartmentName).HasColumnName(@"department_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.MngName).HasColumnName(@"Mng_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().Property(x => x.Note).HasColumnName(@"Note").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().Property(x => x.Image).HasColumnName(@"Image").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.Co).HasColumnName(@"Co").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.CostomerName).HasColumnName(@"Costomer_name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<VForm>().Property(x => x.ProductName).HasColumnName(@"Product_name").HasColumnType(@"nvarchar(max)").ValueGeneratedNever();
            modelBuilder.Entity<VForm>().HasKey(@"FromId");
        }

        partial void CustomizeVFormMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
