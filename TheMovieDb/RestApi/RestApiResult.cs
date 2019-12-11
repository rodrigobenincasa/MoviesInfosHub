using System.Collections.Generic;

namespace TheMovieDb.RestApi
{
    public class RestApiResult
    {
        public string request { get; set; }
        public string response { get; set; }
        public int responseCode { get; set; }
        public bool restFailed { get; set; }

        public RestApiResult() { }

        public RestApiResult(string request, string response, int responseCode, bool restFailed)
        {
            this.request      = request;
            this.response     = response;
            this.responseCode = responseCode;
            this.restFailed   = restFailed;
        }

        public static string RestApiResultListRequest(List<RestApiResult> restApiResultList)
        {
            string restApiResultListRequest = "";

            foreach (var item in restApiResultList)
            {
                restApiResultListRequest += item.request;
            }

            return restApiResultListRequest;
        }

        public static string RestApiResultListResponse(List<RestApiResult> restApiResultList)
        {
            string restApiResultListRequest = "";

            foreach (var item in restApiResultList)
            {
                restApiResultListRequest += item.response;
            }

            return restApiResultListRequest;
        }
    }
}
