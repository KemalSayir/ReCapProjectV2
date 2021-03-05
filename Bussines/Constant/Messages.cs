using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussines.Constant
{
    public static class Messages
    {
        public static string ImageLimit = "This Car has Enough Images";
        internal static string FileNotExist = "File is Not Exist On Path";
        internal static string UserNotFound = "User is not Exist";
        internal static string PasswordNotFound = "Password Not Found";
        internal static string SuccessToLogin = "Login Was Successfuly";
        internal static string UserAlreadyExist = "User Already Exist";
        internal static string UserRegistered = "User Registered";
        internal static string AccessTokenCreated = "Token Created Successfuly";
        internal static string AuthorizationDenied = "You can not";
        internal static string UserGet = "User was get";
    }
}
