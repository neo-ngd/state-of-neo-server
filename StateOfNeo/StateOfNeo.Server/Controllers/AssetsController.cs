﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StateOfNeo.Common.Extensions;
using StateOfNeo.Data.Models;
using StateOfNeo.Services;
using StateOfNeo.ViewModels.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateOfNeo.Server.Controllers
{
    public class AssetsController : BaseApiController
    {
        private readonly IPaginatingService paginating;
        private readonly IAssetService assets;

        public AssetsController(IPaginatingService paginating, IAssetService assets)
        {
            this.paginating = paginating;
            this.assets = assets;
        }

        [HttpGet("[action]")]
        public IActionResult Get(string hash)
        {
            var asset = this.assets.Find(hash);
            if (asset == null)
            {
                return this.BadRequest("Invalid asset hash");
            }

            var result = Mapper.Map<AssetDetailsViewModel>(asset);

            return this.Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List(int page = 1, int pageSize = 10)
        {
            var result = await this.paginating.GetPage<Asset, AssetListViewModel>(page, pageSize);

            return this.Ok(result.ToListResult());
        }
    }
}