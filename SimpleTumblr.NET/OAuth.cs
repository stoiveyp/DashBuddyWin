using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DashBuddy.API
{
    public static class OAuth
    {
        public static string ConsumerKey {get;set;}
        public static string ConsumerSecret { get; set; }

        private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "1234567890";
        private static readonly char[] ValidChars = (UpperCase + LowerCase + Digits + "-._~").ToCharArray();

        public static string GetKeyUrl(string url, Dictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            parameters.Add("api_key", ConsumerKey);
            return GetUnauthorisedContentAsync(url, parameters);
        }

        private static string GetUnauthorisedContentAsync(string url, Dictionary<string, object> parameters)
        {
            parameters.Add("d", DateTime.Now.Ticks.ToString());
            var first = true;
            var str = new StringBuilder("");
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    if (!first)
                    {
                        str.Append("&");
                    }
                    first = false;
                    UrlEncode(str, p.Key);
                    str.Append("=");
                    UrlEncode(str, p.Value.ToString());
                }
            }
            var req = (HttpWebRequest)((str.Length > 0) ? WebRequest.Create(url + "?" + str.ToString()) : WebRequest.Create(url));
            req.Method = "GET";

            var resp = req.GetResponse();
            string content = null;
            using (var stream = new StreamReader(resp.GetResponseStream()))
            {
                content = stream.ReadToEnd();
            }
            return content;
        }

        private static string PostData(String url, string method, string header, Dictionary<string, object> parameters, System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken))
        {
            var Response = (HttpWebResponse)PostDataResponse(url, method, header, parameters, cancelToken);
            StreamReader ResponseDataStream = new StreamReader(Response.GetResponseStream());
            return ResponseDataStream.ReadToEnd();
        }

        private static WebResponse PostDataResponse(String url, string method, string header, Dictionary<string, object> parameters, System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken))
        {
            HttpWebRequest Request;
            if (parameters == null)
            {
                Request = (HttpWebRequest)WebRequest.Create(url);
                Request.Method = method.ToUpper();
            }
            else
            {
                Request = (HttpWebRequest)WebRequest.Create(url);
                Request.Method = method.ToUpper();
                if (method == "POST")
                {
                    Request.ContentType = "application/x-www-form-urlencoded";
                    using (var str = Request.GetRequestStream())
                    {
                        var first = true;
                        foreach (var p in parameters)
                        {
                            if (cancelToken != null && cancelToken.IsCancellationRequested)
                            {
                                throw new OperationCanceledException();
                            }

                            if (!first)
                            {
                                str.WriteByte((byte)'&');
                            }
                            first = false;
                            UrlEncode(str, p.Key);
                            str.WriteByte((byte)'=');
                            if (p.Value is byte[])
                            {
                                var eam = (byte[])p.Value;
                                EncodeBodyStream(str, eam);
                            }
                            else
                            {
                                UrlEncode(str, p.Value.ToString());
                            }
                        }
                    }
                }
                else
                {
                    var first = true;
                    var str = new StringBuilder("");
                    foreach (var p in parameters)
                    {
                        if (cancelToken != null && cancelToken.IsCancellationRequested)
                        {
                            throw new OperationCanceledException();
                        }

                        if (!first)
                        {
                            str.Append("&");
                        }
                        first = false;
                        UrlEncode(str, p.Key);
                        str.Append("=");
                        UrlEncode(str, p.Value.ToString());
                    }
                    Request = (HttpWebRequest)WebRequest.Create(url + "?" + str.ToString());
                    Request.Method = method.ToUpper();
                }
            }

            Request.Headers[HttpRequestHeader.Authorization] = header;
            try
            {
                return Request.GetResponse();
            }
            catch (WebException ex)
            {
                return ex.Response;
            }
        }

        private static string GetSignature(string url, string method, string nonce, string timestamp, string token, string tokenSecret, Dictionary<string, object> parameters)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("oauth_consumer_key", ConsumerKey);
            dict.Add("oauth_nonce", nonce.ToString());
            dict.Add("oauth_signature_method", "HMAC-SHA1");
            dict.Add("oauth_timestamp", timestamp);
            dict.Add("oauth_token", token);
            dict.Add("oauth_version", "1.0");
            var sigBase = new StringBuilder();
            var first = true;
            foreach (var d in (parameters == null ? dict : dict.Union(parameters)).OrderBy(p => p.Key))
            {
                if (!first)
                {
                    sigBase.Append("&");
                }
                first = false;
                if (d.Key.StartsWith("data"))
                {
                    sigBase.Append(d.Key);
                }
                else
                {
                    UrlEncode(sigBase, d.Key);
                }
                sigBase.Append("=");
                if (d.Value is byte[])
                {
                    EncodeSigStream(sigBase, (byte[])d.Value);
                }
                else
                {
                    UrlEncode(sigBase, d.Value.ToString());
                }
            }

            String SigBaseString = method.ToUpper() + "&";
            SigBaseString += UrlEncode(url) + "&" + UrlEncode(sigBase.ToString(), false);

            var keyMaterial = Encoding.UTF8.GetBytes(ConsumerSecret + "&" + tokenSecret);
            var HmacSha1Provider = new System.Security.Cryptography.HMACSHA1 { Key = keyMaterial };
            return Convert.ToBase64String(HmacSha1Provider.ComputeHash(Encoding.UTF8.GetBytes(SigBaseString)));
        }

        private static readonly byte[] percentExtend = System.Text.Encoding.UTF8.GetBytes("25");
        private static readonly byte[] TildeExtend = System.Text.Encoding.UTF8.GetBytes("%7E");
        private static void EncodeBodyStream(Stream osb, byte[] buffer)
        {
            int i = -1, last = -1;
            char c;
            byte[] pieces;
            for (var x = 0; x < buffer.Length; x++)
            {
                i = buffer[x];
                c = (char)i;
                pieces = System.Text.Encoding.UTF8.GetBytes(new[] { c });

                if (last == 37)
                {
                    osb.Write(percentExtend, 0, 2);
                }

                if (pieces[0] == 37 && (pieces.Length > 1 && pieces[1] == 37))
                {
                    osb.Write(System.Text.Encoding.UTF8.GetBytes("%25%"), 0, 4);
                }
                else if (!ValidChars.Contains(c) && c != '~' && c != '%')
                {
                    var res = string.Format("%{0:X2}", i);
                    if (res == "%20")
                    {
                        osb.WriteByte((byte)'+');
                    }
                    else
                    {
                        osb.Write(System.Text.Encoding.UTF8.GetBytes(res), 0, 3);
                    }
                }
                else
                {
                    if (c == '~')
                    {
                        osb.Write(TildeExtend, 0, 3);
                    }
                    else
                    {
                        osb.WriteByte((byte)i);
                    }
                }

                last = pieces.Last();
            }
        }


        private static void EncodeSigStream(StringBuilder osb, byte[] buffer)
        {
            for (var x = 0; x < buffer.Length; x++)
            {
                byte b = (byte)buffer[x];
                if (ValidChars.Contains((char)b) && (((char)b) != '%'))
                {
                    osb.Append((char)b);
                }
                else
                {
                    if (osb[osb.Length - 1] == '%' && ((char)b) == '%')
                    {
                        osb.Append("25%");
                    }
                    else
                    {
                        osb.AppendFormat("%25{0:X2}", (int)b);
                    }
                }
            }
        }

        public static HttpWebResponse OAuthDataResponse(string url, string method, string token, string secret, Dictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            parameters.Add("d", DateTime.Now.Ticks.ToString());

            var header = OAuthHeader(url, method, token, secret, parameters);

            var response = (HttpWebResponse)PostDataResponse(url, method, header, parameters);
            return response;
        }

        public static string OAuthData(string url, string method, string token, string secret, Dictionary<string, object> parameters, System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken))
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            parameters.Add("d", DateTime.Now.Ticks.ToString());

            var header = OAuthHeader(url, method, token, secret, parameters);

            return PostData(url, method, header, parameters, cancelToken);
        }

        private static string OAuthHeader(string url, string method, string token, string secret, Dictionary<string, object> parameters)
        {
            TimeSpan SinceEpoch = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            Random Rand = new Random();
            Int32 Nonce = Rand.Next(1000000000);
            var sig = GetSignature(url, method, Nonce.ToString(), Math.Round(SinceEpoch.TotalSeconds).ToString(), token, secret, parameters);
            return "OAuth oauth_consumer_key=\"" + ConsumerKey + "\", oauth_nonce=\"" + Nonce.ToString() + "\", oauth_signature=\"" + UrlEncode(sig) + "\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"" + Math.Round(SinceEpoch.TotalSeconds) + "\", oauth_token=\"" + token + "\", oauth_version=\"1.0\"";
        }

        public static string UrlEncode(string toEncode)
        {
            var osb = new StringBuilder();
            UrlEncode(osb, toEncode);
            return osb.ToString();
        }

        public static string UrlEncode(string toEncode, bool encode)
        {
            var osb = new StringBuilder();
            UrlEncode(osb, toEncode, encode);
            return osb.ToString();
        }

        public static void UrlEncode(Stream osb, String ToEncode)
        {
            for (int Index = 0; Index < ToEncode.Length; Index++)
            {
                char Test = ToEncode[Index];
                if ((Test >= 'A' && Test <= 'Z') ||
                    (Test >= 'a' && Test <= 'z') ||
                    (Test >= '0' && Test <= '9'))
                {
                    osb.WriteByte((byte)Test);
                }
                else if (Test == '-' || Test == '_' || Test == '.' || Test == '~')
                {
                    osb.WriteByte((byte)Test);
                }
                else
                {
                    osb.WriteByte((byte)'%');
                    osb.Write(System.Text.Encoding.UTF8.GetBytes(string.Format("{0:X2}", (int)Test)), 0, 2);
                }
            }
        }

        public static void UrlEncode(StringBuilder osb, String ToEncode)
        {
            UrlEncode(osb, ToEncode, false);
        }

        public static void UrlEncode(StringBuilder osb, String ToEncode, bool encode)
        {
            for (int Index = 0; Index < ToEncode.Length; Index++)
            {
                char Test = ToEncode[Index];
                if ((Test >= 'A' && Test <= 'Z') ||
                    (Test >= 'a' && Test <= 'z') ||
                    (Test >= '0' && Test <= '9'))
                {
                    osb.Append(Test);
                }
                else if (Test == '-' || Test == '_' || Test == '.' || Test == '~')
                {
                    osb.Append(Test);
                }
                else if (Test == '%' && ToEncode[Index + 1] == '2' && ToEncode[Index + 2] == '5')
                {
                    osb.Append("%25");
                    Index += 2;
                    continue;
                }
                else
                {
                    if (encode)
                    {
                        osb.Append("%25");
                    }
                    else
                    {
                        osb.Append("%");
                    }
                    osb.AppendFormat("{0:X2}", (int)Test);
                }
            }
        }

        public static KeyValuePair<string, string> XAuthAccess(string username, string password)
        {
            TimeSpan SinceEpoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToUniversalTime());
            Random Rand = new Random();
            String url = "http://www.tumblr.com/oauth/access_token";
            Int32 Nonce = Rand.Next(1000000000);

            var osb = new StringBuilder();
            osb.Append("oauth_consumer_key=");
            osb.Append(ConsumerKey);
            osb.Append("&"); osb.Append("oauth_nonce="); osb.Append(Nonce.ToString());
            osb.Append("&"); osb.Append("oauth_signature_method=HMAC-SHA1");
            osb.Append("&"); osb.Append("oauth_timestamp="); osb.Append(Math.Round(SinceEpoch.TotalSeconds));
            osb.Append("&"); osb.Append("oauth_version=1.0");
            osb.Append("&"); osb.Append("x_auth_mode=client_auth");
            osb.Append("&"); osb.Append("x_auth_password="); UrlEncode(osb, password);
            osb.Append("&"); osb.Append("x_auth_username="); UrlEncode(osb, username);
            var SigBaseString = "POST&" + UrlEncode(url) + "&" + UrlEncode(osb.ToString());

            var keyMaterial = Encoding.UTF8.GetBytes(ConsumerSecret + "&");
            var HmacSha1Provider = new System.Security.Cryptography.HMACSHA1 { Key = keyMaterial };
            var sig = Convert.ToBase64String(HmacSha1Provider.ComputeHash(Encoding.UTF8.GetBytes(SigBaseString)));
            String DataToPost = "OAuth oauth_consumer_key=\"" + ConsumerKey + "\", oauth_nonce=\"" + Nonce.ToString() + "\", oauth_signature=\"" + UrlEncode(sig) + "\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"" + Math.Round(SinceEpoch.TotalSeconds) + "\", oauth_version=\"1.0\"";

            var xauth = new Dictionary<string, object>();
            xauth.Add("x_auth_mode", "client_auth");
            xauth.Add("x_auth_username", username);
            xauth.Add("x_auth_password", password);


            var m_PostResponse = PostData(url, "POST", DataToPost, xauth);

            if (m_PostResponse != null)
            {
                String oauth_token = null;
                String oauth_token_secret = null;
                String[] keyValPairs = m_PostResponse.Split('&');

                if (keyValPairs.Length < 2)
                {
                    throw new InvalidOperationException("Invalid Login");
                }

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            oauth_token = splits[1];
                            break;
                        case "oauth_token_secret":
                            oauth_token_secret = splits[1];
                            break;
                    }
                }

                return new KeyValuePair<string, string>(oauth_token, oauth_token_secret);
            }
            return default(KeyValuePair<string, string>);
        }
    }
}
