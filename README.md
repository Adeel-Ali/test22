# Getting started

This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.

## How to Build

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

"This library requires Visual Studio 2017 for compilation."
1. Open the solution (SwaggerPetstore.sln) file.
2. Invoke the build process using `Ctrl+Shift+B` shortcut key or using the `Build` menu as shown below.

![Building SDK using Visual Studio](https://apidocs.io/illustration/cs?step=buildSDK&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

## How to Use

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8,
Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the [MSDN Portable Class Libraries documentation](http://msdn.microsoft.com/en-us/library/vstudio/gg597391%28v=vs.100%29.aspx).

The following section explains how to use the SwaggerPetstore library in a new console project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the *solution explorer* and choose  ``` Add -> New Project ```.

![Add a new project in the existing solution using Visual Studio](https://apidocs.io/illustration/cs?step=addProject&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

Next, choose "Console Application", provide a ``` TestConsoleProject ``` as the project name and click ``` OK ```.

![Create a new console project using Visual Studio](https://apidocs.io/illustration/cs?step=createProject&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the ``` TestConsoleProject ``` as the start-up project. To do this, right-click on the  ``` TestConsoleProject ``` and choose  ``` Set as StartUp Project ``` form the context menu.

![Set the new cosole project as the start up project](https://apidocs.io/illustration/cs?step=setStartup&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

### 3. Add reference of the library project

In order to use the SwaggerPetstore library in the new project, first we must add a projet reference to the ``` TestConsoleProject ```. First, right click on the ``` References ``` node in the *solution explorer* and click ``` Add Reference... ```.

![Open references of the TestConsoleProject](https://apidocs.io/illustration/cs?step=addReference&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

Next, a window will be displayed where we must set the ``` checkbox ``` on ``` SwaggerPetstore.Standard ``` and click ``` OK ```. By doing this, we have added a reference of the ```SwaggerPetstore.Standard``` project into the new ``` TestConsoleProject ```.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=createReference&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

### 4. Write sample code

Once the ``` TestConsoleProject ``` is created, a file named ``` Program.cs ``` will be visible in the *solution explorer* with an empty ``` Main ``` method. This is the entry point for the execution of the entire solution.
Here, you can add code to initialize the client library and acquire the instance of a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

![Add a reference to the TestConsoleProject](https://apidocs.io/illustration/cs?step=addCode&workspaceFolder=Swagger%20Petstore-CSharp&workspaceName=SwaggerPetstore&projectName=SwaggerPetstore.Standard)

## How to Test

The generated SDK also contain one or more Tests, which are contained in the Tests project.
In order to invoke these test cases, you will need *NUnit 3.0 Test Adapter Extension for Visual Studio*.
Once the SDK is complied, the test cases should appear in the Test Explorer window.
Here, you can click *Run All* to execute these test cases.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| oAuthClientId | OAuth 2 Client ID |
| oAuthClientSecret | OAuth 2 Client Secret |
| oAuthUsername | OAuth 2 Resource Owner Username |
| oAuthPassword | OAuth 2 Resource Owner Password |



API client can be initialized as following.

```csharp
// Configuration parameters and credentials
string oAuthClientId = "oAuthClientId"; // OAuth 2 Client ID
string oAuthClientSecret = "oAuthClientSecret"; // OAuth 2 Client Secret
string oAuthUsername = "oAuthUsername"; // OAuth 2 Resource Owner Username
string oAuthPassword = "oAuthPassword"; // OAuth 2 Resource Owner Password

SwaggerPetstoreClient client = new SwaggerPetstoreClient(oAuthClientId, oAuthClientSecret, oAuthUsername, oAuthPassword);
```


You must now authorize the client.

### Authorizing your client

This SDK uses *OAuth 2.0 authorization* to authorize the client.

The `Authorize()` method will exchange the user's credentials for an *access token*.
The access token is an object containing information for authorizing client requests and refreshing the token itself.

You must pass the *[scopes](#scopes)* for which you need permission to access.

```csharp
try
{
    client.Auth.Authorize(scope=new List<OAuthScopeEnum>(){OAuthScopeEnum.WRITEPETS, OAuthScopeEnum.READPETS})
}
catch (OAuthProviderException e)
{
    //handle exception here
}
```

The client can now make authorized endpoint calls.

### Scopes

Scopes enable your application to only request access to the resources it needs while enabling users to control the amount of access they grant to your application. Available scopes are defined in the `SwaggerPetstore.Standard.Models.OAuthScopeEnum` enumeration.

| Scope Name | Description |
| --- | --- |
| `WRITEPETS` | modify pets in your account |
| `READPETS` | read your pets |

### Refreshing token

An access token may expire after some time. To extend its lifetime, you must refresh the token.

```csharp
try
{
    client.Auth.RefreshToken(scope=new List<OAuthScopeEnum>(){OAuthScopeEnum.WRITEPETS, OAuthScopeEnum.READPETS})
}
catch (OAuthProviderException e)
{
    //handle exception here
}
```

If a token expires, the SDK will attempt to automatically refresh the token before the next endpoint call requiring authentication.

### Storing an access token for reuse

It is recommended that you store the access token for reuse.

You can store the access token in a file or a database.

```csharp
// store token
SaveTokenToDatabase(Configuration.OAuthToken);
```
 
However, since the the SDK will attempt to automatically refresh the token when it expires, it is recommended that you register a *token update delegate* to detect any change to the access token.

```csharp
client.Configuration.OAuthTokenUpdateCallback = SaveTokenToDatabase;
```

The token update callback will be fired upon authorization as well as token refresh.

### Creating a client from a stored token

To authorize a client from a stored access token, just set the access token after creating the client:

```csharp
client = SwaggerPetstoreClient();
Configuration.UpdateAccessToken(LoadTokenFromDatabase());
```

### Complete example

```csharp
using SwaggerPetstore.Standard;
using SwaggerPetstore.Standard.Models;
using SwaggerPetstore.Standard.Exceptions;

namespace OAuthTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration parameters and credentials
           string oAuthClientId = "oAuthClientId"; // OAuth 2 Client ID
           string oAuthClientSecret = "oAuthClientSecret"; // OAuth 2 Client Secret
           string oAuthUsername = "oAuthUsername"; // OAuth 2 Resource Owner Username
           string oAuthPassword = "oAuthPassword"; // OAuth 2 Resource Owner Password
           
            SwaggerPetstoreClient client = new SwaggerPetstoreClient(oAuthClientId, oAuthClientSecret, oAuthUsername, oAuthPassword);

            //callback for storing token for reuse when token is updated
            Configuration.OAuthTokenUpdateCallback = SaveTokenToDatabase;

            //obtain access token, needed for client to be authorized
            OAuthToken storedToken = LoadTokenFromDatabase();
            if (storedToken != null)
            {
                Configuration.OAuthToken = storedToken;
            }
            else
            {
                try
                {
                    client.Auth.Authorize(new List<OAuthScopeEnum>(){OAuthScopeEnum.WRITEPETS, OAuthScopeEnum.READPETS});
                }
                catch (OAuthProviderException e)
                {
                    //Handle Exception here
                }
            }
        }

        //function for storing token to database
        static void SaveTokenToDatabase(OAuthToken token)
        {
            //Save token here
        }

        //function for loading token from database
        static OAuthToken LoadTokenFromDatabase()
        {
            OAuthToken token = null;
            //token = Get token here
            return token;
        }
    }
}

// the client is now authorized and you can use controllers to make endpoint calls
// client will automatically refresh the token when it expires and call the token update callback
```


# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [PetController](#pet_controller)
* [StoreController](#store_controller)
* [UserController](#user_controller)

## <a name="pet_controller"></a>![Class: ](https://apidocs.io/img/class.png "SwaggerPetstore.Standard.Controllers.PetController") PetController

### Get singleton instance

The singleton instance of the ``` PetController ``` class can be accessed from the API Client.

```csharp
PetController pet = client.Pet;
```

### <a name="update_pet"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.UpdatePet") UpdatePet

> Update an existing pet


```csharp
Task UpdatePet(Models.Pet body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | Pet object that needs to be added to the store |


#### Example Usage

```csharp
var body = new Models.Pet();

await pet.UpdatePet(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid ID supplied |
| 404 | Pet not found |
| 405 | Validation exception |


### <a name="add_pet"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.AddPet") AddPet

> Add a new pet to the store


```csharp
Task AddPet(Models.Pet body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | Pet object that needs to be added to the store |


#### Example Usage

```csharp
var body = new Models.Pet();

await pet.AddPet(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 405 | Invalid input |


### <a name="find_pets_by_status"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.FindPetsByStatus") FindPetsByStatus

> Finds Pets by status


```csharp
Task<List<Models.Pet>> FindPetsByStatus(List<Models.Status7Enum> status)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| status |  ``` Required ```  ``` Collection ```  | Status values that need to be considered for filter |


#### Example Usage

```csharp
List<Models.Status7Enum> status = new List<Models.Status7Enum> {Models.Status7Enum.AVAILABLE};
List<Models.Pet> result = await pet.FindPetsByStatus(status);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid status value |


### <a name="find_pets_by_tags"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.FindPetsByTags") FindPetsByTags

> Finds Pets by tags


```csharp
Task<List<Models.Pet>> FindPetsByTags(List<string> tags)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| tags |  ``` Required ```  ``` Collection ```  | Tags to filter by |


#### Example Usage

```csharp
List<string> tags = new List<string> { "tags" };

List<Models.Pet> result = await pet.FindPetsByTags(tags);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid tag value |


### <a name="get_pet_by_id"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.GetPetById") GetPetById

> Find pet by ID


```csharp
Task<Models.Pet> GetPetById(long petId)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| petId |  ``` Required ```  | ID of pet to return |


#### Example Usage

```csharp
long petId = 34;

Models.Pet result = await pet.GetPetById(petId);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid ID supplied |
| 404 | Pet not found |


### <a name="update_pet_with_form"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.UpdatePetWithForm") UpdatePetWithForm

> Updates a pet in the store with form data


```csharp
Task UpdatePetWithForm(long petId, string name = null, string status = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| petId |  ``` Required ```  | ID of pet that needs to be updated |
| name |  ``` Optional ```  | Updated name of the pet |
| status |  ``` Optional ```  | Updated status of the pet |


#### Example Usage

```csharp
long petId = 34;
string name = "name";
string status = "status";

await pet.UpdatePetWithForm(petId, name, status);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 405 | Invalid input |


### <a name="delete_pet"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.DeletePet") DeletePet

> Deletes a pet


```csharp
Task DeletePet(long petId, string apiKey = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| petId |  ``` Required ```  | Pet id to delete |
| apiKey |  ``` Optional ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
long petId = 34;
string apiKey = "api_key";

await pet.DeletePet(petId, apiKey);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid ID supplied |
| 404 | Pet not found |


### <a name="upload_file"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.PetController.UploadFile") UploadFile

> uploads an image


```csharp
Task<Models.ApiResponse> UploadFile(long petId, string additionalMetadata = null, FileStreamInfo file = null)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| petId |  ``` Required ```  | ID of pet to update |
| additionalMetadata |  ``` Optional ```  | Additional data to pass to server |
| file |  ``` Optional ```  | file to upload |


#### Example Usage

```csharp
long petId = 34;
string additionalMetadata = "additionalMetadata";
FileStreamInfo file = new FileStreamInfo(new FileStream(@"pathToFile",FileMode.Open));

Models.ApiResponse result = await pet.UploadFile(petId, additionalMetadata, file);

```


[Back to List of Controllers](#list_of_controllers)

## <a name="store_controller"></a>![Class: ](https://apidocs.io/img/class.png "SwaggerPetstore.Standard.Controllers.StoreController") StoreController

### Get singleton instance

The singleton instance of the ``` StoreController ``` class can be accessed from the API Client.

```csharp
StoreController store = client.Store;
```

### <a name="get_inventory"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.StoreController.GetInventory") GetInventory

> Returns pet inventories by status


```csharp
Task<Dictionary<string, int>> GetInventory()
```

#### Example Usage

```csharp

Dictionary<string, int> result = await store.GetInventory();

```


### <a name="create_place_order"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.StoreController.CreatePlaceOrder") CreatePlaceOrder

> *Tags:*  ``` Skips Authentication ``` 

> Place an order for a pet


```csharp
Task<Models.Order> CreatePlaceOrder(Models.Order body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | order placed for purchasing the pet |


#### Example Usage

```csharp
var body = new Models.Order();

Models.Order result = await store.CreatePlaceOrder(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid Order |


### <a name="get_order_by_id"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.StoreController.GetOrderById") GetOrderById

> *Tags:*  ``` Skips Authentication ``` 

> Find purchase order by ID


```csharp
Task<Models.Order> GetOrderById(long orderId)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| orderId |  ``` Required ```  | ID of pet that needs to be fetched |


#### Example Usage

```csharp
long orderId = 34;

Models.Order result = await store.GetOrderById(orderId);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid ID supplied |
| 404 | Order not found |


### <a name="delete_order"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.StoreController.DeleteOrder") DeleteOrder

> *Tags:*  ``` Skips Authentication ``` 

> Delete purchase order by ID


```csharp
Task DeleteOrder(long orderId)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| orderId |  ``` Required ```  | ID of the order that needs to be deleted |


#### Example Usage

```csharp
long orderId = 34;

await store.DeleteOrder(orderId);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid ID supplied |
| 404 | Order not found |


[Back to List of Controllers](#list_of_controllers)

## <a name="user_controller"></a>![Class: ](https://apidocs.io/img/class.png "SwaggerPetstore.Standard.Controllers.UserController") UserController

### Get singleton instance

The singleton instance of the ``` UserController ``` class can be accessed from the API Client.

```csharp
UserController user = client.User;
```

### <a name="create_user"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.CreateUser") CreateUser

> *Tags:*  ``` Skips Authentication ``` 

> Create user


```csharp
Task CreateUser(Models.User body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | Created user object |


#### Example Usage

```csharp
var body = new Models.User();

await user.CreateUser(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 0 | successful operation |


### <a name="create_users_with_array_input"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.CreateUsersWithArrayInput") CreateUsersWithArrayInput

> *Tags:*  ``` Skips Authentication ``` 

> Creates list of users with given input array


```csharp
Task CreateUsersWithArrayInput(List<Models.User> body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  ``` Collection ```  | List of user object |


#### Example Usage

```csharp
var body = new List<Models.User>();

await user.CreateUsersWithArrayInput(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 0 | successful operation |


### <a name="create_users_with_list_input"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.CreateUsersWithListInput") CreateUsersWithListInput

> *Tags:*  ``` Skips Authentication ``` 

> Creates list of users with given input array


```csharp
Task CreateUsersWithListInput(List<Models.User> body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  ``` Collection ```  | List of user object |


#### Example Usage

```csharp
var body = new List<Models.User>();

await user.CreateUsersWithListInput(body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 0 | successful operation |


### <a name="get_login_user"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.GetLoginUser") GetLoginUser

> *Tags:*  ``` Skips Authentication ``` 

> Logs user into the system


```csharp
Task<string> GetLoginUser(string username, string password)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| username |  ``` Required ```  | The user name for login |
| password |  ``` Required ```  | The password for login in clear text |


#### Example Usage

```csharp
string username = "username";
string password = "password";

string result = await user.GetLoginUser(username, password);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid username/password supplied |


### <a name="get_logout_user"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.GetLogoutUser") GetLogoutUser

> *Tags:*  ``` Skips Authentication ``` 

> Logs out current logged in user session


```csharp
Task GetLogoutUser()
```

#### Example Usage

```csharp

await user.GetLogoutUser();

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 0 | successful operation |


### <a name="get_user_by_name"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.GetUserByName") GetUserByName

> *Tags:*  ``` Skips Authentication ``` 

> Get user by user name


```csharp
Task<Models.User> GetUserByName(string username)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| username |  ``` Required ```  | The name that needs to be fetched. Use user1 for testing. |


#### Example Usage

```csharp
string username = "username";

Models.User result = await user.GetUserByName(username);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid username supplied |
| 404 | User not found |


### <a name="update_user"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.UpdateUser") UpdateUser

> *Tags:*  ``` Skips Authentication ``` 

> Updated user


```csharp
Task UpdateUser(string username, Models.User body)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| username |  ``` Required ```  | name that need to be updated |
| body |  ``` Required ```  | Updated user object |


#### Example Usage

```csharp
string username = "username";
var body = new Models.User();

await user.UpdateUser(username, body);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid user supplied |
| 404 | User not found |


### <a name="delete_user"></a>![Method: ](https://apidocs.io/img/method.png "SwaggerPetstore.Standard.Controllers.UserController.DeleteUser") DeleteUser

> *Tags:*  ``` Skips Authentication ``` 

> Delete user


```csharp
Task DeleteUser(string username)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| username |  ``` Required ```  | The name that needs to be deleted |


#### Example Usage

```csharp
string username = "username";

await user.DeleteUser(username);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 400 | Invalid username supplied |
| 404 | User not found |


[Back to List of Controllers](#list_of_controllers)



