﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaPharm.OrderManagement.Domain.Entities
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
    }
}
