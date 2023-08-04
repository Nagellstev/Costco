﻿using Costco.Utilities.FileReader;
using System.Collections;

namespace Costco.TestData.Models
{
    public abstract class BaseModel: IEnumerable<object[]>
    {
        private DataContainer _container;
        internal abstract string testDataFileName { get; }

        public IEnumerator<object[]> GetEnumerator()
        {
            FileReader reader = new();
            _container = (DataContainer)reader.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Costco.TestData", "TestData", testDataFileName),
                typeof(DataContainer).AssemblyQualifiedName);
            return _container.TestData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
