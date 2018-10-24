# Credit Prediction Service

This is a Service for a custom Azure ML model.

The Azure ML project can be found in the article series:
https://developer.telerik.com/topics/machine-learning/consuming-azure-machine-learning-asp-net-core/

# IMPORTANT

## Api Keys

This project uses a functional test to invoke the service. In this functional test user secerets are configured using the following method.

```
// Api Key Management
// From the command line run:
// dotnet user-secrets set "CreditApproval:ServiceApiKey" "Your Azure ML Service API Key here"
// This will keep your Api Key safe
var config = new ConfigurationBuilder().AddUserSecrets("b7e4570a-9694-46e0-a997-2a87c8fe7490").Build();
var apiKey = config["CreditApproval:ServiceApiKey"];
```

If you do not register your Api Key, the project **will fail**.

Optionally, you could replace `var apiKey` with a literal string contaning your Api Key. However, this is bad practice and may allow **unauthorized access to your resoruces**.

## The request failed with status code: BadRequest error

If you are receiving this error. This generally means that your parameters do not match those expected by Azure ML. **This is generally due to JSON serialization**, naming matters!

Often a change to your Azure ML model will cause changes in the paramter names **as a side-effect**. This means that you can unintentionally change your parameter names. Always check your parameter names, JSON serialiaztion when you see this error.

Telerik Fiddler is a great tool to help troubleshoot HTTP traffic.

The expected input/output parameters can be found in your Azure ML studio dashboard.

### More about parameter serialization

The class and property names in `CreditProfile` and `CreditProfileData` are custom to my model. Your property names may vary, please use JSON attributes to adjust.

