using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Communication.Responses
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(IList<string> errors)
        {
            Errors = errors;
        }

        public IList<string> Errors { get; set; }

        public ResponseErrorJson(string error)
        {
            Errors = [error];
        }



    }
}
