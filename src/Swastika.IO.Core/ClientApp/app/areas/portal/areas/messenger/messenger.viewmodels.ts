export class UserData {
    id: string;
    name: string;
    avatarUrl: string;
    connectionId: string;
    
    myTeams: PagingItems<Team>;
    myRooms: PagingItems<Team>;   
}

export class Team {
    id: number;
    name: string;
    hostId: string;
    avatarUrl: string;
    createdDate: Date;
    isNewMessage: boolean;
    totalMember: number;
    isOpen: boolean;
    totalRequest: number;
    isAdmin: boolean;
    maxTeamMember: number;
    members: PagingItems<TeamMember>;
    messages: PagingItems<Message>;
};
export class TeamMember {
    teamId: number;
    memberId: string;
    isAdmin: boolean;
    isNew: boolean;
    status: number;
    createdDate: Date;
    seenMessageDate: Date;
    seenRequestDate: Date;
    seenInviteDate: Date;
    info: MemberInfo;
    chatInfo: MessengerInfo;
    isOnline: boolean;
}

export class MemberInfo {
    id: string;
    avatarUrl: string;
    firstName: string;
    lastName: string;
    department: string;
    jobTitle: string;
    joinDate: Date;
    email: string;
    phoneNumber: null;
    phoneNumberConfirmed: false;
    userName: string;
}

export class MessengerInfo {
    inCall: boolean;
    userId: string;
    username: string;
    userAvatar: string;
    connectionId: string;
    joinedDate: Date;
    Rooms: MessengerRoom[]
}

export class MessengerRoom {
    id: string;
    name: string;
    teamId: number;
    hostId: string;
    title: string;
    description: string;
    avatarUrl: string;
    joinedDate: Date;
}

export class Message {
    id: string;
    userId: string;
    username: string;
    userAvatar: string;
    teamId: number;
    content: string;
    messageType: number;
    notificationType: number;
    createdDate: Date;
    /**
     *
     */
    constructor() {
    }
}

export class PagingItems<T>{
    pageIndex: number;
    pageSize: number;
    totalPage: number;
    totalItems: number;
    items: T[];
    /**
     *
     */
    constructor() {
        this.items = [];            
    }
}
export class ApiResult<T>{
    isSucceed: boolean;
    status: number;
    responseKey: string;
    errors: string[];
    exception: object;
    data: T;

}

export class MessengerRequest{
    teamId: number;
    userId: string;
    connectionId: string;
    memberStatus: MemberStatus;
    isOnline: boolean;
    keyword: string;
}

enum MemberStatus{
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
