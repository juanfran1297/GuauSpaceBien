using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    public bool pausa = false;
    public GameObject canvasPausa;

    private void Start()
    {
        canvasPausa.SetActive(false);
    }

    public void Pausa()
    {
        pausa = !pausa;
    }

    private void Update()
    {
        if (pausa == true)
        {
            Time.timeScale = 0;
            canvasPausa.SetActive(true);
        }
        else if (pausa == false)
        {
            Time.timeScale = 1;
            canvasPausa.SetActive(false);
        }
    }
}
