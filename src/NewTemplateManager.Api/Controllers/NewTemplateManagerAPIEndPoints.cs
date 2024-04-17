namespace NewTemplateManager.Api.Controllers
{
    public static class NewTemplateManagerAPIEndPoints
    {
        public const string APIBase = "api/v{version:apiVersion}";
        //public const string APIBase = "api/v1";
        public static class Model
        {
            public const string Controller = "Models";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelType
        {
            public const string Controller = "ModelTypes";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestingModeGroup
        {
            public const string Controller = "TestingModeGroups";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelVersion
        {
            public const string Controller = "ModelVersions";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelVersionDocument
        {
            public const string Controller = "ModelVersionDocuments";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Product
        {
            public const string Controller = "Products";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ShellMaterial
        {
            public const string Controller = "ShellMaterials";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestPoint
        {
            public const string Controller = "TestPoints";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
    }
}