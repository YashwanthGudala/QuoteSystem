using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;
using Xunit;

namespace QuoteSystemUnitTest
{
    public class AgentDataAccessTest
    {
        //[Fact]
        //public void AddAgentPassingTest()
        //{
        //    //arrange
        //    Agent agent = new Agent()
        //    {
        //        AgentId = "002",
        //        AgencyName = "ABC",
        //        AgentName = "Pranay",
        //        Contact = "123-456-7895",
        //        Mail = "pranay@gmail.com",
        //        Password = "pranay123"

        //    };
        //    string ExpectedOutput = "Agent succesfully Added";

        //    //act
        //    string ObservedOuput = AgentDataAccess.AddAgent(agent);

        //    //assert
        //    Assert.Equal(ExpectedOutput, ObservedOuput);

        //}

        //[Fact]
        //public void AddAgentFailingTest()
        //{
        //    //arrange
        //    Agent agent = null;
        //    string ExpectedOutput = "Agent Data is mandatory";

        //    //act
        //    string ObservedOutput = AgentDataAccess.AddAgent(agent);

        //    //assert
        //    Assert.Equal(ExpectedOutput, ObservedOutput);

        //}

        //[Fact]
        //public void VerifyAgentLoginPassingTest()
        //{
        //    //arrange
        //    string Email = "yash@gmail.com";
        //    string Password = "yash123";

        //    string ExpectedOutput = "Login successfull";

        //    //act
        //    string ObservedOutput = AgentDataAccess.VerifyAgentLogin(Email, Password);

        //    //assert 
        //    Assert.Equal(ExpectedOutput, ObservedOutput);
        //}

        //[Fact]
        //public void VerifyAgentLoginFailingTest()
        //{
        //    //arrange
        //    string Email = "yash@gmail.com";
        //    string Password = "yash423";

        //    string ExpectedOutput = "Login Failed";

        //    //act
        //    string ObservedOutput = AgentDataAccess.VerifyAgentLogin(Email, Password);

        //    //assert 
        //    Assert.Equal(ExpectedOutput, ObservedOutput);
        //}

        //[Fact]
        //public void VerifyAgentLoginFailingTest2()
        //{
        //    //arrange
        //    string Email = "yash@gmail.com";
        //    string Password = null;

        //    string ExpectedOutput = "These fields are mandatory";

        //    //act
        //    string ObservedOutput = AgentDataAccess.VerifyAgentLogin(Email, Password);

        //    //assert 
        //    Assert.Equal(ExpectedOutput, ObservedOutput);
        //}

    }
}
