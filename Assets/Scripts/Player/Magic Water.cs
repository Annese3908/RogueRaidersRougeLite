using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWater : MonoBehaviour
{
    private PlayerStats player = null;
    public float pickUpDistance = .1f;
    public float speed = .1f;

    public void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.transform.position) < pickUpDistance)
            {
                player.CollectWater(1);

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null & other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player == null & other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerStats>();
        }
    }
}
