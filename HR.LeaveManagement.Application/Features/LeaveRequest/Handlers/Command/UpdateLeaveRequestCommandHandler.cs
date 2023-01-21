using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTO.LeaveRequest.Validators;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository leaveRequestReposiotry;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly ILeaveAllocationRepository leaveAllocationRepository; 
        private readonly IMapper mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestReposiotry, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveRequestReposiotry = leaveRequestReposiotry;
            this.mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await leaveRequestReposiotry.Get(request.Id);
            if (request.updateLeaveRequestDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator(leaveTypeRepository);
                var validatorResult = await validator.ValidateAsync(request.updateLeaveRequestDto);
                if (!validatorResult.IsValid) {
                    throw new ValidationException();
                }
            
                mapper.Map(request.updateLeaveRequestDto, leaveRequest);
                await leaveRequestReposiotry.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null) {
                await leaveRequestReposiotry.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
                if (request.ChangeLeaveRequestApprovalDto.Approved.Value) {
                    var allocation = await leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                    int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                    allocation.NumberOfDays -= daysRequested;
                   await  leaveAllocationRepository.Update(allocation);
                }
            }

            return Unit.Value;
        }


















    }
}
