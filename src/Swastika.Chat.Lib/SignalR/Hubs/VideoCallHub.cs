using System;
using System.Collections.Generic;
using System.Text;

namespace Swastika.Messenger.Lib.SignalR.Hubs
{
    public class VideoCallHub
    {
        //#region Video Call

        //private static readonly List<ChatHubUserViewModel> Users = new List<ChatHubUserViewModel>();
        //private static readonly List<UserCall> UserCalls = new List<UserCall>();
        //private static readonly List<CallOffer> CallOffers = new List<CallOffer>();

        //public void Join(string username)
        //{
        //    // Add the new user
        //    var currentUser = Users.FirstOrDefault(u => u.NickName == username);
        //    if (currentUser==null)
        //    {
        //        currentUser = ChatHubUserViewModel.Repository.GetSingleModel(u => u.NickName == username).Data;
        //        currentUser.ConnectionId = Context.ConnectionId;
        //        Users.Add(currentUser);
        //    }
        //    else
        //    {
        //        currentUser.ConnectionId = Context.ConnectionId;
        //    }


        //    // Send down the new list to all clients
        //    SendUserListUpdate();
        //}



        //public void CallUser(string targetConnectionId)
        //{

        //    var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
        //    var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

        //    // Make sure the person we are trying to call is still here
        //    if (targetUser == null)
        //    {
        //        // If not, let the Client(Context.ConnectionId) know
        //        Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, "The user you called has left.");
        //        return;
        //    }

        //    // And that they aren't already in a call
        //    if (GetUserCall(targetUser.ConnectionId) != null)
        //    {
        //        Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, string.Format("{ 0} is already in a call.", targetUser.NickName));
        //        return;
        //    }

        //    // They are here, so tell them someone wants to talk
        //    Clients.Client(targetConnectionId).InvokeAsync("incomingCall", callingUser);

        //    // Create an offer
        //    CallOffers.Add(new CallOffer
        //    {
        //        Caller = callingUser,
        //        Callee = targetUser
        //    });
        //}

        //public void AnswerCall(bool acceptCall, string targetConnectionId)
        //{
        //    try
        //    {
        //        var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
        //        var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

        //        // This can only happen if the server-side came down and clients were cleared, while the user
        //        // still held their browser session.
        //        if (callingUser == null)
        //        {
        //            return;
        //        }

        //        // Make sure the original Client(Context.ConnectionId) has not left the page yet
        //        if (targetUser == null)
        //        {
        //            Clients.Client(Context.ConnectionId).InvokeAsync("callEnded", targetConnectionId, "The other user in your call has left.");
        //            return;
        //        }

        //        // Send a decline message if the callee said no
        //        if (acceptCall == false)
        //        {
        //            Clients.Client(targetConnectionId).InvokeAsync("callDeclined", callingUser, string.Format("{ 0} did not accept your call.", callingUser.NickName));
        //            return;
        //        }

        //        // Make sure there is still an active offer.  If there isn't, then the other use hung up before the Callee answered.
        //        var offerCount = CallOffers.RemoveAll(c => c.Callee.ConnectionId == callingUser.ConnectionId
        //                                              && c.Caller.ConnectionId == targetUser.ConnectionId);
        //        if (offerCount < 1)
        //        {
        //            Clients.Client(Context.ConnectionId).InvokeAsync("callEnded", targetConnectionId, string.Format("{ 0} has already hung up.", targetUser.NickName));
        //            return;
        //        }

        //        // And finally... make sure the user hasn't accepted another call already
        //        if (GetUserCall(targetUser.ConnectionId) != null)
        //        {
        //            // And that they aren't already in a call
        //            Clients.Client(Context.ConnectionId).InvokeAsync("callDeclined", targetConnectionId, string.Format("{ 0} chose to accept someone elses call instead of yours :(", targetUser.NickName));
        //            return;
        //        }

        //        // Remove all the other offers for the call initiator, in case they have multiple calls out
        //        CallOffers.RemoveAll(c => c.Caller.ConnectionId == targetUser.ConnectionId);

        //        // Create a new call to match these folks up
        //        UserCalls.Add(new UserCall
        //        {
        //            Users = new List<ChatHubUserViewModel> { callingUser, targetUser }
        //        });

        //        // Tell the original Client(Context.ConnectionId) that the call was accepted
        //        Clients.Client(targetConnectionId).InvokeAsync("callAccepted", callingUser);

        //        // Update the user list, since thes two are now in a call
        //        SendUserListUpdate();
        //    }
        //    catch (Exception ex)
        //    {
        //        Clients.Client(Context.ConnectionId).InvokeAsync("receiveMessage", ex);
        //    }
        //}

        //public void HangUp()
        //{
        //    var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);

        //    if (callingUser == null)
        //    {
        //        return;
        //    }

        //    var currentCall = GetUserCall(callingUser.ConnectionId);

        //    // Send a hang up message to each user in the call, if there is one
        //    if (currentCall != null)
        //    {
        //        foreach (var user in currentCall.Users.Where(u => u.ConnectionId != callingUser.ConnectionId))
        //        {
        //            Clients.Client(user.ConnectionId).InvokeAsync("callEnded", callingUser.ConnectionId, string.Format("{ 0} has hung up.", callingUser.NickName));
        //        }

        //        // Remove the call from the list if there is only one (or none) person left.  This should
        //        // always trigger now, but will be useful when we implement conferencing.
        //        currentCall.Users.RemoveAll(u => u.ConnectionId == callingUser.ConnectionId);
        //        if (currentCall.Users.Count < 2)
        //        {
        //            UserCalls.Remove(currentCall);
        //        }
        //    }

        //    // Remove all offers initiating from the Client(Context.ConnectionId)
        //    CallOffers.RemoveAll(c => c.Caller.ConnectionId == callingUser.ConnectionId);

        //    SendUserListUpdate();
        //}

        //// WebRTC Signal Handler
        //public void SendSignal(string signal, string targetConnectionId)
        //{
        //    var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
        //    var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

        //    // Make sure both users are valid
        //    if (callingUser == null || targetUser == null)
        //    {
        //        return;
        //    }

        //    // Make sure that the person sending the signal is in a call
        //    var userCall = GetUserCall(callingUser.ConnectionId);

        //    // ...and that the target is the one they are in a call with
        //    if (userCall != null && userCall.Users.Exists(u => u.ConnectionId == targetUser.ConnectionId))
        //    {
        //        // These folks are in a call together, let's let em talk WebRTC
        //        Clients.Client(targetConnectionId).InvokeAsync("receiveSignal", callingUser, signal);
        //    }
        //}

        //#region Private Helpers

        //private void SendUserListUpdate()
        //{
        //    Users.ForEach(u => u.InCall = (GetUserCall(u.ConnectionId) != null));
        //    Clients.All.InvokeAsync("updateUserList", Users);
        //}

        //private UserCall GetUserCall(string connectionId)
        //{
        //    var matchingCall =
        //        UserCalls.SingleOrDefault(uc => uc.Users.SingleOrDefault(u => u.ConnectionId == connectionId) != null);
        //    return matchingCall;
        //}

        //#endregion

        //#endregion
    }
}
