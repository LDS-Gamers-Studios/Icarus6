﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Numerics;
using System.Drawing;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Exceptions;
using DSharpPlus.Interactivity;
using DSharpPlus.Net;
using DSharpPlus.SlashCommands;

namespace Icarus
{
    public class SudoTemplate
    {
        public static void Main() { }

        public object Out { get; private set; } // Data to be returned
        public DiscordMessage Msg { get; set; } // Message that ran the sudo command, mostly for channel reference

        public async Task Sudo()
        {
            {input}
        }
    }
}