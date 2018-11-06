using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue.DataLayer;

namespace Vue.BussinessLayer.Services
{
    public class ProductService : BaseService<Product>
    {
        private ProductService() { }

        private static ProductService Instance;

        private static object LockObj = new object();


        public static ProductService GetInstance
        {

            get
            {
                if (Instance == null)
                {
                    lock (LockObj)
                    {
                        if (Instance == null)
                        {
                            Instance = new ProductService();
                        }
                    }
                }
                return Instance;
            }


        }


        public void decrease(int id)
        {
            Product p = GetById(id);
            if (p.UnitsInStock != 0)
            {
                p.UnitsInStock--;
                Save();
            }

        }


        public void increase(int id)
        {
            Product p = GetById(id);
            p.UnitsInStock++;
            Save();
        }

        

    }
}
