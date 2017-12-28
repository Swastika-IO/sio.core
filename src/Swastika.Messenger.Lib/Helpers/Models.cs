using Newtonsoft.Json;
using System;

namespace Messenger.Lib.Helpers
{

    //public class MessengerRequest
    //{
    //    [JsonProperty("teamId")]
    //    public int TeamId { get; set; }
    //    [JsonProperty("userId")]
    //    public string UserId { get; set; }
    //    [JsonProperty("connectionId")]
    //    public string ConnectionId { get; set; }
    //    [JsonProperty("memberStatus")]
    //    public MemberStatus MemberStatus { get; set; }
    //    [JsonProperty("isOnline")]
    //    public bool IsOnline { get; set; }
    //    [JsonProperty("keyword")]
    //    public string Keyword { get; set; }

    //}

    public class AccessTokenViewModel
    {
        [JsonProperty("access_token")]
        public string Access_token { get; set; }
        [JsonProperty("token_type")]
        public string Token_type { get; set; }
        [JsonProperty("refresh_token")]
        public string Refresh_token { get; set; }
        [JsonProperty("expires_in")]
        public int Expires_in { get; set; }
        [JsonProperty("client_id")]
        public string Client_id { get; set; }
        [JsonProperty("issued")]
        public string Issued { get; set; }
        [JsonProperty("expires")]
        public string Expires { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        //[JsonProperty("userData")]
        //public AccountViewModel UserData { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
    }
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("as:client_id")]
        public string ClientId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("error_description")]
        public string Error { get; set; }
        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }
        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }
    }
}
