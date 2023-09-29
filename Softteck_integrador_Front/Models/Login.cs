namespace UmsaSofttekFront.Models
{
    //public class Login
    //{
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public string Token { get; set; }
    //}
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
    }

    public class LoginResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

}
