using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace GAMEManager
{
    public class ClockAnalog : MonoBehaviour
    {
        private DateTime _time; 
        private float _timeHours, _timeMinutes, _timeSeconds;
        private int localTime = 4; 
        private const float 
            HoursDegree = 360f / 12f,
            MinutesDegree = 360f / 60f,
            SecondsDegree = 360f / 60f;
        public Transform hours, minutes, seconds;
 
        private void Start()
        {
            _time = CheckGlobalTime();
            print(_time);
        }
 
        private void Update()
        {
            _timeHours = localTime + _time.Hour + (Time.time / 3600);
            _timeMinutes = _time.Minute + (Time.time / 60);
            _timeSeconds = _time.Second + Time.time;
 
            hours.localRotation = Quaternion.Euler(0f, 0f, _timeHours * -HoursDegree);
            minutes.localRotation = Quaternion.Euler(0f, 0f, _timeMinutes * -MinutesDegree);
            seconds.localRotation = Quaternion.Euler(0f, 0f, _timeSeconds * -SecondsDegree);
            StartCoroutine(CheckTime());
        }
 
        private DateTime CheckGlobalTime()
        {
            DateTime globDateTime;
 
            var www = new WWW("google.com");
 
            while (!www.isDone && www.error == null)
            {
                Thread.Sleep(1);
            }
 
            var timeStr = www.responseHeaders["Date"];
 
            print(timeStr);
        
            if (!DateTime.TryParse(timeStr, out globDateTime))
            {
                return DateTime.MinValue;
            }
            return globDateTime.ToUniversalTime();
        }
        
        private IEnumerator CheckTime()
        {
            _time = CheckGlobalTime();
            yield return new WaitForSeconds(3600f);
        }
    }
}
