# ClickUpAPI

C# / .NET / .NET Core Implementation for management ClickUp API.

## Sample Usage

For OAuth2 Flow - see https://jsapi.apiary.io/apis/clickup20/introduction/authentication.html and https://jsapi.apiary.io/apis/clickup20/reference/0/authorization/get-access-token.html

```
var apitokens = new ParamsAccessToken(clientId, clientId, code);
var api = ClickUpApi.Create(apitokens);
var getTeamsResponse = api.GetAuthorizedTeams();
if (getTeamsResponse.RequestStatus != HttpStatusCode.OK || !getTeamsResponse.ResponseSuccess.Teams.Any())
  throw new AuthorisationException("Could not find any teams you are part of.");
```

For Personal Token - see https://jsapi.apiary.io/apis/clickup20/introduction/authentication.html

```
var api = new ClickUpApi(personalToken);
var getTeamsResponse = api.GetAuthorizedTeams();
if (getTeamsResponse.RequestStatus != HttpStatusCode.OK || !getTeamsResponse.ResponseSuccess.Teams.Any())
  throw new AuthorisationException("Could not find any teams you are part of.");
```
