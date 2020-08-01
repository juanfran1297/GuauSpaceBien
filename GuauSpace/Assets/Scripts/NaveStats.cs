using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveStats : MonoBehaviour
{
    public float maxEnergy = 5;
    public float currentEnergy;

    public HealthBar healthBar;

    Collider2D thisCollider;
    Animator thisAnim;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        healthBar.SetMaxHealth(maxEnergy);
        thisCollider = GetComponent<Collider2D>();
        thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergy <= 0)
        {
            FindObjectOfType<NaveMovement>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Damage")
        {
            currentEnergy--;
            healthBar.SetHealth(currentEnergy);
            Destroy(collision.gameObject);
            StartCoroutine(Invulnerable());
        }
    }

    IEnumerator Invulnerable()
    {
        thisAnim.SetTrigger("Invulnerable");
        thisCollider.enabled = false;
        yield return new WaitForSeconds(3f);
        thisCollider.enabled = true;
    }
}
