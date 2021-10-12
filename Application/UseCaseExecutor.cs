﻿using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch,TResult> query, TSearch search)
        {
            _logger.Log(query, _actor, search);

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }

            return query.Execute(search);
        }
        public TResult ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }
            return query.Execute();
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logger.Log(command, _actor, request);

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }

            command.Execute(request);
        }
        public void ExecuteCommand<TFirst,TSecond>(ICommand<TFirst,TSecond> command, TFirst first,TSecond second)
        {
            _logger.Log(command, _actor, first, second);

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }

            command.Execute(first,second);
        }

    }
}
