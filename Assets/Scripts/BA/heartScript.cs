using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI library for handling heart images

public class HeartScript : MonoBehaviour
{
    public GameObject Panel; // UI Panel where hearts are displayed
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    public PlayerStats playerStats; // Reference to PlayerStats

    void Start()
    {
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        if (playerStats == null)
        {
            Debug.LogError("HeartScript: PlayerStats reference is NULL! Make sure it is assigned.");
            return;
        }

        DrawHeart(); // Initialize UI
    }

    public void DrawHeart()
    {
        if (playerStats == null)
        {
            Debug.LogError("HeartScript: Cannot update hearts because PlayerStats is NULL!");
            return;
        }

        // Clear previous hearts from the UI before redrawing
        foreach (Transform child in Panel.transform)
        {
            Destroy(child.gameObject);
        }

        float currentHealth = playerStats.GetHealth(); // Get float health value
        int maxHearts = 4; // Adjust based on UI design

        int fullHearts = Mathf.FloorToInt(currentHealth); // Count full hearts
        bool hasHalfHeart = (currentHealth % 1 != 0); // Check for half heart

        // Draw full hearts
        for (int i = 0; i < fullHearts; i++)
        {
            CreateHeart(FullHeart, i);
        }

        // Draw a half heart if needed
        if (hasHalfHeart && fullHearts < maxHearts)
        {
            CreateHeart(HalfHeart, fullHearts);
            fullHearts++; // Increment index to prevent overlap with empty hearts
        }

        // Draw empty hearts for remaining slots
        for (int i = fullHearts; i < maxHearts; i++)
        {
            CreateHeart(EmptyHeart, i);
        }
    }

    private void CreateHeart(Sprite heartType, int index)
    {
        GameObject Heart = new GameObject("Heart");

        Image HeartImage = Heart.AddComponent<Image>();
        HeartImage.sprite = heartType; // Assign sprite

        RectTransform rectTransform = Heart.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Panel.GetComponent<RectTransform>().sizeDelta.x / 4,
                                              Panel.GetComponent<RectTransform>().sizeDelta.y / 10);

        // Positioning
        float XPos = index * (Panel.GetComponent<RectTransform>().sizeDelta.x / 4);
        float YPos = 0;

        rectTransform.position = new Vector2(XPos, YPos);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);

        HeartImage.transform.SetParent(Panel.transform, false);
    }
}
