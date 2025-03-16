using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plants;

[CreateAssetMenu(fileName = "Plant", menuName = "ScriptableObject/Plant")]
public class PlantData : ScriptableObject
{
    [SerializeField]
    private PlantType type;
    public PlantType Type{ get => type; private set => type = value; }
    [SerializeField]
    private Sprite treeSprite;
    public Sprite TreeSprite { get => treeSprite; private set => treeSprite = value; }
    [SerializeField]
    private Sprite seedSprite;
    public Sprite SeedSprite { get => seedSprite; private set => seedSprite = value; }
    [SerializeField]
    private Sprite plantedSeedSprite;
    public Sprite PlantedSeedSprite { get => plantedSeedSprite; private set => plantedSeedSprite = value; }
    [SerializeField]
    private Sprite cropSprite;
    public Sprite CropSprite { get => cropSprite; private set => cropSprite = value; }
}
