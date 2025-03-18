using Plants;
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
    [SerializeField]
    private DaggerController shot;

    private bool playerInFarm = true;

    public void ReadyPlots()
    {
        bool hasSeedsToPlant = playersSeeds.FindPacket(PacketState.Full) >= 0;
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

                //grown plots are always ready for harvest
                case PlotState.Grown:
                    plots[i].SetReadiness(true);
                    break;
                case PlotState.Harvested:
                    plots[i].SetReadiness(false);
                    break;
            }
        }
    }

    public void checkForPlotInteractions()
    {
        for (int i = 0;i < plots.Length;i++)
        {
            //skip plot if it hasnt interacted
            if (!plots[i].interacted)
                continue;

            switch(plots[i].state)
            {
                case PlotState.Empty:
                    //find first packet of unplanted seeds
                    int packetToPlant = playersSeeds.FindPacket(PacketState.Full);

                    //exit function if packet cant be found
                    if (packetToPlant < 0)
                        return;

                    //plant seeds in plot and update packet to planted
                    playersSeeds.AdvancePacket(packetToPlant);
                    plots[i].PlantSeeds(playersSeeds.GetSeeds(packetToPlant));
                    break;

                case PlotState.Planted:
                    //use water to grow plant
                    player.SpendBucket();
                    plots[i].AdvancePlot();
                    break;

                case PlotState.Grown:
                    //find the packet with the same seed type as plot
                    int packetToHarvest = playersSeeds.FindPacket(plots[i].plantData.Type);

                    //exit function if packet cant be found
                    if (packetToHarvest < 0)
                        return;

                    //give player upgrade
                    GiveUpgrade(playersSeeds.GetSeeds(packetToHarvest).Type);

                    //advanced plot and seed packet to harvested
                    playersSeeds.AdvancePacket(packetToHarvest);
                    plots[i].AdvancePlot();
                    break;
            }
            ReadyPlots();
        }
    }

    private void GiveUpgrade(PlantType type)
    {
        switch(type)
        {
            case PlantType.GoldenApple:
                player.IncreaseMaxHP();
                break;
            case PlantType.SplitPea:
                shot.IncreaseAmount();
                break;
            case PlantType.SugarCane:
                player.ChangeSpeed(1.5f);
                break;
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
            //Debug.Log("Player has entered farm");
            playerInFarm = true;
            ReadyPlots();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!playerInFarm)
            return;

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player has exited farm");
            playerInFarm = false;
        }
    }
}
