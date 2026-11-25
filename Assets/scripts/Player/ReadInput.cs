using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public event Action OnJumpPressed;
    public event Action OnRollPressed;
    public event Action OnLightAttackPressed;
    public event Action OnHeavyAttackPressed;
    public event Action OnShootPressed;
    public event Action OnDrinkPotionPressed;

    // Called by PlayerInput (Send Messages)
    private void OnGroundMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Jump");
            OnJumpPressed?.Invoke();
        }
    }

    private void OnRoll(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Roll");
            OnRollPressed?.Invoke();
        }
    }

    private void OnLAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Light Attack");
            OnLightAttackPressed?.Invoke();
        }
    }

    private void OnHAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Heavy Attack");
            OnHeavyAttackPressed?.Invoke();
        }
    }

    private void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Shoot");
            OnShootPressed?.Invoke();
        }
    }

    private void OnDrinkPotion(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Drink Potion");
            OnDrinkPotionPressed?.Invoke();
        }
    }
}