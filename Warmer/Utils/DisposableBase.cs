using System;

namespace Warmer.Utils
{
    /// <summary>
    /// Implementation of the dispose pattern
    /// </summary>
    public abstract class DisposableBase : IDisposable
    {
        /// <summary>
        /// Creates a new DisposedBase
        /// </summary>
        public DisposableBase()
        {
            disposed_ = false;
        }

        /// <summary>
        /// Disposes of the object resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes of the object resources
        /// </summary>
        /// <param name="disposing">If the GC is finalizing this object or not</param>
        protected void Dispose(bool disposing)
        {
            if (!disposed_)
            {
                if (disposing)
                {
                    OnFinalize();
                }

                OnDispose();

                disposed_ = true;
            }
        }

        /// <summary>
        /// Called when the object needs to free unmanaged resources
        /// </summary>
        protected virtual void OnDispose()
        { }

        /// <summary>
        /// Called when the object needs to free managed resources
        /// </summary>
        protected virtual void OnFinalize()
        { }

        /// <summary>
        /// If the object resources were already freed
        /// </summary>
        private bool disposed_;
    }
}
