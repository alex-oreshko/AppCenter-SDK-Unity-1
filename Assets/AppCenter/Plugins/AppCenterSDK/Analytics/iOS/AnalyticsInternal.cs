﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if UNITY_IOS && !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;

namespace Microsoft.AppCenter.Unity.Analytics.Internal
{
    class AnalyticsInternal
    {
        public static void PrepareEventHandlers()
        {
        }

        public static IntPtr GetNativeType()
        {
            return appcenter_unity_analytics_get_type();
        }

        public static void TrackEvent(string eventName)
        {
            appcenter_unity_analytics_track_event(eventName);
        }

        public static void TrackEventWithProperties(string eventName, string[] keys, string[] values, int count)
        {
            appcenter_unity_analytics_track_event_with_properties(eventName, keys, values, count);
        }

        public static AppCenterTask SetEnabledAsync(bool isEnabled)
        {
            appcenter_unity_analytics_set_enabled(isEnabled);
            return AppCenterTask.FromCompleted();
        }

        public static AppCenterTask<bool> IsEnabledAsync()
        {
            var isEnabled = appcenter_unity_analytics_is_enabled();
            return AppCenterTask<bool>.FromCompleted(isEnabled);
        }

#region External

        [DllImport("__Internal")]
        private static extern IntPtr appcenter_unity_analytics_get_type();

        [DllImport("__Internal")]
        private static extern void appcenter_unity_analytics_track_event(string eventName);

        [DllImport("__Internal")]
        private static extern void appcenter_unity_analytics_track_event_with_properties(string eventName, string[] keys, string[] values, int count);

        [DllImport("__Internal")]
        private static extern void appcenter_unity_analytics_set_enabled(bool isEnabled);

        [DllImport("__Internal")]
        private static extern bool appcenter_unity_analytics_is_enabled();

#endregion
    }
}
#endif
