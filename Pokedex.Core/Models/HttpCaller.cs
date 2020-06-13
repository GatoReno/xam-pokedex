using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Models
{
    public class HttpCaller
    { 
        public async Task<string> GetMethod(string s)
        {
            string jsontxt;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(s);

            if (response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Accepted:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.AlreadyReported:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Ambiguous:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.BadGateway:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Conflict:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Continue:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Created:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.EarlyHints:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.ExpectationFailed:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.FailedDependency:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Forbidden:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Found:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.GatewayTimeout:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Gone:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.HttpVersionNotSupported:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.IMUsed:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.InsufficientStorage:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.LengthRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Locked:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.LoopDetected:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.MethodNotAllowed:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.MisdirectedRequest:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Moved:
                        jsontxt = response.StatusCode.ToString();
                        break;

                    case System.Net.HttpStatusCode.MultiStatus:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NetworkAuthenticationRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NoContent:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NonAuthoritativeInformation:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NotAcceptable:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NotExtended:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NotImplemented:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.NotModified:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.OK:
                        jsontxt = await response.Content.ReadAsStringAsync();
                        break;
                    case System.Net.HttpStatusCode.PartialContent:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.PaymentRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.PermanentRedirect:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.PreconditionFailed:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.PreconditionRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Processing:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;

                    case System.Net.HttpStatusCode.RedirectKeepVerb:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RedirectMethod:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RequestEntityTooLarge:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RequestTimeout:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.RequestUriTooLong:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.ResetContent:
                        jsontxt = response.StatusCode.ToString();
                        break;

                    case System.Net.HttpStatusCode.ServiceUnavailable:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.SwitchingProtocols:
                        jsontxt = response.StatusCode.ToString();
                        break;

                    case System.Net.HttpStatusCode.TooManyRequests:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.UnavailableForLegalReasons:
                        jsontxt = response.StatusCode.ToString();

                        break;
                    case System.Net.HttpStatusCode.UnprocessableEntity:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.UnsupportedMediaType:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.Unused:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.UpgradeRequired:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.UseProxy:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    case System.Net.HttpStatusCode.VariantAlsoNegotiates:
                        jsontxt = response.StatusCode.ToString();
                        break;
                    default:
                        jsontxt = response.StatusCode.ToString();
                        break;
                }

            }
            else{ jsontxt = "Error -- http get request fail "; }


            return jsontxt;
        }

    }

     

}
