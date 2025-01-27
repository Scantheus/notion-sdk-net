﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToDoBlock : Block
    {
        public override BlockType Type => BlockType.ToDo;

        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }

            public IEnumerable<Block> Children { get; set; }
        }
    }
}
