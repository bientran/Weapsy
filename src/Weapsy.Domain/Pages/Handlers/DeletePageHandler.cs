using FluentValidation;
using System;
using System.Collections.Generic;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.Pages.Commands;
using Weapsy.Infrastructure.Dispatcher;

namespace Weapsy.Domain.Pages.Handlers
{
    public class DeletePageHandler : ICommandHandler<DeletePage>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IValidator<DeletePage> _validator;

        public DeletePageHandler(IPageRepository pageRepository, IValidator<DeletePage> validator)
        {
            _pageRepository = pageRepository;
            _validator = validator;
        }

        public IEnumerable<IDomainEvent> Handle(DeletePage command)
        {
            var page = _pageRepository.GetById(command.SiteId, command.Id);

            if (page == null)
                throw new Exception("Page not found.");

            page.Delete(command, _validator);

            _pageRepository.Update(page);

            return page.Events;
        }
    }
}
