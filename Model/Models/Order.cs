﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Model.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; }

    public int CusId { get; set; }

    public string DeliveryAddress { get; set; }

    public string ContactNumber { get; set; }

    public int? ShippingMethodId { get; set; }

    public virtual Customer Cus { get; set; }

    public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ShippingMethod ShippingMethod { get; set; }

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}