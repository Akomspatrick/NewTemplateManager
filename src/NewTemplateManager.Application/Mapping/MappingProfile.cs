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
            CreateMap<ModelUpdateRequestDTO, Model>().ReverseMap();
            //CreateMap<ModelDeleteRequestDTO, Model>().ReverseMap();

            // ModelType Mappings 
            //CreateMap<ModelTypeGetRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByIdDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeGetRequestByGuidDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeCreateRequestDTO, ModelType>().ReverseMap();
            CreateMap<ModelTypeUpdateRequestDTO, ModelType>().ReverseMap();
            //CreateMap<ModelTypeDeleteRequestDTO, ModelType>().ReverseMap();

            // ModelVersion Mappings 
            //CreateMap<ModelVersionGetRequestDTO, ModelVersion>().ReverseMap();
            //CreateMap<ModelVersionGetRequestByIdDTO, ModelVersion>().ReverseMap();
            //CreateMap<ModelVersionGetRequestByGuidDTO, ModelVersion>().ReverseMap();
            //CreateMap<ModelVersionCreateRequestDTO, ModelVersion>().ReverseMap();
            CreateMap<ModelVersionUpdateRequestDTO, ModelVersion>().ReverseMap();
            //CreateMap<ModelVersionDeleteRequestDTO, ModelVersion>().ReverseMap();

            // ModelVersionDocument Mappings 
            //CreateMap<ModelVersionDocumentGetRequestDTO, ModelVersionDocument>().ReverseMap();
            //CreateMap<ModelVersionDocumentGetRequestByIdDTO, ModelVersionDocument>().ReverseMap();
            //CreateMap<ModelVersionDocumentGetRequestByGuidDTO, ModelVersionDocument>().ReverseMap();
            //CreateMap<ModelVersionDocumentCreateRequestDTO, ModelVersionDocument>().ReverseMap();
            CreateMap<ModelVersionDocumentUpdateRequestDTO, ModelVersionDocument>().ReverseMap();
            //CreateMap<ModelVersionDocumentDeleteRequestDTO, ModelVersionDocument>().ReverseMap();

            // ShellMaterial Mappings 
            //CreateMap<ShellMaterialGetRequestDTO, ShellMaterial>().ReverseMap();
            //CreateMap<ShellMaterialGetRequestByIdDTO, ShellMaterial>().ReverseMap();
            //CreateMap<ShellMaterialGetRequestByGuidDTO, ShellMaterial>().ReverseMap();
            //CreateMap<ShellMaterialCreateRequestDTO, ShellMaterial>().ReverseMap();
            CreateMap<ShellMaterialUpdateRequestDTO, ShellMaterial>().ReverseMap();
            //CreateMap<ShellMaterialDeleteRequestDTO, ShellMaterial>().ReverseMap();

            // TestingModeGroup Mappings 
            //CreateMap<TestingModeGroupGetRequestDTO, TestingModeGroup>().ReverseMap();
            //CreateMap<TestingModeGroupGetRequestByIdDTO, TestingModeGroup>().ReverseMap();
            //CreateMap<TestingModeGroupGetRequestByGuidDTO, TestingModeGroup>().ReverseMap();
            //CreateMap<TestingModeGroupCreateRequestDTO, TestingModeGroup>().ReverseMap();
            CreateMap<TestingModeGroupUpdateRequestDTO, TestingModeGroup>().ReverseMap();
            //CreateMap<TestingModeGroupDeleteRequestDTO, TestingModeGroup>().ReverseMap();

            // TestPoint Mappings 
            //CreateMap<TestPointGetRequestDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointGetRequestByIdDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointGetRequestByGuidDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointCreateRequestDTO, TestPoint>().ReverseMap();
            CreateMap<TestPointUpdateRequestDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointDeleteRequestDTO, TestPoint>().ReverseMap();

            // TestPoint Mappings 
            //CreateMap<TestPointGetRequestDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointGetRequestByIdDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointGetRequestByGuidDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointCreateRequestDTO, TestPoint>().ReverseMap();
            CreateMap<TestPointUpdateRequestDTO, TestPoint>().ReverseMap();
            //CreateMap<TestPointDeleteRequestDTO, TestPoint>().ReverseMap();

        }
    }
}