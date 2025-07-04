﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images
{
    public class NewImageDTO
    {
        public ImageType Type { get; set; }
        public IFormFile? File { get; set; }
        public int? FootballerId { get; set; }
        public int? TeamId { get; set; }
        public int? RefereeId { get; set; }
        public int? LeagueId { get; set; }
        public int? TrophyId { get; set; }
    }
}
