using System;

namespace BlazorWasmApp1.Client.Shared
{
    public class SessionSate
    {
        private Guid _id;

        public Guid Id
        {
            get
            {
                if (_id.Equals(Guid.Empty))
                    _id = Guid.NewGuid();

                return _id;
            }
        }
    }
}
