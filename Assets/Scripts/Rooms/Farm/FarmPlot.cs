using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer plotPromptSprite, plantSprite;
    [SerializeField]
    private Sprite[] prompts, plants, seeds;

    public PlotState state;
    public SeedType seedType = SeedType.none;

    public bool interacted;

    public void PlantSeeds(SeedType seedsToPlant)
    {
        seedType = seedsToPlant;
        state = PlotState.Planted;

        //enable plant sprite and set it to correct seed type
        plantSprite.enabled = true;
        plantSprite.sprite = seeds[(int)seedType - 1];
    }

    public void WaterPlants()
    {
        state = PlotState.Grown;

        //change seed sprite to plant sprite of the same type
        plantSprite.sprite = plants[(int)seedType - 1];
    }

    public SeedType HarvestCrop()
    {
        //plost cannot be interacted with after harvest
        SetReadiness(false);

        return seedType;
    }

    public void SetReadiness(bool ready)
    {
        //exit function if unchanged
        if (ready == isInteractable)
            return;

        isInteractable = ready;
        updatePromptSprite();
    }

    public void updatePromptSprite()
    {
        //show prompt if plot is interactable
        plotPromptSprite.enabled = isInteractable;

        //display the prompt sprite that is needed at the plot's state
        plotPromptSprite.sprite = prompts[(int)state];
    }

    public override void Interact()
    {
        interacted = true;
    }

    private void Awake()
    {
        plotPromptSprite.sprite = prompts[0];
    }
}
