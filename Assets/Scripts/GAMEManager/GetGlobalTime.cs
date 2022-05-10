using System.Collections;
using UnityEngine;

namespace GAMEManager
{
    public class GetGlobalTime
    {
        public int Hours { get; private set; } = 0;
        public int Minutes { get; private set; } = 0;
        public int Seconds { get; private set; } = 0;

        public void GetTime() 
        {
            Hours = System.DateTime.Now.Hour;
            Minutes = System.DateTime.Now.Minute;
            Seconds = System.DateTime.Now.Second;
        }
		
        public IEnumerator CheckTime()
        {
            GetTime();
            yield return new WaitForSeconds(3600f);
        }
    }
}