using System.ComponentModel.DataAnnotations;

namespace EF_Core.WebApi.Utilities
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Operation has been successful")]
        Succeded = 0,
        [Display(Name = "Operation has been failed")]
        Failed = 1,
    }
}
