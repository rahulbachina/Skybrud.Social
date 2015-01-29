using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Exceptions {

    public class FacebookException : Exception {

        public SocialHttpResponse Response { get; private set; }

        public int Code { get; private set; }
        public string Type { get; private set; }
        public int Subcode { get; private set; }

        public FacebookException(SocialHttpResponse response, int code, string type, string message, int subcode = 0) : base(message) {
            Response = response;
            Code = code;
            Type = type;
            Subcode = subcode;
        }

        [Obsolete]
        public static FacebookException Parse(JsonObject obj) {

            return new FacebookException(
                null,
                obj.GetInt32("code"),
                obj.GetString("type"),
                obj.GetString("message"),
                obj.HasValue("error_subcode") ? obj.GetInt32("error_subcode") : 0
            );

        }

    }

}