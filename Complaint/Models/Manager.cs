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
    public partial class Manager {

        public Manager()
        {
            OnCreated();
        }

        public virtual int MngId { get; set; }

        public virtual string MngName { get; set; }

        public virtual string MngMail { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
