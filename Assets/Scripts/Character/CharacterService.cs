using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService : MonoBehaviour
{
    public static CharacterService Instance { get; set; }
    public AHealth characterHealth;
    private CharacterMovement characterMovement;
    private CharacterJump characterJump;
    
    public GameObject oyuncu;
    public HealthBarBehaviour Healthbar;
    private void Awake()
    {
        Instance = this;
        oyuncu = this.gameObject;
        characterMovement = GetComponent<CharacterMovement>();
        characterJump = GetComponent<CharacterJump>();
    }
    public void Start()
    {
        characterHealth = new CharacterHealth(100, GetComponent<AnimatorService>(),Healthbar);
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
