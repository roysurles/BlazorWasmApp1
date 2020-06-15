//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace BlazorWasmApp1.Shared.Models.Common
//{
//    public abstract class BaseEnumeration : IComparable
//    {
//        protected BaseEnumeration()
//        {
//        }

//        protected BaseEnumeration(int value, string displayName)
//        {
//            Value = value;
//            DisplayName = displayName;
//        }

//        public int Value { get; }

//        public string DisplayName { get; }

//        public override string ToString() =>
//            DisplayName;

//        public static IEnumerable<T> GetAll<T>() where T : BaseEnumeration, new()
//        {
//            var type = typeof(T);
//            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

//            foreach (var info in fields)
//            {
//                var instance = new T();

//                if (info.GetValue(instance) is T locatedValue)
//                    yield return locatedValue;
//            }
//        }

//        public override bool Equals(object obj)
//        {
//            if (!(obj is BaseEnumeration otherValue))
//                return false;

//            var typeMatches = GetType().Equals(obj.GetType());
//            var valueMatches = Value.Equals(otherValue.Value);

//            return typeMatches && valueMatches;
//        }

//        public override int GetHashCode() =>
//            HashCode.Combine(Value);

//        public static int AbsoluteDifference(BaseEnumeration firstValue, BaseEnumeration secondValue) =>
//            Math.Abs(firstValue.Value - secondValue.Value);

//        public static T FromValue<T>(int value) where T : BaseEnumeration, new() =>
//            Parse<T, int>(value, "value", item => item.Value.Equals(value));

//        public static T FromDisplayName<T>(string displayName) where T : BaseEnumeration, new() =>
//            Parse<T, string>(displayName, "display name", item => string.Equals(item.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

//        public static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : BaseEnumeration, new()
//        {
//            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

//            if (matchingItem != null)
//                return matchingItem;

//            var message = $"'{value}' is not a valid {description} in {typeof(T)}";
//            throw new ApplicationException(message);
//        }

//        public int CompareTo(object other) =>
//            Value.CompareTo(((BaseEnumeration)other).Value);

//        public static bool operator ==(BaseEnumeration left, BaseEnumeration right) =>
//            (left is null) ? right is null : left.Equals(right);

//        public static bool operator !=(BaseEnumeration left, BaseEnumeration right) =>
//            !(left == right);

//        public static bool operator <(BaseEnumeration left, BaseEnumeration right) =>
//            left is null ? right is object : left.CompareTo(right) < 0;

//        public static bool operator <=(BaseEnumeration left, BaseEnumeration right) =>
//            left is null || left.CompareTo(right) <= 0;

//        public static bool operator >(BaseEnumeration left, BaseEnumeration right) =>
//            left is object && left.CompareTo(right) > 0;

//        public static bool operator >=(BaseEnumeration left, BaseEnumeration right) =>
//            left is null ? right is null : left.CompareTo(right) >= 0;
//    }
//}
