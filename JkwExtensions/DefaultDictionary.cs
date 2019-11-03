using System.Collections.Generic;

namespace JkwExtensions
{
    public class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        TValue _default;
        public TValue DefaultValue
        {
            get { return _default; }
            set { _default = value; }
        }

        public DefaultDictionary() : base() { }
        public DefaultDictionary(TValue defaultValue)
            : base()
        {
            _default = defaultValue;
        }

        public DefaultDictionary(Dictionary<TKey, TValue> dict)
            : base(dict)
        {
        }

        public DefaultDictionary(Dictionary<TKey, TValue> dict, TValue defaultValue)
            : base(dict)
        {
            _default = defaultValue;
        }

        public new TValue this[TKey key]
        {
            get
            {
                TValue t = _default;
                if (!base.TryGetValue(key, out t))
                {
                    t = _default;
                }
                return t;
            }
            set
            {
                base[key] = DefaultValue;
            }
        }
    }

}
