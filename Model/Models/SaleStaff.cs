﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class SaleStaff
{
    public int SStaffId { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public int? ManagerId { get; set; }

    public virtual Manager Manager { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual User SStaff { get; set; }

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}