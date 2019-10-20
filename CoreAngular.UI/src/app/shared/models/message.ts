export interface Message {
    sendingUserId: number;
    receivingUserId: number;
    title: string;
    body: string;
    isRead: boolean;
    isSenderDeleted: boolean;
    isReceiverDeleted: boolean;
    dateRead: Date;
    dateSent: Date;
}
