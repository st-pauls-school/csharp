using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySortedTree.Lib
{
    public class BinarySortedGenericTree<T> : IBinarySortedTree<T> where T : IComparable<T>, IEquatable<T>
    {
        // make it read only so that, once set in the constructor, we can't change it
        readonly T _value;
        bool _enabled;
        IBinarySortedTree<T> _left, _right;

        /// <summary>
        /// returns the depth of the tree - but ignoring deleted nodes. 
        /// </summary>
        public int Depth
        {
            get
            {
                int l = _left == null ? 0 : _left.Depth;
                int r = _right == null ? 0 : _right.Depth;
                return new List<int> { l, r }.Max() + (_enabled ? 1 : 0);
            }
        }

        public T Sum
        {
            get
            {
                T l = _left == null ? default(T) : _left.Sum;
                T r = _right == null ? default(T) : _right.Sum;
                dynamic a = l;
                dynamic b = r;
                dynamic result = a + _value + b;
                return (T)result;
            }
        }

        public BinarySortedGenericTree(T value)
        {
            _enabled = true;
            _value = value;
            _left = null;
            _right = null;
        }

        public void Delete(T val)
        {
            if (_enabled && _value.Equals(val))
            {
                _enabled = false;
                return;
            }
            // don't actually delete the value, we still want to be able to use it for traversal
            if(_value.CompareTo(val) >= 0)
            {
                if (_left != null)
                    _left.Delete(val);
            }
            if (_value.CompareTo(val) < 0)
            {
                if (_right != null)
                    _right.Delete(val);
            }
        }

        public void Insert(T val)
        {
            IBinarySortedTree<T> direction;
            if (_value.CompareTo(val) >= 0)
            {
                _left = InsertWithDirection(_left, val);
            } 
            else
            {
                _right = InsertWithDirection(_right, val);
            }


        }

        IBinarySortedTree<T> InsertWithDirection(IBinarySortedTree<T> direction, T val)
        {
            if (direction == null)
                direction = new BinarySortedGenericTree<T>(val);
            else
                direction.Insert(val);
            return direction;
        }

        public IEnumerable<T> Output()
        {
            if (_left != null)
                foreach (T t in _left.Output())
                    yield return t;
            yield return _value;
            if (_right != null)
                foreach (T t in _right.Output())
                    yield return t;

            // yield return lazy evaluates, e.g. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield
        }

        public bool Present(T target)
        {
            if (_enabled && _value.Equals(target))
                return true;
            if (_left != null && _value.CompareTo(target) >= 0)
                return _left.Present(target);
            if (_right != null && _value.CompareTo(target) < 0)
                return _right.Present(target);
            return false;
        }

        public T LowestCommonAncestor(T one, T two)
        {
            // we have several choices, either one of the values is the current (enabled) node, in which case the LCA is this value 
            if (_enabled && (_value.Equals(one) || _value.Equals(two)))
                return _value;

            // if we've got here, then we know neither one nor two are equal to my value, unless this node is disabled
            // else if both are to one side, then the LCA (if it exists) is that side 
            if (_left != null && _value.CompareTo(one) >= 0 && _value.CompareTo(two) >= 0)
                return _left.LowestCommonAncestor(one, two);
            if (_right != null && _value.CompareTo(one) < 0 && _value.CompareTo(two) < 0)
                return _right.LowestCommonAncestor(one, two);

            // else if they must be either side, then they need to be present on both sides
            IList<T> both = new List<T> { one, two };
            if (_left.Present(one) && _right.Present(two))
                return _value;


            // otherwise there isn't one (i.e. either it would be this one and it is null or one or other of the values isn't present in the tree) 
            return default(T);
        }       

    }
}
