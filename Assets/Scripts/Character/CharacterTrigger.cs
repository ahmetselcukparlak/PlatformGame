using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class CharacterTrigger : MonoBehaviour
{
    public AltinManager altinManager;
    public Tilemap tilemap;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Gold")
        {
            altinManager.AltinArttir();
        }
        if (other.gameObject.tag == "Door")
        {
            int whichScene = SceneManager.GetActiveScene().buildIndex;
            if (whichScene == 0)
            {
                SceneManager.LoadScene(1);
            }
            else if (whichScene == 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tuzak")
        {
            CharacterService.Instance.characterHealth.CanAzalt(CharacterService.Instance.characterHealth.GetHealth());
        }
    }
}
