using Seeds;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField]
    private PlayerStats player;
    [SerializeField]
    private FarmPlot[] plots;
    [SerializeField]
    private SeedInventory playersSeeds;

    private bool playerInFarm = true;

    public void ReadyPlots()
    {
        bool hasSeedsToPlant = playersSeeds.FindPacket(PacketState.Full) > 0;
        bool hasWaterToUse = player.FilledBuckets() > 0;

        for (int i = 0; i < plots.Length; i++)
        {
            switch (plots[i].state)
            {
                //empty plots are ready if player has unplanted seeds
                case PlotState.Empty:
                    plots[i].SetReadiness(hasSeedsToPlant);
                    break;

                //planted plots are ready if player has at least 1 bucket of water
                case PlotState.Planted:
                    plots[i].SetReadiness(hasWaterToUse);
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
                //reset interaction status
                plots[i].interacted = false;

                switch(plots[i].state)
                {
                    case PlotState.Empty:
                        //find first packet of unplanted seeds
                        int packet = playersSeeds.FindPacket(PacketState.Full);

                        //plant seeds in plot and update packet to planted
                        playersSeeds.AdvancePacket(packet);
                        plots[i].PlantSeeds(playersSeeds.GetSeeds(packet));
                        break;

                    case PlotState.Planted:
                        //use water to grow plant
                        player.SpendBucket();
                        plots[i].WaterPlants();
                        break;

                    case PlotState.Grown:
                        //give player upgrade
                        plots[i].HarvestCrop();
                        break;
                }

                ReadyPlots();
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

        if (other.CompareTag("Player"))
        {
            playerInFarm = true;
            ReadyPlots();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!playerInFarm)
            return;

        if (other.CompareTag("Player"))
            playerInFarm = false;
    }
}
