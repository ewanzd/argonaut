using Argonaut.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Argonaut.Persistence
{
    public class PointOfInterestRepository : IPointOfInterestRepository, IDisposable
    {
        private readonly ArgonautContext _context;

        public PointOfInterestRepository(ArgonautContext context)
        {
            this._context = context;
        }

        public IEnumerable<PointOfInterest> GetAll()
        {
            return _context.PointOfInterests.Select(poi =>
                new PointOfInterest(poi.PointOfInterestId, poi.Name, poi.Description, new Coordinate(poi.Coordinate.X, poi.Coordinate.Y)));
        }

        public PointOfInterest Add(PointOfInterest pointOfInterest)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
