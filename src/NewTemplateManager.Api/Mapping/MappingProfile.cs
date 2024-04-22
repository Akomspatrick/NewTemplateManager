using AutoMapper;

using NewTemplateManager.Contracts.RequestDTO;
using NewTemplateManager.Contracts.ResponseDTO;


namespace NewTemplateManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<SampleModelGetRequestDTO, ApplicationSampleModelCreateRequestDTO>().ReverseMap();
           // CreateMap<SampleModelCreateRequestDTO, ApplicationSampleModelCreateRequestDTO>().ReverseMap();
           // CreateMap<SampleModelUpdateRequestDTO, ApplicationSampleModelUpdateRequestDTO>().ReverseMap();
           // CreateMap<SampleModelDeleteRequestDTO, ApplicationSampleModelDeleteRequestDTO>().ReverseMap();
           // CreateMap<SampleModelGetRequestByGuidDTO, ApplicationSampleModelGetRequestByGuidDTO>().ReverseMap();
           ////==6 CreateMap<SampleModelGetRequestByIdDTO, ApplicationSampleModelGetRequestByIdDTO>().ReverseMap();
           // CreateMap<SampleModelResponseDTO, ApplicationSampleModelResponseDTO>().ReverseMap();
           // CreateMap<ModelResponseDTO, ModelResponseDTO>().ReverseMap();









            //CreateMap<Persistence.Repositories.Models.SampleModel, Domain.ModelAggregateRoot.Entities.SampleModel>();//.ReverseMap();
            //CreateMap< Domain.ModelAggregateRoot.Entities.SampleModel, Persistence.Repositories.Models.SampleModel>();
            ////CreateMap<Domain.ModelAggregateRoot.Entities.SampleModels, Domain.ModelAggregateRoot.Entities.SampleModels>().ReverseMap();


            //CreateMap<Persistence.Repositories.Models.Model, Domain.ModelAggregateRoot.Entities.Model>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacityDocument, Domain.ModelAggregateRoot.Entities.CapacityDocument>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacitySpecification, Domain.ModelAggregateRoot.Entities.CapacitySpecification>().ReverseMap();
        }
    }
}
