using Microsoft.Extensions.Configuration;
using Xunit;

namespace CreditApproval.Services.Tests
{
    public class ServiceTests
    {
        [Fact]
        async void CanCallPredictionService()
        {
            // Arrange
            var profile = new CreditProfile
            {
                LoanAmount = 12232,
                Term = "Short Term",
                CreditScore = 755,
                YearsInCurrentJob = " < 1 year",
                HomeOwnership = "Rent",
                AnnualIncome = 46643,
                Purpose = "Debt Consolidation",
                MonthlyDebt = 777.39,
                YearsOfCreditHistory = 18,
                MonthsSinceLastDelinquent = 10,
                NumberOfOpenAccounts = 12,
                NumberOfCreditProblems = 0,
                CurrentCreditBalence = 6762,
                MaximumOpenCredit = 7946,
                Bankruptcies = 0,
                TaxLiens = 0
            };
            // Wrap profile in Data Transfer Object (DTO) for easy serialization
            var data = new CreditProfileData(profile);

            var service = new CreditPredictionService();

            #region ApiKeys
            // Api Key Management
            // From the command line run:
            // dotnet user-secrets set "CreditApproval:ServiceApiKey" "Your Azure ML Service API Key here"
            // This will keep your Api Key safe
            var config = new ConfigurationBuilder().AddUserSecrets("b7e4570a-9694-46e0-a997-2a87c8fe7490").Build();
            var apiKey = config["CreditApproval:ServiceApiKey"];
            #endregion
            // Act

            var result = await service.PreApproveCredit(data, apiKey);
            
            // Assert
            // Did a response return?
            Assert.True(result.Probability > 0);
            Assert.NotNull(result);
        }
    }
}
