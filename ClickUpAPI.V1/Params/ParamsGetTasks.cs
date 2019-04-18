using PaironsTech.ApiHelper.Attributes;
using PaironsTech.ApiHelper.Interfaces;
using PaironsTech.ApiHelper.ParamConverters;
using PaironsTech.ClickUpAPI.V1.Enums;
using System;
using System.Collections.Generic;

namespace PaironsTech.ClickUpAPI.V1.Params
{

    /// <summary>
    /// The param object of Get Task request
    /// </summary>
    public class ParamsGetTasks : IParams
    {

        #region Attributes

        /// <summary>
        /// The Team Id 
        /// </summary>
        [ParamProperty("team_id")]
        public string TeamId { get; set; }

        /// <summary>
        /// Rappresent the Page Filter
        /// </summary>
        [ParamProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Rappresent the order of Data
        /// </summary>
        [ParamProperty("order_by")]
        public TaskOrderBy? OrderBy { get; set; }

        /// <summary>
        /// Reverse Order
        /// </summary>
        [ParamProperty("reverse")]
        public bool? Reverse { get; set; }

        /// <summary>
        /// Include Subtasks
        /// </summary>
        [ParamProperty("subtasks")]
        public bool? Subtasks { get; set; }

        /// <summary>
        /// Query only on spaces with this ids
        /// </summary>
        [ParamProperty("space_ids[]")]
        [ParamConverter(typeof(ParamConverterIEnumerableString))]
        public List<string> SpaceIds { get; set; }

        /// <summary>
        /// Query only on projects with this ids
        /// </summary>
        [ParamProperty("projects_ids[]")]
        [ParamConverter(typeof(ParamConverterIEnumerableString))]
        public List<string> ProjectIds { get; set; }

        /// <summary>
        /// Query only on lists with this ids
        /// </summary>
        [ParamProperty("list_ids[]")]
        [ParamConverter(typeof(ParamConverterIEnumerableString))]
        public List<string> ListIds { get; set; }

        /// <summary>
        /// Query only on status with this status
        /// </summary>
        [ParamProperty("statuses[]")]
        [ParamConverter(typeof(ParamConverterIEnumerableString))]
        public List<string> Statuses { get; set; }

        /// <summary>
        /// Include Closed Task [Not set Statuses filter!]
        /// </summary>
        [ParamProperty("include_closed")]
        public bool? IncludeClosed { get; set; }

        /// <summary>
        /// Query only on task assign at users with this ids
        /// </summary>
        [ParamProperty("assignees[]")]
        [ParamConverter(typeof(ParamConverterIEnumerableLong))]
        public List<long> Assignees { get; set; }

        /// <summary>
        /// Filter due date greater than posix time
        /// </summary>
        [ParamProperty("due_date_gt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DueDateGt { get; set; }

        /// <summary>
        /// Filter due date less than posix time
        /// </summary>
        [ParamProperty("due_date_lt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DueDateLt { get; set; }

        /// <summary>
        /// Filter date created greater than posix time
        /// </summary>
        [ParamProperty("date_created_gt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DateCreatedGt { get; set; }

        /// <summary>
        /// Filter date created less than posix time
        /// </summary>
        [ParamProperty("date_created_lt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DateCreatedLt { get; set; }

        /// <summary>
        /// Filter date updated greater than posix time
        /// </summary>
        [ParamProperty("date_updated_gt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DateUpdatedGt { get; set; }

        /// <summary>
        /// Filter date updated less than posix time
        /// </summary>
        [ParamProperty("date_updated_lt")]
        [ParamConverter(typeof(ParamConverterDateTimeMilliseconds))]
        public DateTime? DateUpdatedLt { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The constructor of ParamsGetTasks
        /// </summary>
        /// <param name="teamId"></param>
        public ParamsGetTasks(string teamId)
        {
            TeamId = teamId;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method that validate the data insert
        /// </summary>
        public void ValidateData()
        {
            if (string.IsNullOrEmpty(TeamId))
            {
                throw new ArgumentNullException("TeamId");
            }
        }

        #endregion

    }

}
