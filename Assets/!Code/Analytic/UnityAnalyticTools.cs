using System.Collections.Generic;
using UnityEngine.Analytics;


namespace Analytic
{
    public class UnityAnalyticTools : IAnalyticTools
    {
        public void SendMessage(string alias, IDictionary<string, object> eventData = null)
        {
            if (eventData == null)
            {
                eventData = new Dictionary<string, object>();
            }

            Analytics.CustomEvent(alias, eventData);
        }
    }
}