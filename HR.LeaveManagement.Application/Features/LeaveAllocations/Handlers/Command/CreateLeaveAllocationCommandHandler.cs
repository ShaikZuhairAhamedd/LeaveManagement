using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exception;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Modals.Identity;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper,IUserService userService,ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
            this.userService = userService;
            this.leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveAllocationDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveType = await leaveTypeRepository.Get(request.leaveAllocationDto.LeaveTypeId);
            var employees = await userService.GetEmployees();
            var listofLeaveAllocation = new List<LeaveAllocation>();

            Func<Employee,  bool> filter = (emp) =>
            {
                var results= leaveAllocationRepository.AllocationExists(emp.Id, request.leaveAllocationDto.LeaveTypeId, DateTime.Now.Year);
                return results.Result==false;
            };


            employees.Where(filter)
                         .ToList()   
                         .ForEach(emp =>
                         {
            
                                listofLeaveAllocation.Add(new LeaveAllocation
                                {
                                    EmployeeId=emp.Id,
                                    LeaveTypeId=leaveType.Id,
                                    NumberOfDays=leaveType.DefaultDays,
                                    Period=DateTime.Now.Year

                                });
                          });

            await leaveAllocationRepository.AddAllocation(listofLeaveAllocation);

            return response;
        }
    }

 

}
