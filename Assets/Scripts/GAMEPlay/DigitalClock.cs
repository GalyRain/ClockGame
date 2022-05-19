using BD;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAMEPlay
{
	public class DigitalClock : MonoBehaviour {
		
		private int _hours = 0;
		private int _minutes = 0;
		private int _seconds = 0;
		private float _gameTime = 0;
	
		[SerializeField] private GameObject hoursArrow = null;
		[SerializeField] private GameObject minutesArrow = null;
		[SerializeField] private GameObject secondsArrow = null;
		private readonly GetGlobalTime _getGlobalTime = new GetGlobalTime();
		private GetGlobalGoogleTime _globalGoogleTime = new GetGlobalGoogleTime();
		
		private void Awake()
		{
			_getGlobalTime.GetTime();
			_hours = _getGlobalTime.Hours;
			_minutes = _getGlobalTime.Minutes;
			_seconds = _getGlobalTime.Seconds;
		}
		
		private void Update() 
		{
			StartCoroutine(_getGlobalTime.CheckTime());
			_gameTime += Time.deltaTime;
			UpdateTime();
		}

		private void UpdateTime()
		{
			if(_gameTime >= 1.0f)
			{
				_gameTime -= 1.0f;
				_seconds++;
				if(_seconds >= 60)
				{
					_seconds = 0;
					_minutes++;
					if(_minutes > 60)
					{
						_minutes = 0;
						_hours++;
						if(_hours >= 24)
							_hours = 0;
					}
				}
			}

			var rotationSeconds = (360.0f / 60.0f)  * _seconds;
			var rotationMinutes = (360.0f / 60.0f)  * _minutes;
			var rotationHours = ((360.0f / 12.0f) * _hours) + ((360.0f / (60.0f * 12.0f)) * _minutes);
			
			secondsArrow.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationSeconds);
			minutesArrow.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationMinutes);
			hoursArrow.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -rotationHours);
		}
	}
}
