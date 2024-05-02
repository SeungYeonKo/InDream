using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerMove : MonoBehaviour
    {
        private Animator _animator;

        public float Speed = 2; 
        public float JumpSpeed = 2; 
        public float Gravity = 1; 

        public float rotas = 5; 

        // 시간 측정을 위한 변수
        float second; 

        private CharacterController _charactercontroller;
        private Vector3 moveDirection = Vector3.zero;
        
        void Start()
        {
        _animator = GetComponent<Animator>();
        _charactercontroller = GetComponent<CharacterController>();
        }

        void Update()
        {
            // Smile
            if (Input.GetKey("q"))
            {
            _animator.SetBool("smileFlag", true);
            } else {
            _animator.SetBool("smileFlag", false);
            }
 
            // JumpAnimation
            if (_charactercontroller.isGrounded)
            {
                second += Time.deltaTime;

                if (Input.GetKeyDown("space"))
                {
                _animator.SetBool("jumpFlag", true);
                _animator.SetBool("walkFlag", false);
                _animator.SetBool("idleFlag", false);
                } else if ((Input.GetKey("up")) || (Input.GetKey("right")) || (Input.GetKey("down")) || (Input.GetKey("left"))|| Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a"))
                {
                _animator.SetBool("jumpFlag", false);
                _animator.SetBool("walkFlag", true);
                _animator.SetBool("idleFlag", false);
                } else if (second >= 15)
                {
                _animator.SetBool("jumpFlag", false);
                _animator.SetBool("walkFlag", false);
                _animator.SetBool("idleFlag", false);
                _animator.SetTrigger("idleBFlag");
                    second = 0;
                } else {
                _animator.SetBool("jumpFlag", false);
                _animator.SetBool("walkFlag", false);
                _animator.SetBool("idleFlag", true);
                }

                // Move
                if (Input.GetKey("up") || Input.GetKey("w"))
                {
                    float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 180);
                    if (angleDiff == 0)
                    {
                    _charactercontroller.Move (this.gameObject.transform.forward * Speed * Time.deltaTime);
                    } else if (angleDiff < -1f)
                    {
                        transform.Rotate(0, rotas * -1, 0);
                    } else if (angleDiff > 1f)
                    {
                        transform.Rotate(0, rotas * 1, 0);
                    } else {
                        transform.rotation = Quaternion.Euler(0.0f, 180, 0.0f);
                    }
                }

                if (Input.GetKey("right") || Input.GetKey("d"))
                {
                    float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, -90);
                    if (angleDiff == 0)
                    {
                    _charactercontroller.Move (this.gameObject.transform.forward * Speed * Time.deltaTime);
                    } else if (angleDiff < -1f) 
                    {
                        transform.Rotate( 0,rotas * -1, 0);
                    } else if (angleDiff > 1f) 
                    {
                        transform.Rotate( 0,rotas * 1, 0);
                    } else 
                    {
                        transform.rotation = Quaternion.Euler(0.0f, -90, 0.0f);
                    }
                }

                if (Input.GetKey("down") || Input.GetKey("s")) 
                {
                    float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 0);
                    if (angleDiff == 0) 
                    {
                    _charactercontroller.Move (this.gameObject.transform.forward * Speed * Time.deltaTime);
                    } else if (angleDiff < -1f) 
                    {
                        transform.Rotate( 0,rotas * -1, 0);
                    } else if (angleDiff > 1f) 
                    {
                        transform.Rotate( 0,rotas * 1, 0);
                    } else 
                    {
                        transform.rotation = Quaternion.identity;
                    }
                }

                if (Input.GetKey("left") || Input.GetKey("a")) 
                {
                    float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 90);
                    if (angleDiff == 0) 
                    {
                    _charactercontroller.Move (this.gameObject.transform.forward * Speed * Time.deltaTime);
                    } else if (angleDiff < -1f) 
                    {
                        transform.Rotate( 0,rotas * -1, 0);
                    } else if (angleDiff > 1f) 
                    {
                        transform.Rotate( 0,rotas * 1, 0);
                    } else 
                    {
                        transform.rotation = Quaternion.Euler(0.0f, 90, 0.0f);
                    }
                }

                // Jump
                if (Input.GetKeyDown("space"))
                {
                    moveDirection.y = JumpSpeed;
                }

            }

            // 중력 적용
            moveDirection.y -= Gravity * Time.deltaTime;
        _charactercontroller.Move(moveDirection * Time.deltaTime);

        }
    }
