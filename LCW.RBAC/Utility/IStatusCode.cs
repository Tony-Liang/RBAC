using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCW.RBAC.Utility
{
    public interface IStatusCode
    {
        string statusCode { get; }

        string message { get; }
    }

    public class SuccessCode : IStatusCode
    {
        public SuccessCode(string statusCode,string message):this(statusCode,message,"","","","closeCurrent")
        {
            
        }

        public SuccessCode(string statusCode, string message, string navTabId)
            : this(statusCode, message, navTabId, "", "", "closeCurrent")
        {

        }

        public SuccessCode(string statusCode, string message,string navTabId,string forwardUrl,string rel,string callbackType)
        {
            this._message = message;
            this._statusCode = statusCode;
            this.navTabId=navTabId;
            this.rel=rel;
            this.forwardUrl=forwardUrl;
            this.callbackType=callbackType;
        }

        private string _statusCode;
        public string statusCode
        {
            get { return _statusCode; }
        }

        private string _message;
        public string message
        {
            get { return _message; }
        }

        public string navTabId { get; set; }

        public string forwardUrl { get; set; }

        public string callbackType { get; set; }

        public string rel{get;set;}
    }

    public class ErrorCode : IStatusCode
    {
        public ErrorCode(string statusCode, string message)
        {
            this._message = message;
            this._statusCode = statusCode;
        }

        private string _statusCode;
        public string statusCode
        {
            get { return _statusCode; }
        }

        private string _message;
        public string message
        {
            get { return _message; }
        }
    }
}
