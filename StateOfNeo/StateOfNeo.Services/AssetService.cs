﻿using System.Linq;
using AutoMapper.QueryableExtensions;
using StateOfNeo.Data;
using StateOfNeo.Data.Models;

namespace StateOfNeo.Services
{
    public class AssetService : IAssetService
    {
        private readonly StateOfNeoContext db;

        public AssetService(StateOfNeoContext db)
        {
            this.db = db;
        }

        public T Find<T>(string hash) => 
            this.db.Assets
                .Where(x => x.Hash == hash)
                .ProjectTo<T>()
                .FirstOrDefault();        
    }
}
