using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public GameObject[] planetsPlaceHolders;
    public GameObject[] planetas;

    public GameObject[] huesosPlaceHolders;
    public GameObject[] huesos;

    public GameObject[] powerUps;

    public Puntuacion puntuacion;
    public float tiempoEspera;

    public int spawnPlanetas;
    public int spawnPlanetsPlaceHolders;
    public int spawnHuesos;
    public int spawnPowerUps;
    public int spawnHuesosPlaceHolders;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion = FindObjectOfType<Puntuacion>();
        tiempoEspera = 3;

        planetsPlaceHolders = GameObject.FindGameObjectsWithTag("Respawns"); 
        huesosPlaceHolders = GameObject.FindGameObjectsWithTag("RespawnsHuesos"); 
        SpawnearPlanetas();
        StartCoroutine(PararHuesosPlaceHolder());
        StartCoroutine(PararPowerUpPlaceHolder());
    }

    void SpawnearPlanetas()
    {
        spawnPlanetas = UnityEngine.Random.Range(0, planetas.Length);
        spawnPlanetsPlaceHolders = UnityEngine.Random.Range(0, planetsPlaceHolders.Length);

        GameObject newPlanet = Instantiate(planetas[spawnPlanetas]);
        newPlanet.transform.position = planetsPlaceHolders[spawnPlanetsPlaceHolders].transform.position;
        StartCoroutine(PararPlaceHolder());
        Destroy(newPlanet, 16);
    }

    void SpawnearHuesos()
    {
        spawnHuesos = UnityEngine.Random.Range(0, huesos.Length);
        spawnHuesosPlaceHolders = UnityEngine.Random.Range(0, huesosPlaceHolders.Length);

        GameObject newHueso = Instantiate(huesos[spawnHuesos]);
        newHueso.transform.position = huesosPlaceHolders[spawnHuesosPlaceHolders].transform.position;
        StartCoroutine(PararHuesosPlaceHolder());
        Destroy(newHueso, 15);
    }

    void SpawnearPowerUps()
    {
        spawnPowerUps = UnityEngine.Random.Range(0, powerUps.Length);
        spawnHuesosPlaceHolders = UnityEngine.Random.Range(0, huesosPlaceHolders.Length);

        GameObject newPowerUp = Instantiate(powerUps[spawnPowerUps]);
        newPowerUp.transform.position = huesosPlaceHolders[spawnHuesosPlaceHolders].transform.position;
        StartCoroutine(PararPowerUpPlaceHolder());
        Destroy(newPowerUp, 15);
    }

    IEnumerator PararPlaceHolder()
    {
        if (puntuacion.puntos == 10)
        {
            tiempoEspera = 2f;
        }
        if (puntuacion.puntos == 15)
        {
            tiempoEspera = 1f;
        }
        if (puntuacion.puntos == 40)
        {
            tiempoEspera = .7f;
        }
        yield return new WaitForSeconds(tiempoEspera);
        SpawnearPlanetas();
    }

    IEnumerator PararHuesosPlaceHolder()
    {
        var tiempoEspera = UnityEngine.Random.Range(3, 8);
        yield return new WaitForSeconds(tiempoEspera);
        SpawnearHuesos();
    }

    IEnumerator PararPowerUpPlaceHolder()
    {
        var tiempoEspera = UnityEngine.Random.Range(20, 40);
        yield return new WaitForSeconds(tiempoEspera);
        SpawnearPowerUps();
    }
}
