# IO.Swagger.Api.SurveyResponsesApi

All URIs are relative to *https://localhost:5001*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SurveyResponsesDetailsIdGet**](SurveyResponsesApi.md#surveyresponsesdetailsidget) | **GET** /SurveyResponses/details/{id} | 
[**SurveyResponsesGet**](SurveyResponsesApi.md#surveyresponsesget) | **GET** /SurveyResponses | 
[**SurveyResponsesIdGet**](SurveyResponsesApi.md#surveyresponsesidget) | **GET** /SurveyResponses/{id} | 
[**SurveyResponsesMyCompletedGet**](SurveyResponsesApi.md#surveyresponsesmycompletedget) | **GET** /SurveyResponses/MyCompleted | 
[**SurveyResponsesMySurveyResultsGet**](SurveyResponsesApi.md#surveyresponsesmysurveyresultsget) | **GET** /SurveyResponses/MySurveyResults | 
[**SurveyResponsesPost**](SurveyResponsesApi.md#surveyresponsespost) | **POST** /SurveyResponses | 
[**SurveyResponsesSurveyResultsIdGet**](SurveyResponsesApi.md#surveyresponsessurveyresultsidget) | **GET** /SurveyResponses/SurveyResults/{id} | 

<a name="surveyresponsesdetailsidget"></a>
# **SurveyResponsesDetailsIdGet**
> SurveyResponseDetailsDto SurveyResponsesDetailsIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesDetailsIdGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var id = 56;  // int? | 

            try
            {
                SurveyResponseDetailsDto result = apiInstance.SurveyResponsesDetailsIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesDetailsIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**SurveyResponseDetailsDto**](SurveyResponseDetailsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsesget"></a>
# **SurveyResponsesGet**
> List<SurveyResponseListItemDto> SurveyResponsesGet (string name = null, int? surveyId = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var name = name_example;  // string |  (optional) 
            var surveyId = 56;  // int? |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyResponseListItemDto&gt; result = apiInstance.SurveyResponsesGet(name, surveyId, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | [optional] 
 **surveyId** | **int?**|  | [optional] 
 **page** | **int?**|  | [optional] [default to 0]
 **count** | **int?**|  | [optional] [default to 20]

### Return type

[**List<SurveyResponseListItemDto>**](SurveyResponseListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsesidget"></a>
# **SurveyResponsesIdGet**
> SurveyResponseDetailsDto SurveyResponsesIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesIdGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var id = 56;  // int? | 

            try
            {
                SurveyResponseDetailsDto result = apiInstance.SurveyResponsesIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**SurveyResponseDetailsDto**](SurveyResponseDetailsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsesmycompletedget"></a>
# **SurveyResponsesMyCompletedGet**
> List<SurveyResponseListItemDto> SurveyResponsesMyCompletedGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesMyCompletedGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyResponseListItemDto&gt; result = apiInstance.SurveyResponsesMyCompletedGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesMyCompletedGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | [optional] 
 **page** | **int?**|  | [optional] [default to 0]
 **count** | **int?**|  | [optional] [default to 20]

### Return type

[**List<SurveyResponseListItemDto>**](SurveyResponseListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsesmysurveyresultsget"></a>
# **SurveyResponsesMySurveyResultsGet**
> List<SurveyListItemDto> SurveyResponsesMySurveyResultsGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesMySurveyResultsGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyListItemDto&gt; result = apiInstance.SurveyResponsesMySurveyResultsGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesMySurveyResultsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | [optional] 
 **page** | **int?**|  | [optional] [default to 0]
 **count** | **int?**|  | [optional] [default to 20]

### Return type

[**List<SurveyListItemDto>**](SurveyListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsespost"></a>
# **SurveyResponsesPost**
> SurveyResponseDto SurveyResponsesPost (SurveyResponseDto body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesPostExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var body = new SurveyResponseDto(); // SurveyResponseDto |  (optional) 

            try
            {
                SurveyResponseDto result = apiInstance.SurveyResponsesPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**SurveyResponseDto**](SurveyResponseDto.md)|  | [optional] 

### Return type

[**SurveyResponseDto**](SurveyResponseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyresponsessurveyresultsidget"></a>
# **SurveyResponsesSurveyResultsIdGet**
> SurveyResultsDto SurveyResponsesSurveyResultsIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveyResponsesSurveyResultsIdGetExample
    {
        public void main()
        {

            var apiInstance = new SurveyResponsesApi();
            var id = 56;  // int? | 

            try
            {
                SurveyResultsDto result = apiInstance.SurveyResponsesSurveyResultsIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveyResponsesApi.SurveyResponsesSurveyResultsIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**SurveyResultsDto**](SurveyResultsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
