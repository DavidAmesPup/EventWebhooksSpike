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

