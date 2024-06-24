using AmazonClone.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace AmazonClone.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category Get(Expression<Func<Category, bool>> filter);

        void Create(Category Category);
        void Update(Category Category);
        void Remove(Category Category);

        public IEnumerable<SelectListItem> GetCategoriesListItems();
    }
}
