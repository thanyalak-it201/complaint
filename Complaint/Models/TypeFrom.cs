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
    public partial class TypeFrom {

        public TypeFrom()
        {
            this.Forms = new List<Form>();
            OnCreated();
        }

        public virtual string TypeId { get; set; }

        public virtual string TypeName { get; set; }

        public virtual IList<Form> Forms { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
