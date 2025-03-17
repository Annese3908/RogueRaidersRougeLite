using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plants;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine.UIElements;

public class FarmPlot : InteractableObject
{
    [SerializeField]
    private SpriteRenderer plotPromptSprite, plantSprite;
    [SerializeField]
    private Sprite[] prompts;
    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private AudioClip grow, harvest;

    public PlotState state;
    public PlantData plantData;

    public void AdvancePlot()
    {
        state++;
        interacted = false;

        UpdatePromptSprite();
        UpdateCropSprite();
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
        UpdatePromptSprite();
        UpdateCropSprite();
    }

    public void playSound()
    {
        switch (state)
        {
            case PlotState.Grown:
                audioPlayer.clip = grow;
                audioPlayer.Play();
                break;
            case PlotState.Harvested:
                audioPlayer.clip = harvest;
                audioPlayer.Play();
                break;
        }
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

    public void UpdatePromptSprite()
    {
        if (state == PlotState.Harvested)
        {
            plotPromptSprite.enabled = false;
            return;
        }

        plotPromptSprite.enabled = isInteractable;

        if (state == PlotState.Grown)
        {
            plotPromptSprite.sprite = plantData.CropSprite;
            return;
        }

        plotPromptSprite.sprite = prompts[(int)state];
    }

    public override void Interact()
    {
        interacted = true;
    }

    private void Awake()
    {
        UpdatePromptSprite();
    }
}
