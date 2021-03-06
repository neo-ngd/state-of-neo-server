﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using StateOfNeo.Common;
using StateOfNeo.Node.Cache;
using StateOfNeo.Node.Hubs;
using System;

namespace StateOfNeo.Node.Infrastructure
{
    public class NotificationEngine
    {
        private bool IsInitialBlockConnection = false;
        private int NeoBlocksWithoutNodesUpdate = 0;
        private ulong TotalTransactionCount = 0;
        private DateTime LastBlockReceiveTime = default(DateTime);

        private readonly IHubContext<NodeHub> nodeHub;
        private readonly IHubContext<BlockHub> blockHub;
        private readonly NodeCache nodeCache;
        private readonly IHubContext<TransactionCountHub> transCountHub;
        private readonly IHubContext<FailedP2PHub> failP2PHub;
        private readonly IHubContext<TransactionAverageCountHub> transAvgCountHub;
        private readonly NodeSynchronizer nodeSynchronizer;
        private readonly RPCNodeCaller rPCNodeCaller;
        private readonly NetSettings netSettings;
        private readonly PeersEngine peersEngine;

        public NotificationEngine(
            IHubContext<NodeHub> nodeHub,
            IHubContext<BlockHub> blockHub,
            IHubContext<TransactionCountHub> transCountHub,
            IHubContext<TransactionAverageCountHub> transAvgCountHub,
            IHubContext<FailedP2PHub> failP2PHub,
            NodeCache nodeCache,
            PeersEngine peersEngine,
            NodeSynchronizer nodeSynchronizer,
            RPCNodeCaller rPCNodeCaller,
            IOptions<NetSettings> netSettings)
        {
            this.nodeHub = nodeHub;
            this.nodeCache = nodeCache;
            this.transCountHub = transCountHub;
            this.failP2PHub = failP2PHub;
            this.transAvgCountHub = transAvgCountHub;
            this.nodeSynchronizer = nodeSynchronizer;
            this.rPCNodeCaller = rPCNodeCaller;
            this.netSettings = netSettings.Value;
            this.peersEngine = peersEngine;

            this.blockHub = blockHub;
        }

        public void Init()
        {
            //Blockchain.PersistCompleted += Blockchain_PersistCompleted;
        }
    }
}
