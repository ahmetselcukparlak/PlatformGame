using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    public int facingDirection = 1;

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public AnimationToStatemachine atsm { get; private set; }

    public Transform enemyTransform { get; private set; }
    public EnemyService enemyService { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;

    private float currentHealth;

    private float healthDump;

    private int lastDamageDirection;

    private Vector2 velocityWorkspace;

    protected bool isDead = false;

    public virtual void Start()
    {

        aliveGO = transform.Find("Alive").gameObject;
        enemyService = aliveGO.GetComponent<EnemyService>();
        rb = aliveGO.GetComponent<Rigidbody2D>();
        enemyTransform = aliveGO.GetComponent<Transform>();
        anim = aliveGO.GetComponent<Animator>();
        atsm = aliveGO.GetComponent<AnimationToStatemachine>();

        if (enemyService.health != null)
        {
            currentHealth = enemyService.health.GetHealth();
        }
        healthDump = currentHealth;
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        currentHealth = enemyService.health.GetHealth();

        if (currentHealth <= 0)
            isDead = true;
        if (healthDump != currentHealth)
        {
            healthDump = currentHealth;
            Instantiate(entityData.hitParticle, aliveGO.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        }
        if (stateMachine != null)
        {
            if (stateMachine.currentState != null)
            {
                stateMachine.currentState.LogicUpdate();
            }
            else
            {
                stateMachine = new FiniteStateMachine();
            }
        }
    }

    public virtual void FixedUpdate()
    {
        if (stateMachine != null)
        {
            if (stateMachine.currentState != null)
            {
                stateMachine.currentState.PhysicsUpdate();
            }
            else
            {
                stateMachine = new FiniteStateMachine();
            }
        }
    }

    public virtual void SetVelocity(float velocity)
    {

        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = new Vector3(velocityWorkspace.x, velocityWorkspace.y, 0);
    }
    public virtual bool CheckVelocity()
    {
        if (rb.velocity.x == 0)
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x, enemyTransform.position.y + 0.01f, enemyTransform.position.z);
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(rb.velocity.x, velocity);
        rb.velocity = velocityWorkspace;
    }
    public virtual void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;

        DamageHop(entityData.damageHopSpeed);

        if (attackDetails.position.x > aliveGO.transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }
    }
    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }
}
