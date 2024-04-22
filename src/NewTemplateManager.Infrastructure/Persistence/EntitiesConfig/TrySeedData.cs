
using NewTemplateManager.Domain.Entities;
using Microsoft.AspNetCore.Builder;
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

                        //var testData = ctx.TestingModeGroups.Any();
                        //if (!testData)
                        //{
                        //    var data = new List<TestingModeGroup>
                        //    {
                        //        TestingModeGroup.Create("LOADCELLS_GROUP", "AUTOMATIC", "FLOW TYPES FOR LOADCELL", Guid.NewGuid()),
                        //        TestingModeGroup.Create("TESTLINKS_GROUP", "MANUAL", "FLOW TYPES FOR TESTLINKS", Guid.NewGuid()),
                        //        TestingModeGroup.Create("SCALES/PAD", "MANUAL", "FLOW TYPES FOR SCALES/PAD",Guid.NewGuid())
                        //    };
                        //    ctx.TestingModeGroups.AddRange(data);
                        //    ctx.SaveChanges();


                        //}

                        var SampleModels = ctx.SampleModels.Any();
                        if (!SampleModels)
                        {
                            var data = new List<SampleModel>
                            {
                                SampleModel.Create("FIRSTSampleModel",  Guid.NewGuid()),
                                SampleModel.Create("SECONDSampleModel",  Guid.NewGuid()),
                                SampleModel.Create("THIRDSampleModel",Guid.NewGuid())
                            };
                            ctx.SampleModels.AddRange(data);
                            ctx.SaveChanges();
                        }




                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Error in Migration from TrySeeding  data: " + ex.Message);
                }
            }



        }


    }
}
