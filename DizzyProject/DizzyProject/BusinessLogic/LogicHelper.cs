using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public static class LogicHelper
    {
        public static string ErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 40001: return AppResources.ApiError40001Validation;
                case 40002: return AppResources.ApiError40002InvalidEmailOrPassword;
                case 40003: return AppResources.ApiError40003UserAlreadyRegistered;
                case 40004: return AppResources.ApiError40004NoToken;
                case 40005: return AppResources.ApiError40005InvalidToken;
                case 40006: return AppResources.ApiError40006UrlParameterNumber;
                case 40007: return AppResources.ApiError40007CurrentPasswordIncorrect;
                case 40008: return AppResources.ApiError40008LocationNotFound;
                case 40009: return AppResources.ApiError40009RelationExists;
                case 40010: return AppResources.ApiError40010LevelRequired;
                case 40301: return AppResources.ApiError40301OnlyPhysiotherapist;
                case 40302: return AppResources.ApiError40302OnlyPatient;
                case 40303: return AppResources.ApiError40303AccessDenied;
                case 40401: return AppResources.ApiError40401UserNotFound;
                case 40402: return AppResources.ApiError40402ElementNotFound;
                case 40501: return AppResources.ApiError50001InternalServerError;
                default: return AppResources.UnhandledError;
            }
        }

        public static long GetPatientId(long? userId)
        {
            if (userId == null) return Resource.UserId;
            else return (long)userId;
        }
    }
}
