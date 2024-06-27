using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Infrastructure.Utils;


namespace AmazonClone.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // Create
        public void Create(Product Product)
        {
            _unitOfWork.Product.Create(Product);
            _unitOfWork.Save();
        }


        
        //Read
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _unitOfWork.Product.Get(filter);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Product.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            var result = _unitOfWork.Product.GetAllByCategoryID(categoryId);
            return result;
        }

        public IEnumerable<CustomerHomeProductViewModel> GetHomeProductsList(int? categoryId = null)
        {
            if (categoryId is null or 0)
                return GetAll().Select(x => ConvertProductToViewModel(x)).ToList();


            return GetAllByCategoryId((int)categoryId).Select(x => ConvertProductToViewModel(x)).ToList();
        }



        //Update
        public void Update(Product Product)
        {
            _unitOfWork.Product.Update(Product);
            _unitOfWork.Save();
        }

        public string UpsertProductImage(string ImageUrl, IFormFile? file, string wwwRootPath)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Combine(wwwRootPath, FileSettings.ProductsImagesPath);

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                // Delete the old image
                string oldImagePath =
                    Path.Combine(wwwRootPath, ImageUrl.TrimStart('\\'));


                if (File.Exists(oldImagePath))
                    File.Delete(oldImagePath);
            }

            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return @$"\{FileSettings.ProductsImagesPath}\{fileName}";
        }



        //Delete
        public void Remove(Product Product)
        {
            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();
        }

       

        //Misc.
        public CustomerHomeProductViewModel ConvertProductToViewModel(Product product) => new()
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name.Length >= 25 ? $"{product.Name.Substring(0, 25)}.." : product.Name,
                CategoryName = product.Category.Name.ToUpper(),
                DiscountPercentage = product.DiscountPercentage,
                Price = product.Price,
            };
    }
}
