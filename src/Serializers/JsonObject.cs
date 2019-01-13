﻿/*
   Copyright 2016 - 2019 Adrian Popescu.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using Newtonsoft.Json;

namespace RedmineApi.Core.Serializers
{
    public sealed class JsonObject : IDisposable
    {
        private readonly bool hasRoot;

        public JsonObject(JsonWriter writer, string root = null)
        {
            Writer = writer;
            Writer.WriteStartObject();
            if (!string.IsNullOrWhiteSpace(root))
            {
                hasRoot = true;
                Writer.WritePropertyName(root);
                Writer.WriteStartObject();
            }
        }

        private JsonWriter Writer { get; set; }

        public void Dispose()
        {
            Writer.WriteEndObject();
            if (hasRoot)
            {
                Writer.WriteEndObject();
            }
        }
    }
}