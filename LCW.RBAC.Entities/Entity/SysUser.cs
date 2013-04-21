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
    public partial class SysUser : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        static SysUser()
        {
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public SysUser()
        {
            Initialize();
        }

        protected override void Initialize()
        {
        }
        
        #endregion
        
        #region Column Mapped Properties
        
        private System.Int32 _userId;
        
        public virtual System.Int32 UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }
        
        private System.String _loginName;
        
        public virtual System.String LoginName
        {
            get { return _loginName; }
            set
            {
                _loginName = value;
            }
        }
        
        private System.String _password;
        
        public virtual System.String Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }
        
        private System.Byte _status;
        
        public virtual System.Byte Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        private SysUserDetail _sysUserDetail;
        
        public virtual SysUserDetail SysUserDetail
        {
            get { return _sysUserDetail; }
            set
            {
                _sysUserDetail = value;
            }
        }
        
        private IList<SysUserGroup> _sysUserGroupList;
        
        public virtual IList<SysUserGroup> SysUserGroupList
        {
            get { return _sysUserGroupList; }
            set
            {
                _sysUserGroupList = value;
            }
        }
        
        private IList<SysUserRole> _sysUserRoleList;
        
        public virtual IList<SysUserRole> SysUserRoleList
        {
            get { return _sysUserRoleList; }
            set
            {
                _sysUserRoleList = value;
            }
        }
        
        #endregion
        
        
        #region Clone
        
        public virtual SysUser Clone()
        {
            return (SysUser)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        public static SysUser FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysUser));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SysUser;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        public static SysUser FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysUser));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SysUser;
            }
        }
        
        #endregion
    }
}


