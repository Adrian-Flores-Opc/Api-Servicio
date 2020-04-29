using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public static class GerenteJson
    {
        public static void SaveJson(string path, string jsonIn)
        {
            File.WriteAllText(path,jsonIn);
        }

        public static string GetJson(Object objectIn)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Object));
            serializer.WriteObject(stream, objectIn);
            string aux = Encoding.Default.GetString(stream.ToArray());
            return aux;
        }

        private static T Deserialize<T>(string json)
        {
            var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        public static string SerializeObject<T>(this T objectIN)
        {
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(objectIN.GetType());
                serializer.WriteObject(ms, objectIN);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static Stream SerializeObjectStream<T>(this T objectRequest)
        {
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer serializerGen = new DataContractJsonSerializer(objectRequest.GetType());
                serializerGen.WriteObject(ms, objectRequest);
                return ms;
            }
        }


        public static Stream sendGenericPOST<T>(string strEndPointIN, T objectRequest)
        {
            using (var client = new WebClient())
            {
                using (var ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializerGen = new DataContractJsonSerializer(objectRequest.GetType());
                    serializerGen.WriteObject(ms, objectRequest);
                    client.Headers["Content-type"] = "application/json";
                    client.Credentials = CredentialCache.DefaultCredentials;
                    client.UseDefaultCredentials = true;
                    byte[] byteResult = client.UploadData(strEndPointIN, "POST", ms.ToArray());
                    Stream objectRsponse = new MemoryStream(byteResult);
                    return objectRsponse;
                }
            }
        }

        public static Stream sendPOST(string strEndPointIN, MemoryStream objectRequest)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            (se, cert, chain, sslerror) =>
            {
                return true;
            };


            using (var client = new WebClient())
            {
                client.Headers["Content-type"] = "application/json";
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                byte[] byteResult = client.UploadData(strEndPointIN, "POST", objectRequest.ToArray());
                Stream objectRsponse = new MemoryStream(byteResult);
                return objectRsponse;
            }
        }


        public static Stream sendGET(string strEndPointIN)
        {
            using (var client = new WebClient())
            {
                client.Headers["Content-type"] = "application/json";
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                byte[] byteResult = client.DownloadData(strEndPointIN);
                Stream objectRsponse = new MemoryStream(byteResult);
                return objectRsponse;
            }
        }

        public static T DeserializeStream<T>(Stream json)
        {
            var instance = Activator.CreateInstance<T>();
            var serializer = new DataContractJsonSerializer(instance.GetType());
            return (T)serializer.ReadObject(json);
        }
        

        #region Opcion alterna con token 
        //public static Stream sendPOSTwithToken(string strEndPoint, MemoryStream objectRequest, string Token)
        //{
        //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        //    ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
        //    using (var client = new WebClient())
        //    {
        //        client.Headers["Content-Type"] = "application/json";
        //        client.Headers["token"] = Token;
        //        client.Credentials = CredentialCache.DefaultCredentials;
        //        client.UseDefaultCredentials = true;
        //        ServicePointManager.ServerCertificateValidationCallback += delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyError) { return true; };
        //        byte[] byteResult = client.UploadData(strEndPoint, "POST", objectRequest.ToArray());
        //        Stream objectRsponse = new MemoryStream(byteResult);
        //        return objectRsponse;
        //    }
        //}
        #endregion
    }
}
