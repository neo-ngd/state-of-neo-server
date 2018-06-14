﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StateOfNeo.Common;
using StateOfNeo.Data;
using StateOfNeo.Data.Models;
using StateOfNeo.Server.Cache;
using StateOfNeo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateOfNeo.Server.Infrastructure
{
    public class NodeSynchronizer
    {
        private NodeCache _nodeCache;
        private StateOfNeoContext _ctx;
        private RPCNodeCaller _rPCNodeCaller;
        private List<Node> CachedDbNodes;

        public NodeSynchronizer(NodeCache nodeCache, StateOfNeoContext ctx, RPCNodeCaller rPCNodeCaller)
        {
            _nodeCache = nodeCache;
            _ctx = ctx;
            _rPCNodeCaller = rPCNodeCaller;
            CachedDbNodes = _ctx.Nodes
                .Include(n => n.NodeAddresses)
                .ToList();
        }

        public async Task SyncCacheAndDb()
        {
            foreach (var cacheNode in _nodeCache.NodeList)
            {
                var existingDbNode = CachedDbNodes
                    .FirstOrDefault(dbn =>
                        dbn.NodeAddresses.FirstOrDefault(ia => ia.Ip == cacheNode.Ip) != null);
                if (existingDbNode == null)
                {
                    var newDbNode = Mapper.Map<Node>(cacheNode);
                    _ctx.Nodes.Add(newDbNode);
                    await _ctx.SaveChangesAsync();

                    var nodeDbAddress = new NodeAddress
                    {
                        Ip = cacheNode.Ip,
                        Port = cacheNode.Port,
                        Type = cacheNode.Type == null ? NodeAddressType.Default : Enum.Parse<NodeAddressType>(cacheNode.Type),

                        NodeId = newDbNode.Id
                    };
                    _ctx.NodeAddresses.Add(nodeDbAddress);
                    await _ctx.SaveChangesAsync();
                }
                else
                {
                    var portIsDifferent = existingDbNode.NodeAddresses.FirstOrDefault(na => na.Port == cacheNode.Port) == null;
                    if (portIsDifferent)
                    {
                        var nodeDbAddress = new NodeAddress
                        {
                            Ip = cacheNode.Ip,
                            Port = cacheNode.Port,
                            Type = cacheNode.Type == null ? NodeAddressType.Default : Enum.Parse<NodeAddressType>(cacheNode.Type),

                            NodeId = existingDbNode.Id
                        };
                        _ctx.NodeAddresses.Add(nodeDbAddress);
                        await _ctx.SaveChangesAsync();
                    }
                }
            }


            _nodeCache.Update(CachedDbNodes.AsQueryable().ProjectTo<NodeViewModel>());
        }

        public async Task UpdateNodesInformation()
        {
            var dbNodes = _ctx.Nodes
                  .Include(n => n.NodeAddresses)
                  .ToList();

            foreach (var dbNode in dbNodes)
            {
                if (string.IsNullOrEmpty(dbNode.Url))
                {
                }
                foreach (var address in dbNode.NodeAddresses)
                {
                    var height = await _rPCNodeCaller.GetNodeHeight($"{address.Ip}:{address.Port}");
                    if (height > -1)
                    {

                    }
                }
            }
        }
    }
}
