using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuesoController : MonoBehaviour
{
    public int valorHuesos;
    public Puntuacion puntuacion;

    private void Start()
    {
        puntuacion = FindObjectOfType<Puntuacion>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Acierto");
            FindObjectOfType<Puntuacion>().puntos  += valorHuesos;
            Destroy(this.gameObject);
            puntuacion.CalcularVelocidad();
        }
    }
}
