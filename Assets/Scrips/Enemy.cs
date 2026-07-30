using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    protected Animator animator;
    protected bool IsDead => health.CurrentHealth <=0;
    [SerializeField]
    protected Transform target;
    public Transform Target {set {target = value; }}
    protected enum State { Active, Dead}
    protected State currentState;
    private void Awake()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        currentState = State.Active;
    }
    public virtual void OnEnable()
    {
        health.InitializeHealth();
        currentState = State.Active;
    }
}