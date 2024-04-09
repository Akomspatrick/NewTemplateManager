using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersionDocument  : BaseEntity
    {
        private ModelVersionDocument(){}
        public Int32 ModelVersionId    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public Int32 ModelVersionDocumentId    { get; init; } 
        public string DocumentDescription    { get; init; }  = string.Empty; 
        public string Stage    { get; init; }  = string.Empty; 
        public string DocumentDrive    { get; init; }  = string.Empty; 
        public string DocumentPath    { get; init; }  = string.Empty; 
        public Guid DocumentGuid    { get; init; } 
        public string Documentname    { get; init; }  = string.Empty; 
        public DateTime Timestamp    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        public string UserName    { get; init; }  = string.Empty; 
        // public Guid GuidId    { get; init; } 
        
        public static ModelVersionDocument Create(Int32  modelVersionId, string  modelName, Int32  modelVersionDocumentId, string  documentDescription, string  stage, string  documentDrive, string  documentPath, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ModelVersionDocument Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelVersionId = modelVersionId ,
            ModelName = modelName ,
            ModelVersionDocumentId = modelVersionDocumentId ,
            DocumentDescription = documentDescription ,
            Stage = stage ,
            DocumentDrive = documentDrive ,
            DocumentPath = documentPath ,
            DocumentGuid = documentGuid ,
            Documentname = documentname ,
            Timestamp = timestamp ,
            UserName = userName ,
            GuidId = guidId ,
        };
    }
    }
}