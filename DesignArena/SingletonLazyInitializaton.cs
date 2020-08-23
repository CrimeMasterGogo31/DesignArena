using System;
using System.Collections.Generic;
using System.Text;

namespace DesignArena
{
    public sealed class MySingleton
    {
        private MySingleton() { }
        private static readonly Lazy<MySingleton> lazyObjecct = new Lazy<MySingleton>(() => new Lazy<MySingleton>);

        public static MySingleton Instance { get { return lazyObjecct.Value; } }
    }

}
