using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Chinchilla.ClickUp.Params
{

	/// <summary>
	/// The param object of Get Tasks By View ID request
	/// </summary>
	public class ParamsGetTasksByViewId
	{
		#region Attributes

		/// <summary>
		/// The View Id 
		/// </summary>
		[JsonProperty("view_id")]
		[DataMember(Name = "view_id")]
		public string ViewId { get; set; }

		/// <summary>
		/// The page Id 
		/// </summary>
		[JsonProperty("page_id")]
		[DataMember(Name = "page_id")]
		public int PageId { get; set; } = 0;

		#endregion


		#region Constructor

		/// <summary>
		/// The constructor of ParamsGetTasksById
		/// </summary>
		/// <param name="teamId"></param>
		public ParamsGetTasksByViewId(string viewId, int pageId)
		{
			ViewId = viewId;
			PageId = pageId;
		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Method that validate the data insert
		/// </summary>
		public void ValidateData()
		{
			if (string.IsNullOrEmpty(ViewId))
				throw new ArgumentNullException("ViewId");

			if (PageId < 0)
				throw new ArgumentException("PageId");
		}
		#endregion
	}
}