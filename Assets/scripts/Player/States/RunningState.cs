
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.animator.Play("arthur_run", 0, 0);
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
        }

        public override void PhysicsUpdate()
        {
            player.transform.position = new Vector2(player.transform.position.x - (player.speed * Time.deltaTime), player.transform.position.y);
            base.PhysicsUpdate();
        }
    }
}