using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Todoist.Models
{
    /// <summary>
    /// LabelUpdate
    /// </summary>
    [DataContract(Name = "LabelUpdate")]
    public partial class LabelUpdate : IEquatable<LabelUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelUpdate" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="order">order.</param>
        /// <param name="color">color.</param>
        /// <param name="favorite">favorite.</param>
        public LabelUpdate(string name = default(string), int order = default(int), int color = default(int), bool favorite = default(bool))
        {
            this.Name = name;
            this.Order = order;
            this.Color = color;
            this.Favorite = favorite;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public int Order { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [DataMember(Name = "color", EmitDefaultValue = false)]
        public int Color { get; set; }

        /// <summary>
        /// Gets or Sets Favorite
        /// </summary>
        [DataMember(Name = "favorite", EmitDefaultValue = true)]
        public bool Favorite { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LabelUpdate {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Favorite: ").Append(Favorite).Append("\n");
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
            return this.Equals(input as LabelUpdate);
        }

        /// <summary>
        /// Returns true if LabelUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of LabelUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LabelUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Order == input.Order ||
                    this.Order.Equals(input.Order)
                ) && 
                (
                    this.Color == input.Color ||
                    this.Color.Equals(input.Color)
                ) && 
                (
                    this.Favorite == input.Favorite ||
                    this.Favorite.Equals(input.Favorite)
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Order.GetHashCode();
                hashCode = (hashCode * 59) + this.Color.GetHashCode();
                hashCode = (hashCode * 59) + this.Favorite.GetHashCode();
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
