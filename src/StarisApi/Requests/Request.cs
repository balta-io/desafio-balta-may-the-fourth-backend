using Microsoft.AspNetCore.Mvc;
using StarisApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json.Serialization;

namespace StarisApi.Requests
{
    public sealed record Request
    {
        private string? sortOrder = "asc";

        public string? Search { get; set; }

        public int? Page { get; set; } = 1;
        
        public int? PerPage { get ; set; } = 10;

        public string? SortBy { get; set; }

        public string? SortOrder 
        { 
            get => GetSortOrder(); 
            set => sortOrder = value; 
        }

        private string? GetSortOrder()
        {
            return sortOrder?.ToLower(CultureInfo.InvariantCulture) == "desc" ? "desc" : "asc";
        }
    }
}
