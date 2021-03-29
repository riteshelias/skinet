using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification(ProductSpecParams prodParams) : 
            base( x =>
                    (string.IsNullOrEmpty(prodParams.Search) || x.Name.ToLower().Contains(prodParams.Search)) &&
                    (!prodParams.BrandId.HasValue || x.ProductBrandId == prodParams.BrandId) &&
                    (!prodParams.TypeId.HasValue || x.ProductTypeId == prodParams.TypeId)
                )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(prodParams.PageSize * (prodParams.PageIndex - 1), prodParams.PageSize);

            if (!string.IsNullOrEmpty(prodParams.Sort))
            {
                switch (prodParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}