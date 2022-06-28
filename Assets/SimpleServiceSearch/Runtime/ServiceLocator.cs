using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleServiceSearch
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Type> m_Factory = new Dictionary<Type, Type>();

        private static readonly Dictionary<Type, Type> m_Singleton = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, object> m_SingletonInstance = new Dictionary<Type, object>();

        public static void RegisterSingleton<T>(object instance)
        {
            m_Singleton[typeof(T)] = typeof(T);
            if (instance != null)
            {
                m_SingletonInstance[typeof(T)] = instance;
            }

        }

        public static void RegisterSingleton<T>()
        {
            RegisterSingleton<T>(null);
        }

        public static void Register<T>()
        {
            m_Factory[typeof(T)] = typeof(T);
        }

        #region Locator Object Functions
        public static T Locate<T>(bool instanceOnly) where T : class
        {
            object result = default(T);
            Type type = null;
            if (m_Singleton.TryGetValue(typeof(T), out type))
            {
                if (instanceOnly)
                {
                    if (m_SingletonInstance.TryGetValue(type, out result))
                    {
                        return (T)result;
                    }

                    return null;
                }

                if (type.IsSubclassOf(typeof(MonoBehaviour)))
                {
                    if (!m_SingletonInstance.TryGetValue(type, out result))
                    {
                        GameObject go = new GameObject(type.ToString() + "_SingletonInstance");
                        result = go.AddComponent(type);
                        m_SingletonInstance.Add(type, result);
                    }
                }
                else
                {
                    result = Activator.CreateInstance(type);
                    m_SingletonInstance.Add(type, result);
                }
            }
            else if (m_Factory.TryGetValue(typeof(T), out type))
            {
                if (type.IsSubclassOf(typeof(MonoBehaviour)))
                {
                    GameObject go = new GameObject(type.ToString() + "_Instance");
                    result = go.AddComponent(type);
                }
                else
                {
                    result = Activator.CreateInstance(type);
                }
            }

            return (T)result;
        }

        public static T Locate<T>() where T : class
        {
            return Locate<T>(false);
        }
        #endregion
    }
}
