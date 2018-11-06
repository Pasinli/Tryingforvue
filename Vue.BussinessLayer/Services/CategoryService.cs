using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vue.DataLayer;

namespace Vue.BussinessLayer.Services
{
   public class CategoryService:BaseService<Category>
    {
        private CategoryService() { }

        private static CategoryService Instance;

        private static object LockObj = new object();


        public static CategoryService GetInstance
        {

            get
            {
                if (Instance == null)
                {
                    lock (LockObj)
                    {
                        if (Instance == null)
                        {
                            Instance = new CategoryService();
                        }
                    }
                }
                return Instance;
            }


        }

    }
}
