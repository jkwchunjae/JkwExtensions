using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JkwExtensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        private sealed class ReadLockToken : IDisposable
        {
            private ReaderWriterLockSlim _lock;
            public ReadLockToken(ReaderWriterLockSlim lock_)
            {
                _lock = lock_;
                _lock.EnterReadLock();
            }
            public void Dispose()
            {
                _lock?.ExitReadLock();
                _lock = null;
            }
        }
        private sealed class WriteLockToken : IDisposable
        {
            private ReaderWriterLockSlim _lock;
            public WriteLockToken(ReaderWriterLockSlim lock_)
            {
                _lock = lock_;
                _lock.EnterWriteLock();
            }
            public void Dispose()
            {
                _lock?.ExitWriteLock();
                _lock = null;
            }
        }

        /// <summary>
        /// USE THIS FUNCTION
        /// </summary>
        /// <param name="readWriteLock"></param>
        /// <returns></returns>
        public static IDisposable AcquireReaderLock(this ReaderWriterLockSlim readWriteLock)
        {
            return new ReadLockToken(readWriteLock);
        }

        /// <summary>
        /// USE THIS FUNCTION
        /// </summary>
        /// <param name="readWriteLock"></param>
        /// <returns></returns>
        public static IDisposable AcquireWriterLock(this ReaderWriterLockSlim readWriteLock)
        {
            return new WriteLockToken(readWriteLock);
        }
    }
}
