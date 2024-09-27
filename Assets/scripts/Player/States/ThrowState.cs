
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class ThrowState : State
    {
        // constructor
        public ThrowState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.animator.Play("arthur_shoot_forward", 0, 0);
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

            player.CheckForJump();
            Debug.Log("checking for jump");
            base.LogicUpdate();

            player.CheckForCrouch();
            Debug.Log("check for crouch");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}