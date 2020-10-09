using System;
using System.Data;

namespace Inomatica.UnitRepo
{
    public class UnitOfWork<T> : IUnitOfWork<T>, IDisposable where T : IDbConnectionFactory
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction = null;
        private bool _disposedValue;

        public UnitOfWork(T connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public IDbConnection UseConnection()
        {
            return _connection;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public void UseTransaction()
        {
            if (_transaction != null)
            {
                return;
            }

            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Rollback();
                        _transaction.Dispose();
                        _transaction = null;
                        _connection.Dispose();
                        throw new Exception($"{nameof(UnitOfWork<T>)} transaction is active while try to dispose");
                    }
                    _connection.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
