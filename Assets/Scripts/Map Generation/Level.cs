using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level
{
   public static float Height = 500;
   public static float Width = 500;
   public static float Padding = .01f;
   public static float Scale = 1.0f;
   public static float IconScale = 0.1f;
   public static float RoomGenerationChance = 0.5f;
   public static Sprite BossRoomIcon;
   public static Sprite SpawnRoomIcon;
   public static Sprite UnexploredRoomIcon;
   public static Sprite CurrentRoomIcon;
   public static Sprite PlantRoomIcon;
   public static Sprite DefaultRoomIcon;
   public static List<Room> Rooms = new List<Room>();
   public static Room CurrentRoom;

}

public class Room
{
public int RoomNumber = 0;
public vector2 Location;
public Sprite RoomImage;
}