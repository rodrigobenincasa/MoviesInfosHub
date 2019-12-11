using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;

namespace TheMovieDb.RestApi
{
    public class RestApiCommunications
    {
        public static RestApiResult CommunicationWebService(string url, string metodo, string headers, string request, RestApiResult apiResult)
        {

            string apiResponse = "";
            int apiResponseStatusCode = 900;
            bool apiRequestFailed = true;
            byte[] byteData = null;

            request = RestApiFunctions.checkNullString(request);

            SortedList apiRequestHeaders = new SortedList();
            apiRequestHeaders = RestApiFunctions.RestformatHeaders(headers);

            try
            {
                var URI = new Uri(url);
                byte[] requestApi = Encoding.UTF8.GetBytes(request);

                HttpWebRequest wc = WebRequest.Create(URI) as HttpWebRequest;

                foreach (DictionaryEntry header in apiRequestHeaders)
                {
                    switch (header.Key.ToString().ToLower())
                    {
                        case "content-type":
                            wc.ContentType = header.Value.ToString();
                            break;
                        case "accept":
                            wc.Accept = header.Value.ToString();
                            break;
                        case "":
                            break;
                        default:
                            wc.Headers[header.Key.ToString()] = header.Value.ToString();
                            break;
                    }
                }

                switch (metodo.ToUpper())
                {
                    case "GET":
                        apiResponse = WebRequestMethods.Http.Get;
                        break;
                    case "PUT":
                        wc.Method = WebRequestMethods.Http.Put;

                        byteData = UTF8Encoding.UTF8.GetBytes(request);

                        using (Stream postStream = wc.GetRequestStream())
                        {
                            postStream.Write(byteData, 0, byteData.Length);
                        }

                        break;
                    case "POST":
                        wc.Method = WebRequestMethods.Http.Post;

                        byteData = UTF8Encoding.UTF8.GetBytes(request);

                        using (Stream postStream = wc.GetRequestStream())
                        {
                            postStream.Write(byteData, 0, byteData.Length);
                        }

                        break;
                    default:
                        apiResponse = "Método não cadastrado";
                        break;
                }



                using (HttpWebResponse wcResponse = wc.GetResponse() as HttpWebResponse)
                {
                    Stream responseStream = wcResponse.GetResponseStream();
                    apiResponseStatusCode = (int)wcResponse.StatusCode;
                    apiResponse = ((new StreamReader(responseStream)).ReadToEnd());
                    apiRequestFailed = false;
                }
            }
            catch (WebException webErro)
            {
                HttpWebResponse response = webErro.Response as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                apiResponse = ((new StreamReader(responseStream)).ReadToEnd());
                apiResponseStatusCode = (int)response.StatusCode;
                apiRequestFailed = true;
            }
            catch (Exception erro)
            {
                apiResponse = erro.Message;
                apiRequestFailed = true;
                apiResponseStatusCode = 900;
            }

            RestApiResult apiResquestResult = new RestApiResult(request, apiResponse, apiResponseStatusCode, apiRequestFailed);

            return apiResquestResult;

        }
    }
}
