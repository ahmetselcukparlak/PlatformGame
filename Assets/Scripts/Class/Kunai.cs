using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float speed;
    void Start()
    {
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * 2 * Time.deltaTime);
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            Destroy(gameObject);
        }
    }
}
