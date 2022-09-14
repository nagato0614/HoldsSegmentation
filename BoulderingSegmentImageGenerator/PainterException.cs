using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BoulderingSegmentImageGenerator
{
    [Serializable()]
    internal class PainterException : Exception
    {

        public PainterException()
            : base()
        {

        }

        public PainterException(string message)
            : base(message)
        {

        }

        public PainterException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected PainterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
