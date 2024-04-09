
using NewTemplateManager.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NewTemplateManager.Infrastructure.Persistence
{
    public static class TrySeedData
    {


        public async static Task EnsureUsers(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();
            //Migration Should have been Created Might not have been Ran/Runned
            {
                try
                {
                    await scope.ServiceProvider.GetRequiredService<NewTemplateManagerContext>().Database.MigrateAsync();
                    var ctx = scope.ServiceProvider.GetRequiredService<NewTemplateManagerContext>();
                    // if (await ctx.Database.EnsureCreatedAsync())
                    {

                        var testData = ctx.TestingModeGroups.Any();
                        if (!testData)
                        {
                            var data = new List<TestingModeGroup>
                            {
                                TestingModeGroup.Create("LOADCELLS_GROUP", "AUTOMATIC", "FLOW TYPES FOR LOADCELL", Guid.NewGuid()),
                                TestingModeGroup.Create("TESTLINKS_GROUP", "MANUAL", "FLOW TYPES FOR TESTLINKS", Guid.NewGuid()),
                                TestingModeGroup.Create("SCALES/PAD", "MANUAL", "FLOW TYPES FOR SCALES/PAD",Guid.NewGuid())
                            };
                            ctx.TestingModeGroups.AddRange(data);
                            ctx.SaveChanges();


                        }

                        var modelTypes = ctx.ModelTypes.Any();
                        if (!modelTypes)
                        {
                            var data = new List<ModelType>
                            {
                                ModelType.Create("FIRSTMODELTYPE",  Guid.NewGuid()),
                                ModelType.Create("SECONDMODELTYPE",  Guid.NewGuid()),
                                ModelType.Create("THIRDMODELTYPE",Guid.NewGuid())
                            };
                            ctx.ModelTypes.AddRange(data);
                            ctx.SaveChanges();
                        }

                        var models = ctx.Models.Any();
                        if (!models)
                        {
                            var data = new List<Model>
                            {
                                Model.Create("FIRSTMODELNAME", "FIRSTMODELTYPE", Guid.NewGuid()),
                                Model.Create("SECONDMODELNAME", "FIRSTMODELTYPE", Guid.NewGuid()),
                                Model.Create("THIRDMODELNAME", "SECONDMODELTYPE", Guid.NewGuid())
                            };
                            ctx.Models.AddRange(data);
                            ctx.SaveChanges();
                        }
                        //entity.HasData(Model.Create("FIRSTMODELNAME", "FIRSTMODELTYPE", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
                        //                Model.Create("SECONDMODELNAME", "FIRSTMODELTYPE", Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
                        //               Model.Create("THIRDMODELNAME", "SECONDMODELTYPE", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")));

                        var shellMaterials = ctx.ShellMaterials.Any();
                        if (!shellMaterials)
                        {
                            var data = new List<ShellMaterial>
                            {
                                ShellMaterial.Create("ShellMaterial1", true, Guid.NewGuid()),
                                ShellMaterial.Create("ShellMaterial2", true, Guid.NewGuid()),
                                ShellMaterial.Create("ShellMaterial3", true, Guid.NewGuid()),
                                ShellMaterial.Create("ShellMaterial4", true, Guid.NewGuid())
                            };
                            ctx.ShellMaterials.AddRange(data);
                            ctx.SaveChanges();
                        }
                        var modelVersions = ctx.ModelVersions.Any();
                        if (!modelVersions)
                        {
                            var data = new List<ModelVersion>
                               {
                                ModelVersion.Create(1, "SPECIAL DESIGN", "FIRST_VERSION_FIRSTMODEL_NAME", "FIRSTMODELNAME","LOADCELLS_GROUP", "AUTOMATIC", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1
                                                               , 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.NewGuid()),
                                ModelVersion.Create(2, "AUTO DESIGN TO COMBAT SPLIILING", "SECOND_VERSION_FIRSTMODELNAME", "FIRSTMODELNAME", "TESTLINKS_GROUP", "MANUAL", DateTime.UtcNow, "OLADEJI", 100, 2, 2, 2, 2, 2, 2, 2, 2, "SHELLMATERIAL1", true, 20, 2, 2, "CCNUMBER", "CLASS", "APPLICATION", 2, 2, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.NewGuid()),
                                ModelVersion.Create(1, "INITIAL DESIGN", "FIRST_VERSION_SECONDMODELNAME", "SECONDMODELNAME", "SCALES/PAD", "MANUAL", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.NewGuid()),
                                ModelVersion.Create(2, "INITIAL DESIGN TO INPROVE VERSION1", "FIRST_VERSION_SECONDMODELNAME", "SECONDMODELNAME", "SCALES/PAD", "MANUAL", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.NewGuid()),





                               // TestingModeGroup.Create("SCALES/PAD", "MANUAL", "FLOW TYPES FOR SCALES/PAD",Guid.NewGuid())
                         
                                
                                //   public static ModelVersion Create(int  modelVersionId, string  versionDescription, string  modelVersionName, string  modelName, string  defaultTestingMode, DateTime  timestamp, string  userName, int  capacity, Double  nominalOutput, decimal  nominalOutputPercentage, decimal  nonlinearityPercentage, int  minimumDeadLoad, Double  vMin, int  nMax, int  safeLoad, int  ultimateLoad, string  shellMaterialName, Boolean  alloy, int  defaultCableLength, int  numberOfGauges, int  resistance, string  cCNumber, string  accuracyClass, string  application, int  temperingHardnessLow, int  temperingHardnessHigh, string  nTEPCertificationId, DateTime  nTEPCertificationTimestamp, string  oIMLCertificationId, DateTime  oIMLCertificationTimestamp, Boolean  testPointDirection, Guid  guidId)

                            };
                            ctx.ModelVersions.AddRange(data);
                            ctx.SaveChanges();
                        }

                        //entity.HasData(ModelVersion.Create(1, "SPECIAL DESIGN", "FIRST_VERSION_FIRSTMODEL_NAME", "FIRSTMODELNAME", "AUTOMATIC", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1
                        //    , 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
                        //      ModelVersion.Create(2, "AUTO DESIGN TO COMBAT SPLIILING", "SECOND_VERSION_FIRSTMODELNAME", "FIRSTMODELNAME", "MANUAL", DateTime.UtcNow, "OLADEJI", 100, 2, 2, 2, 2, 2, 2, 2, 2, "SHELLMATERIAL1", true, 20, 2, 2, "CCNUMBER", "CLASS", "APPLICATION", 2, 2, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5")),
                        //      ModelVersion.Create(1, "INITIAL DESIGN", "FIRST_VERSION_SECONDMODELNAME", "SECONDMODELNAME", "GETVALUESFROMTESTINGFLOWTYPES", DateTime.UtcNow, "OLADEJI", 100, 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL1", true, 20, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID1", DateTime.UtcNow, true, Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")));


                        var modelversiondocuments = ctx.ModelVersionDocuments.Any();

                        if (!modelversiondocuments)
                        {
                            var data = new List<ModelVersionDocument>
                            {
                                ModelVersionDocument.Create(1, "FIRSTMODELNAME",1, "DOC DESCRPTION", "CABLING","DIVENAME","DRIVEPATH", Guid.NewGuid(), "DOCNAME1.pdf", DateTime.UtcNow, "USER1",Guid.NewGuid()),
                                ModelVersionDocument.Create(2, "FIRSTMODELNAME",2, "DOC DESCRPTION", "WIRING","DIVENAME","DRIVEPATH", Guid.NewGuid(), "DOCNAME1.pdf", DateTime.UtcNow,"USER1", Guid.NewGuid()),
                                ModelVersionDocument.Create(1, "SECONDMODELNAME",1, "DOC DESCRPTION", "WIRING","DIVENAME","DRIVEPATH", Guid.NewGuid(), "DOCNAME1.pdf", DateTime.UtcNow,"USER1",   Guid.NewGuid()),
                                ModelVersionDocument.Create(2, "SECONDMODELNAME", 2, "DOC DESCRPTION", "WIRING","DIVENAME","DRIVEPATH", Guid.NewGuid(), "DOCNAME2.pdf", DateTime.UtcNow, "USER1", Guid.NewGuid()),
                                ModelVersionDocument.Create(3, "SECONDMODELNAME", 3, "DOC DESCRPTION", "WIRING","DIVENAME","DRIVEPATH", Guid.NewGuid(), "DOCNAME3.pdf", DateTime.UtcNow, "USER1", Guid.NewGuid())
                            };
                            ctx.ModelVersionDocuments.AddRange(data);
                            ctx.SaveChanges();
                        }


                        var testPoints = ctx.TestPoints.Any();
                        if (!testPoints)
                        {
                            var data = new List<TestPoint>
                            {
                                TestPoint.Create( 1, "FIRSTMODELNAME",10000, Guid.NewGuid()),
                                TestPoint.Create(1,"FIRSTMODELNAME",  2000, Guid.NewGuid()),
                                TestPoint.Create(1, "FIRSTMODELNAME", 3000, Guid.NewGuid()),
                                TestPoint.Create(1, "FIRSTMODELNAME", 4000, Guid.NewGuid()),
                                TestPoint.Create(1, "SECONDMODELNAME", 49, Guid.NewGuid())
                            };
                            ctx.TestPoints.AddRange(data);
                            ctx.SaveChanges();
                        }


                        //var products = ctx.Products.Any();
                        //if (!products)
                        //{
                        //    var data = new List<Product>
                        //    {
                        //    Product.Create(1, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(2, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(3, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(4, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(5, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(6, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),

                        //    Product.Create(7, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(8, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "AUTOMATIC", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 1, Guid.NewGuid()),
                        //    Product.Create(9, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID1", "SALESORDERID1", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO1", "MACHININGPURCHARSEORDERNO1", "STEELPURCHARSEORDERNO1", 2, Guid.NewGuid()),
                        //    Product.Create(10, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID2", "SALESORDERID2", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO2", "MACHININGPURCHARSEORDERNO2", "STEELPURCHARSEORDERNO2", 2, Guid.NewGuid()),
                        //    Product.Create(11, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID3", "SALESORDERID3", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO3", "MACHININGPURCHARSEORDERNO3", "STEELPURCHARSEORDERNO3", 2, Guid.NewGuid()),
                        //    Product.Create(12, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID4", "SALESORDERID4", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO4", "MACHININGPURCHARSEORDERNO4", "STEELPURCHARSEORDERNO4", 2, Guid.NewGuid()),
                        //    Product.Create(13, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID5", "SALESORDERID5", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO5", "MACHININGPURCHARSEORDERNO5", "STEELPURCHARSEORDERNO5", 2, Guid.NewGuid()),
                        //    Product.Create(14, 1, "FIRSTMODELNAME", 10000, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID6", "SALESORDERID6", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO6", "MACHININGPURCHARSEORDERNO6", "STEELPURCHARSEORDERNO6", 2, Guid.NewGuid()),
                        //    Product.Create(15, 1, "FIRSTMODELNAME", 100, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID7", "SALESORDERID7", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO7", "MACHININGPURCHARSEORDERNO7", "STEELPURCHARSEORDERNO7", 2, Guid.NewGuid()),

                        //    Product.Create(16, 1, "SECONDMODELNAME", 100, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID8", "SALESORDERID8", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO8", "MACHININGPURCHARSEORDERNO8", "STEELPURCHARSEORDERNO8", 2, Guid.NewGuid()),
                        //    Product.Create(17, 1, "SECONDMODELNAME", 49, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID9", "SALESORDERID9", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO9", "MACHININGPURCHARSEORDERNO9", "STEELPURCHARSEORDERNO9", 2, Guid.NewGuid()),
                        //    Product.Create(18, 1, "SECONDMODELNAME", 49, DateTime.UtcNow, "STAGE1", "SUBSTAGE1", "INVOICEID10", "SALESORDERID10", 100, 1, "MANUAL", "LOADCELLS_GROUP", "MANUAL", "THERMEXPURCHARSEORDERNO10", "MACHININGPURCHARSEORDERNO10", "STEELPURCHARSEORDERNO10", 2, Guid.NewGuid()),
                        //    };
                        //    ctx.Products.AddRange(data);
                        //    var x = ctx.SaveChanges();
                        //    var r = x.ToString();

                        //}


                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }


    }
}
