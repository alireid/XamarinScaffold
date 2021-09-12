using System;
using System.IO;
using System.Net;
using Foundation;
using Newtonsoft.Json;
using SkiaSharp;

namespace scaffold.Helpers
{
    public static class Utility
    {

            public static string SerializeObject(object obj)
            {
                return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            }


            public static T DeserializeObject<T>(string value)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            public static string NiceNumbers(int number)
            {
                int _number = Convert.ToInt32(number);
                string name = "";
                switch (_number)
                {

                    case 1:
                        name = "one";
                        break;
                    case 2:
                        name = "two";
                        break;
                    case 3:
                        name = "three";
                        break;
                    case 4:
                        name = "four";
                        break;
                    case 5:
                        name = "five";
                        break;
                    case 6:
                        name = "six";
                        break;
                    case 7:
                        name = "seven";
                        break;
                    case 8:
                        name = "eight";
                        break;
                    case 9:
                        name = "nine";
                        break;
                    case 10:
                        name = "ten";
                        break;
                    case 11:
                        name = "eleven";
                        break;
                    case 12:
                        name = "twelve";
                        break;
                    case 13:
                        name = "thirteen";
                        break;
                    case 14:
                        name = "fourteen";
                        break;
                    case 15:
                        name = "fifteen";
                        break;
                    case 16:
                        name = "sixteen";
                        break;
                    case 17:
                        name = "seventeen";
                        break;
                    case 18:
                        name = "eighteen";
                        break;
                    case 19:
                        name = "nineteen";
                        break;
                    case 20:
                        name = "twenty";
                        break;
                    case 30:
                        name = "thirty";
                        break;
                    case 40:
                        name = "fourty";
                        break;
                    case 50:
                        name = "fifty";
                        break;
                    case 60:
                        name = "sixty";
                        break;
                    case 70:
                        name = "seventy";
                        break;
                    case 80:
                        name = "eighty";
                        break;
                    case 90:
                        name = "ninety";
                        break;
                }
                return name;
            }


        public static SKTypeface GetCustomFont(string name)
        {
            string fontFile = Path.Combine(NSBundle.MainBundle.BundlePath, name);
            SkiaSharp.SKTypeface typeFace;

            using (var asset = File.OpenRead(fontFile))
            {
                var fontStream = new MemoryStream();
                asset.CopyTo(fontStream);
                fontStream.Flush();
                fontStream.Position = 0;
                typeFace = SKTypeface.FromStream(fontStream);
            }

            return typeFace;
        }


        /// <summary>
        /// Could use this to post, and get
        /// End point could accept a param, or number thereof, and do SQL based based tasks from a PHP file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DataRequest(string url)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (System.IO.Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    WebResponse errorResponse = ex.Response;
                    using (System.IO.Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd();
                        return errorText;
                    }
                    throw;
                }
        }
    }
}
