using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Lib.Helpers
{
    public class MessengerConstants
    {
        public static string Domain = "";
        public static string DefaultAvatar = "https://vignette.wikia.nocookie.net/caseclosed/images/0/06/Shadow_Person.PNG";
    }
    public enum GameResponseKey
    {
        UpdateConnectionIdSucceed,

        WithdrawFailed,
        WithdrawSucceed,
        KickPlayersSucceed,
        SuddenDeathSucceed,
        UndoScoreSucceed,
        AdjustPointSucceed,
        AddPointSucceed,

        CreateTournamentSucceed,
        CreateTournamentFailed,
        NotAuthorized,
        StartTournamentSucceed,
        StartTournamentFailed,
        GetTournamentSucceed,

        TournamentNotFound,
        TournamentEnded,
        GetMatchSucceed,
        MatchNotFound,
        JoinTournamentMatchSucceed,
        TournamentMatchNotFound,
        LeaveTournamentMatchSucceed,

        CreateSucceed,
        CreateFailed,
        CreateUmpireRoomSucceed,
        CreateUmpireRoomFailed,
        RoomNotFound,

        RoomClosed,
        ShakingSucceed,
        ShakingFailed,
        SetEnded,
        MatchEnded,

        Unknown,
        ReJoinTournamentSucceed,
        JoinTournamentSucceed,
        RoomFulled,
        LeaveTournamentSucceed,


        UpdateTournamentDataSucceed,
        InvalidUser,
        JoinSucceed,
        ReJoinSucceed,
        ReJoinFailed,

        ResumeSetSucceed,
        StartSetSucceed,
        PauseSetSucceed,
        CancelRoomSucceed,
        CancelRoomFailed,

        EndTournamentMatchSucceed,
        EndMatchSucceed,
        CancelMatchSucceed,
        CancelTournamentMatchSucceed,
        RematchSucceed,

        ReTournamentSucceed,
        CancelTournamentSucceed,
        CancelTournamentFail,
        Failed,
        UserDisconnected
    }
    public enum ApiResponseKey
    {
        Succeed,
        Failed,
        Add,
        Edit,
        Delete
    }
    public enum MessageReponseKey
    {
        NewInvite,
        NewRequest,
        RemovedTeam,
        RemovedMember,
        NewTeam,
        NewMember,
        UpdateMember,
        UpdateOnlineStatus,
        Connect,
        GetTeam,
        GetTeamMessages,
        SendMessage,
        GetTeamNotifications,
        NotMembered,
        CancelRequest,
        RejectInvite
    }

    public enum TeamResponseKey
    {
        GetTeamsSucceed,
        GetTeamsFailed,

        SaveTeamSucceed,
        SaveTeamFailed,
        InvalidModel,
        NameExisted,
        NameRequired,
        CountryRequired,

        SearchTeamMembersSucceed,
        SearchTeamMembersFailed,

        SetMemberStatusSucceed,
        SetMemberStatusFailed,
        NotAuthorized,
        TeamFulled
    }

    public enum MemberStatus
    {
        Requested = 0,
        Invited = 1,
        AdminRejected = 2,
        MemberRejected = 3,
        Banned = 4,
        Membered = 5,
        AdminRemoved = 6,
        MemberCanceled = 7,
        Guest = 8,
        MemberAccepted = 9,
        MemberLeft = 10
    }

    public enum MessageType
    {
        String = 0,
        Notification = 1,
        Image = 2,
        File = 3,
        Voice = 4,
        Location = 5,
        Html = 6
    }

    public enum NotificationType
    {
        NewMessage = 0,
        Join = 1,
        Left = 2
    }
}
