﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if (!UNITY_IOS && !UNITY_ANDROID && !UNITY_WSA_10_0) || UNITY_EDITOR
using System;
using Microsoft.AppCenter.Unity;

namespace Microsoft.AppCenter.Unity.Internal
{
#if UNITY_IOS
    using RawType = System.IntPtr;
    using ServiceType = System.IntPtr;
#elif UNITY_ANDROID
    using RawType = UnityEngine.AndroidJavaObject;
    using ServiceType = System.IntPtr;
#else
    using RawType = System.Object;
    using ServiceType = System.Type;
#endif

    class AppCenterInternal
    {
        public static void Configure(string appSecret)
        {
        }

        public static void Start(string appSecret, ServiceType[] services, int numServices)
        {
        }

        public static void StartServices(ServiceType[] services, int numServices)
        {
        }

        public static void SetLogLevel(int logLevel)
        {
        }

        public static int GetLogLevel()
        {
            return 0;
        }

        public static bool IsConfigured()
        {
            return false;
        }

        public static void SetLogUrl(string logUrl)
        {
        }

        public static AppCenterTask SetEnabledAsync(bool enabled)
        {
            return AppCenterTask.FromCompleted();
        }

        public static AppCenterTask<bool> IsEnabledAsync()
        {
            return AppCenterTask<bool>.FromCompleted(false);
        }

        public static AppCenterTask<string> GetInstallIdAsync()
        {
            return AppCenterTask<string>.FromCompleted("");
        }

        public static void SetCustomProperties(RawType properties)
        {
        }

        public static void SetWrapperSdk(string wrapperSdkVersion,
                                         string wrapperSdkName,
                                         string wrapperRuntimeVersion,
                                         string liveUpdateReleaseLabel,
                                         string liveUpdateDeploymentKey,
                                         string liveUpdatePackageHash)
        {
        }
    }
}
#endif
