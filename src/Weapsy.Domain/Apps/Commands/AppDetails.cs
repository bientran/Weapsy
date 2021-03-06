﻿using System;
using Weapsy.Infrastructure.Dispatcher;

namespace Weapsy.Domain.Apps.Commands
{
    public class AppDetails : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Folder { get; set; }
    }
}
