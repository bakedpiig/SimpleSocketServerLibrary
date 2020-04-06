﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSocketServerLibrary
{
    public interface ITransmittable
    {
        int NetworkID { get; set; }

        void Write(OutputMemoryStream outputMemoryStream);
        void Write(OutputMemoryBitStream outputMemoryBitStream);

        void Read(InputMemoryStream inputMemoryStream);
        void Read(InputMemoryBitStream inputMemoryBitStream);
    }
}
