﻿using System.Text;

/*
 * Copyright 2012 dorkbox, llc
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace PEParserSharp.Types;

using UShort = PEParserSharp.Bytes.UShort;
using SubsystemType = PEParserSharp.Misc.SubsystemType;

public class Subsystem(UShort value, string descriptiveName) : ByteDefinition<SubsystemType>(descriptiveName)
{

    private readonly UShort value = value;

    public override sealed SubsystemType Get => SubsystemType.Get(this.value);

    public override void Format(StringBuilder b)
    {
        SubsystemType s = Get;

        if (s != null)
        {
            b.Append(DescriptiveName).Append(": ").Append(s.Description).Append(System.Environment.NewLine);
        }
        else
        {
            b.Append("ERROR, no subsystem description for value: ").Append(this.value).Append(System.Environment.NewLine);
        }
    }
}