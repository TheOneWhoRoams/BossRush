using System;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving,
    Sprinting,
    Rolling,
    Airborne,
    Staggered,
    Attacking
}

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; } = PlayerState.Idle;
    public event Action<PlayerState, PlayerState> OnStateChanged;

    // Grounded & free to act (Idle, Moving, Sprinting)
    public bool CanMoveXZ => CurrentState == PlayerState.Idle
                          || CurrentState == PlayerState.Moving
                          || CurrentState == PlayerState.Sprinting;

    public bool CanSprint(float currentStamina) => CanMoveXZ && currentStamina > 0f;
    public bool CanJump => CanMoveXZ;
    public bool CanRoll => CanMoveXZ;
    public bool CanAttack => CanMoveXZ || CurrentState == PlayerState.Airborne;

    public void SetState(PlayerState newState)
    {
        if (CurrentState == newState) return;

        PlayerState previous = CurrentState;
        CurrentState = newState;
        OnStateChanged?.Invoke(previous, newState);
    }
}