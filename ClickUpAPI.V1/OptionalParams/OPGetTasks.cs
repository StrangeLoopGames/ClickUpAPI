using Newtonsoft.Json;
using PaironsTech.ClickUpAPI.V1.Enums;
using System;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.OptionalParams
{

    /// <summary>
    /// Optional Params of Request method GetTasks() 
    /// </summary>
    public class OPGetTasks : OptionalParams
    {

        /// <summary>
        /// Rappresent the Page Filter
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Rappresent the order of Data
        /// </summary>
        [JsonProperty("order_by")]
        public TaskOrderBy? OrderBy { get; set; }

        /// <summary>
        /// Reverse Order
        /// </summary>
        [JsonProperty("reverse")]
        public bool? Reverse { get; set; }

        /// <summary>
        /// Include Subtasks
        /// </summary>
        [JsonProperty("subtasks")]
        public bool? Subtasks { get; set; }

        /// <summary>
        /// Query only on spaces with this ids
        /// </summary>
        [JsonProperty("space_ids")]
        public List<string> SpaceIds { get; set; }

        /// <summary>
        /// Query only on projects with this ids
        /// </summary>
        [JsonProperty("projects_ids")]
        public List<string> ProjectIds { get; set; }

        /// <summary>
        /// Query only on lists with this ids
        /// </summary>
        [JsonProperty("list_ids")]
        public List<string> ListIds { get; set; }

        /// <summary>
        /// Query only on status with this status
        /// </summary>
        [JsonProperty("statuses")]
        public List<string> Statuses { get; set; }

        /// <summary>
        /// Include Closed Task [Not set Statuses filter!]
        /// </summary>
        [JsonProperty("include_closed")]
        public bool? IncludeClosed { get; set; }

        /// <summary>
        /// Query only on task assign at users with this ids
        /// </summary>
        [JsonProperty("assignees")]
        public List<long> Assignees { get; set; }

        /// <summary>
        /// Filter due date greater than posix time
        /// </summary>
        [JsonProperty("due_date_gt")]
        public DateTime? DueDateGt { get; set; }

        /// <summary>
        /// Filter due date less than posix time
        /// </summary>
        [JsonProperty("due_date_lt")]
        public DateTime? DueDateLt { get; set; }

        /// <summary>
        /// Filter date created greater than posix time
        /// </summary>
        [JsonProperty("date_created_gt")]
        public DateTime? DateCreatedGt { get; set; }

        /// <summary>
        /// Filter date created less than posix time
        /// </summary>
        [JsonProperty("date_created_lt")]
        public DateTime? DateCreatedLt { get; set; }

        /// <summary>
        /// Filter date updated greater than posix time
        /// </summary>
        [JsonProperty("date_updated_gt")]
        public DateTime? DateUpdatedGt { get; set; }

        /// <summary>
        /// Filter date updated less than posix time
        /// </summary>
        [JsonProperty("date_updated_lt")]
        public DateTime? DateUpdatedLt { get; set; }
        




        /// <summary>
        /// Constructor of OptionalParams object for GetTasks() method.
        /// </summary>
        public OPGetTasks()
        {
            Page = null;
            OrderBy = null;
            Reverse = null;
            Subtasks = null;
            SpaceIds = null;
            ProjectIds = null;
            ListIds = null;
            Statuses = null;
            IncludeClosed = null;
            Assignees = null;
            DueDateGt = null;
            DueDateLt = null;
            DateCreatedGt = null;
            DateCreatedLt = null;
            DateUpdatedGt = null;
            DateUpdatedLt = null;
        }
        
    }

}
