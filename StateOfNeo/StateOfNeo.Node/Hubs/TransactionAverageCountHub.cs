﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace StateOfNeo.Node.Hubs
{
    public interface ITransactionAverageCountHub
    {
        Task Send();
    }

    public class TransactionAverageCountHub : Hub<ITransactionAverageCountHub>
    {
        public async Task Send() => await Clients.All.Send();
    }
}
