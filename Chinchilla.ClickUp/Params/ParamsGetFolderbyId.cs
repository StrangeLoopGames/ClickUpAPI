using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Chinchilla.ClickUp.Params
{

	/// <summary>
	/// The param object of Get folder by id request
	/// </summary>
	public class ParamsGetFolderById
	{
		#region Attributes

		/// <summary>
		/// The Folder Id 
		/// </summary>
		[JsonProperty("folder_id")]
		[DataMember(Name = "folder_id")]
		public string FolderId { get; set; }

		#endregion


		#region Constructor

		/// <summary>
		/// The constructor of ParamsGetFolderById
		/// </summary>
		/// <param name="listId"></param>
		public ParamsGetFolderById(string listId)
		{
			FolderId = listId;
		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Method that validate the data insert
		/// </summary>
		public void ValidateData()
		{
			if (string.IsNullOrEmpty(FolderId))
			{
				throw new ArgumentNullException("FolderId");
			}
		}

		#endregion
	}
}