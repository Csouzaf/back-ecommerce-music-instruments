using System.Dynamic;
using System.Net;

namespace ecommerce_music_back.Dtos
{
    public class GenericResponse<T> where T : class
    {
        public HttpStatusCode httpStatusCode { get; set; }

        public ExpandoObject returnError { get; set; }

        public T? returnData { get; set; }
    }
}