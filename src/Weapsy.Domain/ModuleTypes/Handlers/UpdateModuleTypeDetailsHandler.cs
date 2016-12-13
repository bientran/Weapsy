using System.Collections.Generic;
using FluentValidation;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.ModuleTypes.Commands;
using System;
using Weapsy.Infrastructure.Dispatcher;

namespace Weapsy.Domain.ModuleTypes.Handlers
{
    public class UpdateModuleTypeDetailsHandler : ICommandHandler<UpdateModuleTypeDetails>
    {
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly IValidator<UpdateModuleTypeDetails> _validator;

        public UpdateModuleTypeDetailsHandler(IModuleTypeRepository moduleTypeRepository,
            IValidator<UpdateModuleTypeDetails> validator)
        {
            _moduleTypeRepository = moduleTypeRepository;
            _validator = validator;
        }

        public IEnumerable<IDomainEvent> Handle(UpdateModuleTypeDetails command)
        {
            var page = _moduleTypeRepository.GetById(command.Id);

            if (page == null)
                throw new Exception("Module Type not found");

            page.UpdateDetails(command, _validator);

            _moduleTypeRepository.Update(page);

            return page.Events;
        }
    }
}
