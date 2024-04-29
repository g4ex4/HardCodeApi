namespace Application.DTO
{
    public class Result
    {
        public Result(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public class Result<T> : Result
    {
        public Result(int code, string message, T entity) : base(code, message)
        {
            Entity = entity;
        }
        public T Entity { get; set; }
    }    
}
