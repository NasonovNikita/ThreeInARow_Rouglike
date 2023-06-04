using UnityEngine;

namespace Battle
{
    public abstract class SerializedUseAble : ScriptableObject, IUseAble
    {
        public float value;
        public abstract void Use();
    }
    public interface IUseAble
    {
        public void Use();
    }
}