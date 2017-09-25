using AgileHW.Business.Managers;
using Common.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgileHW.UI.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        private List<ProductDTO> _products;
        private ProductManager _ProductManager;
        public MainViewModel()
        {

        }
        public ProductDTO newProduct;
        public List<ProductDTO> Products
        {
            get { return _products; }
            set
            {
                if (_products != null)
                {
                    _products = value;
                }
            }
        }
        public ICommand SaveCommand => new RelayCommand(SaveButtonClick);
        private void SaveButtonClick()
        {
            _ProductManager.Add(newProduct);
        }
    }
}
