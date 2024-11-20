using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams
{
    public class NewTeamDTO
    {
        [NotMapped]
        public string? CoachId { get; set; }
        public string? CreatorId { get; set; }

        [Required(ErrorMessage = "Nazwa drużyny jest wymagana.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Kraj jest wymagany.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Nazwa stadionu jest wymagana.")]
        public string Stadium { get; set; }

        [Required(ErrorMessage = "Rok założenia jest wymagany.")]
        [Range(1800, 2100, ErrorMessage = "Rok założenia musi być pomiędzy 1800 a 2100.")]
        public int? YearOfFoundation { get; set; }

        [NotMapped]
        [EmailAddress(ErrorMessage ="Email ma nieprawidłowy format.")]
        public string? CoachEmail { get; set; }
    }
}
