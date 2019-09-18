using ModelToKeyValue.src.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ModelToKeyValue.src.Interfaces;
using ModelToKeyValue.src.Comman;
using ModelToKeyValue.src.Models;

namespace ModelToKeyValue.src.Implementation
{
    public class ObjectReader : IObjectReader
    {
        /// <summary>
        /// datas for model,name and value
        /// if there are nested types NestedSeperator will use
        /// </summary>
        private List<ObjectReaderModel> _datas = null;

        /// <summary>
        /// Object reader options,for attribute use or not and 
        /// seperator selector
        /// </summary>
        private readonly IObjectReaderOptions _readerOptions = null;

        public ObjectReader(IObjectReaderOptions options)
        {
            _readerOptions = options;
            _datas = new List<ObjectReaderModel>();
        }

        /// <summary>
        /// Public method for call External
        /// accepts object for find datas
        /// </summary>
        /// <param name="data">will parse object</param>
        /// <returns>datas as key value</returns>
        public List<ObjectReaderModel> GetStrings(object data)
        {
            Serizalize(data,null);
            return _datas;
        }

        /// <summary>
        /// Main method for check type is complex or not
        /// </summary>
        /// <param name="data">User's object</param>
        /// <param name="name">use as data's key</param>
        private void Serizalize(object data,string name)
        {
            Type dataType = data.GetType();

            if (dataType.IsComplex())
                LoopProperties(dataType.GetProperties(), data,name);
            else
                AddData(data,name); 
        }

        /// <summary>
        /// Loop all properties for complex types
        /// check value is not null,and object is collection or not
        /// </summary>
        /// <param name="propertyInfos">object properties' info</param>
        /// <param name="data">object data</param>
        /// <param name="name">use as data's key</param>
        private void LoopProperties(PropertyInfo[] propertyInfos, object data,string name)
        {
            foreach (PropertyInfo item in propertyInfos)
            {
                var val = item.GetValue(data);
                if ((_readerOptions.RequireAttribute == false ? true : item.HasAttribute<SerializableObjectAttribute>()) && val != null)
                {
                    if (val.IsCollection())
                    {
                        if (name == null)
                            LoopCollection(val, item.Name);
                        else
                            LoopCollection(val, name + _readerOptions.NestedSeperator + item.Name);
                    }
                    else
                    {
                        if (name == null)
                            Serizalize(val,item.Name);
                        else
                            Serizalize(val,name+ _readerOptions.NestedSeperator + item.Name);
                    }
                }
            }
        }

        /// <summary>
        /// If collection type loop datas and
        /// use Serialize method one by one
        /// </summary>
        /// <param name="data">list object data</param>
        /// <param name="name">use as data's key</param>
        private void LoopCollection(object data,string name)
        {
            if (!data.IsCollection())
                throw new InvalidOperationException(StaticDatas.ValueMustCollectionMessage);

            var loopData = data as IEnumerable;
            foreach (object item in loopData)
            {
                Serizalize(item,name);
            }
        }

        /// <summary>
        /// add dta to list
        /// </summary>
        /// <param name="data">appended data</param>
        /// <param name="name">use as data's key</param>
        private void AddData(object data,string name)
        {
            _datas.Add(new ObjectReaderModel
            {
                Name = name,
                Value = data
            });           
        }

    }
}
