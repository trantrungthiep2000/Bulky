namespace Bulky.Model.Models
{
    /// <summary>
    /// Information of error view model
    /// CreatedBy: ThiepTT(25/09/2023)
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id of request
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Show request id 
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}