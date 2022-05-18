using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : ICharacterHealth
{
    private IAnimatorService _animatorService;
    private int _health;
    public int Health
    {
        get
        {
            if (_health > 0 && _health <= 100)
                return _health;
            else if (_health > 100)
                return 100;
            else
                return 0;
        }
        set
        {
            _health = value;
        }
    }
    public CharacterHealth(IAnimatorService animatorService)
    {
        _animatorService = animatorService;
        Health = 100;
    }
    public CharacterHealth(int health, IAnimatorService animatorService)
    {
        _animatorService = animatorService;
        Health = health;
    }
    public int GetHealth()
    {
        return Health;
    }
    public void SetHealth(int health)
    {
        Health = health;
    }
    public void CanAzalt(int health)
    {
        Health -= health;
        if (GetHealth() == 0)
        {
            _animatorService.Set("Die");
            Debug.Log("Oyun Bitti Karakter Öldü");
        }
        else
        {
            _animatorService.Set("Hurt");
            Debug.Log("Hasar Aldýk, Yeni Can : " + GetHealth());
        }
    }
    public void CanArttir(int health)
    {
        Health += health;
        Debug.Log("Can Ekledik, Yeni Can : " + GetHealth());
    }

}
