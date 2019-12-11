using System;
using System.Collections;

namespace TheMovieDb.RestApi
{
    public class RestApiFunctions
    {
        public static SortedList RestformatHeaders(string headersSqlImput)
        {
            string key = "";
            string value = "";

            SortedList headersRestApi = new SortedList();

            string[] headersSqlOutput = headersSqlImput.Split('|');

            try
            {
                foreach (string headerSql in headersSqlOutput)
                {

                    string[] headersSqlValue = headerSql.Split(':');

                    foreach (string montaHeader in headersSqlValue)
                    {
                        if (key == "")
                        {
                            key = montaHeader;
                        }
                        else
                        {
                            value = montaHeader;
                        }
                    }

                    headersRestApi.Add(key, value);

                    key = "";
                }

            }
            catch (Exception erro)
            {
                string erroException = erro.Message.ToString();
            }

            return headersRestApi;
        }

        public static string checkNullString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = "";
                return "";
            }
            else
            {
                return text;
            }
        }
    }
}
