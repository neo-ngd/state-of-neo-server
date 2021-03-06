﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StateOfNeo.Common.Enums;
using StateOfNeo.Data;
using StateOfNeo.Data.Models;
using StateOfNeo.ViewModels.Chart;

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

        public int Count(AssetType[] types)
        {
            if (types == null || types.Length == 0)
            {
                return this.db.Assets.Count();
            }

            var assets = this.db.Assets.Where(x => types.Contains(x.Type)).Count();
            return assets;
        }

        public int TxCount(AssetType[] types)
        {
            if (types == null || types.Length == 0)
            {
                return this.db.Transactions.Count();
            }

            var assets = this.db.TransactedAssets
                .Where(x => types.Contains(x.AssetType))
                .Select(x => x.AssetType == AssetType.NEP5 ? x.TransactionHash : x.OutGlobalTransactionHash ?? x.InGlobalTransactionHash)
                .Distinct()
                .Count();

            return assets;
        }

        public IEnumerable<ChartStatsViewModel> TokenChart(int count)
        {
            var result = this.db.Assets
                .Where(x => x.Type == AssetType.NEP5)
                .OrderByDescending(x => x.TransactionsCount)
                .Take(count)
                .Select(x => new ChartStatsViewModel
                {
                    Label = x.Name,
                    Value = x.TransactionsCount
                })
                .ToList();

            return result;
        }

        public IEnumerable<ChartStatsViewModel> AssetTypesChart()
        {
            var globalAssetsModel = new ChartStatsViewModel
            {
                Label = "Global",
                Value = this.db.Assets.Count(x => x.Type != AssetType.NEP5)
            };

            var tokenAssetsModel = new ChartStatsViewModel
            {
                Label = "NEP-5",
                Value = this.db.Assets.Count(x => x.Type == AssetType.NEP5)
            };

            return new List<ChartStatsViewModel> { globalAssetsModel, tokenAssetsModel };
        }

        public int AddressCount(string hash, UnitOfTime unitOfTime = UnitOfTime.None, bool active = false)
        {
            if (unitOfTime == UnitOfTime.Month)
            {
                var date = DateTime.UtcNow.AddMonths(-1);
                if (active)
                {
                    return this.db.AddressBalances
                        .Include(x => x.Address)
                        .Count(x => x.AssetHash == hash && x.Address.FirstTransactionOn >= date);
                }
                else
                {
                    return this.db.AddressBalances
                        .Include(x => x.Address)
                        .Count(x => x.AssetHash == hash && x.Address.LastTransactionOn >= date);
                }
            }

            return this.db.AddressBalances.Count(x => x.AssetHash == hash);
        }
    }
}
