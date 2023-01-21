using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator :AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public CreateLeaveRequestDtoValidator()
        {
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(p=>p.EndDate)
                .GreaterThan(p=>p.StartDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (Id, token) =>
                {
                   return await _leaveTypeRepository.Exists(Id);
                   
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
