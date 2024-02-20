namespace Colosoft.Serialization
{
    public interface ICustomSerializable
    {
        void DeserializeLocal(System.IO.BinaryReader reader);

        void SerializeLocal(System.IO.BinaryWriter writer);
    }
}
