using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public List<GameObject> enemies; 
    public GameObject allEnemies;
    public GameObject Kapi;
    private void Awake() {
        Instance = this;
        
    }
    void Start()
    {
        AllEnemies();
    }

    public void KapiKontrol()
    {
        if(enemies.Count==0){
            Kapi.SetActive(true);
        }
        
    }
    private void Update() {
        KapiKontrol();   
    }
    public void AllEnemies()
    {
        for(int i=0;i<allEnemies.transform.childCount;i++){
            enemies.Add(allEnemies.transform.GetChild(i).gameObject);
        }
    }
}
