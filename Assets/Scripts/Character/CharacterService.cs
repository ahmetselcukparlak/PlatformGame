using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService : MonoBehaviour
{
    public static CharacterService Instance { get; set; }
    public AHealth characterHealth;
    private CharacterMovement characterMovement;
    private CharacterJump characterJump;

    public HealthBar HealthBar;

    public GameObject oyuncu;
    
    private void Awake()
    {
        Instance = this;
        oyuncu = this.gameObject;
        characterMovement = GetComponent<CharacterMovement>();
        characterJump = GetComponent<CharacterJump>();
    }
    public void Start()
    {
        HealthBar.SetMaxHealth(100);
        characterHealth = new CharacterHealth(100, GetComponent<AnimatorService>(),HealthBar);
    }
    public void Dead()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ground");
        gameObject.layer = LayerIgnoreRaycast;
    }
    public void DisableCharacter(){
        characterMovement.enabled = false;
        characterJump.enabled=false;
    }
}
