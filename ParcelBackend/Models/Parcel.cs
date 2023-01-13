using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelBackend.Models
{
	public class Parcel
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int parcelId { get; set; }
        [Required]

        public string parcelCity { get; set; }

		public string parcelCounty { get; set; }

		public string parcelDistrict { get; set; }

	}
}

