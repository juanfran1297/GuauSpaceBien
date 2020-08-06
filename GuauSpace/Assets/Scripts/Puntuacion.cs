using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI puntosTexto;
    public float planetsSpeed;
    public float huesosSpeed;

    public Text puntuacionTotal;

    private void Start()
    {
        planetsSpeed = 4;
        huesosSpeed = 5;
    }

    void Update()
    {
        puntosTexto.text = puntos.ToString();
        puntuacionTotal.text = puntos.ToString();
    }

    public void CalcularVelocidad()
    {
        if (puntos % 5 == 0)
        {
            Debug.Log("Más velocidad");
            planetsSpeed += 1;
            huesosSpeed += 1;
        }
    }
}
