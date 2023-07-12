using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.MerchantProducts.Commands.CreateMerchantProduct;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetAllMerchantProducts;
using CleanArchitecture.Core.Features.Merchants.Command.CreateMerchant;
using CleanArchitecture.Core.Features.Merchants.Queries.GetAllMerchant;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;

namespace CleanArchitecture.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Merchant, GetAllMerchantViewModel>().ReverseMap();
            CreateMap<CreateMerchantCommand, Merchant>();
            CreateMap<GetAllMerchantQuery, GetAllMerchantParameter>();

            CreateMap<MerchantProduct, GetAllMerchantProductViewModel>().ReverseMap();
            CreateMap<CreateMerchantProductCommand, MerchantProduct>();
            CreateMap<GetAllMerchantProductQuery, GetAllMerchantProductParameter>();
        }
    }
}
