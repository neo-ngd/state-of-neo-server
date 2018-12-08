﻿using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StateOfNeo.Common;
using StateOfNeo.Common.Enums;
using StateOfNeo.Data;
using StateOfNeo.ViewModels;
using StateOfNeo.ViewModels.Chart;
using System.Collections.Generic;
using System.Linq;

namespace StateOfNeo.Services
{
    public class StateService : IStateService
    {
        private Dictionary<string, Dictionary<UnitOfTime, IEnumerable<ChartStatsViewModel>>> charts;
        private readonly StateOfNeoContext db;

        private HeaderStatsViewModel headerStats;
        private long? totalTxCount;
        private int? totalAddressCount;
        private int? totalAssetsCount;
        private decimal? totalClaimed;

        public StateService(IOptions<DbSettings> dbOptions)
        {
            this.db = StateOfNeoContext.Create(dbOptions.Value.DefaultConnection);

            this.GetHeaderStats();
            this.GetTotalTxCount();
            this.GetTotalAddressCount();
            this.GetTotalAssetsCount();
            this.GetTotalClaimed();
        }

        public HeaderStatsViewModel GetHeaderStats()
        {
            if (this.headerStats == null)
            {
                this.headerStats = this.db.Blocks
                    .OrderByDescending(x => x.Height)
                    .ProjectTo<HeaderStatsViewModel>()
                    .FirstOrDefault();
            }

            return this.headerStats;
        }

        public void SetHeaderStats(HeaderStatsViewModel newValue)
        {
            this.headerStats = newValue;
        }

        public long GetTotalTxCount()
        {
            if (this.totalTxCount == null) this.totalTxCount = this.db.Transactions.Count();
            return this.totalTxCount.Value;
        }

        public void AddToTotalTxCount(int count)
        {
            this.totalTxCount = this.GetTotalTxCount() + count;
        }

        public int GetTotalAddressCount()
        {
            if (this.totalAddressCount == null) this.totalAddressCount = this.db.Addresses.Count();
            return this.totalAddressCount.Value;
        }

        public void AddTotalAddressCount(int count)
        {
            this.totalAddressCount = this.GetTotalAddressCount() + count;
        }

        public int GetTotalAssetsCount()
        {
            if (this.totalAssetsCount == null) this.totalAssetsCount = this.db.Assets.Count();
            return this.totalAssetsCount.Value;
        }

        public void AddTotalAssetsCount(int count)
        {
            this.totalAssetsCount = this.GetTotalAssetsCount() + count;
        }

        public decimal GetTotalClaimed()
        {
            if (this.totalClaimed == null)
            {
                this.totalClaimed = this.db.Transactions
                    .Include(x => x.GlobalOutgoingAssets).ThenInclude(x => x.Asset)
                    .Where(x => x.Type == Neo.Network.P2P.Payloads.TransactionType.ClaimTransaction)
                    .SelectMany(x => x.GlobalOutgoingAssets.Where(a => a.AssetType == AssetType.GAS))
                    .Sum(x => x.Amount);
            }

            return this.totalClaimed.Value;
        }

        public void AddTotalClaimed(decimal amount)
        {
            this.totalClaimed = this.GetTotalClaimed() + amount;
        }
    }
}