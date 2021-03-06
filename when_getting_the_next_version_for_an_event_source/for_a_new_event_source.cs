// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Machine.Specifications;

namespace Dolittle.Runtime.Events.Store.Specs.when_getting_the_next_version_for_an_event_source
{
    [Subject(typeof(IFetchEventSourceVersion))]
    public class for_a_new_event_source : given.an_event_store
    {
        static IEventStore event_store;
        static EventSourceVersion result;
        static EventSourceKey _key;

        Establish context = () =>
        {
            event_store = get_event_store();
            _key = new EventSourceKey(Guid.NewGuid(), Guid.NewGuid());
        };

        Because of = () => event_store._do(_ => result = _.GetNextVersionFor(_key));

        It should_get_the_initial_version = () => result.ShouldEqual(EventSourceVersion.Initial);

        Cleanup nh = () => event_store.Dispose();
    }
}