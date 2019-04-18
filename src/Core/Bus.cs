﻿using System;
using System.Diagnostics;

namespace ClearMeasure.OnionDevOpsArchitecture.Core
{
    //Code adapted from MvcContrib (https://archive.codeplex.com/?p=mvccontrib)
    //Some code adapted from Mediatr (https://github.com/jbogard/MediatR)
    public delegate object SingleInstanceFactory(Type serviceType);

    public partial class Bus
    {
        private readonly SingleInstanceFactory _singleInstanceFactory;
        private readonly ITelemetrySink _telemetrySink;

        private Bus()
        {
        }

        public Bus(SingleInstanceFactory singleInstanceFactory, ITelemetrySink telemetrySink)
        {
            _singleInstanceFactory = singleInstanceFactory;
            _telemetrySink = telemetrySink;
        }

        public virtual TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            Trace.WriteLine(message: string.Format("Message sent: {0}", request.GetType().FullName));
            var defaultHandler = GetHandler(request);

            var result = defaultHandler.Handle(request);
            _telemetrySink.RecordCall<TResponse>(request, result);

            return result;
        }

        private RequestHandler<TResponse> GetHandler<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var wrapperType = typeof(RequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            object handler;
            try
            {
                handler = _singleInstanceFactory(handlerType);

                if (handler == null)
                    throw new InvalidOperationException(
                        "Handler was not found for request of type " + request.GetType());
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Handler was not found for request of type " + request.GetType(),
                    e);
            }

            var wrapperHandler =
                Activator.CreateInstance(wrapperType, handler);
            return (RequestHandler<TResponse>) wrapperHandler;
        }

        private abstract class RequestHandler<TResult>
        {
            public abstract TResult Handle(IRequest<TResult> message);
        }

        private class RequestHandler<TCommand, TResult> : RequestHandler<TResult> where TCommand : IRequest<TResult>
        {
            private readonly IRequestHandler<TCommand, TResult> _inner;

            public RequestHandler(IRequestHandler<TCommand, TResult> inner)
            {
                _inner = inner;
            }

            public override TResult Handle(IRequest<TResult> message)
            {
                return _inner.Handle((TCommand) message);
            }
        }
    }
}