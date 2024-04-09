using CodeGeneratorAttributesLibrary;

namespace NewTemplateManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("Model", "ModelVersions")]
    [BaseModelsHardForeignKeyAttribute("TestingModeGroup", "ModelVersions", ["TestingModeGroupName"])]
    [BaseModelsHardForeignKeyAttribute("ShellMaterial", "ModelVersions", ["ShellMaterialName"])]
    public class ModelVersion : BaseEntity
    {
        [BaseModelBasicAttribute(true)]
        public int ModelVersionId { get; init; }

        public string VersionDescription { get; init; } = string.Empty;
        public string ModelVersionName { get; init; } = string.Empty;
        public Model Model { get; init; }

        [BaseModelBasicAttribute(32, 0, true, true, false)]
        public string ModelName { get; init; } = string.Empty;
        public string TestingModeGroupName { get; private set; } = string.Empty;
        public string DefaultTestingMode { get; init; } = string.Empty; // Manual, Automatic for each product
        public DateTime Timestamp { get; init; }
        public string UserName { get; init; } = string.Empty;
        public ICollection<ModelVersionDocument> ModelVersionDocuments { get; init; }

        [BaseModelBasicAttribute(0, 0, false, false, false, true)]
        public int Capacity { get; init; }
        public double? NominalOutput { get; init; }
        public decimal? NominalOutputPercentage { get; init; }
        public decimal? NonlinearityPercentage { get; init; }
        public int? MinimumDeadLoad { get; init; }
        [BaseModelBasicAttribute(11, 1, false)]
        public double? vMin { get; init; }
        public int? nMax { get; init; }
        public int? SafeLoad { get; init; }
        public int? UltimateLoad { get; init; }
        [BaseModelBasicAttribute(32, 0, false, false, true)]
        public string? ShellMaterialName { get; init; } = string.Empty;
        public bool Alloy { get; init; }
        public int? DefaultCableLength { get; init; }
        public int? NumberOfGauges { get; init; }
        public int? Resistance { get; init; }
        public string? CCNumber { get; init; }
        public string? AccuracyClass { get; init; } = string.Empty;
        public string? Application { get; init; } = string.Empty;
        public int? TemperingHardnessLow { get; init; }
        public int? TemperingHardnessHigh { get; init; }
        public string? NTEPCertificationId { get; init; } = string.Empty;
        public DateTime? NTEPCertificationTimestamp { get; init; }

        public string? OIMLCertificationId { get; init; } = string.Empty;
        public DateTime? OIMLCertificationTimestamp { get; init; }
        public bool TestPointDirection { get; init; } = true;// true = increasing, false = decreasing
        public required ShellMaterial ShellMaterial { get; init; }
        public required TestingModeGroup TestingModeGroup { get; init; }
        public ICollection<TestPoint> TestPoints { get; set; } = new List<TestPoint>();



    }
}
