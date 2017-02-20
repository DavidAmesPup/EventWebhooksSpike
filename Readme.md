# Event Web Hooks Spike

## About ##

## Endpoints ##
### MockEvents ###
This is our entry point to the spike. There are two types of events that it can generate. ApplicationReceived and EmployeeCreated

They both return 200 OK when successfully called.



GET: https://ienm4x0l7f.execute-api.ap-southeast-2.amazonaws.com/Prod/CreateRandomApplicationReceived
GET: https://ienm4x0l7f.execute-api.ap-southeast-2.amazonaws.com/Prod/CreateRandomEmployeeCreated

POST:https://ienm4x0l7f.execute-api.ap-southeast-2.amazonaws.com/Prod/EmployeeCreated

```json
{
  "firstName": "string",
  "lastName": "string",
  "emailAddres": "string"
}
```


POST:https://ienm4x0l7f.execute-api.ap-southeast-2.amazonaws.com/Prod/ApplicationReceived
```json
{
  "firstName": "string",
  "lastName": "string",
  "company": "string",
  "emailAddres": "string",
  "position": "string"
}
```

## Logging ##
Logs are written to Cloudwatch 
The NuGet package [Amazon.Lambda.Logging.AspNetCore](https://www.nuget.org/packages/Amazon.Lambda.Logging.AspNetCore/) is added to the project to integrate the ASP.NET Core ILogger logging framework into the Amazon CloudWatch Logs built into Lambda functions. By adding this package and the following code in the Startup.cs file controllers that write to the ILogger will have those log messages be written to CloudWatch Logs

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddLambdaLogger(Configuration.GetLambdaLoggerOptions());
    ...
}
```

You can also control what log messages get written to CloudWatch Logs with your configuration. For example this appsettings.json file configures log messages of level informational and above coming from classes under the Microsoft namespace to be sent to CloudWatch Logs and for all other log messages, those at debug level and above are written.
```json
{
  "Lambda.Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Information"
    }
  }
}

