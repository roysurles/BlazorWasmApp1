using System;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;

namespace BlazorWasmApp1.Shared.Models.Common.Enumeration
{
    /// <summary>
    /// https://mcguirev10.com/2018/08/07/serialization-encapsulated-enumeration-classes.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(EnumerationJsonConverter))]
    public abstract class BaseEnumeration<T> : IEnumerationJson, IComparable
    {
        public T Value { get; protected set; }

        public string DisplayName { get; protected set; }

        public string Description { get; protected set; } = "";

        public BaseEnumeration()
        { }

        public BaseEnumeration(T value, string displayName, string description = "")
        {
            Value = value;
            DisplayName = displayName;
            Description = description;
        }

        public override string ToString() =>
            $"{DisplayName}: {Value}";

        public static IEnumerable<E> GetAll<E>() where E : BaseEnumeration<T>, new()
        {
            var type = typeof(E);
            var instance = new E();
            var fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (var info in fields)
            {
                var locatedValue = info.GetValue(instance) as E;
                if (locatedValue != null) yield return locatedValue;
            }
        }

        public override bool Equals(object other)
        {
            var otherValue = other as BaseEnumeration<T>;
            if (otherValue == null) return false;
            var typeMatches = GetType().Equals(other.GetType());
            var valueMatches = Value.Equals(otherValue.Value);
            return typeMatches && valueMatches;
        }

        public override int GetHashCode() =>
            Value.GetHashCode();

        public int CompareTo(object other) =>
            (other.GetType() != GetType()) ? -1 : CompareTo(other as BaseEnumeration<T>);

        public object ReadJson(string jsonValue)
        {
            var type = GetType();
            var instance = Activator.CreateInstance(type);
            var fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (var info in fields)
            {
                var locatedValue = info.GetValue(instance);
                if (locatedValue != null && locatedValue.GetType().IsAssignableFrom(type))
                {
                    var serializedValue = info.FieldType.GetMethod("WriteJson")?.Invoke(locatedValue, null);
                    if (serializedValue != null && ((string)serializedValue).Equals(jsonValue)) return locatedValue;
                }
            }
            return null;
        }

        public string WriteJson() =>
            Value.ToString();

        public static bool operator ==(BaseEnumeration<T> left, BaseEnumeration<T> right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(BaseEnumeration<T> left, BaseEnumeration<T> right) =>
            !(left == right);

        public static bool operator <(BaseEnumeration<T> left, BaseEnumeration<T> right) =>
            left is null ? right is object : left.CompareTo(right) < 0;

        public static bool operator <=(BaseEnumeration<T> left, BaseEnumeration<T> right) =>
            left is null || left.CompareTo(right) <= 0;

        public static bool operator >(BaseEnumeration<T> left, BaseEnumeration<T> right) =>
            left is object && left.CompareTo(right) > 0;

        public static bool operator >=(BaseEnumeration<T> left, BaseEnumeration<T> right) =>
            left is null ? right is null : left.CompareTo(right) >= 0;
    }
}