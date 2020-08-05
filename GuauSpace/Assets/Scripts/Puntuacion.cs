using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI puntosTexto;
    
    void Update()
    {
        puntosTexto.text = puntos.ToString();
    }
}
