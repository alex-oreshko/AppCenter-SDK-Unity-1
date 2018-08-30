﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

using Microsoft.AppCenter.Unity.Crashes.Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.AppCenter.Unity.Crashes
{
#if UNITY_IOS || UNITY_ANDROID
    using RawType = System.IntPtr;
#else
    using RawType = System.Type;
#endif

    public class Crashes
    {
        public static void Initialize()
        {
            CrashesDelegate.SetDelegate();
        }

        public static RawType GetNativeType()
        {
            return CrashesInternal.GetNativeType();
        }

        public static void TrackError(Exception exception, IDictionary<string, string> properties = null)
        {
            if (exception != null)
            {
                var exceptionWrapper = CreateWrapperException(exception);
                if (properties == null || properties.Count == 0)
                {
                    CrashesInternal.TrackException(exceptionWrapper.GetRawObject());
                }
                else
                {
                    CrashesInternal.TrackException(exceptionWrapper.GetRawObject(), properties);
                }
            }
        }

        public static void OnHandleLog(string logString, string stackTrace, LogType type)
        {
            if (LogType.Assert == type || LogType.Exception == type || LogType.Error == type)
            {
                var exception = CreateWrapperException(logString, stackTrace);
                CrashesInternal.TrackException(exception.GetRawObject());
            }
        }

        public static void OnHandleUnresolvedException(object sender, UnhandledExceptionEventArgs args)
        {
            if (args == null || args.ExceptionObject == null)
            {
                return;
            }

            Exception e = args.ExceptionObject as Exception;
            if (e != null)
            {
                var exception = CreateWrapperException(e.Source, e.StackTrace);
                CrashesInternal.TrackException(exception.GetRawObject());
            }
        }

        public static AppCenterTask<bool> IsEnabledAsync()
        {
            return CrashesInternal.IsEnabledAsync();
        }

        public static AppCenterTask SetEnabledAsync(bool enabled)
        {
            return CrashesInternal.SetEnabledAsync(enabled);
        }

        public static void GenerateTestCrash()
        {
            CrashesInternal.GenerateTestCrash();
        }

        public static AppCenterTask<bool> HasCrashedInLastSession()
        {
            return CrashesInternal.HasCrashedInLastSession();
        }

        public static void DisableMachExceptionHandler()
        {
            CrashesInternal.DisableMachExceptionHandler();
        }

        private static WrapperException CreateWrapperException(Exception exception)
        {
            var exceptionWrapper = new WrapperException();
            exceptionWrapper.SetWrapperSdkName(GetExceptionWrapperSdkName());
            exceptionWrapper.SetStacktrace(exception.StackTrace);
            exceptionWrapper.SetMessage(exception.Message);
            exceptionWrapper.SetType(exception.GetType().ToString());

            if (exception.InnerException != null)
            {
                var innerExceptionWrapper = CreateWrapperException(exception.InnerException).GetRawObject();
                exceptionWrapper.SetInnerException(innerExceptionWrapper);
            }

            return exceptionWrapper;
        }

        private static WrapperException CreateWrapperException(string logString, string stackTrace)
        {
            var exception = new WrapperException();
            exception.SetWrapperSdkName(GetExceptionWrapperSdkName());

            string sanitizedLogString = logString.Replace("\n", " ");
            var logStringComponents = sanitizedLogString.Split(new[] { ':' }, 2);
            if (logStringComponents.Length > 1)
            {
                var type = logStringComponents[0].Trim();
                exception.SetType(type);
                var message = logStringComponents[1].Trim();
                exception.SetMessage(message);
            }

            string[] stacktraceLines = stackTrace.Split('\n');
            string stackTraceString = "";
            foreach (string line in stacktraceLines)
            {
                if (line.Length > 0)
                {
                    stackTraceString += "at " + line + "\n";
                }
            }
            exception.SetStacktrace(stackTraceString);

            return exception;
        }

        private static string GetExceptionWrapperSdkName()
        {
            //return WrapperSdk.Name;
            return "appcenter.xamarin"; // fix stack traces are not showing up in the portal UI
        }
    }
}