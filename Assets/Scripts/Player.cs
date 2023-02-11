using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private const string ParameterAnimatorState = "state";

    [SerializeField] private CoinTaker _coinTaker;

    private Animator _animator;
    private int _coinsCollected;

    public static Player Instance { get; set; }

    public States State
    {
        get { return (States)_animator.GetInteger(ParameterAnimatorState); }
        set { _animator.SetInteger(ParameterAnimatorState, (int)value); }
    }

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _coinTaker.CoinTook += TakeCoin;
    }

    private void TakeCoin()
    {
        _coinsCollected++;
    }
}

public enum States
{
    idle,
    run,
    jump
}