using System.Collections.Generic;
using System;
using System.Text;

namespace UruIT.GameOfDrones.Domain.Common
{
    public class RequestResult
    {
        public RequestResult()
        {
            Status = StatusResult.Success;
            Messages = new List<Message>();
        }

        public RequestResult(StatusResult status, params Message[] messages)
            : this()
        {
            Status = status;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public RequestResult(StatusResult status, object data, params Message[] messages)
            : this()
        {
            Status = status;
            Data = data;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public StatusResult Status { get; set; }

        public Object Data { get; set; }

        public List<Message> Messages { get; set; }

        public Exception Exception { get; set; }
    }

    public class RequestResult<T>
    {
        public RequestResult()
        {
            Status = StatusResult.Success;
            Messages = new List<Message>();
        }

        public RequestResult(StatusResult status, T data)
            : this()
        {
            Status = status;
            Data = data;
        }

        public RequestResult(StatusResult status, params Message[] messages)
            : this()
        {
            Status = status;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public RequestResult(StatusResult status, T data, params Message[] messages)
            : this()
        {
            Status = status;
            Data = data;

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    Messages.Add(message);
                }
            }
        }

        public StatusResult Status { get; set; }

        public T Data { get; set; }

        public List<Message> Messages { get; set; }

        public Exception Exception { get; set; }
    }
}