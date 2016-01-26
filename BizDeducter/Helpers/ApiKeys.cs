using System;

namespace BizDeducter.Helpers
{
    public static class ApiKeys
    {
        public static string InsightsKey 
        {
            get
            {
                //TODO: Update Key 
                #if DEBUG
                return Xamarin.Insights.DebugModeKey;
                #else
                return Xamarin.Insights.DebugModeKey;
                #endif
            }
        }
    }
}

