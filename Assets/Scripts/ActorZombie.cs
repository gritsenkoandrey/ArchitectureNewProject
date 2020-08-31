using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using UnityEngine;


namespace Assets.Scripts
{
    public class ActorZombie : MonoBehaviour, ITick
    {
        private void Start()
        {
            ManagerUpdate.AddTo(this);
        }

        public void Tick()
        {
            Debug.Log("Zombie");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Toolbox.Get<ManagerEvents>().CreatePrefab(Random.insideUnitSphere * Random.Range(-10, 10));
            }
        }
    }
}