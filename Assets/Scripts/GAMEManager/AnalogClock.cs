using System;
using TMPro;
using UnityEngine;

namespace GAMEManager
{
    public class AnalogClock : MonoBehaviour
    {
        private int _hours, _hoursOne, _hoursTwo;
        private int _minutes, _minutesOne, _minutesTwo;
        private int _seconds;
        private float _gameTime;
        private DateTime _time; 
        
        [SerializeField] private TextMeshProUGUI text = null;
        private readonly GetGlobalTime _getGlobalTime = new GetGlobalTime();
        
        private void Awake()
        {
            _getGlobalTime.GetTime();
            _hours = _getGlobalTime.Hours;
            _minutes = _getGlobalTime.Minutes;
            _seconds = _getGlobalTime.Seconds;
        }
		
        private void FixedUpdate()
        {
            StartCoroutine(_getGlobalTime.CheckTime());
            text.text = "" + _hours + ":" + _minutes;
            
            // _gameTime += 1 * Time.fixedDeltaTime;
            //
            // if (_gameTime > 1)
            // {
            //     _seconds += 1;
            //     _gameTime = 0;
            // }
            //
            // if (_seconds > 59)
            // {
            //     _minutesTwo += 1;
            //     _seconds = 0;
            // }
            //
            // if (_minutesTwo > 9)
            // {
            //     _minutesOne += 1;
            //     _minutesTwo = 0;
            // }
            //
            // if (_minutesOne > 5)
            // {
            //     _hoursTwo += 1;
            //     _minutesOne = 0;
            // }
            //
            // if (_hoursTwo > 9)
            // {
            //     _hoursOne += 1;
            //     _hoursTwo = 0;
            // }
            //
            // if (_hoursOne == 2 & _hoursTwo > 3)
            // {
            //     _hoursOne = 0;
            //     _hoursTwo = 0;
            // }
        }
    }
}
