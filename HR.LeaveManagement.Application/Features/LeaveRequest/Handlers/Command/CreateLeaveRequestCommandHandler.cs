using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exception;
using HR.LeaveManagement.Application.Features.LeaveRequest.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Modals;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using HR.LeaveManagement.Domain;
using System.Security.Claims;
using HR.LeaveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateLeaveRequestCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IEmailSender emailSender,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.leaveAllocationRepository = unitOfWork.leaveAllocationRepository;
            this.leaveRequestRepository = unitOfWork.leaveRequestRepository;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(leaveRequestRepository);
            var employeeId = this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(q => q.Type == "uid")?.Value;
            LeaveAllocation leaveAllocation = this.leaveAllocationRepository.Get(employeeId, request.LeaveRequestDto.LeaveTypeId);
          
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (!validationResult.IsValid) { //throw new ValidationException(validationResult);

                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            if (leaveAllocation is null)
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDto.EndDate), "You Don't Have Any Leave Allocation For This Type...."));
            }
            else {
                int numberofDaysLeaveApplied = (request.LeaveRequestDto.EndDate - request.LeaveRequestDto.StartDate).Days;
                if (leaveAllocation.NumberOfDays < numberofDaysLeaveApplied)
                {
                    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDto.EndDate), "Now you don't have enough Days"));
                }


            }

            



            var leaveRequest = mapper.Map< HR.LeaveManagement.Domain.LeaveRequest> (request.LeaveRequestDto);
            leaveRequest.RequestingEmployeeId = employeeId;
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest = await leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Creation SuccessFul";
            response.Id = leaveRequest.Id;
            await this.unitOfWork.Save();
            //....Sending Email.... 
            try
            {
                

                var emailAddress = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            
                var email = new Email
                {
                    To = emailAddress,
                    Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                    $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };

                await emailSender.SendEmail(email);
            }
            catch (System.Exception ex)
            {
                //// Log or handle error, but don't throw...
            }
            return response;
        }
    }
}
