using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Redis
{
    public interface IRedisManager
    {
        void Add(string key, string value);

        void Add(string key, string value, TimeSpan expireTime);

        bool Any(string key);

        void Clear();

        T GetJsonData<T>(string key);

        string GetValue(string key);

        void Remove(string key);

        HashEntry[] GetValueFromHash(string key);

    }
}
