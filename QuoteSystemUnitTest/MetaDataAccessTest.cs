using QuoteSystemDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using QuoteSystemDataAccess;
namespace QuoteSystemUnitTest
{
    public class MetaDataAccessTest
    {
    //    [Theory]
    //    [InlineData("Deductible Type")]
    //    [InlineData("Rating Basis")]
    //    [InlineData("US States")]
    //    public void GetCodeValuesByListNamePassingTest(string ListName)
    //    {
    //        // act
    //        List<CodeValue> codevalues = MetadataDataAccess.GetCodeValuesByListName(ListName);

    //        // assert
    //        Assert.NotNull(codevalues);
    //    }

    //    [Fact]
    //    public void GetCodeValuesByListNameFailingTest()
    //    {
    //        //arrange
    //        string ListName = null;
    //        //act+assert
    //        Assert.Throws<DatabaseException>(() => MetadataDataAccess.GetCodeValuesByListName(ListName));
    //    }

    //    [Theory]
    //    [InlineData("ratingbasis")]
    //    [InlineData("usstates")]
    //    [InlineData("deductibletype")]
    //    public void GetCodeValuesByListNameFailingTest2(string ListName)
    //    {
    //        // act
    //        List<CodeValue> codevalues = MetadataDataAccess.GetCodeValuesByListName(ListName);

    //        // assert
    //        Assert.Null(codevalues);
    //    }

    //    [Theory]
    //    [InlineData("Rating Basis", "A")]
    //    [InlineData("Rating Basis", "S")]
    //    [InlineData("Rating Basis", "P")]
    //    public void GetValueFromCodePassingTest(string ListName, string Code)
    //    {
    //        // act
    //        string Value = MetadataDataAccess.GetValueFromCode(ListName, Code);

    //        // assert
    //        Assert.NotNull(Value);
    //    }

    //    [Fact]
    //    public void GetValueFromCodeFailingTest()
    //    {
    //        string ListName = "";
    //        string Key = "A";

    //        string ExpectedOutput = "ListName is mandatory";

    //        string ObservedOutput = MetadataDataAccess.GetValueFromCode(ListName, Key);

    //        Assert.Equal(ExpectedOutput, ObservedOutput);
    //    }

    //    [Fact]
    //    public void GetValueFromCodeFailingTest2()
    //    {
    //        string ListName = "Rating Basis";
    //        string Key = "";

    //        string ExpectedOutput = "Key is mandatory";

    //        string ObservedOutput = MetadataDataAccess.GetValueFromCode(ListName, Key);

    //        Assert.Equal(ExpectedOutput, ObservedOutput);
    //    }

    //    [Fact]
    //    public void GetValueFromCodeFailingTest3()
    //    {
    //        string ListName = "RatingB";
    //        string Key = "A";

    //        string ExpectedOutput = "List Name Not Found";

    //        string ObservedOutput = MetadataDataAccess.GetValueFromCode(ListName, Key);

    //        Assert.Equal(ExpectedOutput, ObservedOutput);
    //    }
    }
}
