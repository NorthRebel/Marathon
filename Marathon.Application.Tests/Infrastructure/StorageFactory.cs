using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Marathon.Domain.Common;
using Newtonsoft.Json;

namespace Marathon.Application.Tests.Infrastructure
{
    public class StorageFactory<T> where T : IEntity
    {
        private List<T> _items;

        public StorageFactory()
        {
            _items = new List<T>();
        }

        public StorageFactory<T> FromJson(string filePath)
        {
            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(filePath)
                ? filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(filePath);

            if (!_items.Any())
                _items = JsonConvert.DeserializeObject<List<T>>(fileData);
            else 
                _items.AddRange(JsonConvert.DeserializeObject<IEnumerable<T>>(fileData));

            return this;
        }


        public StorageFactory<T> FromCollection(IEnumerable<T> collection)
        {
            if (!_items.Any())
                _items = collection.ToList();
            else 
                _items.AddRange(collection);

            return this;
        }

        public List<T> Create()
        {
            return _items;
        }
    }
}
