﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 12/22/2023 1:29:49 PM
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

namespace Complain.Models
{
    public partial class VForm {

        public VForm()
        {
            OnCreated();
        }

        public virtual int FromId { get; set; }

        public virtual DateTime? FromData { get; set; }

        public virtual string FromName { get; set; }

        public virtual string CostomerId { get; set; }

        public virtual string CostomerName { get; set; }

        public virtual string ProductId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual DateTime? Lot { get; set; }

        public virtual string ProblemId { get; set; }

        public virtual string ProblemName { get; set; }

        public virtual int? Number { get; set; }

        public virtual int? Price { get; set; }

        public virtual string Co { get; set; }

        public virtual int TypeId { get; set; }

        public virtual string TypeName { get; set; }

        public virtual string Image { get; set; }

        public virtual string Note { get; set; }

        public virtual string EmpId { get; set; }

        public virtual string EmpName { get; set; }

        public virtual int DepartmentId { get; set; }

        public virtual string DepartmentName { get; set; }

        public virtual int SectionId { get; set; }

        public virtual string SectionName { get; set; }

        public virtual int PositionId { get; set; }

        public virtual string PositionName { get; set; }

        public virtual int MngId { get; set; }

        public virtual string MngName { get; set; }

        public virtual string MngMail { get; set; }

        public virtual string Expr1 { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
