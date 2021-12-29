using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Todoist.Client.FileParameter;
using OpenAPIDateConverter = Todoist.Client.OpenAPIDateConverter;

namespace Todoist.Model
{
    /// <summary>
    /// Project
    /// </summary>
    [DataContract(Name = "Project")]
    public partial class Project : IEquatable<Project>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="commentCount">commentCount.</param>
        /// <param name="order">order.</param>
        /// <param name="color">color.</param>
        /// <param name="shared">shared.</param>
        /// <param name="syncId">syncId.</param>
        /// <param name="favorite">favorite.</param>
        /// <param name="inboxProject">inboxProject.</param>
        /// <param name="url">url.</param>
        public Project(long id = default(long), string name = default(string), int commentCount = default(int), int order = default(int), int color = default(int), bool shared = default(bool), int syncId = default(int), bool favorite = default(bool), bool inboxProject = default(bool), string url = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.CommentCount = commentCount;
            this.Order = order;
            this.Color = color;
            this.Shared = shared;
            this.SyncId = syncId;
            this.Favorite = favorite;
            this.InboxProject = inboxProject;
            this.Url = url;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets CommentCount
        /// </summary>
        [DataMember(Name = "comment_count", EmitDefaultValue = false)]
        public int CommentCount { get; set; }

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
        /// Gets or Sets Shared
        /// </summary>
        [DataMember(Name = "shared", EmitDefaultValue = true)]
        public bool Shared { get; set; }

        /// <summary>
        /// Gets or Sets SyncId
        /// </summary>
        [DataMember(Name = "sync_id", EmitDefaultValue = false)]
        public int SyncId { get; set; }

        /// <summary>
        /// Gets or Sets Favorite
        /// </summary>
        [DataMember(Name = "favorite", EmitDefaultValue = true)]
        public bool Favorite { get; set; }

        /// <summary>
        /// Gets or Sets InboxProject
        /// </summary>
        [DataMember(Name = "inbox_project", EmitDefaultValue = true)]
        public bool InboxProject { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Project {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CommentCount: ").Append(CommentCount).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Shared: ").Append(Shared).Append("\n");
            sb.Append("  SyncId: ").Append(SyncId).Append("\n");
            sb.Append("  Favorite: ").Append(Favorite).Append("\n");
            sb.Append("  InboxProject: ").Append(InboxProject).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
            return this.Equals(input as Project);
        }

        /// <summary>
        /// Returns true if Project instances are equal
        /// </summary>
        /// <param name="input">Instance of Project to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Project input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.CommentCount == input.CommentCount ||
                    this.CommentCount.Equals(input.CommentCount)
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
                    this.Shared == input.Shared ||
                    this.Shared.Equals(input.Shared)
                ) && 
                (
                    this.SyncId == input.SyncId ||
                    this.SyncId.Equals(input.SyncId)
                ) && 
                (
                    this.Favorite == input.Favorite ||
                    this.Favorite.Equals(input.Favorite)
                ) && 
                (
                    this.InboxProject == input.InboxProject ||
                    this.InboxProject.Equals(input.InboxProject)
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
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
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CommentCount.GetHashCode();
                hashCode = (hashCode * 59) + this.Order.GetHashCode();
                hashCode = (hashCode * 59) + this.Color.GetHashCode();
                hashCode = (hashCode * 59) + this.Shared.GetHashCode();
                hashCode = (hashCode * 59) + this.SyncId.GetHashCode();
                hashCode = (hashCode * 59) + this.Favorite.GetHashCode();
                hashCode = (hashCode * 59) + this.InboxProject.GetHashCode();
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
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
