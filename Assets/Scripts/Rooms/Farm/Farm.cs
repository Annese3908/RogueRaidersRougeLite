using Seeds;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private FarmPlot[] plots;
    [SerializeField]
    private SeedInventory seedPackets;

    private bool playerInFarm = true;

    public void ReadyPlots()
    {
        bool hasSeedsToPlant = seedPackets.FindPacket(PacketState.Full) > 0;
        bool hasWaterToUse = player.FullBucketCount() > 0;

        for (int i = 0; i < plots.Length; i++)
        {
            switch (plots[i].state)
            {
                case PlotState.Empty:
                    plots[i].SetPlotReadiness(hasSeedsToPlant);
                    break;
                case PlotState.Planted:
                    plots[i].SetPlotReadiness(hasWaterToUse);
                    break;
            }
        }
    }

    public void checkForPlotInteractions()
    {
        for (int i = 0;i < plots.Length;i++)
        {
            if (plots[i].interacted == true)
            {
                switch(plots[i].state)
                {
                    case PlotState.Empty:
                        break;
                    case PlotState.Planted:
                        break;
                    case PlotState.Grown:
                        break;
                }

                plots[i].interacted = false;
            }
        }
    }

    public void Update()
    {
        if (playerInFarm)
        {
            checkForPlotInteractions();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (playerInFarm)
            return;

        if (other.gameObject.GetComponent<Player>() != null)
        {
            playerInFarm = true;
            ReadyPlots();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!playerInFarm)
            return;

        if (other.gameObject.GetComponent<Player>() != null)
            playerInFarm = false;
    }
}
