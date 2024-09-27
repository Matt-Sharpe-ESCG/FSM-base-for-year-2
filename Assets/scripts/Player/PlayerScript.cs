using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public bool isGrounded;
        public float speed = 4;
        public float jumpFactor = 3;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpingState jumpingState;
        public CrouchingState crouchingState;
        public ThrowState throwState;

        public StateMachine sm;
        public Animator animator;
        public SpriteRenderer sr;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            animator = gameObject.GetComponent<Animator>();
            sr = gameObject.GetComponent<SpriteRenderer>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpingState = new JumpingState(this, sm);
            crouchingState = new CrouchingState(this, sm);
            throwState = new ThrowState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}\nisGrounded={2}", sm.LastState, sm.CurrentState, isGrounded);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press A or D to Move, S to crouch, W to jump, E to Throw");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            if (Input.GetKey("d") && isGrounded) // key held down
            {
                speed = -4;
                sr.flipX = false;
                sm.ChangeState(runningState);
                return;
            }

            if (Input.GetKey("a") && isGrounded)
            {
                speed = 4;
                sr.flipX = true;
                sm.ChangeState(runningState);
                return;
            }
        }
        public void CheckForIdle()
        {
            if (!Input.anyKey)
            {
                sm.ChangeState(idleState);
            }
        }

        public void CheckForJump()
        {
            if (Input.GetKey("w") && isGrounded)
            {
                sm.ChangeState(jumpingState);
            }


        }

        public void CheckForCrouch()
        {
            if (Input.GetKey("s") && isGrounded)
            {
                sm.ChangeState(crouchingState);
            }
        }

        public void CheckForThrow()
        {
            if (Input.GetKey("e") && isGrounded)
            {
                sm.ChangeState(throwState);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            isGrounded = true;
            print("isGrounded");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
            print("Not Grounded");
        }
    }

}