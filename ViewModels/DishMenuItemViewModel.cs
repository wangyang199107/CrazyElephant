﻿using CrazyElephant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.ViewModels
{
    class DishMenuItemViewModel :NotificationObject
    {
        public Dish dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");    
        }
        }




    }
}
