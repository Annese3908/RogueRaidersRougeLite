using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer promptSR, plantSR;
    private Sprite[] prompts, plants, seeds;

    public PlotState state;
    public SeedType seedType = SeedType.none;

    public bool interacted;

    public void PlantSeeds(SeedType seeds)
    {
        seedType = seeds;
        state = PlotState.Planted;

        //enable plant sprite and set it to proper plant type
        plantSR.enabled = true;
    }

    public void WaterPlants()
    {
        state = PlotState.Grown;

        //change plant sprite to proper fully grown sprite
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
        promptSR.enabled = isInteractable;

        //display the prompt sprite that is needed at the plot's state
        promptSR.sprite = prompts[(int)state];
    }

    public override void Interact()
    {
        interacted = true;
    }
    private void Awake()
    {
        promptSR.sprite = prompts[0];
    }
}
