using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Execution;

namespace HotChocolate.Subscriptions;

/// <summary>
/// The <see cref="ITopicEventReceiver" /> creates subscriptions to
/// specific event topics and returns an <see cref="ISourceStream{TMessage}" />
/// which represents a stream of event message for the specified topic.
/// </summary>
public interface ITopicEventReceiver
{
    /// <summary>
    /// Subscribes to the specified event <paramref name="topicName" />.
    /// </summary>
    /// <param name="topicName">
    /// The topic name to which the event message belongs to.
    /// </param>
    /// <param name="bufferCapacity">
    ///
    /// </param>
    /// <param name="bufferFullMode">
    ///
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// Returns a <see cref="ISourceStream{TMessage}" />
    /// for the given event <paramref name="topicName" />.
    /// </returns>
    ValueTask<ISourceStream<TMessage>> SubscribeAsync<TMessage>(
        string topicName,
        int? bufferCapacity = null,
        TopicBufferFullMode? bufferFullMode = null,
        CancellationToken cancellationToken = default);
}
