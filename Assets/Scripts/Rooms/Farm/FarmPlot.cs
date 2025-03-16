using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plants;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer plotPromptSprite, plantSprite;
    [SerializeField]
    private Sprite[] prompts;

    [HideInInspector]
    public PlotState state;
    [HideInInspector]
    public PlantData plantData;

    public void AdvancePlot()
    {
        state++;
        isInteractable = false;

    }

    public void PlantSeeds(PlantData plant)
    {
        //plant seed if plot is empty
        if (state != PlotState.Empty)
            return;

        plantData = plant;
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
            case PlotState.Empty:
                //disable plant sprite
                plantSprite.enabled = false;
                break;

            case PlotState.Planted:
                //set plant sprite to planted seeds sprite
                plantSprite.enabled = true;
                plantSprite.sprite = plantData.PlantedSeedSprite;
                break;

            case PlotState.Grown:
                //set plant sprite to tree sprite
                plantSprite.enabled = true;
                plantSprite.sprite = plantData.TreeSprite;
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
