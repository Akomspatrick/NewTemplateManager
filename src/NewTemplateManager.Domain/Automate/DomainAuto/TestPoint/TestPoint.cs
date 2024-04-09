using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestPoint  : BaseEntity
    {
        private TestPoint(){}
        public int ModelVersionId    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public int CapacityTestPoint    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        public Guid GuidId    { get; init; } 
        
        public static TestPoint Create(int  modelVersionId, string  modelName, int  capacityTestPoint, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"TestPoint Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelVersionId = modelVersionId ,
            ModelName = modelName ,
            CapacityTestPoint = capacityTestPoint ,
            GuidId = guidId ,
        };
    }
    }
}