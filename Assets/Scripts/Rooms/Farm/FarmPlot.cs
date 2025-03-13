using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer waterSprite, packetSprite, plantSprite, sickleSprite;

    public PlotState state;

    private bool readyForNextStep;

    public bool interacted;

    public SeedType seedType = SeedType.none;

    public void PlantSeeds(SeedType seeds)
    {
        seedType = seeds;

        state = PlotState.Planted;

        plantSprite.enabled = true;
        //change sprite to correct seed sprite
    }

    public void WaterPlants()
    {
        state = PlotState.Grown;

        //change sprite to correct plant sprite
    }

    public void SetPlotReadiness(bool ready)
    {
        //exit function if readiness is unchanged
        if (ready == readyForNextStep)
            return;

        readyForNextStep = ready;
        UpdateInteractSprites();
    }

    public void UpdateInteractSprites()
    {
        if (!readyForNextStep)
        {
            waterSprite.enabled = false;
            packetSprite.enabled = false;
            sickleSprite.enabled = false;
            return;
        }

        switch (state)
        {
            case PlotState.Empty:
                packetSprite.enabled = true;
                break;

            case PlotState.Planted:
                packetSprite.enabled = false;
                waterSprite.enabled = true;
                break;

            case PlotState.Grown:
                waterSprite.enabled = false;
                sickleSprite.enabled= true;
                break;
        }
    }

    public override void Interact()
    {
        interacted = true;
    }
    public override void Update()
    {
        if (readyForNextStep)
            base.Update();
    }
}
