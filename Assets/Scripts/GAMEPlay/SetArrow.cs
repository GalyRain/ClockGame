using UnityEngine;

namespace GAMEPlay
{
    public class SetArrow
    {
        private float _speed = 100f;
        private Vector2 _startPosition = Vector2.zero;
        private float _directionX = 0f;
        private float _directionY = 0f;
        private float _moveX = 0f;
        private float _moveY = 0f;
        private float _angle = 0f;
        public float _hoursAlarm = 0f;

        public void Rotate(Transform target, GameObject hoursArrow)
        {
            Vector3 _target = target.transform.position;
            Vector3 _hoursArrow = hoursArrow.transform.position;
 
            _angle = Mathf.Atan2(_hoursArrow.x - _target.x, - _hoursArrow.y + _target.y) * Mathf.Rad2Deg;
            hoursArrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _angle));
        }
        
        private void InputTime()
        {
#if UNITY_EDITOR
            _moveX = Input.GetAxisRaw("Horizontal");
            _moveY = Input.GetAxisRaw("Vertical");
#endif
#if UNITY_ANDROID
            GetTouchInput();
#endif
        }

        private void GetTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {

                    case TouchPhase.Moved:
                        _directionX = touch.position.x > _startPosition.x ? 1f : -1f;
                        _directionY = touch.position.y > _startPosition.y ? 1f : -1f;
                        break;
                    default:
                        _startPosition = touch.position;
                        _directionX = 0f;
                        _directionY = 0f;
                        break;
                }
                _moveX = _directionX;
                _moveY = _directionY;
            }
        }

        public void MoveTarget(Transform target)
        {
            InputTime();
            var positionX = target.transform.position.x + _moveX * Time.deltaTime * _speed;
            var positionY = target.transform.position.y + _moveY * Time.deltaTime * _speed;
            target.transform.position = new Vector2(positionX, positionY);
        }

        public void SetHours()
        {
            if (_angle is > 0f and < 30f) _hoursAlarm = 11;
            if (_angle is > 30f and < 60f) _hoursAlarm = 10;
            if (_angle is > 60f and < 90f) _hoursAlarm = 9;
            if (_angle is > 90f and < 120f) _hoursAlarm = 8;
            if (_angle is > 120f and < 150f) _hoursAlarm = 7;
            if (_angle is > 150f and < 180f) _hoursAlarm = 6;
            if (_angle is < -150f and > -180f) _hoursAlarm = 5;
            if (_angle is < -120f and > -150f) _hoursAlarm = 4;
            if (_angle is < -90f and > -120f) _hoursAlarm = 3;
            if (_angle is < -60f and > -90f) _hoursAlarm = 2;
            if (_angle is < -30f and > -60f) _hoursAlarm = 1;
            if (_angle is < 0f and > -30f) _hoursAlarm = 12;
        }
    }
}