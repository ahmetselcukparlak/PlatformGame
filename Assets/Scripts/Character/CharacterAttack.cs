using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorService))]
public class CharacterAttack : MonoBehaviour
{
    private ICharacterInput characterInput;
    private AnimatorService animatorService;
    [SerializeField]
    private CircleCollider2D attackCollider;
    public List<string> attackNames = new List<string>();
    private bool attack;
    private void Awake()
    {
        characterInput = new CharacterInput();
        attackCollider = GetComponent<CircleCollider2D>();
        animatorService = GetComponent<AnimatorService>();
    }

    void Update()
    {
        characterInput.SetInput();
        if (characterInput.isAttack && !attack)
        {
            Invoke("TurnOnCollider", 0);
            Invoke("TurnOffCollider", 0.5f);
            //D��man�n Can�n� Azalt
            animatorService.Set(attackNames[Random.Range(0, attackNames.Count)]);
        }
    }
    void TurnOnCollider()
    {
        attackCollider.enabled = true;
        attack = true;
    }
    void TurnOffCollider()
    {
        attackCollider.enabled = false;
        attack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyService>().health.CanAzalt(50);
            Debug.Log(collision.GetComponent<EnemyService>().health.GetHealth());
        }
    }

}
