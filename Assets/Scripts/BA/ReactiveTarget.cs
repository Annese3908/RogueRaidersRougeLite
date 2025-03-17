using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particles;
    public Coroutine deathAnim {private set; get;}
    // Start is called before the first frame update
    void Start()
    {
        _particles.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Death animation coroutine
    public IEnumerator Die()
    {
        // Rotate the game object as if it fell over
        this.transform.Rotate(-75, 0, 0);

        //turn on p[articles
        _particles.enableEmission = true;

        // Wait for a few seconds
        yield return new WaitForSeconds(1.5f);

        // Destroy the game object
        Destroy(gameObject);
    }

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null){
            behavior.SetAlive(false);
        }


        if(deathAnim == null) deathAnim = StartCoroutine(Die());
    }
}
