using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;

public class SeedInventory : MonoBehaviour
{
    private SeedPacket[] packets = new SeedPacket[3];

    public void DebugGivePackets()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CollectSeeds(SeedType.GoldenApple);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CollectSeeds(SeedType.SplitPea);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CollectSeeds(SeedType.SugarCane);
        }
    }

    public void AdvancePacket(int packet)
    {
        packets[packet].state++;

        Debug.Log("Packet " + packet + ": is " + packets[packet].state);
    }

    public void CollectSeeds(SeedType type)
    {
        bool hasSeeds = FindPacket(type) > -1;
        int packet = FindPacket(PacketState.Empty);

        if (packet > -1 & !hasSeeds)
        {
            packets[packet].type = type;
            AdvancePacket(packet);
        }
    }

    public int FindPacket(SeedType seedType)
    {
        for (int i = 0; i < packets.Length; i++)
        {
            if (packets[i].type == seedType)
                return i;
        }

        //if packet cant be found
        return -1;
    }

    public int FindPacket(PacketState packetState)
    {
        for (int i = 0; i < packets.Length; i++)
        {
            if (packets[i].state == packetState)
                return i;
        }

        //if packet cant be found
        return -1;
    }

    public PacketState GetSeedState(int packet)
    {
        return packets[packet].state;
    }

    public SeedType GetSeeds(int packet)
    {
        return packets[packet].type;
    }

    public void Start()
    {
        for (int i = 0; i < packets.Length; i++)
        {
            packets[i] = new SeedPacket(SeedType.none, PacketState.Empty);
        }
    }

    public void Update()
    {
        DebugGivePackets();
    }
}
