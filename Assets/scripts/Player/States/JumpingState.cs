
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class JumpingState : State
    {
        public JumpingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }
        public override void Enter()
        {
            player.animator.Play("arthur_jump_up", 0, 0);
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
            player.CheckForIdle();
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            player.rb.velocityY = 4;
            base.PhysicsUpdate();
        }
    }
}