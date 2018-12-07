using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public static class ErrorHandling
    {
        public static string ErrorMessage(int errorNumber)
        {
            switch (errorNumber)
            {
                case 40001:
                    return AppResources.ApiError40001validation;
                case 40002:
                    return AppResources.ApiError40002invalidEmailOrPassword;
                case 40003:
                    return AppResources.ApiError40003userAlreadyRegistered;
                case 40004:
                    return AppResources.ApiError40004noToken;
                case 40005:
                    return AppResources.ApiError40005invalidToken;
                case 40006:
                    return AppResources.ApiError40006urlParameterNumber;
                case 40007:
                    return AppResources.ApiError40007currentPasswordIncorrect;
                case 40008:
                    return AppResources.ApiError40008locationNotFound;
                case 40009:
                    return AppResources.ApiError40009relationExists;
                case 40010:
                    return AppResources.ApiError40010levelRequired;
                case 40301:
                    return AppResources.ApiError40301onlyPhysiotherapist;
                case 40302:
                    return AppResources.ApiError40302onlyPatient;
                case 40303:
                    return AppResources.ApiError40303accessDenied;
                case 40401:
                    return AppResources.ApiError40401userNotFound;
                case 40402:
                    return AppResources.ApiError40402elementNotFound;
                case 40501:
                    return AppResources.ApiError50001internalServerError;    
                default:
                    return AppResources.UnhandledError;
            }
        }
    }
}
