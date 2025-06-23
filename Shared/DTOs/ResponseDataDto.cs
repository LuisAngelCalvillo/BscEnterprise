namespace Shared.DTOs
{
    public class ResponseDataDto<T> : ResponseDto
    {
        public T? Data { get; set; }
    }
}
