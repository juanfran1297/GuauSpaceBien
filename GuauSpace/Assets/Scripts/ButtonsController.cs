using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
   
    public void CargarEscena(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Salir()
    {
        Application.Quit();
    }

    
}
