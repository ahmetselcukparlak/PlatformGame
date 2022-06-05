using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTrigger : MonoBehaviour
{
    //Altın adında script oluştur
    //Playerprefs save load işlemi olsun
    public AltinManager altinManager;
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Gold")
        {
            altinManager.AltinArttir();
            Debug.Log(altinManager.Altin);
        }
        if (other.gameObject.tag == "Door")
        {
        int whichScene = SceneManager.GetActiveScene().buildIndex;
           if(whichScene == 0)
           {
               SceneManager.LoadScene(1);
           }
           else if(whichScene == 1)
           {
               SceneManager.LoadScene(0);
           }
        }
    }
}
