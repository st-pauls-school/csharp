using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySortedTree.Lib
{
    /// <summary>
    /// A tree with up to two children, each of which is another <see cref="BinarySortedTree{T}"/>, 
    /// the left tree is strictly lower value (based on <see cref="IComparable{T}"/>), 
    /// the right weakly greater than
    /// </summary>
    /// <typeparam name="T">The underlying type for the value of the node</typeparam>
    public class BinarySortedTree<T> : IBinarySortedTree<T> where T : IComparable<T>, IEquatable<T>
    {
        // make it read only so that, once set in the constructor, we can't change it 
        readonly T _value;

        // to be properly immutable, this property would be readonly too, but that would break this way of resolving the problem
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
                // dynamic seems like a kludge 
                dynamic a = l;
                dynamic b = r;
                dynamic v = (_enabled ? _value : default(T));
                dynamic result = a + v + b;

                // cast it back to the type T 
                return (T)result;
            }
        }

        public BinarySortedTree(T value)
        {
            _enabled = true;
            _value = value;
            _left = null;
            _right = null;
        }

        /// <summary>
        /// finds the value and disables the first enabled node that contains the value 
        /// </summary>
        /// <param name="val"></param>
        public void Delete(T val)
        {
            // don't actually delete the value, we still want to be able to use the node for traversal
            if (_enabled && _value.Equals(val))
            {
                _enabled = false;
                return;
            }
            // look in the left tree or the right tree 
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
            // hide this sub-function in here because nothing else should ever have access to it
            IBinarySortedTree<T> InsertWithDirection(IBinarySortedTree<T> direction, T v)
            {
                if (direction == null)
                    direction = new BinarySortedTree<T>(v);
                else
                    direction.Insert(v);
                return direction;
            }

            // delegated to the sub-function because DRY 
            if (_value.CompareTo(val) >= 0)
            {
                _left = InsertWithDirection(_left, val);
            } 
            else
            {
                _right = InsertWithDirection(_right, val);
            }


        }


        public IEnumerable<T> Output()
        {
            // in-order traversal - do left, output this, do right 
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

            // if we've got here, then we know neither one nor two are equal to my value (or this node is disabled) 
            // else if both are to one side, then the LCA (if it exists) is that side 
            
            // first is this value bigger than both one and two
            if (_left != null && _value.CompareTo(one) >= 0 && _value.CompareTo(two) >= 0)
                return _left.LowestCommonAncestor(one, two);
            // or is this value small than both one and two 
            if (_right != null && _value.CompareTo(one) < 0 && _value.CompareTo(two) < 0)
                return _right.LowestCommonAncestor(one, two);

            // else they must be either side, in which case they need to be present on both sides
            IList<T> both = new List<T> { one, two };
            if (_left.Present(one) && _right.Present(two))
                return _value;

            // otherwise there isn't one (i.e. either it would be this one and it is null or one or other of the two values isn't
            // present in the requisite sub-tree) 
            return default(T);
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", Output())}}}";
        }
    }
}
