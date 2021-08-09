﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using KunalsDiscordBot.Modules.Images;

using Image = System.Drawing.Image;

namespace KunalsDiscordBot.Services.Images
{
    public interface IImageService
    {
        public void GetFontAndBrush(string fontName, int fontSize, Color fontColor, out Font font, out SolidBrush brush);

        public EditData GetEditData(string fileName);

        public string GetFileByCommand(in CommandContext ctx);
        public List<ImageGraphic> GetImages(Dictionary<string, int> urls);
    }
}