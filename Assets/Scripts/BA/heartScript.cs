using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI library for handling heart images

public class HeartScript : MonoBehaviour
{
    // UI panel where the hearts will be displayed
    public GameObject Panel;

    // Sprites representing different heart states (Full, Half, Empty)
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    // Reference to PlayerStats, which stores the player's current health
    public PlayerStats playerStats;

    /// <summary>
    /// Unity Start() function - Initializes health display and ensures PlayerStats is assigned.
    /// </summary>
    void Start()
    {
        // If playerStats is not assigned in the Inspector, try to find it dynamically
        if (playerStats == null) 
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        // Check if playerStats was successfully found or assigned
        if (playerStats == null) 
        {
            Debug.LogError("HeartScript: PlayerStats reference is NULL! Make sure it is assigned in the Inspector.");
            return; // Stop execution to prevent errors
        }

        // Initialize heart display
        DrawHeart();
    }

    /// <summary>
    /// Creates and positions a heart UI element in the panel.
    /// </summary>
    /// <param name="Type">The sprite (Full, Half, Empty) to display</param>
    /// <param name="num">Position index of the heart</param>
    public void DrawHeart(Sprite Type, int num)
    {
        // Create a new UI GameObject for the heart
        GameObject Heart = new GameObject("Heart");

        // Add an Image component to display the heart sprite
        Image HeartImage = Heart.AddComponent<Image>();
        HeartImage.sprite = Type; // Set the sprite to the provided heart type

        // Get RectTransform for positioning and sizing in UI
        RectTransform rectTransform = Heart.GetComponent<RectTransform>();

        // Scale the heart size based on the panel dimensions (divide by 4 to keep within one row)
        rectTransform.sizeDelta = new Vector2(Panel.GetComponent<RectTransform>().sizeDelta.x / 4, 
                                              Panel.GetComponent<RectTransform>().sizeDelta.y / 10);

        // Ensure all hearts are placed in a single row
        float XPos = num * (Panel.GetComponent<RectTransform>().sizeDelta.x / 4); // Space them evenly
        float YPos = 0; // Keep Y-position constant to prevent multiple rows

        // Set the position and anchoring for the heart image
        rectTransform.position = new Vector2(XPos, YPos);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);

        // Attach the heart object to the UI Panel
        HeartImage.transform.SetParent(Panel.transform, false);
    }

    /// <summary>
    /// Draws the hearts UI according to the player's current health.
    /// </summary>
    public void DrawHeart()
    {
        // Ensure playerStats is assigned before updating UI
        if (playerStats == null) 
        {
            Debug.LogError("HeartScript: Cannot update hearts because PlayerStats is NULL!");
            return;
        }

        // Clear previous hearts from the panel before redrawing
        foreach (Transform child in Panel.transform)
        {
            Destroy(child.gameObject);
        }

        // Get the current health of the player
        int currentHealth = playerStats.Health();
        int maxHearts = 4; // Restrict max hearts to 4

        // Draw full hearts for the current health (limit to 4 max)
        for (int i = 0; i < Mathf.Min(currentHealth, maxHearts); i++)
        {
            DrawHeart(FullHeart, i);
        }

        // If health is not a whole number (e.g., 2.5), draw a half heart (within limit)
        if (currentHealth % 1 != 0 && currentHealth < maxHearts)
        {
            DrawHeart(HalfHeart, (int)currentHealth);
        }

        // Fill remaining slots with empty hearts (up to 4 hearts total)
        for (int i = currentHealth; i < maxHearts; i++)
        {
            DrawHeart(EmptyHeart, i);
        }
    }
}
