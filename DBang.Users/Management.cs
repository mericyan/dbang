using System;
using DBang.Data;
using DBang.Users.Entities;

namespace DBang.Users
{
    public partial class UserManager
    {
        public long SendVerificationCode(string mobileNumber)
        {
            if (Exists(mobileNumber))
                return -1;

            int vCode = _vCodeGen.Next(100000, 999999);

            const string cmdText = "insert users (verified_mobile_number,verification_code) values(@mNumber,@vCode) select scope_identity()";

            //object userId = _database.ExecuteScalar(cmdText, new DataParameter("@mNumber", mobileNumber), new DataParameter("@vCode", vCode));

            _sender.Send("0", mobileNumber, vCode.ToString());

            return 1;// Convert.ToInt64(userId);
        }

        public bool Create(UserInfoEntity userInfo)
        {
            return true;
            //const string cmdText = "update users set" 
            //    + " promoter_id=@promoterId," 
            //    + " region_id=@regionId," 
            //    + " name=@name," 
            //    + " password=@password," 
            //    + " introduction=@introduction," 
            //    + " default_photo=@defaultPhoto," 
            //    + " default_location=@defaultLocation" 
            //    + " where"
            //    + " verification_code=@vCode" 
            //    + " and verified_mobile_number=@mNumber" 
            //    + " insert logins (user_id) values(@userId)";

            //return _database.ExecuteNonQuery(cmdText, new DataParameter("promoterId", userInfo.PromoterId), new DataParameter("regionId", userInfo.RegionId), new DataParameter("name", userInfo.Name), new DataParameter("password", userInfo.Password), new DataParameter("introduction", userInfo.Introduction), new DataParameter("defaultPhoto", userInfo.DefaultPhoto), new DataParameter("defaultLocation", userInfo.DefaultLocation), new DataParameter("vCode", userInfo.VerificationCode), new DataParameter("mNumber", userInfo.VerifiedMobileNumber), new DataParameter("userId", userInfo.Id)) == 2;
        }

        public bool Exists(string userMobileNumber)
        {
            return true;

            //const string cmdText = "select top 1 login_time from logins where user_id=(select top 1 id from users where verified_mobile_number=@mNumber)";

            //return _database.ExecuteScalar(cmdText, new DataParameter("mNumber", userMobileNumber)) != null;
        }

        public bool Update(UserInfoEntity userInfo)
        {
            return true;

            //const string cmdText = "update users set" 
            //    + " promoter_id=@promoterId," 
            //    + " region_id=@regionId," 
            //    + " name=@name," 
            //    + " password=@password," 
            //    + " introduction=@introduction," 
            //    + " default_photo=@defaultPhoto," 
            //    + " default_location=@defaultLocation" 
            //    + " where" 
            //    + " id=@userId";

            //return _database.ExecuteNonQuery(cmdText, new DataParameter("promoterId", userInfo.PromoterId), new DataParameter("regionId", userInfo.RegionId), new DataParameter("name", userInfo.Name), new DataParameter("password", userInfo.Password), new DataParameter("introduction", userInfo.Introduction), new DataParameter("defaultPhoto", userInfo.DefaultPhoto), new DataParameter("defaultLocation", userInfo.DefaultLocation), new DataParameter("userId", userInfo.Id)) == 1;
        }
    }
}