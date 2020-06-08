/* 
 * Student survey system API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing SurveyResponsesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class SurveyResponsesApiTests
    {
        private SurveyResponsesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new SurveyResponsesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of SurveyResponsesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' SurveyResponsesApi
            //Assert.IsInstanceOfType(typeof(SurveyResponsesApi), instance, "instance is a SurveyResponsesApi");
        }

        /// <summary>
        /// Test SurveyResponsesGet
        /// </summary>
        [Test]
        public void SurveyResponsesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //int? page = null;
            //int? count = null;
            //var response = instance.SurveyResponsesGet(name, page, count);
            //Assert.IsInstanceOf<List<SurveyResponseDetailsDto>> (response, "response is List<SurveyResponseDetailsDto>");
        }
        /// <summary>
        /// Test SurveyResponsesIdGet
        /// </summary>
        [Test]
        public void SurveyResponsesIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //var response = instance.SurveyResponsesIdGet(id);
            //Assert.IsInstanceOf<SurveyResponseDto> (response, "response is SurveyResponseDto");
        }
        /// <summary>
        /// Test SurveyResponsesMyCompletedGet
        /// </summary>
        [Test]
        public void SurveyResponsesMyCompletedGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //int? page = null;
            //int? count = null;
            //var response = instance.SurveyResponsesMyCompletedGet(name, page, count);
            //Assert.IsInstanceOf<List<SurveyResponseDetailsDto>> (response, "response is List<SurveyResponseDetailsDto>");
        }
        /// <summary>
        /// Test SurveyResponsesPost
        /// </summary>
        [Test]
        public void SurveyResponsesPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //SurveyResponseDto body = null;
            //var response = instance.SurveyResponsesPost(body);
            //Assert.IsInstanceOf<SurveyResponseDto> (response, "response is SurveyResponseDto");
        }
    }

}
