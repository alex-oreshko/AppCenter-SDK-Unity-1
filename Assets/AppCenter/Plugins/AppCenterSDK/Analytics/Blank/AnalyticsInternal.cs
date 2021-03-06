﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if (!UNITY_IOS && !UNITY_ANDROID && !UNITY_WSA_10_0) || UNITY_EDITOR
using System;

namespace Microsoft.AppCenter.Unity.Analytics.Internal
{
#if UNITY_IOS || UNITY_ANDROID
    using RawType = System.IntPtr;
#else
    using RawType = System.Type;
#endif

    class AnalyticsInternal
    {
        public static void PrepareEventHandlers()
        {
        }

        public static RawType GetNativeType()
        {
            return default(RawType);
        }

        public static void TrackEvent(string eventName)
        {
        }

        public static void TrackEventWithProperties(string eventName, string[] keys, string[] values, int count)
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
    }
}
#endif
