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
    public partial class SysUserDetail : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        static SysUserDetail()
        {
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public SysUserDetail()
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
        
        private System.String _cName;
        
        public virtual System.String CName
        {
            get { return _cName; }
            set
            {
                _cName = value;
            }
        }
        
        private System.String _eName;
        
        public virtual System.String EName
        {
            get { return _eName; }
            set
            {
                _eName = value;
            }
        }
        
        private System.String _email;
        
        public virtual System.String Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
        
        private System.Byte _type;
        
        public virtual System.Byte Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }
        
        private System.String _iDCard;
        
        public virtual System.String IDCard
        {
            get { return _iDCard; }
            set
            {
                _iDCard = value;
            }
        }
        
        private System.Byte _sex;
        
        public virtual System.Byte Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
            }
        }
        
        private System.DateTime _birthDay;
        
        public virtual System.DateTime BirthDay
        {
            get { return _birthDay; }
            set
            {
                _birthDay = value;
            }
        }
        
        private System.String _mobile;
        
        public virtual System.String Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
            }
        }
        
        private System.String _userNO;
        
        public virtual System.String UserNO
        {
            get { return _userNO; }
            set
            {
                _userNO = value;
            }
        }
        
        private System.DateTime? _workStartDate;
        
        public virtual System.DateTime? WorkStartDate
        {
            get { return _workStartDate; }
            set
            {
                _workStartDate = value;
            }
        }
        
        private System.DateTime? _workEndDate;
        
        public virtual System.DateTime? WorkEndDate
        {
            get { return _workEndDate; }
            set
            {
                _workEndDate = value;
            }
        }
        
        private System.String _companyMail;
        
        public virtual System.String CompanyMail
        {
            get { return _companyMail; }
            set
            {
                _companyMail = value;
            }
        }
        
        private System.String _extension;
        
        public virtual System.String Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
            }
        }
        
        private System.String _homeTel;
        
        public virtual System.String HomeTel
        {
            get { return _homeTel; }
            set
            {
                _homeTel = value;
            }
        }
        
        private System.String _remark;
        
        public virtual System.String Remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
            }
        }
        
        private System.DateTime _createDate;
        
        public virtual System.DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
            }
        }
        
        private System.DateTime _modifiedDate;
        
        public virtual System.DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set
            {
                _modifiedDate = value;
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        private SysDepartment _sysDepartment;
        
        public virtual SysDepartment SysDepartment
        {
            get { return _sysDepartment; }
            set
            {
                _sysDepartment = value;
            }
        }
        
        private SysPosition _sysPosition;
        
        public virtual SysPosition SysPosition
        {
            get { return _sysPosition; }
            set
            {
                _sysPosition = value;
            }
        }
        
        private SysUser _sysUser;
        
        public virtual SysUser SysUser
        {
            get { return _sysUser; }
            set
            {
                _sysUser = value;
            }
        }
        
        #endregion
        
        
        #region Clone
        
        public virtual SysUserDetail Clone()
        {
            return (SysUserDetail)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        public static SysUserDetail FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysUserDetail));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as SysUserDetail;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        public static SysUserDetail FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(SysUserDetail));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as SysUserDetail;
            }
        }
        
        #endregion
    }
}


