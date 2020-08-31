using Assets.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class Starter : MonoBehaviour
    {
        public List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake()
        {
            foreach (var managerBase in managers)
            {
                Toolbox.Add(managerBase);
            }
        }
    }
}