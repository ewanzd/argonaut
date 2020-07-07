﻿using Argonaut.Core;
using Argonaut.Persistence.Models;
using NetTopologySuite.Geometries;
using System;
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

        public IQueryable<PointOfInterest> GetAll()
        {
            return 
                from poi in _context.PointOfInterests
                select new PointOfInterest(poi.PointOfInterestId, poi.Name, poi.Description, new Coordinate(poi.Coordinate.X, poi.Coordinate.Y));
        }

        public PointOfInterest Add(PointOfInterest pointOfInterest)
        {
            var poiEntity = new PointOfInterestEntity
            {
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
                Coordinate = new Point(pointOfInterest.Coordinate.Latitude, pointOfInterest.Coordinate.Longitude)
            };
            _context.PointOfInterests.Add(poiEntity);

            return pointOfInterest.SetId(poiEntity.PointOfInterestId);
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
