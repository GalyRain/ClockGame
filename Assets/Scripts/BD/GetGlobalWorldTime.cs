using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BD
{
    public class GetGlobalWorldTime : MonoBehaviour
    {
        private DateTime _time;
        private string _url = "http://worldtimeapi.org/api/timezone/Europe/London";

        private void Start()
        {
            StartCoroutine(GetGlobalTime());
        }

        private IEnumerator GetGlobalTime()
        {
            UnityWebRequest request = UnityWebRequest.Get(this._url);

            yield return request.SendWebRequest();

            ResponseDataTime responseTime = JsonUtility.FromJson<ResponseDataTime>(request.downloadHandler.text);
            Debug.Log("datetime: " + responseTime.utc_datetime);
        }
    }
}