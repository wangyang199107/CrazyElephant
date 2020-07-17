using CrazyElephant.Commands;
using CrazyElephant.Models;
using CrazyElephant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }

        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged("DishMenu");
            }
        }

        public MainWindowViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand();
            this.PlaceOrderCommand.ExecuteAction = new Action<object>(this.PlaceOrderCommandExecute);
            this.SelectMenuItemCommand = new DelegateCommand();
            this.SelectMenuItemCommand.ExecuteAction = new Action<object>(this.SelectMenuItemExecute);
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Crazy Adam";
            this.Restaurant.Address = "12345";
        }

        private void LoadDishMenu()
        {
            XmlDataService xmlData = new XmlDataService();
            var dishes = xmlData.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel dishMenuModel = new DishMenuItemViewModel()
                {
                    dish = dish
                };

                DishMenu.Add(dishMenuModel);
            }


        }

         private void PlaceOrderCommandExecute(object parameter)
        {
            var selectDishes = this.DishMenu.Where(p => p.IsSelected == true).Select(p => p.dish.Name).ToList();

            IOrderService orderService = new MockOrderService();

            orderService.PlaceOrder(selectDishes);

            MessageBox.Show("Order Successed");
                                 
        }

        private void SelectMenuItemExecute(object parameter)
        {
            this.Count = this.DishMenu.Count(p => p.IsSelected == true);
        }

    }
}
