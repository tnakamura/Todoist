using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using OpenAPIDateConverter = Todoist.Client.OpenAPIDateConverter;

namespace Todoist.Models
{
    /// <summary>
    /// Due
    /// </summary>
    [DataContract(Name = "Due")]
    public partial class Due : IEquatable<Due>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Due" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Due() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Due" /> class.
        /// </summary>
        /// <param name="_string">_string (required).</param>
        /// <param name="date">date (required).</param>
        /// <param name="recurring">recurring (required).</param>
        /// <param name="datetime">datetime.</param>
        /// <param name="timezone">timezone.</param>
        public Due(string _string = default(string), DateTimeOffset date = default(DateTimeOffset), bool recurring = default(bool), DateTimeOffset datetime = default(DateTimeOffset), string timezone = default(string))
        {
            // to ensure "_string" is required (not null)
            if (_string == null) {
                throw new ArgumentNullException("_string is a required property for Due and cannot be null");
            }
            this.String = _string;
            this.Date = date;
            this.Recurring = recurring;
            this.Datetime = datetime;
            this.Timezone = timezone;
        }

        /// <summary>
        /// Gets or Sets String
        /// </summary>
        [DataMember(Name = "string", IsRequired = true, EmitDefaultValue = false)]
        public string String { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name = "date", IsRequired = true, EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Gets or Sets Recurring
        /// </summary>
        [DataMember(Name = "recurring", IsRequired = true, EmitDefaultValue = true)]
        public bool Recurring { get; set; }

        /// <summary>
        /// Gets or Sets Datetime
        /// </summary>
        [DataMember(Name = "datetime", EmitDefaultValue = false)]
        public DateTimeOffset Datetime { get; set; }

        /// <summary>
        /// Gets or Sets Timezone
        /// </summary>
        [DataMember(Name = "timezone", EmitDefaultValue = false)]
        public string Timezone { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Due {\n");
            sb.Append("  String: ").Append(String).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Recurring: ").Append(Recurring).Append("\n");
            sb.Append("  Datetime: ").Append(Datetime).Append("\n");
            sb.Append("  Timezone: ").Append(Timezone).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Due);
        }

        /// <summary>
        /// Returns true if Due instances are equal
        /// </summary>
        /// <param name="input">Instance of Due to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Due input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.String == input.String ||
                    (this.String != null &&
                    this.String.Equals(input.String))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Recurring == input.Recurring ||
                    this.Recurring.Equals(input.Recurring)
                ) && 
                (
                    this.Datetime == input.Datetime ||
                    (this.Datetime != null &&
                    this.Datetime.Equals(input.Datetime))
                ) && 
                (
                    this.Timezone == input.Timezone ||
                    (this.Timezone != null &&
                    this.Timezone.Equals(input.Timezone))
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
                if (this.String != null)
                {
                    hashCode = (hashCode * 59) + this.String.GetHashCode();
                }
                if (this.Date != null)
                {
                    hashCode = (hashCode * 59) + this.Date.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Recurring.GetHashCode();
                if (this.Datetime != null)
                {
                    hashCode = (hashCode * 59) + this.Datetime.GetHashCode();
                }
                if (this.Timezone != null)
                {
                    hashCode = (hashCode * 59) + this.Timezone.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
