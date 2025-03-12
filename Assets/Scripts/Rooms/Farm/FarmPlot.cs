using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;
using System.Runtime.InteropServices;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SeedInventory seeds;
    [SerializeField]
    private Player player;

    [SerializeField]
    private SpriteRenderer waterSprite, packetSprite, plantSprite, sickleSprite;

    private enum PlotState
    {
        Empty,
        ReadyToPlant,
        Planted,
        ReadyToWater,
        ReadyToHarvest,
        Harvested
    }
    private PlotState plotState;

    private int packet = -1;

    public void CheckForPlotUpdates()
    {
        switch (plotState)
        {
            case PlotState.Empty:
            case PlotState.ReadyToPlant:
                packet = seeds.FindPacket(PacketState.Full);

                if (packet > 0)
                    SetPlotState(PlotState.ReadyToPlant);
                else
                    SetPlotState(PlotState.Empty);
                break;

            case PlotState.Planted:
            case PlotState.ReadyToWater:
                if (player.FullBucketCount() > 0)
                    SetPlotState(PlotState.ReadyToWater);
                else
                    SetPlotState(PlotState.Planted);
                break;
        }
    }

    private void SetPlotState(PlotState state)
    {
        plotState = state;

        waterSprite.enabled = false;
        packetSprite.enabled = false;
        sickleSprite.enabled = false;

        switch (plotState)
        {
            case PlotState.ReadyToPlant:
                packetSprite.enabled = true;
                break;
            case PlotState.ReadyToWater:
                waterSprite.enabled = true;
                break;

            case PlotState.Planted:
                plantSprite.enabled = true;

                //set plant sprite to seeds of proper type
                break;

            case PlotState.ReadyToHarvest:
                sickleSprite.enabled= true;

                //set plant sprite to plant of proper type
                break;
        }
    }

    public override void Interact()
    {
        switch (plotState)
        {
            case PlotState.ReadyToPlant:
                //advance seed packet to planted
                seeds.AdvancePacket(packet);
                SetPlotState(PlotState.Planted);
                break;

            case PlotState.ReadyToWater:
                //remove 1 bucket of water from player
                player.SpendBucket();
                SetPlotState(PlotState.ReadyToHarvest);
                break;

            case PlotState.ReadyToHarvest:
                //give player proper upgrade
                SetPlotState(PlotState.Harvested);
                break;
        }

    }
}
