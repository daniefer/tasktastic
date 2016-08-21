﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using RestSharp;

namespace Common
{
    public class EventStoreProxy<T, TKey> : EventStore<T, TKey>, IDisposable where T: struct, IKey<TKey>
                                                                             where TKey: struct
    {
        private RestClient _client;

        public EventStoreProxy(Uri host)
        {
            this._client = new RestClient(host);
        }

        public override void Add(Transform<T> transform)
        {
            var request = new RestRequest(new Uri(this._client.BaseUrl, ""));
            this._client.Post<Transform<T>>(request);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EventStoreProxy() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
