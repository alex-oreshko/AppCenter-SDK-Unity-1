// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if (!UNITY_IOS && !UNITY_ANDROID && !UNITY_WSA_10_0) || UNITY_EDITOR
using Microsoft.AppCenter.Unity.Analytics.Internal;
using System;
using System.Collections.Generic;
#if UNITY_IOS
    using RawType = System.IntPtr;
#elif UNITY_ANDROID
using RawType = UnityEngine.AndroidJavaObject;
#else
    using RawType = System.Object;
#endif
namespace Microsoft.AppCenter.Unity.Analytics
{

    public class WrapperTransmissionTargetInternal
    {

        public static void TrackEvent(RawType transmissionTarget, string eventName)
        {
            
        }

        public static void TrackEventWithProperties(RawType transmissionTarget, string eventName, IDictionary<string, string> properties)
        {
            
        }

        public static void SetEnabled(RawType transmissionTarget, bool enabled)
        {
            
        }

        public static bool IsEnabled(RawType transmissionTarget)
        {
            return false;
        }
    }
}
#endif