using System;
using GAMEPlay;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject setAnAlarmPanel = null;
        [SerializeField] private GameObject panelTimerIcon = null;
        [SerializeField] private GameObject timerIcon = null;
        [SerializeField] private TextMeshProUGUI textAlarmButton = null;
        [SerializeField] private Transform target = null;
        [SerializeField] private GameObject hoursArrow = null;
        [SerializeField] private TextMeshProUGUI analogClockText = null;
        
        private readonly GetGlobalTime _getGlobalTime = new GetGlobalTime();
        private readonly SetArrow _setArrow = new SetArrow();
        private bool _isActivate = false;
        private bool _state = true;
        
        private int _hours = 0;
        private int _minutes = 0;
        private int _seconds = 0;
        
        private void Awake()
        {
            _getGlobalTime.GetTime();
            _hours = _getGlobalTime.Hours;
            _minutes = _getGlobalTime.Minutes;
            _seconds = _getGlobalTime.Seconds;
        }

        private void Update()
        {
            if (!_isActivate)
            {
                _setArrow.Rotate(target, hoursArrow);
                _setArrow.MoveTarget(target);
                _setArrow.SetHours();
                analogClockText.text = "" + _setArrow._hoursAlarm + ":00";
            }
            Debug.Log("_isActivate = true" + _isActivate.ToString());
            analogClockText.text = "" + _setArrow._hoursAlarm + ":00";
            StartTimer();
        }

        public void SetAlarmButton()
        {
            setAnAlarmPanel.SetActive(true);
        }
        
        public void GoBackButton()
        {
            setAnAlarmPanel.SetActive(false);
            timerIcon.SetActive(true);
        }
        
        public void SetAndDeletedAlarmButton()
        {
            if (_state)
            {
                _isActivate = true;
                panelTimerIcon.SetActive(_state);
                textAlarmButton.text = "Delete Alarm";
                _state = false;
                StartTimer();
            } 
            else 
            {
                _isActivate = false;
                panelTimerIcon.SetActive(false);
                textAlarmButton.text = "Set An Alarm";
                _state = true;
                StopTimer();
            }
        }
        
        private void StartTimer()
        {
        }

        private void StopTimer()
        {
        }
    }
}
