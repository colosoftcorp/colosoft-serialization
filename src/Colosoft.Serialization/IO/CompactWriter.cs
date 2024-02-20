using System;

namespace Colosoft.Serialization.IO
{
    public abstract class CompactWriter
    {
        protected CompactWriter()
        {
        }

        public abstract void Write(bool value);

        public abstract void Write(byte value);

        public abstract void Write(char ch);

        public abstract void Write(DateTime value);

        public abstract void Write(DateTimeOffset value);

        public abstract void Write(TimeSpan value);

        public abstract void Write(decimal value);

        public abstract void Write(double value);

        public abstract void Write(short value);

        public abstract void Write(int value);

        public abstract void Write(long value);

        public abstract void Write(float value);

        public abstract void Write(byte[] buffer);

        public abstract void Write(Guid value);

        public virtual void Write(sbyte value)
        {
        }

        public abstract void Write(char[] chars);

        public abstract void Write(string value);

        public virtual void Write(ushort value)
        {
        }

        public virtual void Write(uint value)
        {
        }

        public virtual void Write(ulong value)
        {
        }

        public virtual void Write(Type type, object value)
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

                    this.Write((byte)(value == null ? 1 : 0));

                    if (value == null)
                    {
                        return;
                    }
                }
            }

            switch (type.FullName)
            {
                case "System.String":
                    this.Write((string)value);
                    break;
                case "System.Int16":
                    this.Write((short)value);
                    break;
                case "System.UInt16":
                    this.Write((ushort)value);
                    break;
                case "System.Int32":
                    this.Write((int)value);
                    break;
                case "System.UInt32":
                    this.Write((uint)value);
                    break;
                case "System.Int64":
                    this.Write((long)value);
                    break;
                case "System.UInt64":
                    this.Write((ulong)value);
                    break;
                case "System.Single":
                    this.Write((float)value);
                    break;
                case "System.Double":
                    this.Write((double)value);
                    break;
                case "System.Boolean":
                    this.Write((bool)value);
                    break;
                case "System.Char":
                    this.Write((char)value);
                    break;
                case "System.Byte":
                    this.Write((byte)value);
                    break;
                case "System.DateTime":
                    this.Write((DateTime)value);
                    break;
                case "System.DateTimeOffset":
                    this.Write((DateTimeOffset)value);
                    break;
                case "System.Decimal":
                    this.Write((decimal)value);
                    break;

                case "System.Byte[]":
                    this.Write(((byte[])value)?.Length ?? 0);
                    this.Write((byte[])value);
                    break;

                default:
                    throw new NotSupportedException($"Not support type '{type.FullName}'");
            }
        }

        public abstract void Write(byte[] buffer, int index, int count);

        public abstract void Write(char[] chars, int index, int count);

        public abstract void WriteObject(object graph);

        public abstract void WriteObjectAs<T>(T graph);

        public abstract void WriteObjectAs(Type type, object graph);
    }
}
