using System.Collections.Generic;
using UnityEngine;

namespace TDShooter.Pools
{
    /// <summary>
    /// родитель всех пулов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePool<T> where T : MonoBehaviour
    {
        protected T _prefab;
        protected Transform _parent;
        protected List<T> _elements;

        public BasePool(T prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
            _elements = new List<T>();
        }

        public virtual void Init(int count)
        {
            for (int i = 0; i < count; i++)
            {
                PoolUp(false);
            }
        }

        public virtual T GetAviableOrCreateNew()
        {
            T result = _elements.Find(element => element.gameObject.activeSelf == false);
            if (result == null)
                result = PoolUp(true);
            else
                result.gameObject.SetActive(true);

            return result;
        }

        protected abstract T GetCreated();

        protected T PoolUp(bool isActive)
        {
            T element = GetCreated();
            element.transform.SetParent(_parent);
            element.gameObject.SetActive(isActive);
            _elements.Add(element);
            return element;
        }
    }
}