using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class CrouchingState : State
    {
        public CrouchingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }
        public override void Enter()
        {
            player.animator.Play("arthur_crouch", 0, 0);
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            Debug.Log("checking for idle");

        }
    }
}