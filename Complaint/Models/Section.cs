﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2/20/2024 5:17:08 PM
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
    public partial class Section {

        public Section()
        {
            OnCreated();
        }

        public virtual int SectionId { get; set; }

        public virtual string SectionName { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
