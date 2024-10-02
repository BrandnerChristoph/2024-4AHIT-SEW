﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public override string ToString()
        {
            return $"Product [ID={Id}, ProductName={ProductName}]";
        }
    }
}