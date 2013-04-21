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
    public partial class SysGroupRole : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        static SysGroupRole()
        {
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public SysGroupRole()
        {
            Initialize();
        }

        protected override void Initialize()
        {
        }
        
        #endregion
        
        #region Column Mapped Properties
        
        private System.Int32 _identification;
        
        public virtual System.Int32 Identification
        {
            get { return _identification; }
            set
            {
                _identification = value;
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        private SysGroup _sysGroup;
        
        public virtual SysGroup SysGroup
        {
            get { return _sysGroup; }
            set
            {
                _sysGroup = value;
            }
        }
        
        private SysRole _sysRole;
        
        public virtual SysRole SysRole
        {
            get { return _sysRole; }
            set
            {
                _sysRole = value;
            }
        }
        
        #endregion
        
        
        #region Clone
        
        public virtual SysGroupRole Clone()
        {
            return (SysGroupRole)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        public static SysGroupRole FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysGroupRole));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SysGroupRole;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        public static SysGroupRole FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysGroupRole));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SysGroupRole;
            }
        }
        
        #endregion
    }
}

