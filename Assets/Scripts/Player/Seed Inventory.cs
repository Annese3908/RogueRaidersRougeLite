using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seeds;

public class SeedInventory : MonoBehaviour
{
    private SeedPacket[] packets = new SeedPacket[3];

    public void DebugLogPackets()
    {
        for (int i = 0; i < packets.Length; i++)
        {
            Debug.Log("Packet " + i + ": Seeds - " + packets[i].type + ", State - " + packets[i].state);
        }
    }

    public void DebugGivePackets()
    {

    }

    public void AdvancePacket(int packet)
    {
        packets[packet].state++;

        DebugLogPackets();
    }

    public void CollectSeeds(SeedType type)
    {
        int packet = FindPacket(PacketState.Empty);

        if (packet > -1)
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

    public int FindPacket(PacketState seedState)
    {
        for (int i = 0; i < packets.Length; i++)
        {
            if (packets[i].state == seedState)
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
}
