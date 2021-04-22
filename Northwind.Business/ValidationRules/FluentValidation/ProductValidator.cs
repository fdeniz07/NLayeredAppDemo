using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        //fluent validation
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi bos olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan((0)); // ürün fiyati 0 dan büyük olmali
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short) 0); //stok miktari sifir veya daha büyük olmali
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 2); // 2.kategorideki ürünlerin fiyati 10 veya daha büyük olmali

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün adi A ile baslamali"); // Kendi kuralimizi yazmak istersek (örnegin ürün adi A ile baslamali)
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
