using System;
using TMPro;
using UnityEngine;

namespace GAMEManager
{
    public class AlarmClock : MonoBehaviour
    {
        [SerializeField] private TMP_InputField timerText;
 
        private float _time= 0f;

        private void Start()
        {
            UpdateTimeText();
        }

        private void UpdateTimeText()
        {
            float hours = Mathf.FloorToInt(60);
            float minutes = Mathf.FloorToInt(24);
            timerText.text = string.Format("{0:00} : {1:00}", hours, minutes);
        }
    }
    
    
}
