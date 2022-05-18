using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorService))]
public class CharacterAttack : MonoBehaviour
{
    private ICharacterInput characterInput;
    private AnimatorService animatorService;

    public List<string> attackNames = new List<string>();

    private void Awake()
    {
        characterInput = new CharacterInput();
        animatorService = GetComponent<AnimatorService>();
    }
   
    void Update()
    {
        characterInput.SetInput();
        if (characterInput.isAttack)
        {
            //Collider Aktif Et
            //Düþmanýn Canýný Azalt
            animatorService.Set(attackNames[Random.Range(0, attackNames.Count)]);
        }
    }
}
