using System;
using UnityEngine;

namespace GAMEPlay
{
    public class InputTime : MonoBehaviour
    {
        public static event Action<float> OnMoveX;
        public static event Action<float> OnMoveY;

        private Vector2 _startPosition = Vector2.zero;
        private float _directionX = 0f;
        private float _directionY = 0f;

        private void Update()
        {
#if UNITY_EDITOR
            OnMoveX?.Invoke(Input.GetAxisRaw("Horizontal"));
            OnMoveY?.Invoke(Input.GetAxisRaw("Vertical"));
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
                OnMoveX?.Invoke(_directionX);
                OnMoveX?.Invoke(_directionY);
            }
        }
    }
}