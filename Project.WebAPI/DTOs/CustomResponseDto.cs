using System.Text.Json.Serialization;

namespace Project.WebAPI.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        // Postman veya Swagger bu datayı{StatusCode} dönüyor. Ama bana program için lazım olabileceğinden ötürü JsonIgnore kullandık.
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }


        // static => newlemeden ulaşabilmek için.
        // static factory method
        // factory design pattern'den gelir.
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }
        // overload method
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode};
        }

        public static CustomResponseDto<T> Fail(int statusCode,List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode , Errors = errors};
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
