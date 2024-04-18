﻿using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MembershipEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MembershipCQRS.Command.DeleteCommand
{
    internal sealed class DeleteMembershipCommandHandler : IRequestHandler<DeleteMembershipCommand, int>
    {

        private readonly IMembershipRepository _membershipRepository;

        public DeleteMembershipCommandHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<int> Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
        {
            var data = await _membershipRepository.GetById(request.MembershipId);
            await _membershipRepository.DeleteAsync(data);
            await _membershipRepository.SaveChangeAsync();
            return request.MembershipId;
        }
    }
}
