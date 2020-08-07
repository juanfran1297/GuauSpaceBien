using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveStats : MonoBehaviour
{
    public float maxEnergy = 5;
    public float currentEnergy;

    public HealthBar healthBar;

    public GameObject canvasJuego;
    public GameObject canvasFinal;

    Animator thisAnim;

    PowerUpsController powerUpsController;

    // Start is called before the first frame update
    void Start()
    {
        canvasJuego.SetActive(true);
        canvasFinal.SetActive(false);
        currentEnergy = maxEnergy;
        healthBar.SetMaxHealth(maxEnergy);
        thisAnim = GetComponent<Animator>();
        powerUpsController = GetComponent<PowerUpsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergy <= 0)
        {
            FindObjectOfType<NaveMovement>().enabled = false;
            //SceneManager.LoadScene("Final");
            canvasJuego.SetActive(false);
            canvasFinal.SetActive(true);
        }
        if (powerUpsController.numGolpesEscudo <= 0)
        {
            powerUpsController.invencible = false;
            powerUpsController.numGolpesEscudo = powerUpsController.golpesEscudo;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Damage")
        {
            if(powerUpsController.invencible == true)
            {
                powerUpsController.DeleteEscudo();
                Destroy(collision.gameObject);
            }
            else
            {
                currentEnergy--;
                healthBar.SetHealth(currentEnergy);
                Destroy(collision.gameObject);
                StartCoroutine(Invulnerable());
            }
            FindObjectOfType<AudioManager>().Play("Fallo");
        }
    }

    IEnumerator Invulnerable()
    {
        thisAnim.SetTrigger("Invulnerable");
        this.gameObject.layer = 0;

        yield return new WaitForSeconds(3f);
        this.gameObject.layer = 8;
    }
}
