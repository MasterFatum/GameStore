﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    interface IOrderProcessor
    {
        void ProcessOrder(Cart Cart, ShippingDetails shippingDetails);
    }
}
