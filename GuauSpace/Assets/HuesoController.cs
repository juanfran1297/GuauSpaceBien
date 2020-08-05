using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoController : MonoBehaviour
{
    public int valorHuesos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<Puntuacion>().puntos  += valorHuesos;
            Destroy(this.gameObject);
        }
    }
}
