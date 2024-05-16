using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniSpace.Services.Notifications.Application.Dto;

namespace MiniSpace.Services.Notifications.Application.Services.Clients
{
    public interface IFriendsServiceClient
    {
        Task<IEnumerable<FriendDto>> GetAsync(Guid studentId);
    }
}