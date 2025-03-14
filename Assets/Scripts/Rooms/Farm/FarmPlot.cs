using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer plotPromptSprite, plantSprite;
    [SerializeField]
    private Sprite[] prompts, plants, seeds;

    public PlotState state;
    public SeedType seedType = SeedType.none;

    public bool interacted;

    public void AdvancePlot()
    {
        state++;
        isInteractable = false;
    }

    public void PlantSeeds(SeedType seedsToPlant)
    {
        //plant seed if plot is empty
        if (state != PlotState.Empty)
            return;

        seedType = seedsToPlant;
        AdvancePlot();
    }

    public void SetReadiness(bool ready)
    {
        //update prompt is readiness has changed
        if (ready == isInteractable)
            return;

        isInteractable = ready;
        updatePromptSprite();
    }

    public void UpdateCropSprite()
    {
        switch (state)
        {
            //plant sprite should not show is plot is empty
            case PlotState.Empty:
                plantSprite.enabled = false;
                break;

            //plant sprite should be the seed of the correct type
            case PlotState.Planted:
                plantSprite.enabled = true;
                plantSprite.sprite = seeds[(int)seedType - 1];
                break;

            //plant sprite should be the plant of the correct type
            case PlotState.Grown:
                plantSprite.enabled = true;
                plantSprite.sprite = plants[(int)seedType - 1];
                break;
        }
    }

    public void updatePromptSprite()
    {
        plotPromptSprite.enabled = isInteractable;

        plotPromptSprite.sprite = prompts[(int)state];
    }

    public override void Interact()
    {
        interacted = true;
    }

    private void Awake()
    {
        updatePromptSprite();
    }
}
