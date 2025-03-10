using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMap : MonoBehaviour
{
    public Sprite Default;
    public Sprite SpawnRoom;
    public Sprite BossRoom;
    public Sprite PlantRoom;
    public Sprite UnexploredRoom;
    public Sprite CurrRoom;

    void DrawRoomOnMap(Room r){
        GameObject MapTile = new GameObject("MapTile");
        Image RoomImage = MapTile.AddComponent<Image>();
        RoomImage.sprite = s;
        RectTransform rT = RoomImage.GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(Level.Height, Level.Width) * Level.IconScale;
        rT.position = Location * (Level.IconScale * Level.Height * Level.Scale + (Level.Padding * Level.Height * Level.Scale));
        RoomImage.transform.SetParent(transform, false);
    }
    // Start is called before the first frame update
    void Generate(Room room){
        if(Random.value > Level.RoomGenerationChance){
         DrawRoomOnMap(Level.DefaultRoomIcon, Location + new Vector2(-1,0));
         Generate(Location + new Vector2(-1,0));
       }
       //Right
       if(Random.value > Level.RoomGenerationChance){
         DrawRoomOnMap(Level.DefaultRoomIcon, Location + new Vector2(1,0));
         Generate(Location + new Vector2(1,0));
       }
       //Up
       if(Random.value > Level.RoomGenerationChance){
         DrawRoomOnMap(Level.DefaultRoomIcon, Location + new Vector2(0,1));
         Generate(Location + new Vector2(0,1));
       }
       //Down
       if(Random.value > Level.RoomGenerationChance){
         DrawRoomOnMap(Level.UnexploredRoomIcon, new Vector2(0,-1));
         Generate(Location + new Vector2(0,-1));
       }
    }
    void Start()
    {
        Level.DefaultRoomIcon= Default;
        Level.BossRoomIcon = BossRoom;
        Level.SpawnRoomIcon = SpawnRoom;
        Level.PlantRoomIcon = PlantRoom;
        Level.UnexploredRoomIcon = UnexploredRoom;
        Level.CurrentRoomIcon = CurrRoom;
        
        DrawRoomOnMap(Level.CurrentRoomIcon, new Vector2(0,0));

        Room StartRoom = new Room();
        StartRoom.Location = new vector2(0,0);
        StartRoom.RoomImage = Level.CurrentRoom;

        DrawRoomOnMap(StartRoom);
        //Left

        //right

        //up
        
        //down
    }

  
}
