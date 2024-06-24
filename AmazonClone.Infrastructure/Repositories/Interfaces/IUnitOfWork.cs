using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClone.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category{ get; set; }
        public IProductRepository Product { get; set; }


        void Save();
    }
}
