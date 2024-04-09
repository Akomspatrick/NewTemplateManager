using CodeGeneratorAttributesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTemplateManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("ModelVersion", "ModelVersionDocuments")]
    public class ModelVersionDocument : BaseEntity
    {

        [BaseModelBasicAttribute(true, true)]

        public int ModelVersionId { get; init; }


        [BaseModelBasicAttribute(32, 0, true, true)]
        public string ModelName { get; init; } = string.Empty;

        [BaseModelBasicAttribute(true)]
        public int ModelVersionDocumentId { get; init; }

        [BaseModelBasicAttribute(64, 0, false, false)]
        public string DocumentDescription { get; init; } = string.Empty;

        public string Stage { get; init; } = string.Empty;

        public string DocumentDrive { get; init; } = string.Empty;
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string DocumentPath { get; init; } = string.Empty;
        public Guid DocumentGuid { get; init; }
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string Documentname { get; init; }

        public DateTime Timestamp { get; init; }
        public ModelVersion ModelVersion { get; init; }
        public string UserName { get; init; } = string.Empty;
    }

    /*
         public class DocumentDocumentType : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, true, false, true)]
        public string DocumentName { get; init; } = string.Empty;//documents_name
        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }
        [BaseModelBasicAttribute(32, 0, true, true, false, true)]
        public string ModelName { get; init; } = string.Empty;//documents_models_name


        [BaseModelBasicAttribute(32, 0, true, true, false)]

        public string DocumentTypeName { get; init; } = string.Empty;//documentTypes_name
        public Document Document { get; init; }
        public DocumentType DocumentType { get; init; }

    }
        [BaseModelsForeignKeyAttribute("ModelVersion", "Documents")]
    public class Document : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false)]
        public string DocumentName { get; init; } = string.Empty;

        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }

        [BaseModelBasicAttribute(32, 0, true, true)]
        public string ModelName { get; init; } = string.Empty;

        //public Guid DocumentGuid { get; init; }
        public string ContentPDFPath { get; init; } = string.Empty;
        public string ChangeOrderPDFPath { get; init; } = string.Empty;
        public string DocumentBasePathId { get; init; } = string.Empty;

        public string DocumentDescription { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }


        public ModelVersion ModelVersion { get; init; }

        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }


    }

        public class DocumentBasePath : BaseEntity
    {
        [BaseModelBasicAttribute(128, 0, true, false)]
        public string DocumentBasePathId { get; init; } = string.Empty;
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string Path { get; init; } = string.Empty;
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string Description { get; init; } = string.Empty;


    }

        public class DocumentType : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false, false, true)]
        public string DocumentTypeName { get; init; } = string.Empty;// This is the primary key and the id of the document type name

        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }


    }
     
     */
}
