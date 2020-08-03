# IO.Swagger.Api.SurveysApi

All URIs are relative to *https://localhost:5001*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SurveysGetSemestersAndMyCoursesGet**](SurveysApi.md#surveysgetsemestersandmycoursesget) | **GET** /Surveys/GetSemestersAndMyCourses | 
[**SurveysGetSemsAndCoursesAsStudentGet**](SurveysApi.md#surveysgetsemsandcoursesasstudentget) | **GET** /Surveys/GetSemsAndCoursesAsStudent | 
[**SurveysIdDelete**](SurveysApi.md#surveysiddelete) | **DELETE** /Surveys/{id} | 
[**SurveysIdGet**](SurveysApi.md#surveysidget) | **GET** /Surveys/{id} | 
[**SurveysIdPut**](SurveysApi.md#surveysidput) | **PUT** /Surveys/{id} | 
[**SurveysMyActiveSurveyNamesGet**](SurveysApi.md#surveysmyactivesurveynamesget) | **GET** /Surveys/MyActiveSurveyNames | 
[**SurveysMyNotFilledFormGet**](SurveysApi.md#surveysmynotfilledformget) | **GET** /Surveys/MyNotFilledForm | 
[**SurveysMySurveyTemplatesGet**](SurveysApi.md#surveysmysurveytemplatesget) | **GET** /Surveys/MySurveyTemplates | 
[**SurveysMySurveysGet**](SurveysApi.md#surveysmysurveysget) | **GET** /Surveys/MySurveys | 
[**SurveysPost**](SurveysApi.md#surveyspost) | **POST** /Surveys | 
[**SurveysPut**](SurveysApi.md#surveysput) | **PUT** /Surveys | 
[**SurveysStartSurveyFromTemplatePost**](SurveysApi.md#surveysstartsurveyfromtemplatepost) | **POST** /Surveys/StartSurveyFromTemplate | 

<a name="surveysgetsemestersandmycoursesget"></a>
# **SurveysGetSemestersAndMyCoursesGet**
> List<SemesterDto> SurveysGetSemestersAndMyCoursesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysGetSemestersAndMyCoursesGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();

            try
            {
                List&lt;SemesterDto&gt; result = apiInstance.SurveysGetSemestersAndMyCoursesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysGetSemestersAndMyCoursesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<SemesterDto>**](SemesterDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysgetsemsandcoursesasstudentget"></a>
# **SurveysGetSemsAndCoursesAsStudentGet**
> List<SemesterDto> SurveysGetSemsAndCoursesAsStudentGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysGetSemsAndCoursesAsStudentGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();

            try
            {
                List&lt;SemesterDto&gt; result = apiInstance.SurveysGetSemsAndCoursesAsStudentGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysGetSemsAndCoursesAsStudentGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<SemesterDto>**](SemesterDto.md)

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
> void SurveysIdPut (int? id, SurveyDto body = null, bool? activate = null)



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
            var activate = true;  // bool? |  (optional)  (default to false)

            try
            {
                apiInstance.SurveysIdPut(id, body, activate);
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
 **activate** | **bool?**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmyactivesurveynamesget"></a>
# **SurveysMyActiveSurveyNamesGet**
> List<string> SurveysMyActiveSurveyNamesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SurveysMyActiveSurveyNamesGetExample
    {
        public void main()
        {

            var apiInstance = new SurveysApi();

            try
            {
                List&lt;string&gt; result = apiInstance.SurveysMyActiveSurveyNamesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SurveysApi.SurveysMyActiveSurveyNamesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmynotfilledformget"></a>
# **SurveysMyNotFilledFormGet**
> List<SurveyListItemDto> SurveysMyNotFilledFormGet (string name = null, int? page = null, int? count = null)



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
                List&lt;SurveyListItemDto&gt; result = apiInstance.SurveysMyNotFilledFormGet(name, page, count);
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

[**List<SurveyListItemDto>**](SurveyListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmysurveytemplatesget"></a>
# **SurveysMySurveyTemplatesGet**
> List<SurveyListItemDto> SurveysMySurveyTemplatesGet (string name = null, int? page = null, int? count = null)



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
                List&lt;SurveyListItemDto&gt; result = apiInstance.SurveysMySurveyTemplatesGet(name, page, count);
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

[**List<SurveyListItemDto>**](SurveyListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysmysurveysget"></a>
# **SurveysMySurveysGet**
> List<SurveyListItemDto> SurveysMySurveysGet (string name = null, int? page = null, int? count = null)



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
                List&lt;SurveyListItemDto&gt; result = apiInstance.SurveysMySurveysGet(name, page, count);
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

[**List<SurveyListItemDto>**](SurveyListItemDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveyspost"></a>
# **SurveysPost**
> SurveyDto SurveysPost (SurveyDto body = null, bool? activate = null)



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
            var activate = true;  // bool? |  (optional)  (default to false)

            try
            {
                SurveyDto result = apiInstance.SurveysPost(body, activate);
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
 **activate** | **bool?**|  | [optional] [default to false]

### Return type

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysput"></a>
# **SurveysPut**
> SurveyDto SurveysPut (SurveyDto body = null, bool? activate = null)



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
            var activate = true;  // bool? |  (optional)  (default to false)

            try
            {
                SurveyDto result = apiInstance.SurveysPut(body, activate);
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
 **activate** | **bool?**|  | [optional] [default to false]

### Return type

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="surveysstartsurveyfromtemplatepost"></a>
# **SurveysStartSurveyFromTemplatePost**
> SurveyDto SurveysStartSurveyFromTemplatePost (SurveyDto body = null)



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
                SurveyDto result = apiInstance.SurveysStartSurveyFromTemplatePost(body);
                Debug.WriteLine(result);
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

[**SurveyDto**](SurveyDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
