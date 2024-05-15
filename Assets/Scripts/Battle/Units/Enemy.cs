using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

namespace Battle.Units
{
    [Serializable]
    public class Enemy : Unit
    {
        [SerializeField] private AI.Ai ai;

        public override List<Unit> Enemies => new() { target };

        public override void Awake()
        {
            hp.OnValueChanged += _ => AudioManager.Instance.Play(AudioEnum.EnemyHit);
            
            base.Awake();
        }

        public IEnumerator Turn()
        {
            while (HasMoves)
            {
                yield return StartCoroutine(ai.Act());
                WasteMove();
                if (HasMoves) continue;
                RefillMoves();
                yield break;
            }
        }
    }
}