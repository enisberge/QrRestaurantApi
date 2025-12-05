using AutoMapper;
using QRRestaurantApp.Backend.DTOs.CategoryDtos;
using QRRestaurantApp.Backend.DTOs.OptionGroupDtos;
using QRRestaurantApp.Backend.DTOs.OptionValueDtos;
using QRRestaurantApp.Backend.DTOs.ProductDtos;
using QRRestaurantApp.Backend.DTOs.ProductOptionGroupDtos;
using QRRestaurantApp.Backend.DTOs.PromotionDtos;
using QRRestaurantApp.Backend.DTOs.TableDtos;
using QRRestaurantApp.Backend.DTOs.TableSessionDtos;
using QRRestaurantApp.Backend.Entities;

namespace QRRestaurantApp.Backend.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<CreateCategoryDto, Category>().
                ForMember(c => c.ImageUrl, opt => opt.Ignore()); //Dtoda imageurl IFormFiledan geleceği için conflict olmasın diye böyle yaptık
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<CreateProductDto ,Product>().ForMember(p=>p.ImageUrl, opt => opt.Ignore());
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<CreatePromotionDto, Promotion>().
                ForMember(pm => pm.ImageUrl, opt => opt.Ignore());
            CreateMap<Promotion, ResultPromotionDto>().ReverseMap();
            CreateMap<Promotion, UpdatePromotionDto>().ReverseMap();

            CreateMap<CreateTableDto, Table>().ReverseMap();
            CreateMap<ResultTableDto, Table>().ReverseMap();
            CreateMap<UpdateTableDto, Table>().ReverseMap();

            CreateMap<CreateTableSessionLogDto, TableSessionLog>().ReverseMap();
            CreateMap<ResultTableSessionLogDto, TableSessionLog>().ReverseMap();

            CreateMap<CreateOptionGroupDto,OptionGroup>().ReverseMap();
            CreateMap<ResultOptionGroupDto, OptionGroup>().ReverseMap();
            CreateMap<UpdateOptionGroupDto, OptionGroup>().ReverseMap();

            CreateMap<CreateOptionValueDto, OptionValue>().ReverseMap();
            CreateMap<ResultOptionValueDto, OptionValue>().ReverseMap();
            CreateMap<UpdateOptionValueDto, OptionValue>().ReverseMap();

            CreateMap<CreateProductOptionGroupDto, ProductOptionGroup>().ReverseMap();
            CreateMap<ResultProductOptionGroupDto, ProductOptionGroup>().ReverseMap();

        }
    }
}
