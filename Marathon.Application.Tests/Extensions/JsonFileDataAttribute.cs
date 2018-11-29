using System;
using Xunit.Sdk;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Marathon.Tests.DAL.Extensions;

namespace Marathon.Application.Tests.Extensions
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly string _propertyName;

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public JsonFileDataAttribute(string filePath)
            : this(filePath, null) { }

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        /// <param name="propertyName">The name of the property on the JSON file that contains the data for the test</param>
        public JsonFileDataAttribute(string filePath, string propertyName = null)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            // Load the file
            var fileData = File.ReadAllText(PathExtensions.GetAbsolutePath(_filePath));

            if (string.IsNullOrEmpty(_propertyName))
                //whole file is the data
                return JsonConvert.DeserializeObject<IEnumerable<object[]>>(fileData);

            // Only use the specified property as the data
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName];

            // Get parameters of test method
            ParameterInfo[] parameters = testMethod.GetParameters();

            // data to inject as arguments to method
            var rightData = new List<object[]>();

            // Iterate parameters collections
            foreach (var paramsCollection in data)
            {
                int i = 0;
                var objects = new object[paramsCollection.Count()];

                // Cast parameters to right type
                foreach (var paramether in paramsCollection)
                {
                    objects[i] = paramether.ToObject(parameters[i].ParameterType);
                    i++;
                }

                rightData.Add(objects);
            }

            return rightData;
        }
    }
}
