using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;


namespace Assets.Scripts
{
    public class Toolbox : Singleton<Toolbox>
    {
        /// <summary>
        /// Контейнер для менеджеров
        /// </summary>
        private Dictionary<Type, object> data = new Dictionary<Type, object>();

        /// <summary>
        /// Добавление менеджера в Toolbox
        /// </summary>
        public static void Add(object obj)
        {
            var add = obj;
            var manager = obj as ManagerBase;

            if (manager != null)
            {
                add = Instantiate(manager);
            }
            else
            {
                return;
            }

            Instance.data.Add(obj.GetType(), add);

            if (add is IAwake)
            {
                (add as IAwake).OnAwake();
            }
        }

        /// <summary>
        /// Возвращение менеджера по типу
        /// </summary>
        public static T Get<T>()
        {
            object resolve;
            Instance.data.TryGetValue(typeof(T), out resolve);
            return (T)resolve;
        }

        /// <summary>
        /// Очистка менеджеров на сцене
        /// </summary>
        public void ClearScene()
        {

        }
    }
}