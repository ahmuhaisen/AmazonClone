using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace AmazonClone.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public void Create(Category Category)
        {
            _unitOfWork.Category.Create(Category);
            _unitOfWork.Save();
        }



        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _unitOfWork.Category.Get(filter);
        }
        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }
        public IEnumerable<SelectListItem> GetCategoriesAsListItems()
        {
            return _unitOfWork.Category
                .GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .OrderBy(s => s.Text)
                .ToList();
        }
        public IEnumerable<CustomerHomeCategoryViewModel> GetMostPopular()
        {
            return _unitOfWork.Category.GetMostPopular()
                                       .Select(x => new CustomerHomeCategoryViewModel { Id = x.Id, Name = x.Name, IconString = x.IconString })
                                       .ToList();
        }



        public void Remove(Category Category)
        {
            _unitOfWork.Category.Remove(Category);
            _unitOfWork.Save();
        }



        public void Update(Category Category)
        {
            _unitOfWork.Category.Update(Category);
            _unitOfWork.Save();
        }

    }
}
