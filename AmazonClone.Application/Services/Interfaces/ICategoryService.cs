using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace AmazonClone.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(Category Category);


        IEnumerable<Category> GetAll();
        Category Get(Expression<Func<Category, bool>> filter);
        public IEnumerable<SelectListItem> GetCategoriesAsListItems();
        /// <returns>Returns the top 4 popular categories, "Popular": The categories with most assigned products</returns>
        public IEnumerable<CustomerHomeCategoryViewModel> GetMostPopular();


        void Update(Category Category);


        void Remove(Category Category);

    }
}
