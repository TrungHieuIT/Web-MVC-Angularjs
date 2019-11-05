using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using System.Collections.Generic;
using WebDemo.Models;

namespace WebDemo.Service
{
    public interface IProductTestService
    {
        Product Add(Product product);

        void Update(Product product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        void Save();
    }

    public class ProductTestService : IProductTestService
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;

        public ProductTestService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            var pro = _productRepository.Add(product);
            _unitOfWork.Commit();
            return pro;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}