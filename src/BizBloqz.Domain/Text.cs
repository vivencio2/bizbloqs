using System;

namespace BizBloqz.Domain
{
    public class Text
    {
        public Guid Id { get; private set; }
        public string Value { get; private set; }

        public Text(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }

        public Text(Guid id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}
