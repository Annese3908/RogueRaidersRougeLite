namespace Seeds
{
    public enum SeedType
    {
        none,
        GoldenApple,
        SplitPea,
        SugarCane
    }

    public enum PacketState
    {
        Empty,
        Full,
        Planted,
        Grown,
        Harvested
    }

    public class SeedPacket
    {
        public SeedType type;
        public PacketState state;

        public SeedPacket(SeedType seedType, PacketState packetState)
        {
            type = seedType;
            state = packetState;
        }
    }
}
