using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gestor.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void MensagemSessao(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetAutorizacao(this ISession session, string key, string usuarioid = "0")
        {
            session.SetString("user", key);
            session.SetString("userId", usuarioid);
        }

        /// <summary>
        /// Metodo para retornar o Id do Usuario logado
        /// </summary>
        /// <param name="session">Variavel ISession injetada no Controller</param>
        /// <returns></returns>
        public static int? GetUsuarioIdLogin(this ISession session)
        {
            return int.Parse(session.GetString("userId").ToString());
        }

        public static bool GetAutorizacao(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == "1";
        }
    }
}
