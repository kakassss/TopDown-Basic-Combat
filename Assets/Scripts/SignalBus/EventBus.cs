using System.Collections.Generic;
using UnityEngine;

public static class EventBus<T> where T : IEvent
{
    private static readonly HashSet<IEventBinding<T>> Bindings = new HashSet<IEventBinding<T>>();

    public static void Subscribe(EventBinding<T> binding) => Bindings.Add(binding);
    public static void Unsubscribe(EventBinding<T> binding) => Bindings.Remove(binding);

    public static void Fire(T eventToRaise)
    {
        foreach(var binding in Bindings)
        {
            binding.OnEvent.Invoke(eventToRaise);
            binding.OnEventNoArgs.Invoke();
        }
    }

    private static void Clear()
    {
        Bindings.Clear();
        Debug.Log("Clearing " + typeof(T).Name + " bindings");
    }
}