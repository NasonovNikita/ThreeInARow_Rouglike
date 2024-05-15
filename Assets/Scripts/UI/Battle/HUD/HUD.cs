using Core;
using Core.Singleton;
using Other;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle.HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private ObjectMover mover;
        [SerializeField] private Text text;
        
        [SerializeField] private float moveLength;

        public static HUD Create(string content, Color color, Transform parentTransform)
        {
            HUD hud = Instantiate(PrefabsContainer.instance.hud, parentTransform);

            hud.text.text = content;
            hud.text.color = color;
            

            return hud;
        }
        
        public void MoveUp() => Move(1);
        public void MoveDown() => Move(-1);
        public void Stay() => Move(-0.5f);

        private void Move(float direction) =>
            StartCoroutine(mover.MoveBy(
                    MoveVector(direction), 
                    OnMoveEnd
                    ));

        private Vector3 MoveVector(float direction) => Vector3.up * (moveLength * direction);

        private void OnMoveEnd() => Destroy(gameObject);
    }
}