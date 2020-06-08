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
    /// UsosAuthDto
    /// </summary>
    [DataContract]
        public partial class UsosAuthDto :  IEquatable<UsosAuthDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsosAuthDto" /> class.
        /// </summary>
        /// <param name="usosAuthUrl">usosAuthUrl.</param>
        /// <param name="requestToken">requestToken.</param>
        /// <param name="tokenSecret">tokenSecret.</param>
        /// <param name="oAuthVerifier">oAuthVerifier.</param>
        public UsosAuthDto(string usosAuthUrl = default(string), string requestToken = default(string), string tokenSecret = default(string), string oAuthVerifier = default(string))
        {
            this.UsosAuthUrl = usosAuthUrl;
            this.RequestToken = requestToken;
            this.TokenSecret = tokenSecret;
            this.OAuthVerifier = oAuthVerifier;
        }
        
        /// <summary>
        /// Gets or Sets UsosAuthUrl
        /// </summary>
        [DataMember(Name="usosAuthUrl", EmitDefaultValue=false)]
        public string UsosAuthUrl { get; set; }

        /// <summary>
        /// Gets or Sets RequestToken
        /// </summary>
        [DataMember(Name="requestToken", EmitDefaultValue=false)]
        public string RequestToken { get; set; }

        /// <summary>
        /// Gets or Sets TokenSecret
        /// </summary>
        [DataMember(Name="tokenSecret", EmitDefaultValue=false)]
        public string TokenSecret { get; set; }

        /// <summary>
        /// Gets or Sets OAuthVerifier
        /// </summary>
        [DataMember(Name="oAuthVerifier", EmitDefaultValue=false)]
        public string OAuthVerifier { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UsosAuthDto {\n");
            sb.Append("  UsosAuthUrl: ").Append(UsosAuthUrl).Append("\n");
            sb.Append("  RequestToken: ").Append(RequestToken).Append("\n");
            sb.Append("  TokenSecret: ").Append(TokenSecret).Append("\n");
            sb.Append("  OAuthVerifier: ").Append(OAuthVerifier).Append("\n");
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
            return this.Equals(input as UsosAuthDto);
        }

        /// <summary>
        /// Returns true if UsosAuthDto instances are equal
        /// </summary>
        /// <param name="input">Instance of UsosAuthDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UsosAuthDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UsosAuthUrl == input.UsosAuthUrl ||
                    (this.UsosAuthUrl != null &&
                    this.UsosAuthUrl.Equals(input.UsosAuthUrl))
                ) && 
                (
                    this.RequestToken == input.RequestToken ||
                    (this.RequestToken != null &&
                    this.RequestToken.Equals(input.RequestToken))
                ) && 
                (
                    this.TokenSecret == input.TokenSecret ||
                    (this.TokenSecret != null &&
                    this.TokenSecret.Equals(input.TokenSecret))
                ) && 
                (
                    this.OAuthVerifier == input.OAuthVerifier ||
                    (this.OAuthVerifier != null &&
                    this.OAuthVerifier.Equals(input.OAuthVerifier))
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
                if (this.UsosAuthUrl != null)
                    hashCode = hashCode * 59 + this.UsosAuthUrl.GetHashCode();
                if (this.RequestToken != null)
                    hashCode = hashCode * 59 + this.RequestToken.GetHashCode();
                if (this.TokenSecret != null)
                    hashCode = hashCode * 59 + this.TokenSecret.GetHashCode();
                if (this.OAuthVerifier != null)
                    hashCode = hashCode * 59 + this.OAuthVerifier.GetHashCode();
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
