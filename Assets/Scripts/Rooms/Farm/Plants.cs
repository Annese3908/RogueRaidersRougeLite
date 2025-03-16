namespace Plants
{
    public enum PlantType
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
        Harvested
    }
    public enum PlotState
    {
        Empty,
        Planted,
        Grown,
        Harvested
    }

    public class SeedPacket
    {
        public PlantType type;
        public PacketState state;

        public SeedPacket(PlantType seedType, PacketState packetState)
        {
            type = seedType;
            state = packetState;
        }
    }
}
