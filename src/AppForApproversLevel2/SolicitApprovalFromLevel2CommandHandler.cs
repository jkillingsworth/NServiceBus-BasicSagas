﻿using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForApproversLevel2
{
    public class SolicitApprovalFromLevel2CommandHandler : IHandleMessages<SolicitApprovalFromLevel2Command>
    {
        public Context<ItemViewModel> Context { get; set; }

        public void Handle(SolicitApprovalFromLevel2Command message)
        {
            Context.MarshalToUiThread(() => HandleOnUiThread(message));
        }

        private void HandleOnUiThread(SolicitApprovalFromLevel2Command message)
        {
            var item = new ItemViewModel
            {
                RequestId = message.RequestId,
                Description = message.Description,
                Cost = message.Cost
            };

            Context.Items.Add(item);
        }
    }
}
