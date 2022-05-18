using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterService : MonoBehaviour
{
    public static CharacterService Instance { get; set; }
    public AHealth characterHealth;
    public CharacterMovement characterMovement;

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        characterHealth = new CharacterHealth(100, GetComponent<AnimatorService>());
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            characterHealth.CanArttir(5);
        if (Input.GetKeyDown(KeyCode.U))
            characterHealth.CanAzalt(10);
    }
}
