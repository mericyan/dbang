namespace DBang.Users.Entities
{
    public class UserInfoEntity
    {
        public long Id { get; set; }
        public long PromoterId { get; set; }
        public long RegionId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Introduction { get; set; }
        public string DefaultPhoto { get; set; }
        public string DefaultLocation { get; set; }
        public string VerificationCode { get; set; }
        public string VerifiedMobileNumber { get; set; }
    }
}