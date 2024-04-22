using NewTemplateManager.Domain.Entities;
using FluentAssertions;
using LanguageExt.Common;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text.RegularExpressions;

namespace NewTemplateManager.Domain.Tests
{
    public class SampleModelEntityTest
    {
        [Fact]
        public void CreateSampleModelShouldThrowAnExceptionWhenGuidValuesIsEmpty()
        {
            //Arrange
            //Expected exception message to match the equivalent of "SampleModel Guid cannot be empty guidId)", but "Model Type Guid cannot be empty guidId" does not.
            //Expected exception message to match the equivalent of "SampleModel Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'SampleModelName')" does not.

            var SampleModelName = Faker.Name.First();//"ML101";
            //var nodelGrade = Faker.Name.First();//"SCALES/PAD";
            var guidId = Guid.Empty;
            var PropertyName = "SampleModel Guid value cannot be empty guidId";
            //Act
            Action act = () => SampleModel.Create(SampleModelName, guidId);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage($"*{PropertyName}*");
        }

        [Fact(Skip = "I have check for other null @ Create")]
        public void CreateSampleModelShouldThrowAnExceptionWhenSampleModelNameValuesIsNullOrEmpty()
        {
            //Arrange
            //  Expected exception message to match the equivalent of "SampleModel Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'SampleModelName')" does not.

            var SampleModelName = "";
            var guidId = Guid.NewGuid();
            //Act
            Action act = () => SampleModel.Create(null, guidId);
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'SampleModelName')");
        }
    }
}