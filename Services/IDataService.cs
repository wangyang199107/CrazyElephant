﻿using CrazyElephant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Services
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
