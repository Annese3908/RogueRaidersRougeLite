using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmEntrance : MonoBehaviour
{
    [SerializeField]
    private FarmPlot[] plots;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            for (int i = 0; i < plots.Length; i++)
            {
                plots[i].CheckForSeedUpdate();
            }
        }
    }
}
