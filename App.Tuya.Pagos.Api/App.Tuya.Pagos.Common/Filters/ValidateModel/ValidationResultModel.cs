using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static App.Tuya.Pagos.Common.Resources.GenericValuesResource;

namespace App.Tuya.Pagos.Common.Filters.ValidateModel
{
    public class ValidationResultModel
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public List<ValidationError> Detalle { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Codigo = (int)HttpStatusCode.BadRequest;
            Mensaje = resultModelMsg;
            Detalle = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }

    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Atributo { get; }

        public string Mensage { get; }

        public ValidationError(string field, string message)
        {
            Atributo = field != string.Empty ? field : null;
            Mensage = message;
        }
    }
}
