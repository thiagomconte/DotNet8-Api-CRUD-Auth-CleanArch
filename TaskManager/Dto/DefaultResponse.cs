namespace TaskManager.Dto
{
    public class DefaultResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;

        public DefaultResponse(T? data, string message)
        {
            Data = data;
            Message = message;
        }

        public DefaultResponse(T data)
        {
            Data = data;
        }

        public DefaultResponse(string message)
        {
            Message = message;
        }
    }
}
