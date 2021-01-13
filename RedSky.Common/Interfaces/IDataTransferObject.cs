using System;
using System.Runtime.Serialization;

namespace RedSky.Common.Interfaces
{
    public interface IDataTransferObject
    {
        [DataMember]
        Int32 Id { get; set; }
    }
}
