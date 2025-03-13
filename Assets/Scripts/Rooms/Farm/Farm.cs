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
        //bool hasWaterToUse = player.FullBucketCount() > 0;

        for (int i = 0; i < plots.Length; i++)
        {
            switch (plots[i].state)
            {
                case PlotState.Empty:
                    plots[i].SetPlotReadiness(hasSeedsToPlant);
                    break;
                case PlotState.Planted:
                    //plots[i].SetPlotReadiness(hasWaterToUse);
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
                plots[i].interacted = false;

                switch(plots[i].state)
                {
                    case PlotState.Empty:
                        //find first availible seeds and plant them 
                        int packet = seedPackets.FindPacket(PacketState.Full);
                        seedPackets.AdvancePacket(packet);

                        plots[i].PlantSeeds(seedPackets.GetSeeds(packet));
                        break;

                    case PlotState.Planted:
                        //use water to grow plant
                        //player.SpendBucket();
                        plots[i].WaterPlants();
                        break;

                    case PlotState.Grown:
                        //give upgrade
                        break;
                }

                plots[i].interacted = false;
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
