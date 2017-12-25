using Newtonsoft.Json;

namespace ChatRoom.Lib.Models.SignalR
{
    public class CreateMatchHubModel
    {
        [JsonProperty("hostPlayerId")]
        public string HostPlayerId { get; set; }
        [JsonProperty("setCount")]
        public int SetCount { get; set; }
    }
    public class MatchLogModel
    {
        [JsonProperty("roomNumber")]
        public string RoomNumber { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class ClientMessage
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("fromUserId")]
        public string FromUserId { get; set; }
        [JsonProperty("toUserId")]
        public string ToUserId { get; set; }
    }

    public class GameRequest<T>
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("tournamentId")]
        public string TournamentId { get; set; }
        [JsonProperty("matchId")]
        public string MatchId { get; set; }
        [JsonProperty("setId")]
        public string SetId { get; set; }
        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        public T Data { get; set; }

        public string Action { get; set; }
    }

    public class TeamChatConnectedData
    {
        [JsonProperty("totalInvitation")]
        public int TotalInvitation { get; set; }
        [JsonProperty("isCreatedTeam")]
        public bool IsCreatedTeam { get; set; }
        //[JsonProperty("teams")]
        //public PaginationModel<TeamInfoViewModel> Teams { get; set; }
        //[JsonProperty("otherTeams")]
        //public PaginationModel<TeamInfoViewModel> OtherTeams { get; set; }

    }
}
