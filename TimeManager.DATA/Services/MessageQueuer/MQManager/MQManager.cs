﻿using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace TimeManager.DATA.Services.MessageQueuer
{
    public class MQManager : IMQManager
    {
        private readonly DefaultObjectPool<IModel> _objectPool;
        public IModel channel { get; }

        public MQManager(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
            channel = _objectPool.Get();
        }

        public void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey) where T : class
        {
            if (message == null) return;

            try
            {
                channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);
                var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.ReplyTo = exchangeName;

                channel.BasicPublish(
                    exchangeName,
                    routeKey,
                    properties,
                    sendBytes
                    );

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }
    }
}
