using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public GameObject[] placeHolders;
    public GameObject[] planetas;

    public float maxTime = 1;
    public float timer = 0;

    public int spawnPlanetas;
    public int spawnPlaceHolders;
    // Start is called before the first frame update
    void Start()
    {
        placeHolders = GameObject.FindGameObjectsWithTag("Respawns");
    }

    // Update is called once per frame
    void Update()
    {        
        spawnPlanetas = UnityEngine.Random.Range(0, planetas.Length);
        spawnPlaceHolders = UnityEngine.Random.Range(0, placeHolders.Length);
        
        if(timer > maxTime)
        {
            if (placeHolders[spawnPlaceHolders].GetComponent<PlaceHolderController>().activo != false)
            {
                GameObject newPlanet = Instantiate(planetas[spawnPlanetas]);
                newPlanet.transform.position = placeHolders[spawnPlaceHolders].transform.position;
                StartCoroutine(PararPlaceHolder());
                Destroy(newPlanet, 15);
                timer = 0;
            }
            else return;
        }
        timer += Time.deltaTime;
    }

    IEnumerator PararPlaceHolder()
    {
        placeHolders[spawnPlaceHolders].GetComponent<PlaceHolderController>().activo = false;
        yield return new WaitForSeconds(2);
        placeHolders[spawnPlaceHolders].GetComponent<PlaceHolderController>().activo = true;
    }
}
