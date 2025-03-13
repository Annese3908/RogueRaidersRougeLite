using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmEntrance : MonoBehaviour
{
    [SerializeField]
    private Farm farm;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            farm.ReadyPlots();
        }
    }
}
