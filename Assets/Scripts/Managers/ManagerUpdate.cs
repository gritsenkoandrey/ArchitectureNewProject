using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Managers
{
    [CreateAssetMenu(fileName = "ManagerUpdate", menuName = "Managers/ManagerUpdate")]
    public class ManagerUpdate : ManagerBase, IAwake
    {
        private List<ITick> _ticks = new List<ITick>();
        private List<ITickFixed> _ticksFixeds = new List<ITickFixed>();
        private List<ITickLate> _ticksLates = new List<ITickLate>();

        public static void AddTo(object updatable)
        {
            var mngUpdate = Toolbox.Get<ManagerUpdate>();

            if (updatable is ITick)
            {
                mngUpdate._ticks.Add(updatable as ITick);
            }
            if (updatable is ITickFixed)
            {
                mngUpdate._ticksFixeds.Add(updatable as ITickFixed);
            }
            if (updatable is ITickLate)
            {
                mngUpdate._ticksLates.Add(updatable as ITickLate);
            }
        }

        public static void RemoveFrom(object updatable)
        {
            var mngUpdate = Toolbox.Get<ManagerUpdate>();

            if (updatable is ITick)
            {
                mngUpdate._ticks.Remove(updatable as ITick);
            }
            if (updatable is ITickFixed)
            {
                mngUpdate._ticksFixeds.Remove(updatable as ITickFixed);
            }
            if (updatable is ITickLate)
            {
                mngUpdate._ticksLates.Remove(updatable as ITickLate);
            }
        }

        public void Tick()
        {
            for (int i = 0; i < _ticks.Count; i++)
            {
                _ticks[i].Tick();
            }
        }

        public void TickFixed()
        {
            for (int i = 0; i < _ticksFixeds.Count; i++)
            {
                _ticksFixeds[i].TickFixed();
            }
        }

        public void TickLate()
        {
            for (int i = 0; i < _ticksLates.Count; i++)
            {
                _ticksLates[i].TickLate();
            }
        }

        public void OnAwake()
        {
            GameObject.Find("[SETUP]").AddComponent<ManagerUpdateComponent>().Setup(this);
        }
    }
}