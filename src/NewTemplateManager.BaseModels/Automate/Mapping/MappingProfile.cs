using AutoMapper;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Contracts.RequestDTO.V1.auto;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ModelType Mappings 
            //CreateMap<ModelTypeGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelTypeUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeDeleteRequestDTO, ModelType>().ReverseMap();
        
            // Model Mappings 
            //CreateMap<ModelGetRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByIdDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByGuidDTO, Model>().ReverseMap();
            //CreateMap<ModelCreateRequestDTO, Model>().ReverseMap();
            CreateMap<ModelUpdateRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelDeleteRequestDTO, Model>().ReverseMap();
        
            // Model Mappings 
            //CreateMap<ModelGetRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByIdDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByGuidDTO, Model>().ReverseMap();
            //CreateMap<ModelCreateRequestDTO, Model>().ReverseMap();
            CreateMap<ModelUpdateRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelDeleteRequestDTO, Model>().ReverseMap();
        
        }
        }
}