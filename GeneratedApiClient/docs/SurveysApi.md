# IO.Swagger.Api.SurveysApi

All URIs are relative to *https://localhost:5001*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SurveysGet**](SurveysApi.md#surveysget) | **GET** /Surveys | 
[**SurveysIdDelete**](SurveysApi.md#surveysiddelete) | **DELETE** /Surveys/{id} | 
[**SurveysIdGet**](SurveysApi.md#surveysidget) | **GET** /Surveys/{id} | 
[**SurveysIdPut**](SurveysApi.md#surveysidput) | **PUT** /Surveys/{id} | 
[**SurveysMyNotFilledFormGet**](SurveysApi.md#surveysmynotfilledformget) | **GET** /Surveys/MyNotFilledForm | 
[**SurveysMySurveyTemplatesGet**](SurveysApi.md#surveysmysurveytemplatesget) | **GET** /Surveys/MySurveyTemplates | 
[**SurveysMySurveysGet**](SurveysApi.md#surveysmysurveysget) | **GET** /Surveys/MySurveys | 
[**SurveysPost**](SurveysApi.md#surveyspost) | **POST** /Surveys | 
[**SurveysPut**](SurveysApi.md#surveysput) | **PUT** /Surveys | 
[**SurveysStartSurveyFromTemplatePost**](SurveysApi.md#surveysstartsurveyfromtemplatepost) | **POST** /Surveys/StartSurveyFromTemplate | 

<a name="surveysget"></a>
# **SurveysGet**
> List<SurveyDto> SurveysGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyDto&gt; result = apiInstance.SurveysGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysGet: " + e.Message );
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

[**List<SurveyDto>**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysiddelete"></a>
# **SurveysIdDelete**
> void SurveysIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysIdDeleteExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.SurveysIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysIdDelete: " + e.Message );
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

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysidget"></a>
# **SurveysIdGet**
> SurveyDto SurveysIdGet (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysIdGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var id = 56;  // int? | 

            try
            {
                SurveyDto result = apiInstance.SurveysIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysIdGet: " + e.Message );
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

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysidput"></a>
# **SurveysIdPut**
> void SurveysIdPut (int? id, SurveyDto body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysIdPutExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var id = 56;  // int? | 
            var body = new SurveyDto(); // SurveyDto |  (optional) 

            try
            {
                apiInstance.SurveysIdPut(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **body** | [**SurveyDto**](SurveyDto.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmynotfilledformget"></a>
# **SurveysMyNotFilledFormGet**
> List<SurveyDto> SurveysMyNotFilledFormGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysMyNotFilledFormGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyDto&gt; result = apiInstance.SurveysMyNotFilledFormGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysMyNotFilledFormGet: " + e.Message );
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

[**List<SurveyDto>**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmysurveytemplatesget"></a>
# **SurveysMySurveyTemplatesGet**
> List<SurveyDto> SurveysMySurveyTemplatesGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysMySurveyTemplatesGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyDto&gt; result = apiInstance.SurveysMySurveyTemplatesGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysMySurveyTemplatesGet: " + e.Message );
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

[**List<SurveyDto>**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmysurveysget"></a>
# **SurveysMySurveysGet**
> List<SurveyDto> SurveysMySurveysGet (string name = null, int? page = null, int? count = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysMySurveysGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var name = name_example;  // string |  (optional) 
            var page = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 20)

            try
            {
                List&lt;SurveyDto&gt; result = apiInstance.SurveysMySurveysGet(name, page, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysMySurveysGet: " + e.Message );
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

[**List<SurveyDto>**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyspost"></a>
# **SurveysPost**
> SurveyDto SurveysPost (SurveyDto body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysPostExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var body = new SurveyDto(); // SurveyDto |  (optional) 

            try
            {
                SurveyDto result = apiInstance.SurveysPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**SurveyDto**](SurveyDto.md)|  | [optional] 

### Return type

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysput"></a>
# **SurveysPut**
> SurveyDto SurveysPut (SurveyDto body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysPutExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var body = new SurveyDto(); // SurveyDto |  (optional) 

            try
            {
                SurveyDto result = apiInstance.SurveysPut(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**SurveyDto**](SurveyDto.md)|  | [optional] 

### Return type

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysstartsurveyfromtemplatepost"></a>
# **SurveysStartSurveyFromTemplatePost**
> void SurveysStartSurveyFromTemplatePost (SurveyDto body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysStartSurveyFromTemplatePostExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();
            var body = new SurveyDto(); // SurveyDto |  (optional) 

            try
            {
                apiInstance.SurveysStartSurveyFromTemplatePost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysStartSurveyFromTemplatePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**SurveyDto**](SurveyDto.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)