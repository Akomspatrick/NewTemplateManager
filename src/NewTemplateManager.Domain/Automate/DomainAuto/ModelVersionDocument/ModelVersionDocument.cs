using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersionDocument  : BaseEntity
    {
        private ModelVersionDocument(){}
        public int ModelVersionId    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public int ModelVersionDocumentId    { get; init; } 
        public string DocumentDescription    { get; init; }  = string.Empty; 
        public string Stage    { get; init; }  = string.Empty; 
        public Guid DocumentGuid    { get; init; } 
        public string Documentname    { get; init; }  = string.Empty; 
        public DateTime Timestamp    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        public string UserName    { get; init; }  = string.Empty; 
        public Guid GuidId    { get; init; } 
        
        public static ModelVersionDocument Create(int  modelVersionId, string  modelName, int  modelVersionDocumentId, string  documentDescription, string  stage, Guid  documentGuid, string  documentname, DateTime  timestamp, string  userName, Guid  guidId)
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
            DocumentGuid = documentGuid ,
            Documentname = documentname ,
            Timestamp = timestamp ,
            UserName = userName ,
            GuidId = guidId ,
        };
    }
    }
}