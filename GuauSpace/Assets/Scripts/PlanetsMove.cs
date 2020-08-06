using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsMove : MonoBehaviour
{
    public Puntuacion puntuacion;

    private void Start()
    {
        puntuacion = FindObjectOfType<Puntuacion>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * puntuacion.planetsSpeed * Time.deltaTime;
    }
}
