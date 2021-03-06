using System;
using System.Collections.Generic;
using System.Text;
using UtilsSharp.Dependency;

namespace UtilsSharp.RabbitMq.Extension
{
    /// <summary>
    ///  消费者接口
    /// </summary>
    public interface IConsumer : IUnitOfWorkDependency
    {
        /// <summary>
        /// 执行消费者
        /// </summary>
        /// <param name="rabbitMqBusinessName">业务名称</param>
        /// <param name="consumerCount">消费者数量</param>
        /// <param name="consumerHandleCount">每个消费者每次执行条数</param>
        void Execute(string rabbitMqBusinessName, int consumerCount = 1, int consumerHandleCount = 500);

        /// <summary>
        /// 执行消费者
        /// </summary>
        /// <param name="rabbitMqBusinessName">业务名称</param>
        /// <param name="consumerCount">消费者数量</param>
        /// <param name="consumerHandleCount">每个消费者每次执行条数</param>
        void ExecuteAsync(string rabbitMqBusinessName, int consumerCount = 1, int consumerHandleCount = 500);

        /// <summary>
        /// 消费者委托
        /// </summary>
        /// <param name="contents">拉取到的内容</param>
        void ReceiveCallBack(List<string> contents);

    }
}
