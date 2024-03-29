﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCW.RBAC.Entities
{
    public abstract partial class EntityBase :
        System.ComponentModel.INotifyPropertyChanging,
        System.ComponentModel.INotifyPropertyChanged,
        System.ICloneable
    {
        #region Abstract Methods

        protected abstract void Initialize();

        #endregion

        #region Notification Events

        /// <summary>
        /// Implements a PropertyChanged event.
        /// </summary>
        [field: NonSerialized]
        public virtual event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event for a specific property.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed.</param>
        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Implements a PropertyChanging event.
        /// </summary>
        public virtual event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Raise the PropertyChanging event for a specific property.
        /// </summary>
        /// <param name="propertyName">Name of the property that is changing.</param>
        protected virtual void SendPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));

        }

        #endregion

        #region Clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            var serializer = new System.Runtime.Serialization.DataContractSerializer(GetType());
            using (var ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                return serializer.ReadObject(ms);
            }
        }

        #endregion

        #region Serialization
        protected bool serializing;

        /// <summary>
        /// Called when serializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        protected void OnSerializing(System.Runtime.Serialization.StreamingContext context)
        {
            serializing = true;
        }

        /// <summary>
        /// Called when serialized.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        protected void OnSerialized(System.Runtime.Serialization.StreamingContext context)
        {
            serializing = false;
        }

        /// <summary>
        /// Called when deserializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        protected void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
            Initialize();
        }

        #endregion

        #region ToString()

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="indentLevel">The indent level.</param>
        /// <param name="indentValue">The indent value.</param>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public virtual string ToEntityString(int indentLevel, string indentValue)
        {
            System.Reflection.PropertyInfo[] props = this.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            var sb = new System.Text.StringBuilder();
            object value = null;
            bool includeProperty = true;

            for (int t = 0; t < indentLevel; t++)
                sb.Append(indentValue);

            sb.AppendLine("{");

            for (int i = 0; i < props.Length; i++)
            {
                value = null;

                if (props[i].PropertyType == typeof(byte[])
                    || props[i].PropertyType == typeof(System.Data.Linq.Binary))
                {
                    value = "<binary>";
                }
                else if (props[i].PropertyType == typeof(System.Data.Linq.EntitySet<>)
                    || props[i].PropertyType.BaseType == typeof(EntityBase))
                {
                    includeProperty = false;
                }
                else
                {
                    try
                    {
                        value = props[i].GetValue(this, null);
                    }
                    catch (Exception)
                    {
                        value = "<exception>";
                    }
                }

                if (includeProperty)
                {
                    if (value != null)
                        value = value.ToString().Replace("\r\n", " ").Replace('\n', ' ').Replace('\t', ' ');

                    if (value != null && value.ToString().Length > 50)
                        value = String.Concat(value.ToString().Substring(0, 50), "...");

                    for (int t = 0; t < indentLevel + 1; t++)
                        sb.Append(indentValue);

                    sb.Append(props[i].Name);
                    sb.Append(" = ");

                    sb.AppendLine(value != null ? value.ToString().Length > 0 ? value.ToString() : "<empty>" : "<null>");
                }
            }

            for (int t = 0; t < indentLevel; t++)
                sb.Append(indentValue);

            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Returns an XML <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>. 
        /// </summary>
        /// <returns>An XML <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.</returns>
        public virtual string ToXml()
        {
            var settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            var sb = new System.Text.StringBuilder();
            using (var writer = System.Xml.XmlWriter.Create(sb, settings))
            {
                var serializer = new System.Runtime.Serialization.DataContractSerializer(GetType());
                serializer.WriteObject(writer, this);
                writer.Flush();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a byte array that represents the current <see cref="T:System.Object"/>. 
        /// </summary>
        /// <returns>A byte array that represents the current <see cref="T:System.Object"/>.</returns>
        public virtual byte[] ToBinary()
        {
            byte[] buffer;
            using (var ms = new System.IO.MemoryStream())
            using (var writer = System.Xml.XmlDictionaryWriter.CreateBinaryWriter(ms))
            {
                var serializer = new System.Runtime.Serialization.DataContractSerializer(GetType());
                serializer.WriteObject(writer, this);
                writer.Flush();
                buffer = ms.ToArray();
            }
            return buffer;
        }

        #endregion
    }
}
