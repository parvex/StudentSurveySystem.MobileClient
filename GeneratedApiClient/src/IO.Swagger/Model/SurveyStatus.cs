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
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Defines SurveyStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
        public enum SurveyStatus
    {
        /// <summary>
        /// Enum Draft for value: Draft
        /// </summary>
        [EnumMember(Value = "Draft")]
        Draft = 1,
        /// <summary>
        /// Enum Active for value: Active
        /// </summary>
        [EnumMember(Value = "Active")]
        Active = 2,
        /// <summary>
        /// Enum Ended for value: Ended
        /// </summary>
        [EnumMember(Value = "Ended")]
        Ended = 3    }
}
