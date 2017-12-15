import { Component, OnInit } from '@angular/core';
import { HubConnection, TransportType } from '@aspnet/signalr-client';
import * as models from './messenger.viewmodels';

import { forEach } from '@angular/router/src/utils/collection';
@Component({
    selector: 'app-messenger',
    templateUrl: './messenger.component.html'
})
/** messenger component*/
export class MessengerComponent implements OnInit {
    private responseMethod = '';
    private hubData: models.HubData = new models.HubData();
    private user = new models.MessengerInfo();
    public messages: models.Message[] = [];
    public message: models.Message = new models.Message();
    ngOnInit(): void {

        this._hubConnection = new HubConnection('/messenger', { transport: TransportType.LongPolling });
        this._hubConnection.on('receiveMessage', function (this: MessengerComponent, response) {
            // Add the message to the page.
            var message = response.data;            
            switch (response.responseKey) {
                case 'UpdateOnlineStatus':
                    if (response.status === 1 && this.hubData.activedTeam.id === message.teamId) {
                        this.hubData.activedTeam.members.items.forEach(member => {
                            if (member.memberId === message.userId) {
                                member.isOnline = message.isOnline;
                                member.chatInfo.connectionId = message.connectionId;                                
                                return false;
                            }
                        });                        
                    }
                    break;
                case 'SendMessage':
                    if (response.status === 1) {
                        if (this.hubData.activedTeam.id === message.teamId) {
                            this.hubData.activedTeam.messages.items.push(message);
                            // this.seenTeamMessages();
                        }
                        else {
                            this.hubData.teams.items.forEach(team => {
                                if (team.id === message.teamId) {
                                    team.isNewMessage = true;
                                    return false;
                                }
                            });
                        }
                        //});
                    }
                    break;
                case 'Connect':
                    if (response.status === 1) {
                        this.hubData = response.data;
                        console.log(this.hubData);
                        //this.hubData.activedTeam = this.hubData.teams.items[0];
                        //this.messages = this.hubData.activedTeam.messages.items;
                        // this._startSession();                        
                    }
                    break;
                case 'GetTeam':
                    if (response.status === 1) {
                        this.hubData.activedTeam = response.data;
                        // this.seenTeamMessages();
                        this.hubData.teams.items.forEach(team => {
                            if (team.id === this.hubData.activedTeam.id) {
                                team.isNewMessage = false;
                            }
                        });
                        // setTimeout(function () {
                        //     $("#discussion").animate({
                        //         scrollTop: $('#discussion')[0].scrollHeight - $('#discussion')[0].clientHeight
                        //     }, 500);
                        // }, 500);
                    }
                    break;
                case 'RemovedTeam':
                    if (response.status === 1) {
                        // this.proxy.invoke('hubconnect', this.user);
                    }
                    break;
            }            
        });
        this.user.userId='86549ce1-9d5b-473c-9ec8-3302df3875be';
        this.user.username = 'tin';
        
        this._hubConnection.start().then(()=>{
            console.log('Hub connection started');
            console.log(this.user);
            this._hubConnection.invoke('hubconnect', this.user);
        })
        .catch(err=>{
            console.log(err);
        });
    }
    private _hubConnection: HubConnection;
    /** messenger ctor */
    constructor() {

    }

    public sendMessage(): void{
        this._hubConnection.invoke('SendMessage', this.message).then(()=>{
            console.log('success:', this.message)
            this.message = new models.Message();
        })
        .catch(err=>{
            console.log('error: ', err);
        });
    }
}