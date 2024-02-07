using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_music_back.Error
{
    public class BadRequestError :Exception
    {
        public BadRequestError() : base(){

        }
        public BadRequestError(string message) : base(message){
            
        }
    }
}