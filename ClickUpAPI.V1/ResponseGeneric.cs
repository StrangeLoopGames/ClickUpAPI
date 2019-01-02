using PaironsTech.ClickUpAPI.V1.Responses;

namespace PaironsTech.ClickUpAPI.V1
{
    public class ResponseGeneric<TResponseSuccess> where TResponseSuccess : Response
    {

        // Attributes

        /// <summary>
        /// Contain Success Response of the Method. If there is error is null.
        /// </summary>
        public TResponseSuccess ResponseSuccess { get; set; }

        /// <summary>
        /// Contain Error Response of the Method. If there isn't error is null.
        /// </summary>
        public ResponseError ResponseError { get; set; }



        // Constructor
        public ResponseGeneric()
        {
            ResponseSuccess = null;
            ResponseError = null;
        }

    }
}
