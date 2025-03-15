using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;

[CreateAssetMenu(fileName = "FruitTree", menuName = "ScriptableObject/FruitTree")]
public class FruitTreeData : ScriptableObject
{
    [SerializeField]
    private SeedType fruit;
    public SeedType Fruit{ get => fruit; private set => fruit = value; }
    [SerializeField]
    private Sprite plantSprite;
    public Sprite PlantSprite { get => plantSprite; private set => plantSprite = value; }
    [SerializeField]
    private Sprite seedSprite;
    public Sprite SeedSprite { get => seedSprite; private set => seedSprite = value; }
    [SerializeField]
    private Sprite cropSprite;
    public Sprite CropSprite { get => cropSprite; private set => cropSprite = value; }
}
