﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 12/21/2023 4:29:00 PM
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
    public partial class VCostomer {

        public VCostomer()
        {
            OnCreated();
        }

        public virtual string CostomerId { get; set; }

        public virtual string CostomerName { get; set; }

        public virtual string ProductId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual string Telephone { get; set; }

        public virtual string Address { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
