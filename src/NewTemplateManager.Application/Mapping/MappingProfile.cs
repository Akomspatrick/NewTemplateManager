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
            //CreateMap<ModelGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelDeleteRequestDTO, ModelType>().ReverseMap();

            // ModelType Mappings 
            //CreateMap<ModelTypeGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelTypeUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeDeleteRequestDTO, ModelType>().ReverseMap();

            // ModelVersion Mappings 
            //CreateMap<ModelVersionGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelVersionUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionDeleteRequestDTO, ModelType>().ReverseMap();

            // ModelVersionDocument Mappings 
            //CreateMap<ModelVersionDocumentGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionDocumentGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionDocumentGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionDocumentCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelVersionDocumentUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelVersionDocumentDeleteRequestDTO, ModelType>().ReverseMap();

            // ShellMaterial Mappings 
            //CreateMap<ShellMaterialGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ShellMaterialGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ShellMaterialGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ShellMaterialCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ShellMaterialUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ShellMaterialDeleteRequestDTO, ModelType>().ReverseMap();

            // TestingModeGroup Mappings 
            //CreateMap<TestingModeGroupGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestingModeGroupGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<TestingModeGroupGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<TestingModeGroupCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<TestingModeGroupUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestingModeGroupDeleteRequestDTO, ModelType>().ReverseMap();

            // TestPoint Mappings 
            //CreateMap<TestPointGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<TestPointUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointDeleteRequestDTO, ModelType>().ReverseMap();

            // TestPoint Mappings 
            //CreateMap<TestPointGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<TestPointUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<TestPointDeleteRequestDTO, ModelType>().ReverseMap();

        }
    }
}