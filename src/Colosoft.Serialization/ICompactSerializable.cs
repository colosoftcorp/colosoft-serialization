namespace Colosoft.Serialization
{
    public interface ICompactSerializable
    {
        void Deserialize(IO.CompactReader reader);

        void Serialize(IO.CompactWriter writer);
    }
}
