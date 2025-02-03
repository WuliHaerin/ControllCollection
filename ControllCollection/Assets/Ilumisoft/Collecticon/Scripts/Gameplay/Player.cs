using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ilumisoft.Collecticon
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveForce /*= 5.0f*/;
        [SerializeField] private float maxVelocity /*= 10.0f*/;
        [SerializeField] private float turnVelocity /*= 10.0f*/;
        public Vector3 RevivePlace;
        public Vector3 ReviveRotation;

        public void SetPos()
        {
            if(RevivePlace!=null)
            {
                transform.position = RevivePlace;
                transform.localEulerAngles = ReviveRotation;
                StopCoroutine("Record");
                StartCoroutine("Record");
                _rigidbody2D.velocity = Vector2.zero;
            }
        }


        public IEnumerator Record()
        {
            for(; ; )
            {
                yield return new WaitForSeconds(4f);
                RevivePlace = transform.position;
                ReviveRotation = transform.localEulerAngles;
            }
        }

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine("Record");
        }


        private void FixedUpdate()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            var horizontalInput = GetInput();

            //Add forward force
            _rigidbody2D.AddForce(transform.up * moveForce, ForceMode2D.Force);
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, maxVelocity);

            //Player is rotated by player input
            _rigidbody2D.MoveRotation(_rigidbody2D.rotation - turnVelocity * horizontalInput * Time.deltaTime);
        }

        float GetInput()
        {
            //Mouse/Touch Input
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var mousePosition = Input.mousePosition;

                var screenCenter = new Vector2(Screen.width, Screen.height) / 2.0f;

                return mousePosition.x > screenCenter.x ? 1.0f : -1.0f;
            }
            //Keyboard Input
            else
            {
                return Input.GetAxis("Horizontal");
            }
        }


    }
}