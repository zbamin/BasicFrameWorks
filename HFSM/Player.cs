using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    public State state = State.Idle;

    Dictionary<State, PlayerState> playerStates = new Dictionary<State, PlayerState>();


    #region HFSM
    public abstract class PlayerState
    {
        protected Player m_Player;
        protected State m_State;

        public PlayerState(Player player, State state)  //플레이어, 상태 받아오기
        {
            m_Player = player;
            m_State = state;
        }

        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
    }

    public class IdleState : PlayerState
    {
        public IdleState(Player player, State state) : base(player, state) { }

        public override void Enter()
        {
            Debug.Log("Enter IdleState");
        }
        public override void Tick()
        {
            Debug.Log("Idle Tick");
        }

        public override void Exit()
        {
            Debug.Log("Idle Exit");
        }
    }

    public class MoveState : PlayerState
    {
        public MoveState(Player player, State state) : base(player, state) { }

        public override void Enter()
        {
            Debug.Log("Enter MoveState");
        }
        public override void Tick()
        {
            Debug.Log("Move Tick");
        }

        public override void Exit()
        {
            Debug.Log("Exit Move");
        }
    }

    public class AttackState : PlayerState
    {
        public AttackState(Player player, State state) : base(player, state) { }

        public override void Enter()
        {
            Debug.Log("Enter AttackState");
        }
        public override void Tick()
        {
            Debug.Log("Attack Tick");
        }

        public override void Exit()
        {
            Debug.Log("Exit Attack");
        }
    }
    
    #endregion

    void SetHFSM()
    {
        playerStates.Add(State.Idle, new IdleState(this, State.Idle));  //Idle 
        playerStates.Add(State.Move, new MoveState(this, State.Move));  //Move
        playerStates.Add(State.Attack, new AttackState(this, State.Attack));  //Attack
    }

    void ChangeHFSM(State s)
    {
        playerStates[state].Exit();
        state = s;
        playerStates[state].Enter();
    }


    private void Awake()
    {
        SetHFSM();
        state = State.Idle;
    }

    private void Update()
    {
        playerStates[state].Tick();
    }

}