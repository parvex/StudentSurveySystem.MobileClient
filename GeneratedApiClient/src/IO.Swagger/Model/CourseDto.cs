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
    /// CourseDto
    /// </summary>
    [DataContract]
        public partial class CourseDto :  IEquatable<CourseDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDto" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="semesterId">semesterId.</param>
        /// <param name="semesterName">semesterName.</param>
        /// <param name="leaderId">leaderId.</param>
        public CourseDto(int? id = default(int?), string name = default(string), int? semesterId = default(int?), string semesterName = default(string), int? leaderId = default(int?))
        {
            this.Id = id;
            this.Name = name;
            this.SemesterId = semesterId;
            this.SemesterName = semesterName;
            this.LeaderId = leaderId;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets SemesterId
        /// </summary>
        [DataMember(Name="semesterId", EmitDefaultValue=false)]
        public int? SemesterId { get; set; }

        /// <summary>
        /// Gets or Sets SemesterName
        /// </summary>
        [DataMember(Name="semesterName", EmitDefaultValue=false)]
        public string SemesterName { get; set; }

        /// <summary>
        /// Gets or Sets LeaderId
        /// </summary>
        [DataMember(Name="leaderId", EmitDefaultValue=false)]
        public int? LeaderId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CourseDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SemesterId: ").Append(SemesterId).Append("\n");
            sb.Append("  SemesterName: ").Append(SemesterName).Append("\n");
            sb.Append("  LeaderId: ").Append(LeaderId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CourseDto);
        }

        /// <summary>
        /// Returns true if CourseDto instances are equal
        /// </summary>
        /// <param name="input">Instance of CourseDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CourseDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.SemesterId == input.SemesterId ||
                    (this.SemesterId != null &&
                    this.SemesterId.Equals(input.SemesterId))
                ) && 
                (
                    this.SemesterName == input.SemesterName ||
                    (this.SemesterName != null &&
                    this.SemesterName.Equals(input.SemesterName))
                ) && 
                (
                    this.LeaderId == input.LeaderId ||
                    (this.LeaderId != null &&
                    this.LeaderId.Equals(input.LeaderId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.SemesterId != null)
                    hashCode = hashCode * 59 + this.SemesterId.GetHashCode();
                if (this.SemesterName != null)
                    hashCode = hashCode * 59 + this.SemesterName.GetHashCode();
                if (this.LeaderId != null)
                    hashCode = hashCode * 59 + this.LeaderId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
