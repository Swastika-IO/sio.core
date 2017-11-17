using Microsoft.AspNetCore.Identity;
using Swastika.Identity.Data;
using Swastika.Identity.Models;
using Swastika.Identity.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swastika.IO.Cms.Lib.Repositories
{
    public class AuthRepository : IDisposable
    {
        private static AuthRepository _instance;
        public static AuthRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthRepository();
                }
                return _instance;
            }
        }

        public ApplicationDbContext _ctx;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _ctx = new ApplicationDbContext();
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel, string registerType, bool isDeviceActived)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                EmailConfirmed = isDeviceActived,
                JoinDate = DateTime.Now.ToUniversalTime(),
                LastModified = DateTime.Now.ToUniversalTime(),
                IsActived = false
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                TTX.Data.TTX_UserInfo info = new TTX.Data.TTX_UserInfo()
                {
                    UserId = user.Id,
                    WeiboId = userModel.WeiboId,
                    FacebookId = userModel.FacebookId,
                    Culture = userModel.Culture,
                    RegisterType = registerType
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
                //string err = "";
                string responseKey = "NewUser";
                if (!string.IsNullOrEmpty(user.Email) && registerType != "Weibo" && registerType != "Facebook")
                {
                    SendEmailActive(user.Id, user.Email, info.NickName, device.ActiveCode, responseKey);
                }

            }
            return result;
        }
        public bool SendEmailActive(string userId, string userEmai, string username, string activeCode, string responseKey)
        {
            string azureURL = "https://dev.ttx.world/";
            string error = string.Empty;

            Hashtable hashDynamicEmailInfo = new Hashtable();

            string template = "/Templates/EDMs/ttx-activation.html";
            string body = CommonHelper.ReadFromFile(template);
            body = body.Replace("[USERID]", userId);
            body = body.Replace("[ACTIVECODE]", activeCode);
            body = body.Replace("[HOST]", CommonHelper.CurrentDomain);
            body = body.Replace("[RESPONSEKEY]", responseKey);
            body = body.Replace("[USERNAME]", username);
            body = body.Replace("[SSLHOST]", azureURL);
            CommonHelper.send_email(userEmai, userEmai,
                GlobalConfigurations.Instance.GetConfigValue("EmailTitles", "ActiveAccount"),
                body, GlobalConfigurations.Instance.EmailConfigParam, ref error);
            return string.IsNullOrEmpty(error);
        }

        public bool SendEmailNewDevice(string userId, string userEmai, string username, string activeCode, string responseKey)
        {
            string azureURL = "https://dev.ttx.world/";
            string error = string.Empty;

            Hashtable hashDynamicEmailInfo = new Hashtable();

            string template = "/Templates/EDMs/ttx-newdevice.html";
            string body = CommonHelper.ReadFromFile(template);
            body = body.Replace("[USERID]", userId);
            body = body.Replace("[ACTIVECODE]", activeCode);
            body = body.Replace("[HOST]", CommonHelper.CurrentDomain);
            body = body.Replace("[RESPONSEKEY]", responseKey);
            body = body.Replace("[USERNAME]", username);
            body = body.Replace("[SSLHOST]", azureURL);
            CommonHelper.send_email(userEmai, userEmai,
                GlobalConfigurations.Instance.GetConfigValue("EmailTitles", "ActiveNewDevice"),
                body, GlobalConfigurations.Instance.EmailConfigParam, ref error);
            return string.IsNullOrEmpty(error);
        }

        public bool SendEmailUpdateEmail(string userId, string newEmail, string username, string responseKey)
        {
            string azureURL = "https://dev.ttx.world/";
            string template = "/Templates/EDMs/ttx-changeemail.html";
            string error = string.Empty;
            string body = CommonHelper.ReadFromFile(template);
            body = body.Replace("[USERID]", userId);
            body = body.Replace("[USERNAME]", username);
            body = body.Replace("[NEWEMAIL]", newEmail);
            body = body.Replace("[RESPONSEKEY]", responseKey);
            body = body.Replace("[HOST]", CommonHelper.CurrentDomain);
            body = body.Replace("[SSLHOST]", azureURL);

            //string body = string.Format(@"<h1>userId: {0}</h1>
            //                            <div><a href='{1}updateEmail?userId={0}&newEmail={2}&responseKey={3}'>Active Account</a></div>
            //                            <div><a href='" + azureURL + @"updateEmail?userId={0}&newEmail={2}&responseKey={3}'>Active Account IOS</a></div>"
            //, userId, CommonHelper.CurrentDomain, newEmail, responseKey);
            CommonHelper.send_email(newEmail, newEmail,
                GlobalConfigurations.Instance.GetConfigValue("EmailTitles", "UpdateEmail"),
                body, GlobalConfigurations.Instance.EmailConfigParam, ref error);
            return string.IsNullOrEmpty(error);
        }
        public ApiResult<UserViewModel> UpdateUserInfo(UpdateUserModel userModel, AuthData authData)
        {
            ApiResult<UserViewModel> result = null;
            int status = 0;
            string errorMsg = string.Empty;
            string responseKey = string.Empty;
            string message = string.Empty;
            ApplicationUser user = _userManager.FindById(userModel.UserId);
            UserViewModel vmUser = null;
            string strCulture = !string.IsNullOrEmpty(userModel.Culture) ? userModel.Culture : CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
            if (user != null)
            {
                var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == user.Id);

                if (!string.IsNullOrWhiteSpace(userModel.Gender))
                {
                    info.Gender = userModel.Gender.Trim();
                    info.LastGenderRank = -1;
                }
                if (userModel.CountryId.HasValue)
                {
                    info.CountryId = userModel.CountryId.Value;
                    info.LastCountryRank = -1;
                }
                if (userModel.DOB.HasValue)
                {
                    info.DOB = userModel.DOB;
                    info.LastAgeGroupRank = -1;
                    info.AgeGroup = CommonHelper.GetAgeGroup(info.DOB);
                }
                if (!string.IsNullOrEmpty(userModel.Culture))
                {
                    info.Culture = userModel.Culture;
                }

                TTXUserInfoDAL.Instance.SaveModel(info, out errorMsg);

                vmUser = CreateUserViewModel(user, null, info, info.Culture);

                status = string.IsNullOrEmpty(errorMsg) ? 1 : 0;
                responseKey = string.IsNullOrEmpty(errorMsg) ? "UpdateUserSucceed" : "UpdateUserFail";
            }
            else
            {
                responseKey = "UserNotFound";

            }
            AccessTokenViewModel auth = null;
            if (status == 1)
            {

                var updResult = _userManager.Update(user);
                status = updResult.Succeeded ? 1 : 0;
                LoginModel login = new LoginModel()
                {
                    Culture = vmUser.Culture,
                    DeviceId = authData.DeviceId,
                    Email = vmUser.Email,
                    FacebookId = vmUser.FacebookId,
                    WeiboId = vmUser.WeiboId

                };
                var token = GetNewAccessToken(authData.RefreshToken);

                if (token != null && !string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    //user = FindUserById(token.UserId);
                    auth = new AccessTokenViewModel()
                    {
                        access_token = token.TokenType + " " + token.AccessToken,
                        token_type = token.TokenType,
                        refresh_token = token.RefreshToken,
                        expires_in = token.ExpiresIn,
                        client_id = token.ClientId,
                        deviceId = token.DeviceId,
                        issued = token.Issued.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        expires = token.Expires.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        userData = CreateUserViewModel(user, null, vmUser.Culture)
                    };
                }
            }

            result = new ApiResult<UserViewModel>()
            {
                status = status,
                responseKey = responseKey,
                data = vmUser,
                authData = auth,
                error = errorMsg,
                message = !string.IsNullOrEmpty(message) ? message : responseKey
            };

            return result;
        }

        public async Task<ApiResult<UserViewModel>> UpdateUser(UpdateUserModel userModel, AuthData authData)
        {
            ApiResult<UserViewModel> result = null;
            int status = 0;
            string errorMsg = string.Empty;
            string responseKey = string.Empty;
            string message = string.Empty;
            var user = _userManager.FindById(userModel.UserId);
            UserViewModel vmUser = null;
            switch (userModel.FieldType.ToLower())
            {
                case "username":
                    if (userModel.Value.Length > 12)
                    {
                        responseKey = "InvalidUserName";
                        message = GlobalConfigurations.Instance.GetConfigValue("ErrorMessages", "InvalidUserName");
                    }
                    else
                    {
                        //var userByName = UserInfoDAL.Instance.GetSingleModel(u => u.NickName == userModel.Value);
                        var userByName = TTXUserInfoDAL.Instance.GetSingleModel(u => u.NickName == userModel.Value);
                        if (userByName == null)
                        {

                            //user.UserInfo.NickName = userModel.Value;
                            userByName = new TTX.Data.TTX_UserInfo()
                            {
                                UserId = user.Id,
                                NickName = userModel.Value
                            };
                            status = TTXUserInfoDAL.Instance.SaveModel(userByName) != null ? 1 : 0;
                            user.IsActived = status == 1;
                        }
                        else
                        {

                            responseKey = "UserNameExisted";
                            message = string.Format(GlobalConfigurations.Instance.GetConfigValue("ErrorMessages", "UserNameExisted"), userModel.Value);
                        }
                    }
                    break;
                case "email":
                    var userByEmail = await _userManager.FindByEmailAsync(userModel.Value);
                    if (userByEmail == null)
                    {
                        status = 1;
                        user.Email = userModel.Value;
                    }
                    else
                    {

                        responseKey = "EmailExisted";
                        message = GlobalConfigurations.Instance.GetConfigValue("ErrorMessages", "EmailExisted");
                    }
                    break;
                case "avatar":
                    Image imgAvatar = CommonHelper.LoadImage(userModel.Value);
                    if (imgAvatar != null)
                    {
                        string filePath = GetUserFilePath(userModel.UserId);
                        string fileName = CommonHelper.UploadPhoto(filePath, imgAvatar);
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == userModel.UserId);
                            if (!string.IsNullOrEmpty(info.Avatar))
                            {
                                CommonHelper.RemoveFile(info.Avatar);
                            }
                            info.Avatar = string.Format("{0}/{1}", filePath, fileName);

                            TTXUserInfoDAL.Instance.SaveModel(info);

                            status = 1;
                            message = GlobalConfigurations.Instance.GetConfigValue("AlertMessages", "UpdateAvatarSucceed");
                            info.Avatar = string.Format("{0}/{1}", filePath, fileName);
                        }
                    }
                    else
                    {
                        responseKey = "InvalidImage";
                    }
                    break;
                case "dob":
                    var dobInfo = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == userModel.UserId);
                    dobInfo.AgeGroup = CommonHelper.GetAgeGroup(userModel.DOB);

                    TTXUserInfoDAL.Instance.SaveModel(dobInfo);
                    status = 1;
                    message = GlobalConfigurations.Instance.GetConfigValue("AlertMessages", "UpdateDOBSucceed");
                    break;
            }
            AccessTokenViewModel auth = null;
            if (status == 1)
            {

                var updResult = _userManager.Update(user);
                status = updResult.Succeeded ? 1 : 0;
                responseKey = updResult.Succeeded ? "Succeed" : "Unknown";
                var token = GetNewAccessToken(authData.RefreshToken);

                if (token != null && !string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    //user = FindUserById(token.UserId);
                    auth = new AccessTokenViewModel()
                    {
                        access_token = token.TokenType + " " + token.AccessToken,
                        token_type = token.TokenType,
                        refresh_token = token.RefreshToken,
                        expires_in = token.ExpiresIn,
                        client_id = token.ClientId,
                        issued = token.Issued.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        expires = token.Expires.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        userData = CreateUserViewModel(user, null)
                    };
                }
                vmUser = CreateUserViewModel(user, null);
            }
            result = new ApiResult<UserViewModel>()
            {
                status = status,
                responseKey = responseKey,
                data = vmUser,
                authData = auth,
                error = errorMsg,
                message = !string.IsNullOrEmpty(message) ? message : responseKey
            };

            return result;
        }



        private string GetUserFilePath(string userId)
        {
            return string.Format(GlobalConfigurations.Instance.GetConfigValue("FolderPaths", "UserFiles"), userId);
        }

        public async Task<IdentityResult> UpdateUser(ApplicationUser user)
        {

            var result = await _userManager.UpdateAsync(user);

            return result;
        }
        public async Task<IdentityResult> RemoveUser(UserViewModel userModel)
        {
            var user = await _userManager.FindByIdAsync(userModel.Id);
            //ApplicationUser user = null;
            //if (!string.IsNullOrEmpty(userModel.Email))
            //{
            //    user = await FindUser(userModel.Email);
            //}
            //else if (!string.IsNullOrEmpty(userModel.WeiboId))
            //{
            //    user = await FindUserByWeiboIdAsync(userModel.WeiboId);
            //}
            //else if (!string.IsNullOrEmpty(userModel.FacebookId))
            //{
            //    user = await FindUserByFacebookIdAsync(userModel.WeiboId);
            //}
            if (user != null)
            {
                var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == user.Id);
                string nickName = info.NickName;
                //var rolesForUser = await _userManager.GetRolesAsync(userModel.Id);

                foreach (var device in user.Devices)
                {
                    UserDeviceDAL.Instance.RemoveModel(d => d.DeviceId == device.Id);
                }
                //UserInfoDAL.Instance.RemoveModel(u => u.NickName == nickName);
                TTXUserInfoDAL.Instance.RemoveModel(u => u.UserId == userModel.Id);
                //foreach (var item in rolesForUser.ToList())
                //{
                //    // item should be the name of the role
                //    await _userManager.RemoveFromRoleAsync(userModel.Id, item);
                //}

            }

            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel model)
        {
            var result = await _userManager.ChangePasswordAsync(model.UserID, model.CurrentPassword, model.NewPassword);
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }
        public async Task<ApplicationUser> FindUser(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            return user;
        }
        public ApplicationUser FindUserByWeiboId(string weiboId)
        {
            var userInfo = TTXUserInfoRepository.Instance.GetSingleModel(u => u.WeiboId == weiboId, false);
            if (userInfo != null)
            {
                ApplicationUser user = _userManager.FindById(userInfo.UserId);
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<ApplicationUser> FindUserByWeiboIdAsync(string weiboId)
        {
            var userInfo = await TTXUserInfoRepository.Instance.GetSingleModelAsync(u => u.WeiboId == weiboId, false);
            if (userInfo != null)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userInfo.UserId);
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<ApplicationUser> FindUserByFacebookIdAsync(string facebookId)
        {
            var userInfo = await TTXUserInfoRepository.Instance.GetSingleModelAsync(u => u.FacebookId == facebookId, false);
            if (userInfo != null)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userInfo.UserId);
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public ApplicationUser FindUserById(string id)
        {
            ApplicationUser user = _userManager.FindById(id);

            return user;
        }

        public async Task<ApplicationUser> FindUserByEmailDeviceId(string email, string deviceId)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user.Devices != null)
            {
                var divice = user.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
                return deviceId != null ? user : null;
            }
            return null;
        }
        public async Task<ApplicationUser> FindUserByWeiboIdDeviceId(string weiboId, string deviceId)
        {
            ApplicationUser user = await FindUserByWeiboIdAsync(weiboId);
            if (user.Devices != null)
            {
                var divice = user.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
                return deviceId != null ? user : null;
            }
            return null;
        }
        public async Task<ApplicationUser> FindUserByFacebookIdDeviceId(string facebookId, string deviceId)
        {
            ApplicationUser user = await FindUserByFacebookIdAsync(facebookId);
            if (user.Devices != null)
            {
                var divice = user.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
                return deviceId != null ? user : null;
            }
            return null;
        }
        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }

        public Client FindClient(string clientId)
        {
            var client = _ctx.Clients.Find(clientId);

            return client;
        }

        public IdentityRole FindRole(string roleId)
        {
            var role = _ctx.Roles.Find(roleId);

            return role;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = _ctx.RefreshTokens.Where(r => r.Subject == token.Subject && r.DeviceId == token.DeviceId && r.ClientId == token.ClientId).FirstOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            _ctx.RefreshTokens.Add(token);

            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                _ctx.RefreshTokens.Remove(refreshToken);
                return await _ctx.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            _ctx.RefreshTokens.Remove(refreshToken);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _ctx.RefreshTokens.ToList();
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            ApplicationUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public async Task<IdentityResult> AddDeviceId(string deviceId, string notificationId, ApplicationUser userModel, bool isActived)
        {
            //if (!string.IsNullOrEmpty(deviceId))
            //{

            UserDevice device = new UserDevice()
            {
                Id = Guid.NewGuid().ToString(),
                DeviceId = deviceId,
                NotificationId = notificationId,
                ActiveCode = Guid.NewGuid().ToString("N"),
                CreatedDate = DateTime.Now.ToUniversalTime(),
                IsActived = isActived
            };
            if (userModel.Devices == null)
            {
                userModel.Devices = new List<UserDevice>();
            }

            userModel.Devices.Add(device);
            var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == userModel.Id);
            string err = string.Empty;
            var result = await UpdateUser(userModel);
            if (result.Succeeded)
            {
                string responseKey = "NewDevice";
                if (!isActived)
                {
                    SendEmailNewDevice(userModel.Id, userModel.Email, info != null ? info.NickName : "there", device.ActiveCode, responseKey);
                }
            }

            return result;
        }

        public void ActiveUserDevice(string currentUserId, string deviceId)
        {
            // Deactive other Account on this device
            var lstDevice = UserDeviceDAL.Instance.GetModelListBy(d => d.DeviceId == deviceId);
            //var lstConnectingUserDevice = UserDeviceDAL.Instance.GetModelListBy(d => d.ApplicationUser_Id == currentUserId && d.IsConnecting);
            foreach (var device in lstDevice)
            {
                device.IsConnecting = device.ApplicationUser_Id == currentUserId;
                UserDeviceDAL.Instance.SaveModel(device);
            }

            ////Disconnect Other Devices
            UserDeviceDAL.Instance.RemoveListModel(d => d.ApplicationUser_Id == currentUserId && d.DeviceId != deviceId);
            //foreach (var device in lstConnectingUserDevice)
            //{
            //    device.IsConnecting = device.ApplicationUser_Id == currentUserId;
            //    UserDeviceDAL.Instance.SaveModel(device);
            //}
        }

        public Token GetAccessToken(LoginModel login)
        {
            using (var client = new HttpClient())
            {
                string baseAddress = CommonHelper.CurrentDomain;
                var form = new Dictionary<string, string>
                   {
                       {"grant_type", "password"},
                       {"client_id", CommonHelper.AppConfig("AppId")},
                       {"email", login.Email},
                       {"weiboId", login.WeiboId},
                       {"facebookId", login.FacebookId},
                       {"deviceId", login.DeviceId},
                       {"password", login.Password},
                       {"culture" , login.Culture}
                   };
                var tokenResponse = client.PostAsync(Path.Combine(baseAddress, "token"), new FormUrlEncodedContent(form)).Result;
                return tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
            }
        }

        public Token GetAccessToken(string email, string password)
        {
            using (var client = new HttpClient())
            {
                string baseAddress = CommonHelper.CurrentDomain;
                var form = new Dictionary<string, string>
                   {
                       {"grant_type", "password"},
                       {"username", email},
                       {"password", password},
                   };
                var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(form)).Result;
                return tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
            }
        }
        public AuthData ValidateAuth(IAuthenticationManager Authentication, string refreshtoken)
        {
            AccessTokenViewModel auth = null;
            string culture = string.Empty;
            string deviceId = string.Empty;
            DateTime expiredDate;// = DateTime.Now.AddMinutes(int.Parse(CommonHelper.AppConfig("ExpiredTokenTime")));
            bool isAuth = Authentication.User.Identity.IsAuthenticated;
            string userId = Authentication.User.Identity.GetUserId();
            //var objExpiredDate = Authentication.User.Claims.FirstOrDefault(c => c.Type == "expiredDate");
            //string strExpiredDate = objExpiredDate != null ? objExpiredDate.Value : string.Empty;
            //bool isHaveExpiredDate = DateTime.TryParseExact(strExpiredDate, "dd-MM-yyyy hh:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out expiredDate);
            //Logger.Info("Auth => " + refreshtoken + " || " + userId);
            if (!isAuth && !string.IsNullOrEmpty(refreshtoken))// || (objExpiredDate != null && isHaveExpiredDate && DateTime.UtcNow.AddSeconds(10) > expiredDate))
            {

                var token = GetNewAccessToken(refreshtoken);
                expiredDate = token.Expires;
                if (token != null && !string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    isAuth = string.IsNullOrWhiteSpace(userId) || userId == token.UserId;
                    var user = FindUserById(token.UserId);
                    auth = new AccessTokenViewModel()
                    {
                        access_token = token.TokenType + " " + token.AccessToken,
                        token_type = token.TokenType,
                        refresh_token = token.RefreshToken ?? string.Empty,
                        expires_in = token.ExpiresIn,
                        client_id = token.ClientId,
                        deviceId = token.DeviceId,
                        issued = token.Issued.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        expires = token.Expires.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        userData = CreateUserViewModel(user, null)
                    };

                    refreshtoken = token.RefreshToken;
                    culture = auth != null && auth.userData != null ? auth.userData.Culture : CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
                    deviceId = token.DeviceId;
                }
            }
            else
            {
                try
                {
                    culture = Authentication.User.Claims.FirstOrDefault(c => c.Type == "culture").Value;
                    deviceId = Authentication.User.Claims.FirstOrDefault(c => c.Type == "deviceId").Value;

                }
                catch
                {
                    culture = CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
                }

            }
            //cheat temp
            //isAuth = true;
            AuthData result = new AuthData()
            {
                IsAuth = isAuth,
                accessToken = auth,
                UserId = userId,
                Culture = culture,
                DeviceId = deviceId,
                RefreshToken = refreshtoken ?? string.Empty
            };

            //Logger.Info("Current Token => " + result.RefreshToken + " || " + result.UserId);
            return result;
        }

        public AuthData ValidateAuth(IIdentity identity, string userId, string refreshtoken)
        {
            AccessTokenViewModel auth = null;
            string culture = string.Empty;
            bool isAuth = identity.IsAuthenticated;
            //Logger.Info("Auth => " + refreshtoken + " || " + userId);
            if (!isAuth)
            {

                var token = GetNewAccessToken(refreshtoken);

                if (token != null && !string.IsNullOrWhiteSpace(token.AccessToken))
                {
                    isAuth = string.IsNullOrWhiteSpace(userId) || userId == token.UserId;
                    var user = FindUserById(token.UserId);
                    auth = new AccessTokenViewModel()
                    {
                        access_token = token.TokenType + " " + token.AccessToken,
                        token_type = token.TokenType,
                        refresh_token = token.RefreshToken ?? string.Empty,
                        expires_in = token.ExpiresIn,
                        client_id = token.ClientId,
                        deviceId = token.DeviceId,
                        issued = token.Issued.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        expires = token.Expires.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss"),
                        userData = CreateUserViewModel(user, null)
                    };
                    refreshtoken = token.RefreshToken;
                    culture = auth != null && auth.userData != null ? auth.userData.Culture : CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
                }
            }
            else
            {
                try
                {
                    var claimsIdentity = identity as ClaimsIdentity;
                    culture = claimsIdentity.FindFirst("culture").Value;
                }
                catch
                {
                    culture = CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
                }
            }
            //cheat temp
            //isAuth = true;
            AuthData result = new AuthData()
            {
                IsAuth = isAuth,
                accessToken = auth,
                UserId = userId,
                Culture = culture,
                RefreshToken = refreshtoken ?? string.Empty
            };
            //Logger.Info("Current Token => " + result.RefreshToken + " || " + result.UserId);
            return result;
        }

        public Token GetNewAccessToken(string refreshToken)
        {
            using (var client = new HttpClient())
            {
                string baseAddress = CommonHelper.CurrentDomain;
                var form = new Dictionary<string, string>
                   {
                       {"grant_type", "refresh_token"},
                       {"refresh_token", refreshToken},
                       {"Client_id", CommonHelper.AppConfig("AppId")},
                   };
                var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(form)).Result;
                return tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
            }
        }
        public UserViewModel CreateBackendUserViewModel(ApplicationUser appUser, List<IdentityRole> lstRole)
        {
            string strCulture = CommonHelper.AppConfig(TTXConstants.AppConfig.DefaultCulture.ToString());
            var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == appUser.Id);
            List<RoleViewModel> lstVMRole = new List<RoleViewModel>();
            foreach (var role in lstRole)
            {
                var vmRole = new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsUserInRole = role.Users.FirstOrDefault(u => u.UserId == appUser.Id) != null
                };
                lstVMRole.Add(vmRole);
            }
            CountryViewModel country = null;
            if (info != null)
            {
                country = new CountryViewModel(TTXCountryDAL.Instance.GetSingleModel(c => c.Id == info.CountryId));
            }
            else
            {
                info = new TTX.Data.TTX_UserInfo()
                {
                    InviteCode = Guid.NewGuid().ToString("N"),
                    UserId = appUser.Id
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
            }

            return new UserViewModel(info, appUser, lstVMRole, strCulture);
            //{
            //    //Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
            //    Id = appUser.Id,
            //    IsActived = appUser.IsActived,
            //    IsSetPassword = appUser.IsSetPassword,
            //    //NickName = appUser.UserInfo.NickName,
            //    //FirstName = appUser.UserInfo.FirstName,
            //    //LastName = appUser.UserInfo.LastName,
            //    //FullName = string.Format("{0} {1}", appUser.UserInfo.FirstName, appUser.UserInfo.LastName),
            //    //Avatar = string.IsNullOrWhiteSpace(appUser.UserInfo.Avatar) ? "" : string.Format("{0}{1}", CommonHelper.CurrentDomain, appUser.UserInfo.Avatar),
            //    ELO = info.ELO,
            //    NickName = info.NickName,
            //    Gender = info.Gender,
            //    DOB = info.DOB.HasValue ? info.DOB.Value.ToString("yyyy-MM-dd") : null,
            //    AgeGroup = info.AgeGroup,
            //    CountryId = info.CountryId,
            //    Country = country,
            //    Avatar = string.IsNullOrWhiteSpace(info.Avatar) ? null : string.Format("{0}{1}", CommonHelper.CurrentDomain, info.Avatar),

            //    Email = appUser.Email,

            //    EmailConfirmed = appUser.EmailConfirmed,
            //    //Level = appUser.Level,
            //    JoinDate = appUser.JoinDate,
            //    LastActiveDate = info.LastActiveDate.HasValue ? info.LastActiveDate.Value.ToLocalTime() : info.LastActiveDate,
            //    Roles = lstVMRole,
            //    RoleNames = _userManager.GetRolesAsync(appUser.Id).Result.ToList(),
            //    //Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result.ToList(),
            //    Devices = appUser.Devices,

            //};

        }
        public UserViewModel CreateUserViewModel(ApplicationUser appUser, string strCulture)
        {
            var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == appUser.Id);
            if (info == null)
            {
                info = new TTX.Data.TTX_UserInfo()
                {
                    InviteCode = Guid.NewGuid().ToString("N"),
                    Culture = strCulture,
                    UserId = appUser.Id
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
            }

            return new UserViewModel(info, appUser, _userManager.GetRolesAsync(appUser.Id).Result.ToList(), strCulture);
            //{
            //    //Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
            //    Id = appUser.Id,
            //    IsActived = appUser.IsActived,
            //    IsSetPassword = appUser.IsSetPassword,
            //    ELO = info.ELO,
            //    NickName = info.NickName,
            //    Gender = info.Gender,
            //    DOB = info.DOB.HasValue ? info.DOB.Value.ToString("yyyy-MM-dd") : null,
            //    AgeGroup = info.AgeGroup,
            //    CountryId = info.CountryId,
            //    Country = country,
            //    Avatar = string.IsNullOrWhiteSpace(info.Avatar) ? null : string.Format("{0}{1}", CommonHelper.CurrentDomain, info.Avatar),

            //    Email = appUser.Email,

            //    EmailConfirmed = appUser.EmailConfirmed,
            //    //Level = appUser.Level,
            //    JoinDate = appUser.JoinDate,
            //    LastActiveDate = info.LastActiveDate,
            //    //Roles = _userManager.GetRolesAsync(appUser.Id).Result.ToList(),
            //    RoleNames = _userManager.GetRolesAsync(appUser.Id).Result.ToList(),
            //    //Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result.ToList(),
            //    Devices = appUser.Devices,

            //};

        }

        public UserViewModel CreateUserViewModel(TTX.Data.AspNetUser appUser, string strCulture)
        {
            var info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == appUser.Id);
            if (info == null)
            {
                info = new TTX.Data.TTX_UserInfo()
                {
                    Culture = strCulture,
                    InviteCode = Guid.NewGuid().ToString("N"),
                    UserId = appUser.Id
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
            }
            return new UserViewModel(info, appUser, _userManager.GetRolesAsync(appUser.Id).Result.ToList(), strCulture);
        }

        public UserViewModel CreateUserViewModel(ApplicationUser appUser, UserDevice device, string strCulture)
        {
            TTX.Data.TTX_UserInfo info = TTXUserInfoDAL.Instance.GetSingleModel(u => u.UserId == appUser.Id);
            if (info == null)
            {
                info = new TTX.Data.TTX_UserInfo()
                {
                    Culture = strCulture,
                    InviteCode = Guid.NewGuid().ToString("N"),
                    UserId = appUser.Id
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
            }
            return new UserViewModel(info, appUser, _userManager.GetRolesAsync(appUser.Id).Result.ToList(), strCulture);


        }
        public UserViewModel CreateUserViewModel(ApplicationUser appUser, UserDevice device, TTX.Data.TTX_UserInfo info, string strCulture)
        {
            if (info == null)
            {
                info = new TTX.Data.TTX_UserInfo()
                {
                    InviteCode = Guid.NewGuid().ToString("N"),
                    UserId = appUser.Id
                };
                TTXUserInfoDAL.Instance.SaveModel(info);
            }
            return new UserViewModel(info, appUser, _userManager.GetRolesAsync(appUser.Id).Result.ToList(), strCulture);
            //{
            //    //Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
            //    Id = appUser.Id,
            //    IsActived = appUser.IsActived,
            //    IsSetPassword = appUser.IsSetPassword,
            //    NickName = info.NickName,
            //    //FirstName = appUser.UserInfo.FirstName,
            //    //LastName = appUser.UserInfo.LastName,
            //    DOB = info.DOB.HasValue ? info.DOB.Value.ToString("yyyy-MM-dd") : null,
            //    AgeGroup = info.AgeGroup,
            //    Gender = info.Gender,

            //    CountryId = info.CountryId,
            //    Country = country,
            //    //FullName = string.Format("{0} {1}", appUser.UserInfo.FirstName, appUser.UserInfo.LastName),
            //    Email = appUser.Email,
            //    Avatar = string.IsNullOrWhiteSpace(info.Avatar) ? null : string.Format("{0}{1}", CommonHelper.CurrentDomain, info.Avatar),
            //    EmailConfirmed = appUser.EmailConfirmed,
            //    //Level = appUser.Level,
            //    JoinDate = appUser.JoinDate,
            //    LastActiveDate = info.LastActiveDate,
            //    Device = device,
            //    //Roles = _userManager.GetRolesAsync(appUser.Id).Result.ToList(),
            //    RoleNames = _userManager.GetRolesAsync(appUser.Id).Result.ToList(),
            //    //Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result.ToList(),
            //    //Devices = appUser.Devices
            //};

        }
    }
}
