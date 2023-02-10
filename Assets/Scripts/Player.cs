using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ParameterAnimatorState = "state";

    [SerializeField] private CoinTaker _coinTaker;

    private Animator animator;
    private int coinsCollected;

    public static Player Instance { get; set; }

    public States State
    {
        get { return (States)animator.GetInteger(ParameterAnimatorState); }
        set { animator.SetInteger(ParameterAnimatorState, (int)value); }
    }

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        _coinTaker.CoinTook += TakeCoin;
    }

    private void TakeCoin()
    {
        coinsCollected++;
    }
}

public enum States
{
    idle,
    run,
    jump
}