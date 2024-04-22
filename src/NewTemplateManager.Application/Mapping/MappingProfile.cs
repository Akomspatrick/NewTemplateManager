using AutoMapper;
using NewTemplateManager.Contracts.RequestDTO.V1;
using NewTemplateManager.Domain.Entities;
namespace NewTemplateManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model Mappings 
            //CreateMap<ModelGetRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByIdDTO, Model>().ReverseMap();
            //CreateMap<ModelGetRequestByGuidDTO, Model>().ReverseMap();
            //CreateMap<ModelCreateRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelUpdateRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelDeleteRequestDTO, Model>().ReverseMap();

            // SampleModel Mappings 
            //CreateMap<SampleModelGetRequestDTO, SampleModel>().ReverseMap();
            //CreateMap<SampleModelGetRequestByIdDTO, SampleModel>().ReverseMap();
            //CreateMap<SampleModelGetRequestByGuidDTO, SampleModel>().ReverseMap();
            //CreateMap<SampleModelCreateRequestDTO, SampleModel>().ReverseMap();
            CreateMap<SampleModelUpdateRequestDTO, SampleModel>().ReverseMap();
            //CreateMap<SampleModelDeleteRequestDTO, SampleModel>().ReverseMap();


        }
    }
}