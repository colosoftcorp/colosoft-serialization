using System;

namespace Colosoft.Serialization.IO
{
    public abstract class CompactReader
    {
        protected CompactReader()
        {
        }

        public abstract int Read(byte[] buffer, int index, int count);

        public abstract int Read(char[] buffer, int index, int count);

        public abstract bool ReadBoolean();

        public abstract byte ReadByte();

        public abstract byte[] ReadBytes(int count);

        public abstract char ReadChar();

        public abstract char[] ReadChars(int count);

        public abstract DateTime ReadDateTime();

        public abstract DateTimeOffset ReadDateTimeOffset();

        public abstract TimeSpan ReadTimeSpan();

        public abstract decimal ReadDecimal();

        public abstract double ReadDouble();

        public abstract Guid ReadGuid();

        public abstract short ReadInt16();

        public abstract int ReadInt32();

        public abstract long ReadInt64();

        public abstract object ReadObject();

        public abstract T ReadObjectAs<T>();

        public abstract object ReadObjectAs(Type type);

        public virtual sbyte ReadSByte()
        {
            return 0;
        }

        public abstract float ReadSingle();

        public abstract string ReadString();

        public virtual ushort ReadUInt16()
        {
            return 0;
        }

        public virtual uint ReadUInt32()
        {
            return 0;
        }

        public virtual ulong ReadUInt64()
        {
            return 0;
        }

        public virtual object Read(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsGenericType)
            {
                var genericDefinition = type.GetGenericTypeDefinition();

                if (genericDefinition == typeof(Nullable<>))
                {
                    type = type.GetGenericArguments()[0];

                    // Verifica se o valor é nulo
                    if (this.ReadByte() == 1)
                    {
                        return null;
                    }
                }
            }

            switch (type.FullName)
            {
                case "System.String":
                    return this.ReadString();
                case "System.Int16":
                    return this.ReadInt16();
                case "System.UInt16":
                    return this.ReadUInt16();
                case "System.Int32":
                    return this.ReadInt32();
                case "System.UInt32":
                    return this.ReadUInt32();
                case "System.Int64":
                    return this.ReadInt64();
                case "System.UInt64":
                    return this.ReadUInt64();
                case "System.Single":
                    return this.ReadSingle();
                case "System.Double":
                    return this.ReadDouble();
                case "System.Boolean":
                    return this.ReadBoolean();
                case "System.Char":
                    return this.ReadChar();
                case "System.Byte":
                    return this.ReadByte();
                case "System.DateTime":
                    return this.ReadDateTime();
                case "System.DateTimeOffset":
                    return this.ReadDateTimeOffset();
                case "System.Decimal":
                    return this.ReadDecimal();

                case "System.Byte[]":
                    var bytesCount = this.ReadInt32();
                    return this.ReadBytes(bytesCount);

                default:
                    throw new NotSupportedException($"Not support type '{type.FullName}'");
            }
        }

        public virtual void Skip(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsGenericType)
            {
                var genericDefinition = type.GetGenericTypeDefinition();

                if (genericDefinition == typeof(Nullable<>))
                {
                    type = type.GetGenericArguments()[0];

                    if (this.ReadByte() == 1)
                    {
                        return;
                    }
                }
            }

            switch (type.FullName)
            {
                case "System.String":
                    this.SkipString();
                    break;
                case "System.Int16":
                    this.SkipInt16();
                    break;
                case "System.UInt16":
                    this.SkipUInt16();
                    break;
                case "System.Int32":
                    this.SkipInt32();
                    break;
                case "System.UInt32":
                    this.SkipUInt32();
                    break;
                case "System.Int64":
                    this.SkipInt64();
                    break;
                case "System.UInt64":
                    this.SkipUInt64();
                    break;
                case "System.Single":
                    this.SkipSingle();
                    break;
                case "System.Double":
                    this.SkipDouble();
                    break;
                case "System.Boolean":
                    this.SkipBoolean();
                    break;
                case "System.Char":
                    this.SkipChar();
                    break;
                case "System.Byte":
                    this.SkipByte();
                    break;
                case "System.DateTime":
                    this.SkipDateTime();
                    break;
                case "System.DateTimeOffset":
                    this.SkipDateTimeOffset();
                    break;
                case "System.Decimal":
                    this.SkipDecimal();
                    break;

                case "System.Byte[]":
                    var bytesCount = this.ReadInt32();
                    this.SkipBytes(bytesCount);
                    break;

                default:
                    throw new NotSupportedException($"Not support type '{type.FullName}'");
            }
        }

        public abstract void SkipBoolean();

        public abstract void SkipByte();

        public abstract void SkipBytes(int count);

        public abstract void SkipChar();

        public abstract void SkipChars(int count);

        public abstract void SkipDateTime();

        public abstract void SkipDateTimeOffset();

        public abstract void SkipTimeSpan();

        public abstract void SkipDecimal();

        public abstract void SkipDouble();

        public abstract void SkipGuid();

        public abstract void SkipInt16();

        public abstract void SkipInt32();

        public abstract void SkipInt64();

        public abstract void SkipObject();

        public abstract void SkipObjectAs<T>();

        public abstract void SkipObjectAs(Type type);

        public virtual void SkipSByte()
        {
        }

        public abstract void SkipSingle();

        public abstract void SkipString();

        public virtual void SkipUInt16()
        {
        }

        public virtual void SkipUInt32()
        {
        }

        public virtual void SkipUInt64()
        {
        }
    }
}
