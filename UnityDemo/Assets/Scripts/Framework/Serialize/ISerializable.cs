﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geek.Client
{
    public interface ISerializable
    {
        int Read(byte[] buffer, int offset);

        int Write(byte[] buffer, int offset);

    }
}
