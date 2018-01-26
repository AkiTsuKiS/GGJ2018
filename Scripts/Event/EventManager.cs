using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

	public static class EventManager
	{
		private static Dictionary<string, MyUnityEvent> _eventDictionary = new Dictionary<string, MyUnityEvent>();

		public static void AddEventListener(string eventName, UnityAction<object> callBackFunction)
		{
			MyUnityEvent _unityEvent;

			if (_eventDictionary.TryGetValue(eventName,out _unityEvent))
			{
				_unityEvent.AddListener(callBackFunction);
			}
			else
			{
				_unityEvent = new MyUnityEvent();
				_unityEvent.AddListener(callBackFunction);
				_eventDictionary.Add(eventName, _unityEvent);
			}

			Log.L("[EventManager] Add Listener : event = " + eventName + ", callback = " + callBackFunction.Target.ToString() + '.' + callBackFunction.Method.ToString());
		}

		public static bool RemoveEventListener(string eventName, UnityAction<object> callBackFunction)
		{
			MyUnityEvent _unityEvent;

			if(_eventDictionary.TryGetValue(eventName, out _unityEvent))
			{
				_unityEvent.RemoveListener(callBackFunction);
				Log.L("[EventManager] Remove Listener : event = " + eventName + ", callback = " + callBackFunction.Target.ToString() + '.' + callBackFunction.Method.ToString());
				return true;
			}

			Log.L
			("[EventManager] Remove listener fail, cannot found listener : event = " + eventName + ", callback = " + callBackFunction.Target.ToString() + '.' + callBackFunction.Method.ToString());
			return false;
		}

		public static void DispatchEvent(string eventName)
		{
			DispatchEvent(eventName, null);
		}

		public static void DispatchEvent(string eventName, object args)
		{
			MyUnityEvent _unityEvent;

			if(_eventDictionary.TryGetValue(eventName,out _unityEvent))
			{
				Log.L("[EventManager] Dispatch Event : event = " + eventName + "args = " + args);
				_unityEvent.Invoke(args);
			}
		}
	}
	public class MyUnityEvent : UnityEvent<object> { }

