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

    public int spawnPlanetas;
    public int spawnPlanetsPlaceHolders;
    public int spawnHuesos;
    public int spawnHuesosPlaceHolders;
    // Start is called before the first frame update
    void Start()
    {
        planetsPlaceHolders = GameObject.FindGameObjectsWithTag("Respawns"); 
        huesosPlaceHolders = GameObject.FindGameObjectsWithTag("RespawnsHuesos"); 
        SpawnearPlanetas();
        StartCoroutine(PararHuesosPlaceHolder());
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

    IEnumerator PararPlaceHolder()
    {
        yield return new WaitForSeconds(2);
        SpawnearPlanetas();
    }

    IEnumerator PararHuesosPlaceHolder()
    {
        var tiempoEspera = UnityEngine.Random.Range(3, 8);
        Debug.Log(tiempoEspera);
        yield return new WaitForSeconds(tiempoEspera);
        SpawnearHuesos();
    }
}
