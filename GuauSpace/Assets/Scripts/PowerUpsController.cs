using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsController : MonoBehaviour
{
    public bool invencible = false;
    public int golpesEscudo;
    public int numGolpesEscudo;
    public bool escudoAlMaximo = false;

    public bool escudoAgain;

    public List<Image> Escudos = new List<Image>();
    public Image escudoImage;
    public Transform escudoInventory;

    [SerializeField] private GameObject escudo;
    // Start is called before the first frame update
    void Start()
    {
        golpesEscudo = 3;
        numGolpesEscudo = golpesEscudo;
        escudoAgain = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numGolpesEscudo == golpesEscudo)
        {
            escudoAlMaximo = true;
        }
        else escudoAlMaximo = false;

        if(invencible == true)
        {
            escudo.SetActive(true);
        }
        else
        {
            escudo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Escudo":
                if (escudoAgain == false)
                {
                    Escudo();
                }
                else if(escudoAgain == true)
                {
                    RegenerarEscudo();
                }
                Destroy(collision.gameObject);
                break;
        }
    }

    public void Escudo()
    {
        if (invencible == false)
        {
            invencible = true;
            InstanciarEscudo();
            escudoAgain = true;
        }
        else
        {
            return;
        }
    }

    public void InstanciarEscudo()
    {
        for(int i = 0; i < numGolpesEscudo; i++)
        {
            Escudos[i] = Instantiate(escudoImage, escudoInventory, false);
        }
    }

    public void RegenerarEscudo()
    {
        if (invencible == false)
        {
            invencible = true;
            for (int i = 0; i < numGolpesEscudo; i++)
            {
                Escudos[i].enabled = true;
            }
        }
        else
        {
            return;
        }
    }

    public void DeleteEscudo()
    {
        numGolpesEscudo--;
        for(int i = numGolpesEscudo; i >= numGolpesEscudo; i--)
        {
            Escudos[i].enabled = false;
        }
    }
}
