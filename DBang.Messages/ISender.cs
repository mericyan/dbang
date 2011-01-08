namespace DBang.Messages
{
    public interface ISender
    {
        bool Send(string senderMobileNumber, string receiverMobileNumber, string message);
    }
}