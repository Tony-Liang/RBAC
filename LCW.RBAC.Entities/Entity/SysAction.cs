﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace LCW.RBAC.Entities
{
    [Serializable]
    public partial class SysAction : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        static SysAction()
        {
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public SysAction()
        {
            Initialize();
        }

        protected override void Initialize()
        {
        }
        
        #endregion
        
        #region Column Mapped Properties
        
        private System.Int32 _actionId;
        
        public virtual System.Int32 ActionId
        {
            get { return _actionId; }
            set
            {
                _actionId = value;
            }
        }
        
        private System.String _actionCode;
        
        public virtual System.String ActionCode
        {
            get { return _actionCode; }
            set
            {
                _actionCode = value;
            }
        }
        
        private System.String _actionName;
        
        public virtual System.String ActionName
        {
            get { return _actionName; }
            set
            {
                _actionName = value;
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        private IList<SysResourceAction> _sysResourceActionList;
        
        public virtual IList<SysResourceAction> SysResourceActionList
        {
            get { return _sysResourceActionList; }
            set
            {
                _sysResourceActionList = value;
            }
        }
        
        #endregion
        
        
        #region Clone
        
        public virtual SysAction Clone()
        {
            return (SysAction)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        public static SysAction FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysAction));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SysAction;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        public static SysAction FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysAction));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SysAction;
            }
        }
        
        #endregion
    }
}

