import { Component, OnInit } from '@angular/core';
import { HubConnection, TransportType } from '@aspnet/signalr-client';
import * as models from './messenger.viewmodels';

import { forEach } from '@angular/router/src/utils/collection';
import { PagingItems, Team } from './messenger.viewmodels';
@Component({
    selector: 'app-messenger',
    templateUrl: './messenger.component.html'
})
/** messenger component*/
export class MessengerComponent implements OnInit {
    private responseMethod = '';
    private request: models.MessengerRequest;
    private hubData: models.HubData = new models.HubData();
    private user = new models.MessengerInfo();
    private teams: PagingItems<Team>;
    private activedTeam: Team;
    public messages: models.Message[] = [];
    public message: models.Message = new models.Message();
    ngOnInit(): void {
        this._hubConnection = new HubConnection('/messenger', { transport: TransportType.LongPolling });
        this._hubConnection.on('receiveMessage', (response) => {
            // Add the message to the page.
            var message = response.data;
            console.log(response);
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
                        if (this.activedTeam.id === message.teamId) {
                            this.activedTeam.messages.items.push(message);
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
                        this.teams = response.data.teams;
                        // if (this.teams.totalItems > 0) {
                        //     this.request.teamId = this.teams.items[0].id;
                        //     this.getTeam();
                        // }
                        //this.messages = this.hubData.activedTeam.messages.items;

                        // this._startSession();                        
                    }
                    break;
                case 'GetTeam':
                    if (response.status === 1) {
                        this.activedTeam = response.data;
                        // this.seenTeamMessages();

                        this.hubData.teams.items.forEach(team => {
                            if (team.id === this.activedTeam.id) {
                                team.isNewMessage = false;
                            }
                        });

                        // setTime
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

        this.user.userId = '86549ce1-9d5b-473c-9ec8-3302df3875be';
        this.user.username = 'tin';
        this.request = new models.MessengerRequest();
        this.message.userId = this.user.userId;
        this.message.avatarUrl = this.user.avatarUrl;
        this.message.username = this.user.username;
        this.request.isOnline = true;
        this.request.userId = this.user.userId;
        this._hubConnection.start().then(() => {
            this.hubInvoke('hubconnect', this.user, null);
        })
            .catch(err => {
                console.log(err);
            });
    }
    private _hubConnection: HubConnection;
    /** messenger ctor */
    constructor() {

    }
    public getTeam(id: number): void {
        this.request.teamId = id;
        this.hubInvoke('GetTeam', this.request, null);
    }

    public sendMessage(): void {
        this.message.teamId = this.activedTeam.id;
        this.hubInvoke('SendMessage', this.message, () => {
            this.message.message ='';
        });
    }

    public hubInvoke(methodName: string, data: any, callBack: any): void {
        this._hubConnection.invoke(methodName, data).then(() => {
            if (callBack != null) {
                callBack();
            }
        })
            .catch(err => {
                
                console.log('error: ', methodName, err);
            });
    }
}