using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class Request : MonoBehaviour
    {
        private void Start()
        {
            _time = CheckGlobalTime();
            print(_time);
        }

        private DateTime _time;
        private string _url = "http://worldtimeapi.org/api/timezone/America/Argentina/Salta";

        private void Awake()
        {
            StartCoroutine(SendRequest());
        }

        private IEnumerator SendRequest()
        {
            UnityWebRequest request = UnityWebRequest.Get(this._url);

            yield return request.SendWebRequest();

            ResponseDataTime responseTime = JsonUtility.FromJson<ResponseDataTime>(request.downloadHandler.text);
            // Debug.Log("datetime" + responseTime.datetime + "datetime");
        }
        
        // второй способ получения времени
        private DateTime CheckGlobalTime()
        {
            var www = new WWW("google.com");

            while (!www.isDone && www.error == null)
            {
                Thread.Sleep(1);
            }

            var timeStr = www.responseHeaders["Date"];

            print(timeStr);

            if (!DateTime.TryParse(timeStr, out var globDateTime))
            {
                return DateTime.MinValue;
            }

            return globDateTime.ToUniversalTime();
        }

        private IEnumerator CheckTime()
        {
            _time = CheckGlobalTime();
            yield return new WaitForSeconds(50f); // здесь раз в 50 секунд
        }
    }
}