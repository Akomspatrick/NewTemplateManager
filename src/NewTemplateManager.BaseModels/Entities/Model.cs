﻿using CodeGeneratorAttributesLibrary;

namespace NewTemplateManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("ModelType", "Models")]
    public partial class Model : BaseEntity
    {
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
        // public string ModelId { get; init; } = string.Empty;
        // public Guid ModelId { get; private set; }
        [BaseModelBasicAttribute(32, 0, true, false, false, true)]
        public string ModelName { get; init; } = string.Empty;

        [BaseModelBasicAttribute(32, 0, false, true, false, true)]
        public string ModelTypeName { get; private set; } = string.Empty;
        public ModelType? ModelType { get; set; }


        public ICollection<ModelVersion> ModelVersions { get; set; }
        //public string ModelTypesId { get; init; } = string.Empty;

        //if I am not using domain driven design then i can specify the detail model here eg 



    }

}


