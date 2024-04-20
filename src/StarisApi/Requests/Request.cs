using Microsoft.AspNetCore.Mvc;
using StarisApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace StarisApi.Requests
{
    /// <summary>
    /// testett
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Item de procura
        /// </summary>
        public string? Search { get; set; }
        public int? Page { get; set; } = 1;
        public int? PerPage { get; set; } = 10;
        public string? SortBy { get; set; } = "id";
        public string? SortOrder { get; set; } = "asc";
        public int? Offset { get; set; } = 0;
    }
}
