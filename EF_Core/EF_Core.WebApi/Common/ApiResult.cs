namespace EF_Core.WebApi.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }   
        public T Data { get; set; }
        public string Error { get; set; }
        public ApiResponse() 
        {
            Success = true;
        }
    }
}
