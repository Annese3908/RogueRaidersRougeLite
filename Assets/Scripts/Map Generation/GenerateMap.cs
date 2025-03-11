// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GenerateMap : MonoBehaviour
// {
//     public Sprite Default;
//     public Sprite SpawnRoom;
//     public Sprite BossRoom;
//     public Sprite PlantRoom;
//     public Sprite UnexploredRoom;
//     public Sprite CurrRoom;

//     int failsafe = 0;

//     public void DrawRoomOnMap(Room r){
//         GameObject MapTile = new GameObject("MapTile");
//         Image RoomImage = MapTile.AddComponent<Image>();
//         RoomImage.sprite = r.RoomImage;
//         RectTransform rT = RoomImage.GetComponent<RectTransform>();
//         rT.sizeDelta = new Vector2(Level.Height, Level.Width) * Level.IconScale;
//         rT.position = r.Location * (Level.IconScale * Level.Height * Level.Scale + (Level.Padding * Level.Height * Level.Scale));
//         RoomImage.transform.SetParent(transform, false);
//         Level.Rooms.Add(r);
//     }
//     // Start is called before the first frame update
//    public void Generate(Room room)
//    {
//       failsafe++;
//       if(failsafe > 50){
//         return;
//       }
//       DrawRoomOnMap(room);
//       //If statements to generate a room
//       if(Random.value > .5f){
//         Room newRoom = new Room();
//         newRoom.Location = new Vector2(-1,0) + room.Location;
//         newRoom.RoomImage = Level.DefaultRoomIcon;
//         if(!CheckIfRoomExists(newRoom.Location)){
//           if(CheckRoomsAround(newRoom.Location, "LEFT"))
//           Generate(newRoom);
//         }
//       }
//       //right
//       if(Random.value > .5f){
//         Room newRoom = new Room();
//         newRoom.Location = new Vector2(1,0) + room.Location;
//         newRoom.RoomImage = Level.DefaultRoomIcon;
//         if(!CheckIfRoomExists(newRoom.Location)){
//           Generate(newRoom);
//         };
//       }
//       //up
//       if(Random.value > .5f){
//         Room newRoom = new Room();
//         newRoom.Location = new Vector2(0,1) + room.Location;
//         newRoom.RoomImage = Level.DefaultRoomIcon;
//         if(!CheckIfRoomExists(newRoom.Location)){
//           Generate(newRoom);
//         }
//       }
//       //down
//       if(Random.value > .5f){
//         Room newRoom = new Room();
//         newRoom.Location = new Vector2(0,-1) + room.Location;
//         newRoom.RoomImage = Level.DefaultRoomIcon;
//         if(!CheckIfRoomExists(newRoom.Location)){
//           Generate(newRoom);
//         }
//       }
//     }

//     bool CheckIfRoomExists(Vector2 v)
//     {
//       return(Level.Rooms.Exists(x => x.Location == v));
//     }

//     bool CheckRoomsAround(Vector2 v, string direction){
//       switch(direction){
//         case "RIGHT":{

//         }
//       }
//     }
//     public void Start()
//     {
//         Level.DefaultRoomIcon= Default;
//         Level.BossRoomIcon = BossRoom;
//         Level.SpawnRoomIcon = SpawnRoom;
//         Level.PlantRoomIcon = PlantRoom;
//         Level.UnexploredRoomIcon = UnexploredRoom;
//         Level.CurrentRoomIcon = CurrRoom;
        

//         Room StartRoom = new Room();
//         StartRoom.Location = new Vector2(0,0);
//         StartRoom.RoomImage = Level.CurrentRoomIcon;

//         DrawRoomOnMap(StartRoom);
//     }

  
// }
