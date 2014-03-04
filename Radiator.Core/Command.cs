using System;

namespace Radiator.Core
{
    public abstract class Command
    {
        protected Command()
        {
            CommandReference = Guid.NewGuid();
        }

        /// <summary>
        /// A reference to the command. This is set in the Command Constructor.
        /// </summary>
        public Guid CommandReference { get; private set; }

        internal void SetCommandReference()
        {
            if (CommandReference == Guid.Empty)
                CommandReference = Guid.NewGuid();
        }
    }
}