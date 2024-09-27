
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.animator.Play("arthur_stand", 0, 0);
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
            player.CheckForRun();
            player.CheckForJump();
            player.CheckForCrouch();
            player.CheckForThrow();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}